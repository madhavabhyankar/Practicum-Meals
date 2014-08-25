using Practicum.Contracts;
using Practicum.Meals.Interfaces;

namespace Practicum.Meals.Concrete.Morning
{
    //These are implementations of various morning meals.
    public class Entree : IDish,IMorningDish
    {
        public int Id
        {
            get { return 1; }
        }
        public string Name
        {
            get { return "eggs"; }
        }
        public bool CanAddMoreThanOne { get { return false; } }
    }

    public class Side : IDish, IMorningDish
    {
        public int Id
        {
            get { return 2; }
        }
        public string Name
        {
            get { return "toast"; }
        }
        public bool CanAddMoreThanOne
        {
            get { return false; }
        }
    }
    public class Drink : IDish, IMorningDish
    {
        public int Id
        {
            get { return 3; }
        }
        public string Name
        {
            get { return "coffee"; }
        }
        public bool CanAddMoreThanOne
        {
            get { return true; }
        }
    }

    
}
