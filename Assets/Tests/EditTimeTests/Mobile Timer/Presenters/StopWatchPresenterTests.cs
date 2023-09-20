using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Tests.MobileTimer.Presenters
{
    public class StopWatchPresenterTests
    {
        [Test]
        public void LoadData_View_DidLoadData_Invoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<ITimerView>();
            var sut = new TimerPresenter(mapper);

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
            var sut = new TimerPresenter(mapper);

            mapper.MapSingle().Returns(new TimerModel { Time = 0 });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            var expectedModel = new TimerModel { Time = 0 };

            // Assert.
            view.Received(1).DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }
    }
}
