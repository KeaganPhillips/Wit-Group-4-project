using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Exceptions;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests.ClassesUnderTest.Account.Test___Debit_Credit
{
    [TestClass]
    [TestName("Debit/Credit Account Test")]
    public class can_only_debit_if_enough_in_balance : IScenario
    {
        private DemoApp.Account _account;
        private bool exception_thrown = false;

        [TestInitialize]
        public void Setup()
        {
            TestHelper.SetupTest(this);
        }

        public Type ClassUnderTest
        {
            get { return typeof(DemoApp.Account); }
        }

        public string SecnarionDescription
        {
            get { return "Cannot debit an account with more then the blance"; }
        }

        #region Given
        public string GivenDescription
        {
            get { return "The account balance is R500"; }
        }

        public void Given()
        {
            _account = new DemoApp.Account();
            _account.Credit(500);
        }
        #endregion

        #region When
        public string WhenDescription
        {
            get { return "We debit the account with R700"; }
        }

        public void When()
        {
            try
            {
                _account.Debit(700);
            }
            catch (InsufficientException)
            {
                exception_thrown = true;
            }
        }
        #endregion

        #region Then
        [TestMethod]
        [ThenDescription(@"An insufficient funds exception thrown")]
        public void TestMethod1()
        {
            Assert.IsTrue(exception_thrown);
        }
        #endregion
    }
}
