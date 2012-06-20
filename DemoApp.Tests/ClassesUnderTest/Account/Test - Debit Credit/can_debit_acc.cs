using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests.ClassesUnderTest.Account.Test___Debit_Credit
{
    [TestClass]
    [TestName("Debit/Credit Account Test")]
    public class can_debit_acc : IScenario
    {
        private DemoApp.Account _account;

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
            get { return "Can Debit an Account"; }
        }

        #region Given

        public string GivenDescription
        {
            get { return "We have an Account with a R250 balance"; }
        }

        public void Given()
        {
            _account = new DemoApp.Account();
            _account.Credit(250);
        }
        #endregion

        #region When
        public string WhenDescription
        {
            get { return "We debit the account with R100"; }
        }

        public void When()
        {
            _account.Debit(100);
        }
        #endregion 

        #region Then
        [TestMethod]
        [ThenDescription(@"The blance should be 150.00")]
        public void TestMethod1()
        {
            Assert.AreEqual(150, _account.Balance);
        }
        #endregion
    }
}
