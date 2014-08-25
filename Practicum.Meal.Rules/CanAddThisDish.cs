using System.Collections.Generic;
using System.Linq;
using Practicum.Contracts;

namespace Practicum.Meal.Rules
{
    /// <summary>
    /// This implementation of MealRule (Business Rule) is to signal whether this dish can be added or not
    /// </summary>
    public class CanAddThisDish : IMealRule 
    {
        public IRuleExecutionResult Validate(IDish dishToAdd, IEnumerable<IDish> dishesAlreadyAdded)
        {
            if ((dishesAlreadyAdded.Any(x => x.Id == dishToAdd.Id) && dishToAdd.CanAddMoreThanOne) ||
                (dishesAlreadyAdded.All(x => x.Id != dishToAdd.Id)))
            {
                return new RuleExecutionResult();
            }
            else
            {
                return new RuleExecutionResult
                {
                    Error =
                        "Cannot add this dish becasue the dish already exists and the dish cannont be added more than once"
                };
            }
        }
    }
}
