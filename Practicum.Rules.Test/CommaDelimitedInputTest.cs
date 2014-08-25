using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Rules.PrimaryRules;

namespace Practicum.Rules.Test
{
    [TestClass]
    public class CommaDelimitedInputTest
    {
        [TestMethod()]
        public void ValidateCommaDelimitedRuleWithCommaDelimitedInput()
        {
            var commaRule = new CommaDelimitedInput();
            var retResult = commaRule.Validate("a,v,c,d,e,w");
            Assert.IsTrue(retResult.IsValid,"Comma delimited rule should have passed");

        }
        [TestMethod()]
        public void ValidateCommaDelimitedRuleWithFlatInput()
        {
            var commaRule = new CommaDelimitedInput();
            var retResult = commaRule.Validate("abcdef");
            Assert.IsFalse(retResult.IsValid, "Comma delimited rule should have failed.");

        }
    }
}
