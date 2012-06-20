using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests.ClassesUnderTest.Account.Test___Credit_Acc
{
    [TestClass]
    [TestName("Debit/Credit Account Test")]
    public class can_credit_acc:IScenario
    {
        [TestInitialize]
        public void Setup()
        {
            TestHelper.SetupTest(this);
        }

        private DemoApp.Account _account;

        public Type ClassUnderTest
        {
            get { return typeof(DemoApp.Account); }
        }

        public string SecnarionDescription
        {
            get { return "Can credit an Account"; }
        }

        #region Given
        public string GivenDescription
        {
            get { return "We have a valid open account with R0.00 balance"; }
        }

        public void Given()
        {
            _account = new DemoApp.Account();
        }
        #endregion

        #region When
        public string WhenDescription
        {
            get { return "We credit the account with R550.00"; }
        }

        public void When()
        {
            _account.Credit(550);
        }
        #endregion 

        #region Then
        [TestMethod]
        [ThenDescription(@"The blance should be 550.00")]
        public void Then()
        {
            Assert.AreEqual(550, _account.Balance );
        }
        #endregion 
    }
}
