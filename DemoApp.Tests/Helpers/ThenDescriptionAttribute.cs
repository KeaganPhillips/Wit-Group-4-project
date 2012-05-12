using System;

namespace DemoApp.Tests.Helpers
{
    public class ThenDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public ThenDescriptionAttribute(string description)
        {
            this.Description = description;
        }
    }
}