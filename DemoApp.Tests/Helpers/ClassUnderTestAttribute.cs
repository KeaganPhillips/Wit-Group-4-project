using System;

namespace DemoApp.Tests.Helpers
{
    public class ClassUnderTestAttribute : Attribute
    {
        public string ClassFullName { get; set; }

        public ClassUnderTestAttribute(string classFullName)
        {
            ClassFullName = classFullName;
        }
    }
}