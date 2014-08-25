using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;
using Castle.MicroKernel.Resolvers;
using Practicum.Contracts;

namespace Practicum.Console.Builder
{
    public class MealBuilder : IMealBuilder
    {
        
        private readonly IKernel _kernel;
        private readonly IPrimaryRule[] _allRules;

        /// <summary>
        /// Inject the collection of primary rules.  These rules are expected to be defined in a external library. 
        /// Castle windsor resolves this dependency.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="allRules"></param>
        public MealBuilder(IKernel kernel, IPrimaryRule[] allRules)
        {
            _kernel = kernel;
            _allRules = allRules;
        }

        /// <summary>
        /// Validate all the defined primary rules.
        /// </summary>
        /// <param name="inputParams"></param>
        /// <returns></returns>
        public IEnumerable<IRuleExecutionResult> ValidateRules(string inputParams)
        {
            return _allRules.Select(x => x.Validate(inputParams));
        }
        /// <summary>
        /// Build meal based on preferences.  This function gets the meal based on the input and passes the parameters 
        /// required to build the meal.
        /// </summary>
        /// <param name="inputParams"></param>
        /// <returns></returns>
        public string BuildMeal(string inputParams)
        {

            var splitParams = inputParams.Split(new char[] { ',' });

            //Get the meal implementation that matches the specified input.
            var mealGenerator = GetMealGeneratorFor(splitParams[0]);

            //Build the meal based on the parameters specified.
            return mealGenerator == null? String.Format("No meal defined for {0}",splitParams[0]): mealGenerator.BuildMeal(splitParams.Skip(1).Take(splitParams.Length).ToArray());

        }
        /// <summary>
        /// This returns the implementation of the required meal based on time of day.
        /// </summary>
        /// <param name="timeOfDay"></param>
        /// <returns>Implementation of Meal </returns>
        public IMeal GetMealGeneratorFor(string timeOfDay)
        {
            try
            {
                var pascalCasedTimeOfDay =
                    System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(timeOfDay.Trim().ToLower());

                //Convention over configuration.
                var mealToResolve = string.Format("{0}Meal", pascalCasedTimeOfDay);

                return _kernel.Resolve<IMeal>(mealToResolve);
            }
            catch (ComponentNotFoundException)
            {
                System.Console.WriteLine("Meal was not found! Please check the installation.");
                return null;
            }
            catch (DependencyResolverException)
            {
                System.Console.WriteLine("Not able to load the required libraries, please ensure the installation is correct!");
                return null;
            }
        }
    }
}
