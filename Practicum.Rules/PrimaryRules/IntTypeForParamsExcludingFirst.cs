using System.Linq;
using Practicum.Contracts;
using Practicum.Rules.Dto;

namespace Practicum.Rules.PrimaryRules
{
    /// <summary>
    /// Validate that all the inputs after the first one are ints.
    /// </summary>
    public class IntTypeForParamsExcludingFirst : IPrimaryRule
    {
        public IRuleExecutionResult Validate(string input)
        {
            var result = new RuleExecutionResult();

            var splitParams = input.Split(new char[] { ',' });
            var dishIds = splitParams.Skip(1).Take(splitParams.Length).ToArray();
            if (!dishIds.All(x =>
            {
                int dishId;
                return int.TryParse(x, out dishId);
            }))
            {
                result.Error = "Specified input is not correct. Please check the dishes parameter for the meal";
            }
            return result;

        }
    }
}
