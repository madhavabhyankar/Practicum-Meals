using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Rules.PrimaryRules;

namespace Practicum.Rules.Test
{
    [TestClass]
    public class TimeOfDayRuleTest
    {
        [TestMethod]
        public void NightIsAValidTimeOfDay()
        {
            var timeOfDayRule = new TimeOfDayRule();
            var result = timeOfDayRule.Validate("night,1,2,3,4");
            Assert.IsTrue(result.IsValid, "Night should be a valid time of day");

        }
        [TestMethod]
        public void MorningIsAValidTimeOfDay()
        {
            var timeOfDayRule = new TimeOfDayRule();
            var result = timeOfDayRule.Validate("morning,1,2,3,4");
            Assert.IsTrue(result.IsValid, "morning should be a valid time of day");

        }
        [TestMethod]
        public void EveningIsNotAValidTimeOfDay()
        {
            var timeOfDayRule = new TimeOfDayRule();
            var result = timeOfDayRule.Validate("evening,1,2,3,4");
            Assert.IsFalse(result.IsValid, "Evening is not a valid time of day");

        }
        [TestMethod]
        public void PascalCaseTimeOfDayIsAValidTimeOfDay()
        {
            var timeOfDayRule = new TimeOfDayRule();
            var nightResult = timeOfDayRule.Validate("Night,1,2,3,4");
            Assert.IsTrue(nightResult.IsValid, "Night should be a valid time of day");

            var morningResult = timeOfDayRule.Validate("Morning,1,2,3,4");
            Assert.IsTrue(morningResult.IsValid, "Morning should be a valid time of day");
        }
        [TestMethod]
        public void MixedCaseTimeOfDayIsAValidTimeOfDay()
        {
            var timeOfDayRule = new TimeOfDayRule();
            var nightResult = timeOfDayRule.Validate("niGht,1,2,3,4");
            Assert.IsTrue(nightResult.IsValid, "niGht should be a valid time of day");

            var morningResult = timeOfDayRule.Validate("morNIng,1,2,3,4");
            Assert.IsTrue(morningResult.IsValid, "morNIng should be a valid time of day");
        }
    }
}
