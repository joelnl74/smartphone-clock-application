using MobileClock.Models;
using NUnit.Framework;
using System;

namespace Tests.MobileTimer.Models
{
    [TestFixture]
    public class ClockModelTests
    {
        private DateTime _timeStamp = new DateTime(1);
        private DateTime _otherTimeStamp = new DateTime(2);

        private class OtherObject
        {

        }

        [Test]
        public void SameInstance_ShouldSucceedEqualityObjectComparer()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };

            // Assert.
            Assert.AreEqual(data, data);
            Assert.True(data.Equals((object)data));
        }

        [Test]
        public void SameInstance_ShouldSucceedEqualityItemComparer()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };

            // Assert.
            Assert.AreEqual(data, data);
            Assert.True(data.Equals(data));
        }

        [Test]
        public void SameData_ShouldSucceedEquality()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };
            var otherData = new ClockModel { currentDateTime = _timeStamp };

            // Assert.
            Assert.AreEqual(data, otherData);
            Assert.True(data.Equals(otherData));
        }

        [Test]
        public void DifferentType_ShouldFailEquality()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };
            object otherData = new OtherObject();

            // Assert.
            Assert.AreNotEqual(data, otherData);
            Assert.False(data.Equals(otherData));
        }

        [Test]
        public void NullInstance_ShouldFailEqualityObjectComparer()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };
            ClockModel otherData = null;

            // Assert.
            Assert.AreNotEqual(data, otherData);
            Assert.False(data.Equals((object)otherData));
        }

        [Test]
        public void NullInstance_ShouldFailEqualityItemComparer()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };
            ClockModel otherData = null;

            // Assert.
            Assert.AreNotEqual(data, otherData);
            Assert.False(data.Equals(null));
        }

        [Test]
        public void DifferentId_ShouldFailEquality()
        {
            // Arrange.
            var data = new ClockModel { currentDateTime = _timeStamp };
            var otherData = new ClockModel { currentDateTime = _otherTimeStamp };

            // Assert.
            Assert.AreNotEqual(data, otherData);
        }
    }

}
