using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Zenject;

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
        public void LoadData_View_MapperInvoked()
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
            mapper.Received(1).MapSingle();
        }
    }
}
