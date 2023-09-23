using MobileClock.Mapper;
using MobileClock.Models;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Tests.MobileTimer.Mappers
{
    public class ClockModelMapperTests
    {
        #region MapSingle

        [Test]
        public void MapSingle_ReturnsExpectedTimer()
        {
            // Arrange.
            var sut = new ClockModelMapper();

            // Act.
            var result = sut.MapSingle();

            // Assert.
            var expected = new ClockModel { currentDateTime = DateTime.Now };
            // Ticks can always be slightly different.
            var expectedResult = expected.currentDateTime.Ticks / 1000;

            Assert.IsTrue(Mathf.Approximately(result.currentDateTime.Ticks / 1000.0f, expectedResult));
        }

        #endregion
    }
}
