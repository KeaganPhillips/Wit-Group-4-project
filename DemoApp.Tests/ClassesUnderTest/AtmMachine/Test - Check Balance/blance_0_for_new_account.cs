using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Tests.ClassesUnderTest.AtmMachine.Test___Insert_Card;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests.ClassesUnderTest.AtmMachine.Test___Check_Balance
{
    [TestName("Check Balance")]
    public class blance_0_for_new_account: IScenario
    {
        public Type ClassUnderTest
        {
            get { return typeof(DemoApp.AtmMachine); }
        }

        public string SecnarionDescription
        {
            get { return "Desc...."; }
        }

        public string GivenDescription
        {
            get { return "The customer just opened an account"; }
        }

        public string WhenDescription
        {
            get { return "He checks his bank balance"; }
        }

        public void Given()
        {
            throw new NotImplementedException();
        }

        public void When()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.Fail();
        }

    }
}
