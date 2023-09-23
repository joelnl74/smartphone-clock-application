using MobileClock.Mapper;
using MobileClock.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.MobileTimer.Mappers
{
    public class TimerLapModelMapperTests
    {
        private const int _time = 1;

        #region MapSingle

        [Test]
        public void MapSingle_ReturnsExpectedTimer()
        {
            // Arrange.
            var sut = new TimerLapModelMapper();
            var model = new TimerModel { timeSpan = new System.TimeSpan() };
            var lapModelsList = new List<TimerLapModel>();

            // Act.
            var result = sut.MapSingle(model , lapModelsList);

            // Assert.
            var expected = new TimerLapModel
            {
                lapTimeSpan = new System.TimeSpan(),
            };

            Assert.IsTrue(expected.Equals(result));
        }

        [Test]
        public void MapSingle_WithPreviousLaps_ReturnsExpectedTimer()
        {
            // Arrange.
            var sut = new TimerLapModelMapper();
            var model = new TimerModel { timeSpan = new System.TimeSpan(0, 0, 20) };
            var lapModelsList = new List<TimerLapModel> { new TimerLapModel { globalTimeSpan = new System.TimeSpan(0, 0, 10) }};

            // Act.
            var result = sut.MapSingle(model, lapModelsList);

            // Assert.
            var expected = new TimerLapModel
            {
                globalTimeSpan = new System.TimeSpan(0, 0, 20),
                lapTimeSpan = new System.TimeSpan(0, 0, 10),
            };

            Assert.IsTrue(expected.Equals(result));
        }

        #endregion
    }
}
