using System.Collections.Generic;

namespace Practicum.Contracts
{
    /// <summary>
    /// This contract defines how the Business Rule should be defined.
    /// </summary>
    public interface IMealRule
    {
        IRuleExecutionResult Validate(IDish dishToAdd, IEnumerable<IDish> dishesAlreadyAdded);
    }
}
