using System.Collections.Generic;
using System.Linq;
using System.Text;
using Practicum.Contracts;
using Practicum.Meals.Concrete.Common;

namespace Practicum.Meals.Concrete
{
    /// <summary>
    /// Meal Collection is a helper class that validates all the business rules and add the required dishes.
    /// Castle windsor resolves this as transient.  This is important becasue, we would like a new instance, everytime 
    /// a meal instance is create and used.
    /// </summary>
    public  class MealCollection
    {
        private readonly IMealRule[] _mealRules;
        private List<IDish> _dishes;
        private bool _errorOnAdd;

        public MealCollection(IMealRule[] mealRules)
        {
            _mealRules = mealRules;
            _errorOnAdd = false;
            _dishes = new List<IDish>();
        }
        public void AddErrorDish()
        {
            //add the error dish only if it has not already been added
            if (!_errorOnAdd)
            {
                _errorOnAdd = true;
                _dishes.Add(new ErrorDish());
            }
        }
        public bool AddDish(IDish dish)
        {
            //Validate all the business rules and add the dish.
            if(_mealRules.Select(x=>x.Validate(dish,_dishes)).All(x=>x.IsValid))
            {
                _dishes.Add(dish);
                return true;
            }
            //If we have gotten here, one of the business rules has failed.  Add the error dish and continue
            AddErrorDish();
            return false;

        }
        /// <summary>
        /// UI can assume the responsibility to build the meal as string can be argued, but for the sake of simplicy,
        /// I have implemented in the business process.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            //Building Meal follow this logic:
            //1) Order the meals by id, thus, error will always be last
            //2) Group the meals by Id, so we can count when coffee is ordered 3 time
            //3) Iterate through each group and build the output.
            foreach (var meal in _dishes.OrderBy(x=>x.Id).GroupBy(g=>g.Id).Select(y=> new {key = y.Key, dishes = y.ToList()}))
            {
                var anyDish = meal.dishes.First();
                sb.Append(meal.dishes.Count > 1
                    ? string.Format("{0}(x{1})", anyDish.Name, meal.dishes.Count)
                    : anyDish.Name);
                sb.Append(",");
            }
            return sb.ToString().Trim(',');
        }
    }
}
