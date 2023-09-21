using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.MobileTimer.Presenters
{
    public class ClockTimerPresenterTests
    {
        [Test]
        public void LoadData_View_DidLoadData_Invoked()
        {
            // Arrange.
            var mapper = Substitute.For<IClockModelMapper>();
            var view = Substitute.For<IClockView>();
            var sut = new ClockPresenter(mapper);

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
            var mapper = Substitute.For<IClockModelMapper>();
            var view = Substitute.For<IClockView>();
            var sut = new ClockPresenter(mapper);

            mapper.MapSingle().Returns(new ClockModel { currentDateTime = new DateTime() });
            sut.Bind(view);

            // Act.
            sut.LoadData();

            var expectedModel = new ClockModel { currentDateTime = new DateTime() };

            // Assert.
            view.Received(1).DidLoadData(Arg.Is<ClockModel>(x => expectedModel.Equals(x)));
        }
    }
}
