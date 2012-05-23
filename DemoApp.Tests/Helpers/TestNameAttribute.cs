using System;

namespace DemoApp.Tests.Helpers
{
    public class TestNameAttribute : Attribute
    {
        public string TestName { get; set; }

        public TestNameAttribute(string testName)
        {
            TestName = testName;
        }
    }
}