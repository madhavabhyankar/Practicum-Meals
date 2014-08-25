using Practicum.Contracts;

namespace Practicum.Meal.Rules
{
    public class RuleExecutionResult : IRuleExecutionResult
    {
        public bool IsValid {
            get { return string.IsNullOrEmpty(Error); }
        }
        public string Error { get;  set; }
    }
}
