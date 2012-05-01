namespace DemoApp.Tests.Helpers
{
    public interface IWhen
    {
        void FireEvent();
        string WhenDescription { get; }
    }
}