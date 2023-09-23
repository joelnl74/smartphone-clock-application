using MobileClock.Mapper;
using MobileClock.Models;
using MobileClock.Presenter;
using MobileClock.View.Interfaces;
using NSubstitute;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.MobileTimer.Presenter
{
    public class ClockPresenterTests
    {
        [UnityTest]
        public IEnumerator LoadData_AfterOneSec_DataChanged()
        {
            // Arrange.
            var view = Substitute.For<IClockView>();
            var sut = new ClockPresenter(new ClockModelMapper());
            var currentTime = DateTime.Now;

            sut.Bind(view);

            // Act.
            sut.LoadData();
            yield return new WaitForSeconds(1);

            // Assert.
            view.Received().DidLoadData(Arg.Is<ClockModel>(x => x.currentDateTime != currentTime));
        }

        [UnityTest]
        public IEnumerator LoadData_AfterOneSec_ReceivedCorrectData()
        {
            // Arrange.
            var view = Substitute.For<IClockView>();
            var sut = new ClockPresenter(new ClockModelMapper());

            sut.Bind(view);

            // Act.
            sut.LoadData();
            yield return new WaitForSeconds(1);

            var expectedData = new ClockModel { currentDateTime = DateTime.Now };

            // Assert.
            view.Received().DidLoadData(Arg.Is<ClockModel>(x => x.Equals(expectedData)));
        }
    }
}
