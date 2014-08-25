using Practicum.Contracts;

namespace Practicum.Meals.Concrete.Common
{
    /// <summary>
    /// Error, implements IDish interface, to simplify error detection.
    /// </summary>
    class ErrorDish : IDish
    {
        public int Id
        {
            get { return int.MaxValue; }
        }

        public string Name { get { return "error"; } }
        public bool CanAddMoreThanOne { get { return false; } }
    }
}
