using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests.MobileTimer.Presenters
{
    public class ClockPresenterTests
    {
        [Test]
        public void LoadData_View_DidLoadData_NotInvoked()
        {
            // Arrange.
            var mapper = Substitute.For<IClockModelMapper>();
            var view = Substitute.For<IClockView>();
            var sut = new ClockPresenter(mapper);

            mapper.MapSingle().Returns(new ClockModel { currentDateTime = DateTime.Now });
            sut.Bind(view);

            // Act.
            sut.LoadData();
            
            // Assert.
            Assert.That(view.ReceivedCalls().Count(), Is.EqualTo(0));
        }

        [Test]
        public void LoadData_View_MapperCalled()
        {
            // Arrange.
            var mapper = Substitute.For<IClockModelMapper>();
            var view = Substitute.For<IClockView>();
            var sut = new ClockPresenter(mapper);

            mapper.MapSingle().Returns(new ClockModel { currentDateTime = DateTime.Now });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            // Assert.
            mapper.Received(1).MapSingle();
        }
    }
}
