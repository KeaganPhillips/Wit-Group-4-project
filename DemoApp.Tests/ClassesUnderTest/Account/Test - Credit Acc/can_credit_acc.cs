using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests.ClassesUnderTest.Account.Test___Credit_Acc
{
    [TestClass]
    [TestName("Credit Account Test")]
    public class can_credit_acc:IScenario
    {
        public Type ClassUnderTest
        {
            get { return typeof(DemoApp.Account); }
        }

        public string SecnarionDescription
        {
            get { return "The account can be credited"; }
        }

        #region Given
        public string GivenDescription
        {
            get { return "We have a valid open account with R100.00 balance"; }
        }

        public void Given()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region When
        public string WhenDescription
        {
            get { return "We credit the account with R550.00"; }
        }

        public void When()
        {
            throw new NotImplementedException();
        }
        #endregion 

        #region Then
        [TestMethod]
        [ThenDescription(@"The blance should be R650.00")]
        public void Then()
        {
            Assert.Fail();
        }
        #endregion 
    }
}
