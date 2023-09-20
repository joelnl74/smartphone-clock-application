using MobileClock.Mapper;
using MobileClock.Models;
using NUnit.Framework;

namespace Tests.MobileTimer.Mappers
{
    public class TimerModelMapperTests
    {
        private const float _time = 1;

        #region MapSingle

        [Test]
        public void MapSingle_ReturnsExpectedTimer()
        {
            // Arrange.
            var sut = new TimerModelMapper();

            // Act.
            var result = sut.MapSingle(_time);

            // Assert.
            var expected = new TimerModel
            {
                Time = _time,
            };

            Assert.IsTrue(expected.Equals(result));
        }

        #endregion
    }
}
