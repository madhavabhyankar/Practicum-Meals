namespace Practicum.Contracts
{
    /// <summary>
    /// Every IRule Implementaion returns this execution result.
    /// </summary>
    public interface IRuleExecutionResult
    {
        bool IsValid { get; }
        string Error { get; }
    }
}
