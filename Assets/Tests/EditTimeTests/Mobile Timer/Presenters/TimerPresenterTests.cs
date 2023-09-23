using MobileClock.Mapper;
using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests.MobileTimer.Presenters
{
    public class TimerPresenterTests
    {
        [Test]
        public void LoadData_View_DidLoadData_Invoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            sut.Bind(view);

            // Act.
            sut.LoadData();

            // Assert.
            Assert.That(view.ReceivedCalls().Count(), Is.EqualTo(1));
        }

        [Test]
        public void LoadData_View_ReceivedCorrectData()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan() };

            // Assert.
            view.Received(1).DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void StartTimer_WithEmptyModel_View_DidStartTime_NotInvoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            
            sut.Bind(view);
            sut.LoadData();
            
            // Act.
            sut.StartTimer();

            // Assert.
            view.DidNotReceive().DidStartTimer();
        }

        [Test]
        public void StartTimer_WithModel_View_DidStartTime_Invoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan(1) });
            
            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(1);

            // Act.
            sut.StartTimer();

            // Assert.
            view.Received().DidStartTimer();
        }

        [Test]
        public void ResetData_View_ReceivedCorrectData()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.Reset();

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan() };

            // Assert.
            view.Received(1).DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void LoadData_View_InvokeMapper()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            // Assert.
            mapper.Received(1).MapSingle();
        }


        [Test]
        public void IncreaseTimer_View_ReceivedCorrectData()
        {
            // Arrange.
            var mapper = new TimerModelMapper();
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(mapper, null);

            sut.Bind(view);
            sut.LoadData();

            // Act.
            sut.IncreaseTimer(10);

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan(0, 0, 10) };

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void DecreaseTimer_TimerBelowZero_NotReceivedData()
        {
            // Arrange.
            var mapper = new TimerModelMapper();
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(mapper, null);

            sut.Bind(view);
            sut.LoadData();

            // Act.
            sut.DecreaseTimer(10);

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan(0, 0, -10) };

            // Assert.
            view.DidNotReceive().DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void DecreaseTimer_TimerDecreate_ReceiveCorrectData()
        {
            // Arrange.
            var mapper = new TimerModelMapper();
            var view = Substitute.For<ITimerView>();

            var sut = new TimerPresenter(mapper, null);

            sut.Bind(view);
            sut.LoadData();
            sut.IncreaseTimer(10);

            // Act.
            sut.DecreaseTimer(5);

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan(0, 0, 5) };

            // Assert.
            view.Received().DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }
    }
}
