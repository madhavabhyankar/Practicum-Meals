using System.Collections.Generic;
using Practicum.Contracts;

namespace Practicum.Console.Builder
{
    public interface IMealBuilder
    {

        /// <summary>
        /// Validate all the defined primary rules.
        /// </summary>
        /// <param name="inputParams"></param>
        /// <returns></returns>
        IEnumerable<IRuleExecutionResult> ValidateRules(string inputParams);

        /// <summary>
        /// Build meal based on preferences.  This function gets the meal based on the input and passes the parameters 
        /// required to build the meal.
        /// </summary>
        /// <param name="inputParams"></param>
        /// <returns>Returns Built meal.</returns>
        string BuildMeal(string inputParams);

        /// <summary>
        /// This returns the implementation of the required meal based on time of day.
        /// </summary>
        /// <param name="timeOfDay"></param>
        /// <returns>Implementation of Meal </returns>
        IMeal GetMealGeneratorFor(string timeOfDay);
    }
}