using Castle.Core.Internal;
using Practicum.Contracts;

namespace Practicum.Rules.Dto
{
    public class RuleExecutionResult : IRuleExecutionResult
    {
        public bool IsValid { get { return Error.IsNullOrEmpty(); } }
        public string Error { get; set; }
    }
}
