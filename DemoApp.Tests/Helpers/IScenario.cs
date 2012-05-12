using System;

namespace DemoApp.Tests.Helpers
{
    public interface IScenario
    {
        Type ClassUnderTest { get; }

        string SecnarionDescription { get; }
        string GivenDescription { get; }
        string WhenDescription { get; }
        
        void Given();
        void When();
    }
}
