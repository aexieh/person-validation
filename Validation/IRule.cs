namespace Validation
{
    public interface IRule
    {
        int ViolationCode { get; }
        string ViolationMessage { get; }
        string CheckingValue { get; }

        bool Passed();
    }
}
