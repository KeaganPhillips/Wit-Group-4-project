using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests.ClassesUnderTest.Customer.Test___Withdraw_Cash
{
    [TestClass]
    [TestName("Can Withdraw Cash")]
    public class can_withdraw_cash : IScenario
    {
        [TestInitialize]
        public void Setup()
        {
            TestHelper.SetupTest(this);
        }

        public Type ClassUnderTest
        {
            get { return typeof (DemoApp.Customer); }
        }

        public string SecnarionDescription
        {
            get { return  "The customer can withdraw cash from the ATM"; }
        }

        #region Given
        public string GivenDescription
        {
            get { return "The we have a valid Customer, ATM machine and Bank Card. "; }
        }

        public void Given()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region When
        public string WhenDescription
        {
            get { return "The Customer insert his card, enter his pin and withdraws cash."; }
        }

        public void When()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Then
        [TestMethod]
        [ThenDescription(@"The ATM status is Card Inserted")]
        public void TestMethod1()
        {
        }
        #endregion
    }
}
