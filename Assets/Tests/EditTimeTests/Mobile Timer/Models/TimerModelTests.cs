using MobileClock.Models;
using NUnit.Framework;

namespace Tests.MobileTimer.Models
{
    [TestFixture]
    public class TimerModelTests
    {
        private const float _timeStamp = 1;
        private const float _otherTimeStamp = 2;

        private class OtherObject
        {

        }

        [Test]
        public void SameInstance_ShouldSucceedEqualityObjectComparer()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };

            // Assert.
            Assert.AreEqual(data, data);
            Assert.True(data.Equals((object)data));
        }

        [Test]
        public void SameInstance_ShouldSucceedEqualityItemComparer()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };

            // Assert.
            Assert.AreEqual(data, data);
            Assert.True(data.Equals(data));
        }

        [Test]
        public void SameData_ShouldSucceedEquality()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };
            var otherData = new TimerModel { Time = _timeStamp };

            // Assert.
            Assert.AreEqual(data, otherData);
            Assert.True(data.Equals(otherData));
        }

        [Test]
        public void DifferentType_ShouldFailEquality()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };
            object otherData = new OtherObject();

            // Assert.
            Assert.AreNotEqual(data, otherData);
            Assert.False(data.Equals(otherData));
        }

        [Test]
        public void NullInstance_ShouldFailEqualityObjectComparer()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };
            TimerModel otherData = null;

            // Assert.
            Assert.AreNotEqual(data, otherData);
            Assert.False(data.Equals((object)otherData));
        }

        [Test]
        public void NullInstance_ShouldFailEqualityItemComparer()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };
            TimerModel otherData = null;

            // Assert.
            Assert.AreNotEqual(data, otherData);
            Assert.False(data.Equals(null));
        }

        [Test]
        public void DifferentId_ShouldFailEquality()
        {
            // Arrange.
            var data = new TimerModel { Time = _timeStamp };
            var otherData = new TimerModel { Time = _otherTimeStamp };

            // Assert.
            Assert.AreNotEqual(data, otherData);
        }
    }

}
