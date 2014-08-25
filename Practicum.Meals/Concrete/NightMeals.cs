using Practicum.Contracts;
using Practicum.Meals.Interfaces;

namespace Practicum.Meals.Concrete.Night
{
    //Implementation of various night dishes.
    public class Entree : IDish,INightDish
    {
        public int Id
        {
            get { return 1; }
        }
        public string Name
        {
            get { return "steak"; }
        }
        public bool CanAddMoreThanOne { get { return false; } }
    }

    public class Side : IDish, INightDish
    {
        public int Id
        {
            get { return 2; }
        }
        public string Name
        {
            get { return "potato"; }
        }
        public bool CanAddMoreThanOne
        {
            get { return true; }
        }
    }
    public class Drink : IDish, INightDish
    {
        public int Id
        {
            get { return 3; }
        }
        public string Name
        {
            get { return "wine"; }
        }
        public bool CanAddMoreThanOne
        {
            get { return false; }
        }
    }
    public class Dessert : IDish, INightDish
    {
        public int Id
        {
            get { return 4; }
        }
        public string Name
        {
            get { return "cake"; }
        }
        public bool CanAddMoreThanOne
        {
            get { return false; }
        }
    }
    
}
