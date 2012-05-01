using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestReflector.Core
{
    [TestClass]
    public abstract class ScenarioBase
    {
        [ClassInitialize]
        public void Setup()
        {
            // Get and create the context
            var testContext = Given();
            testContext.CreateInitialState();

            // Fire the event tha occurs
            var testEvent = When();
            testEvent.FireEvent();
        }

        public abstract string SecnarionDescription { get; }
        public abstract IGiven Given();
        public abstract IWhen When();
    }
}
