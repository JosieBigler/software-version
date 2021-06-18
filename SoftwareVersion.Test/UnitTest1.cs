using NUnit.Framework;
using SoftwareVersion.Logic;

namespace SoftwareVersion.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VersionCompare_FirstVersionIsLarger_ReturnTrue()
        {
            var firstVersion = "2.15.4";
            var secondVersion = "1";

            var results = Version.GreaterThan(firstVersion, secondVersion);
            Assert.AreEqual(true, results);
        }

        [Test]
        public void VersionCompare_FirstVersionIsSmaller_ReturnFalse()
        {
            var firstVersion = "2.15.4";
            var secondVersion = "13";

            var results = Version.GreaterThan(firstVersion, secondVersion);
            Assert.AreEqual(false, results);
        }

        [Test]
        public void VersionCompare_FirstVersionIsSmaller_ManyDecimals_ReturnFalse()
        {
            var firstVersion = "2.15.4.1.5.2.7";
            var secondVersion = "2.15.4.1.5.2.8";

            var results = Version.GreaterThan(firstVersion, secondVersion);
            Assert.AreEqual(false, results);
        }

        [Test]
        public void VersionCompare_IndexOutofRange_ReturnTrue()
        {
            var firstVersion = "13.15.4";
            var secondVersion = "13";

            var results = Version.GreaterThan(firstVersion, secondVersion);
            Assert.AreEqual(true, results);
        }

        [Test]
        public void VersionCompare_VersionsAreEqual1_ReturnFalse()
        {
            var firstVersion = "13.15.4";
            var secondVersion = "13.15.4";

            var results = Version.GreaterThan(firstVersion, secondVersion);
            Assert.AreEqual(false, results);
        }

        [Test]
        public void VersionCompare_VersionsAreEqual2_ReturnFalse()
        {
            var firstVersion = "0";
            var secondVersion = "0";

            var results = Version.GreaterThan(firstVersion, secondVersion);
            Assert.AreEqual(false, results);
        }
    }
}