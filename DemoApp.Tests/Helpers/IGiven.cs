namespace DemoApp.Tests.Helpers
{
    public interface IGiven
    {
        void CreateInitialState();
        string GivenDescription { get; }
    }
}