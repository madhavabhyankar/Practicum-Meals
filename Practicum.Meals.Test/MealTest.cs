using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Meals.Concrete;
using Practicum.Meals.Interfaces;
using MorningDishes = Practicum.Meals.Concrete.Morning;
using NightDishes = Practicum.Meals.Concrete.Night;
using Practicum.Contracts;
using Practicum.Meal.Rules;
namespace Practicum.Meals.Test
{
    [TestClass]
    public class MealTest
    {
        
        private INightDish[] _nightDishes;
        private IMorningDish[] _morningDishes;
        private IMealRule[] _mealRules;
        [TestInitialize]
        public void Setup()
        {
            
            _morningDishes = new IMorningDish[]
            {
                new MorningDishes.Entree(),
                new MorningDishes.Drink(),
                new MorningDishes.Side()
            };
            _nightDishes = new INightDish[]
            {
                new NightDishes.Dessert(), new NightDishes.Drink(), new NightDishes.Entree(), new NightDishes.Side(),
            };
            _mealRules = new IMealRule[]{
                new CanAddThisDish(),
                new ErrorDishHasNotBeenAddedYet()
            };
        }

        private void MorningMealGeneration(string[] input, string output, string message)
        {
            var mealCollection = new MealCollection(_mealRules);
            var morningMeal = new MorningMeal(_morningDishes, mealCollection);
            var meal = morningMeal.BuildMeal(input);
            Assert.AreEqual(output, meal, true, CultureInfo.CurrentCulture, message);
        }
        private void NightMealGeneration(string[] input, string output, string message)
        {
            var mealCollection = new MealCollection(_mealRules);
            var nightMeal = new NightMeal(_nightDishes, mealCollection);
            var meal = nightMeal.BuildMeal(input);
            Assert.AreEqual(output, meal, true, CultureInfo.CurrentCulture, message);
        }
        [TestMethod]
        public void MorningTests()
        {
            MorningMealGeneration(new string[]{"1","2","3"},"eggs,toast,coffee","Simple Test" );
            MorningMealGeneration(new string[] { "2", "1", "3" }, "eggs,toast,coffee", "Unorderd Input");
            MorningMealGeneration(new string[] { "1", "2", "3","4" }, "eggs,toast,coffee,error", "Error Input");
            MorningMealGeneration(new string[] { "1", "2", "3", "3", "3" }, "eggs,toast,coffee(x3)", "Multiple item success Test");
            MorningMealGeneration(new string[] { "1", "2","2","2", "3" }, "eggs,toast,error", "Multiple Items Error Test");
            
        }

        [TestMethod]
        public void NightTests()
        {
            NightMealGeneration(new string[]{"1","2","3","4"},"steak,potato,wine,cake","Simple Test" );
            NightMealGeneration(new string[] { "1", "2", "2", "4" }, "steak,potato(x2),cake", "Multiple Items and Skip one Test");
            NightMealGeneration(new string[] { "1", "2", "3", "4","5" }, "steak,potato,wine,cake,error", "Item that that does not exist Test");
            NightMealGeneration(new string[] { "1", "1", "2", "3","4","5" }, "steak,error", "Multiple Item Error Test");

        }

    }
}
