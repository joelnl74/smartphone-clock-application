using MobileClock.Mapper;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using System;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;

namespace Tests.MobileTimer.Presenter
{
    public class StopWatchPresenterTests
    {
        [UnityTest]
        public IEnumerator LoadData_AfterOneSec_ReceivedNoDataChanged()
        {
            // Arrange.
            var view = Substitute.For<IStopWatchView>();
            var sut = new StopWatchPresenter(new TimerModelMapper(), new TimerLapModelMapper());
            var currentTime = new TimeSpan();

            sut.Bind(view);
            sut.LoadData();

            sut.Bind(view);

            // Act.
            sut.LoadData();
            yield return new WaitForSeconds(1);

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => x.timeSpan == currentTime));
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterOneSec_ReceivedDifferentData()
        {
            // Arrange.
            var view = Substitute.For<IStopWatchView>();
            var sut = new StopWatchPresenter(new TimerModelMapper(), new TimerLapModelMapper());
            var currentTime = new TimeSpan();

            sut.Bind(view);
            sut.LoadData();

            // Act.
            sut.StartTimer();

            yield return new WaitForSeconds(1);

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => x.timeSpan != currentTime));
        }

        [UnityTest]
        public IEnumerator StartTimer_AfterOneSec_ReceivedCorrectData()
        {
            // Arrange.
            var view = Substitute.For<IStopWatchView>();
            var sut = new StopWatchPresenter(new TimerModelMapper(), new TimerLapModelMapper());

            sut.Bind(view);
            sut.LoadData();

            // Act.
            sut.StartTimer();

            yield return new WaitForSeconds(1);

            var expectedModel = new TimerModel { timeSpan = new TimeSpan(0, 0, 0, 1) };

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => x.Equals(expectedModel)));
        }

        [UnityTest]
        public IEnumerator StartTimer_ResetAfterOneSec_ReceivedDidReset()
        {
            // Arrange.
            var view = Substitute.For<IStopWatchView>();
            var sut = new StopWatchPresenter(new TimerModelMapper(), new TimerLapModelMapper());

            sut.Bind(view);
            sut.LoadData();

            // Act.
            sut.StartTimer();
            yield return new WaitForSeconds(1);
            sut.Reset();

            // Assert.
            view.Received(1).DidReset();
        }
    }
}
