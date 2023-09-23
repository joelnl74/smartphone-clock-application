using MobileClock.Mapper;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using System;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using Zenject;
using Audio;
using ModestTree;

namespace Tests.MobileTimer.Presenter
{
    public class TimerPresenterTests : ZenjectUnitTestFixture
    {
        [UnityTest]
        public IEnumerator LoadData_AfterOneSec_DataNotChanged()
        {
            // Arrange.
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(new TimerModelMapper(), null);
            var currentTime = new TimeSpan();

            sut.Bind(view);

            // Act.
            sut.LoadData();
            yield return new WaitForSeconds(1);

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => x.timeSpan == currentTime));
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterOneSec_DataChanged()
        {
            // Arrange.
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(new TimerModelMapper(), null);
            var currentTime = new TimeSpan(0, 0, 10);

            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(10);

            // Act.
            sut.StartTimer();
            
            yield return new WaitForSeconds(1);

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => x.timeSpan != currentTime));
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterOneSec_TimerMinusOne()
        {
            // Arrange.
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(new TimerModelMapper(), null);
            var currentTime = new TimeSpan(0, 0, 10);

            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(10);

            // Act.
            sut.StartTimer();

            yield return new WaitForSeconds(1);

            var exectedTimeSpan = new TimeSpan(0, 0, 9);

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => x.timeSpan != exectedTimeSpan));
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterSomeTime_Completion_DidStopIsCalled()
        {
            // Arrange.
            SignalBusInstaller.Install(Container);
            Container.Inject(this);
            
            Container.DeclareSignal<PlayAudioSignal>();
            Container.BindSignal<PlayAudioSignal>().ToMethod(() => { });
            Container.ResolveRoots();

            var signalBus = Container.Resolve<SignalBus>();
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(new TimerModelMapper(), signalBus);

            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(1);

            // Act.
            sut.StartTimer();

            yield return new WaitForSeconds(2);

            // Assert.
            view.Received().DidStop();
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterSomeTime_Completion_DidResetIsCalled()
        {
            // Arrange.
            SignalBusInstaller.Install(Container);
            Container.Inject(this);

            Container.DeclareSignal<PlayAudioSignal>();
            Container.BindSignal<PlayAudioSignal>().ToMethod(() => { });
            Container.ResolveRoots();

            var signalBus = Container.Resolve<SignalBus>();
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(new TimerModelMapper(), signalBus);

            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(1);

            // Act.
            sut.StartTimer();

            yield return new WaitForSeconds(2);

            // Assert.
            view.Received().DidReset();
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterSomeTime_Completion_DidSendPlayAudioSignal()
        {
            // Arrange.
            SignalBusInstaller.Install(Container);
            Container.Inject(this);

            bool received = false;

            Container.DeclareSignal<PlayAudioSignal>();
            Container.BindSignal<PlayAudioSignal>().ToMethod(() => { received = true; });
            Container.ResolveRoots();

            var signalBus = Container.Resolve<SignalBus>();
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(new TimerModelMapper(), signalBus);

            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(1);

            // Act.
            sut.StartTimer();

            yield return new WaitForSeconds(2);

            // Assert.
            Assert.That(received);
        }
    }
}
