namespace FizzBuzz.Domain.Abstract
{
    public interface ISettingsStore
    {
        string FizzWord { get; }
        string BuzzWord { get; }
    }
}