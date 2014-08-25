using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Contracts;

namespace Practicum.Meal.Rules.Test
{
    [TestClass]
    public class MealRulesTest
    {
        class DishCanBeAddedMultipleTimes : IDish
        {
            public int Id { get { return 1; } }
            public string Name { get { return "Can be added Multiple Times"; }}
            public bool CanAddMoreThanOne { get{return true;} }
        }

        class DishCannotBeAddedMultTimes : IDish
        {
            public int Id { get { return 2; }}
            public string Name { get { return "Dish Cannot be added Mult Times"; }}
            public bool CanAddMoreThanOne { get { return false; } }
        }

        class  ErrorDish: IDish
        {
            public int Id {
                get { return int.MaxValue; }
            }
            public string Name { get { return "Error"; } }
            public bool CanAddMoreThanOne { get { return false; }}
        }
        [TestMethod]
        public void ValidateThatTheDishCanBeAddedWhenNoDishesExist()
        {
            
            var canAddDishRule = new CanAddThisDish();
            var dishes = new List<IDish>();
            var moreThanOnce = new DishCanBeAddedMultipleTimes();
            var onlyOnce = new DishCannotBeAddedMultTimes();
            var error = new ErrorDish();
            var ret = canAddDishRule.Validate(moreThanOnce, dishes);
            Assert.IsTrue(ret.IsValid);

        }

        [TestMethod]
        public void ValidateThatDishThatCanBeAddOnlyOnce()
        {
            var canAddDishRule = new CanAddThisDish();
            var onlyOnce = new DishCannotBeAddedMultTimes();
            var dishes = new List<IDish> { onlyOnce };

            var ret = canAddDishRule.Validate(onlyOnce, dishes);
            Assert.IsFalse(ret.IsValid);
        }

        [TestMethod]
        public void ValidateThatDishesThatCanBeAddedMoreThanOnce()
        {
            var canAddDishRule = new CanAddThisDish();
            var moreThanOnce = new DishCanBeAddedMultipleTimes();
            var dishes = new List<IDish> {moreThanOnce, moreThanOnce, moreThanOnce};
            
            var ret = canAddDishRule.Validate(moreThanOnce, dishes);
            Assert.IsTrue(ret.IsValid);

        }

        [TestMethod]
        public void ErrorDishValidationPositive()
        {
            var dishes = new List<IDish>();
            var onlyOnce = new DishCannotBeAddedMultTimes();
            var errorDishRule = new ErrorDishHasNotBeenAddedYet();
            var ret = errorDishRule.Validate(onlyOnce, dishes);
            Assert.IsTrue(ret.IsValid);
        }
        [TestMethod]
        public void ErrorDishValidationNegative()
        {
            var dishes = new List<IDish> {new ErrorDish()};
            var onlyOnce = new DishCannotBeAddedMultTimes();
            var errorDishRule = new ErrorDishHasNotBeenAddedYet();
            var ret = errorDishRule.Validate(onlyOnce, dishes);
            Assert.IsFalse(ret.IsValid);
        }
    }
}
