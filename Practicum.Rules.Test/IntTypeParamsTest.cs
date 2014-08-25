using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Rules.PrimaryRules;

namespace Practicum.Rules.Test
{
    [TestClass]
    public class IntTypeParamsTest
    {
        [TestMethod]
        public void AllParamsAreInts()
        {
            var intRule = new IntTypeForParamsExcludingFirst();
            var result = intRule.Validate("morning,1,2,3,4");
            Assert.IsTrue(result.IsValid, "1,2,3,4 are valid int params");
        }
        [TestMethod]
        public void AllParamsAreIntsWithSpaces()
        {
            var intRule = new IntTypeForParamsExcludingFirst();
            var result = intRule.Validate("morning,1, 2,3 ,4 ");
            Assert.IsTrue(result.IsValid, "1, 2,3 ,4 are valid int params");
        }
        [TestMethod]
        public void AllParamsAreAlphaNumericWithSpaces()
        {
            var intRule = new IntTypeForParamsExcludingFirst();
            var result = intRule.Validate("morning,a1, 2v,c ,D ");
            Assert.IsFalse(result.IsValid, "a1, 2v,c ,D  are invalid int params");
        }
    }
}
