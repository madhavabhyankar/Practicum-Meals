using System.Globalization;
using Practicum.Contracts;
using Practicum.Rules.Dto;

namespace Practicum.Rules.PrimaryRules
{
    /// <summary>
    /// Validate that time of day is "morning" or "night"
    /// </summary>
    public class TimeOfDayRule : IPrimaryRule
    {
        
        public IRuleExecutionResult Validate(string input)
        {
            var result = new RuleExecutionResult();
            if (!(input.StartsWith("morning", true, CultureInfo.CurrentCulture) ||
                input.StartsWith("night", true, CultureInfo.CurrentCulture)))
            {
                result.Error = "Specified time of day is incorrect";
            }
            return result;

        }
    }
}
