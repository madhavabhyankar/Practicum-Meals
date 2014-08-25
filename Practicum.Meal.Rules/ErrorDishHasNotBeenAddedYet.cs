using System.Collections.Generic;
using System.Linq;
using Practicum.Contracts;

namespace Practicum.Meal.Rules
{
    /// <summary>
    /// This implementation of MealRule (Business Rule) is to check if the an error has already be found.
    /// </summary>
    public class ErrorDishHasNotBeenAddedYet : IMealRule
    {
        public IRuleExecutionResult Validate(IDish dishToAdd, IEnumerable<IDish> dishesAlreadyAdded)
        {
            if (dishesAlreadyAdded.Any(x => x.Id == int.MaxValue))
            {
                return new RuleExecutionResult {Error = "Error dish has already been added"};
            }
            else
            {
                return new RuleExecutionResult();
            }
        }
    }
}
