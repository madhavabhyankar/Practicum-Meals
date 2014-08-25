namespace Practicum.Contracts
{
    /// <summary>
    /// Primary rule contract, defines how the rule is validated.
    /// </summary>
    public interface IPrimaryRule
    {
        IRuleExecutionResult Validate(string input);
    }
}
