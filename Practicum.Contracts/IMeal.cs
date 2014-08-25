namespace Practicum.Contracts
{
    /// <summary>
    /// Meal Contract defines how the meal is built.  
    /// </summary>
    public interface IMeal
    {
        string BuildMeal(string[] input);
    }
}
