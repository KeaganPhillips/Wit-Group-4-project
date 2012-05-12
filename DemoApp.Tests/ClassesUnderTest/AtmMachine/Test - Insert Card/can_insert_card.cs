using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DemoApp.Tests.ClassesUnderTest.AtmMachine.Test___Insert_Card
{
    [TestClass]
    [ClassUnderTest("DemoApp.AtmMachine")]
    [TestName("Insert Card")]
    public class can_insert_card: IScenario
    {
        private IAtmCard _atmCard;
        private IAtmMachine _atmMachine;
        
        [TestInitialize]
        public void Setup()
        {
            TestHelper.SetupTest(this);
        }

        #region Scenario

        public Type ClassUnderTest
        {
            get { return typeof(DemoApp.AtmMachine); }
        }

        public string SecnarionDescription
        {
            get { return "Can insert card into the ATM"; }
        }
        #endregion

        #region Given
        public string GivenDescription 
        {
            get { return "We have an ATM card and a ATM Machine"; }
        }
        public void Given()
        {
            _atmCard = new AtmCard();
            _atmMachine = new DemoApp.AtmMachine();
        }
        #endregion

        #region When
        public string WhenDescription 
        {
            get { return "we inserts the ATM Card"; }
        }
        public void When()
        {
            _atmMachine.InsertCard(_atmCard);
        }
        #endregion

        #region Then
        [TestMethod]
        [ThenDescription(@"ATM status is 'Card Inserted'")]
        public void atm_status_is_card_inserted()
        {
            Assert.IsTrue(_atmMachine.CardInserted);
        }

        #endregion
    }
}
