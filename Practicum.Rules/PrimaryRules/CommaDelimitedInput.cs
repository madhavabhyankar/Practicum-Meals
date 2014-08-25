using Practicum.Contracts;
using Practicum.Rules.Dto;

namespace Practicum.Rules.PrimaryRules
{
    /// <summary>
    /// Validate that the input is comma delimited.
    /// </summary>
    public class CommaDelimitedInput:IPrimaryRule
    {
        public IRuleExecutionResult Validate(string input)
        {
            var result = new RuleExecutionResult();
            if (!input.Contains(","))
            {
                result.Error = "Input is not comma delimited";
            }
            return result;
        }
    }
}
