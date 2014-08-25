using System.Linq;
using Practicum.Contracts;
using Practicum.Meals.Interfaces;
using Practicum.Meals.Concrete;
namespace Practicum.Meals
{
    public class MorningMeal : IMeal
    {
        private readonly IMorningDish[] _morningDishes;
        private readonly MealCollection _mealCollection;
        /// <summary>
        /// Castle Windsor resolves theis by creating instances of morning dishes and MealCollection.
        /// This way, this class doesn't neet to worry about building all moring dishes.  Also, we dont need to recomplie
        /// if a new dish is added.
        /// </summary>
        /// <param name="morningDishes"></param>
        /// <param name="mealCollection"></param>
        public MorningMeal(IMorningDish[] morningDishes , MealCollection mealCollection)
        {
            _morningDishes = morningDishes;
            _mealCollection = mealCollection;
        }
        /// <summary>
        /// This function builds the meal by matching morning dish to the dish id being passed in.  If the dish is found, its added
        /// else an error is added.
        /// </summary>
        /// <param name="dishIds"></param>
        /// <returns></returns>
        public string BuildMeal(string[] dishIds)
        {
            // The responsibility of validating the inputs is assumed by the Rules Validator.  It is also the responsibility of
            // the service composor i.e. consol app, to ensure the services are composed in the right order. Hence, here we 
            // assume that the id are ints.
            foreach (var dishId in dishIds)
            {
                var dishToAdd = _morningDishes.FirstOrDefault(x => x.Id == int.Parse(dishId)) as IDish;
                if (dishToAdd != null)
                {
                    _mealCollection.AddDish(dishToAdd);
                }
                else
                {
                    _mealCollection.AddErrorDish();
                }
            }
            return _mealCollection.ToString();

            
        }

    }
}

