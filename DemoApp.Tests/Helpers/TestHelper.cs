using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Tests.ClassesUnderTest.AtmMachine.Test___Insert_Card;
using UnitTestReflector.Core;

namespace DemoApp.Tests.Helpers
{
    public class TestHelper
    {
        public static void SetupTest(IScenario scenario)
        {
            scenario.Given();
            scenario.When();
        }
    }
}
