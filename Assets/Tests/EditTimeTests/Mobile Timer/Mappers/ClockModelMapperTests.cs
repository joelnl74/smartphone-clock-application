using MobileClock.Mapper;
using MobileClock.Models;
using NUnit.Framework;
using System;

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
            var expected = new ClockModel { TimeStamp = DateTime.Now.Ticks };

            Assert.IsTrue(expected.Equals(result));
        }

        #endregion
    }
}
