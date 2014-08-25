namespace Practicum.Contracts
{
    public interface IDish
    {
        int Id { get;  }
        string Name { get; }
        bool CanAddMoreThanOne { get; }
    }
}
