using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestReflector.Core
{
    public interface IScenario
    {
        string SecnarionDescription { get; }
        string GivenDescription { get; }
        string WhenDescription { get; }
        
        void Given();
        void When();
    }
}
