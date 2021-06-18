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

            var results = Version.GreaterThanOrEqual(firstVersion, secondVersion);
            Assert.AreEqual(true, results);
        }

        [Test]
        public void VersionCompare_FirstVersionIsSmaller_ReturnFalse()
        {
            var firstVersion = "2.15.4";
            var secondVersion = "13";

            var results = Version.GreaterThanOrEqual(firstVersion, secondVersion);
            Assert.AreEqual(false, results);
        }

        [Test]
        public void VersionCompare_FirstVersionIsSmaller_ManyDecimals_ReturnFalse()
        {
            var firstVersion = "2.15.4.1.5.2.7";
            var secondVersion = "2.15.4.1.5.2.8";

            var results = Version.GreaterThanOrEqual(firstVersion, secondVersion);
            Assert.AreEqual(false, results);
        }

        [Test]
        public void VersionCompare_IndexOutofRange_ReturnTrue()
        {
            var firstVersion = "13.15.4";
            var secondVersion = "13";

            var results = Version.GreaterThanOrEqual(firstVersion, secondVersion);
            Assert.AreEqual(true, results);
        }
    }
}