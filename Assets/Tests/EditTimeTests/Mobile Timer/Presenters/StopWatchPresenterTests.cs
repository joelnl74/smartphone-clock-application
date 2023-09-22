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
    public class StopWatchPresenterTests
    {
        [Test]
        public void LoadData_View_DidLoadData_Invoked()
        {
            // Arrange.
            var timerModelMapper = Substitute.For<ITimerModelMapper>();
            var lapTimeModelMapper = Substitute.For<ITimerLapModelMapper>();

            var view = Substitute.For<IStopWatchView>();
            var sut = new StopWatchPresenter(timerModelMapper, lapTimeModelMapper);

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
            var timerModelMapper = Substitute.For<ITimerModelMapper>();
            var lapTimeModelMapper = Substitute.For<ITimerLapModelMapper>();
            var view = Substitute.For<IStopWatchView>();
            var sut = new StopWatchPresenter(timerModelMapper, lapTimeModelMapper);

            timerModelMapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan() };

            // Assert.
            view.Received(1).DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void DidUpdateLapTime_View_ReceivedCorrectData()
        {
            // Arrange.
            var timerModelMapper = Substitute.For<ITimerModelMapper>();
            var lapTimeModelMapper = Substitute.For<ITimerLapModelMapper>();
            var view = Substitute.For<IStopWatchView>();
            var lapTimes = new List<TimerLapModel>();

            var sut = new StopWatchPresenter(timerModelMapper, lapTimeModelMapper);

            timerModelMapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            lapTimeModelMapper.MapSingle(Arg.Any<TimerModel>(), Arg.Any<List<TimerLapModel>>()).Returns(new TimerLapModel { globalTimeSpan = new System.TimeSpan(), lapTimeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.LoadData();
            sut.SetLapTime();

            var expectedModel = new TimerLapModel { globalTimeSpan = new System.TimeSpan(), lapTimeSpan = new System.TimeSpan() };

            // Assert.
            view.Received(1).DidUpdateLapTime(Arg.Is<TimerLapModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void DidUpdateLapTime_FirsTime_ReturnsGlobalTime()
        {
            // Arrange.
            var timerModelMapper = Substitute.For<ITimerModelMapper>();
            var lapTimeModelMapper = Substitute.For<ITimerLapModelMapper>();
            var view = Substitute.For<IStopWatchView>();

            var sut = new StopWatchPresenter(timerModelMapper, lapTimeModelMapper);

            lapTimeModelMapper.MapSingle(Arg.Any<TimerModel>(), Arg.Any<List<TimerLapModel>>()).Returns(new TimerLapModel { globalTimeSpan = new System.TimeSpan(10), lapTimeSpan = new System.TimeSpan(10) });
            sut.Bind(view);

            // Act.
            sut.LoadData();
            sut.SetLapTime();

            var expectedModel = new TimerLapModel { globalTimeSpan = new System.TimeSpan(10), lapTimeSpan = new System.TimeSpan(10) };

            // Assert.
            view.Received(1).DidUpdateLapTime(Arg.Is<TimerLapModel>(x => expectedModel.Equals(x)));
        }
    }
}
