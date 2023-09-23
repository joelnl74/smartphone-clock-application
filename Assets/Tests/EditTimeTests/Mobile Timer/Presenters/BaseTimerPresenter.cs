using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Tests.MobileTimer.Presenters
{
    public interface IMockBaseTimerView : IBaseTimerView { }
    public class MockBaseTimerPresenter : BaseTimerPresenter<IMockBaseTimerView>
    {
        public MockBaseTimerPresenter(ITimerModelMapper timerModelMapper) : base(timerModelMapper) { }
        public override void UpdateTimer() { }
    }

    public class BaseTimerPresenterTests
    {
        [Test]
        public void LoadData_View_DidLoadData_NotInvoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<IMockBaseTimerView>();
            var sut = new MockBaseTimerPresenter(mapper);

            // Act.
            sut.Bind(view);

            // Assert.
            Assert.That(view.ReceivedCalls().Count(), Is.EqualTo(0));
        }

        [Test]
        public void LoadData_View_DidLoad_Invoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<IMockBaseTimerView>();
            var sut = new MockBaseTimerPresenter(mapper);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan() };

            // Assert.
            view.Received(1).DidLoadData(Arg.Is<TimerModel>(x => expectedModel.Equals(x)));
        }

        [Test]
        public void LoadData_View_DidStop_Invoked()
        {
            // Arrange.
            var mapper = Substitute.For<ITimerModelMapper>();
            var view = Substitute.For<IMockBaseTimerView>();
            var sut = new MockBaseTimerPresenter(mapper);

            mapper.MapSingle().Returns(new TimerModel { timeSpan = new System.TimeSpan() });
            sut.Bind(view);

            // Act.
            sut.Stop();

            var expectedModel = new TimerModel { timeSpan = new System.TimeSpan() };

            // Assert.
            view.Received(1).DidStop();
        }
    }
}
