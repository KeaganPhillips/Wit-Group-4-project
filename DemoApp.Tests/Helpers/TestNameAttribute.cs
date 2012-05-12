using System;

namespace DemoApp.Tests.ClassesUnderTest.AtmMachine.Test___Insert_Card
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