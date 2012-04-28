using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests
{
    [TestClass]
    public class AtmMachineTest
    {
        [TestMethod]
        public void CheckBalance_balance_0_for_new_account()
        {
            // Given: The customer opened a new account and didn't deposit any cash yet
            ICustomer customer = new Customer();
            IAtmCard atmCard = new AtmCard();
            IAtmMachine atmMachine = new AtmMachine();


            // When: He checks his back balance
            atmMachine.InsertCard(atmCard);
            atmMachine.EnterPin("1234");
            var balance = atmMachine.CheckBalance();

            // Then: The balance should be 0
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void InsertCard_can_insert_card()
        {
            // Given: We have an ATM card
            IAtmCard atmCard = new AtmCard();
            IAtmMachine atmMachine = new AtmMachine();

            // When: we inserts the ATM Card
            atmMachine.InsertCard(atmCard);

            // Then: The card must be inserted
            Assert.IsTrue(atmMachine.CardInserted);
        }

        [TestMethod]
        public void InsertCard_card_not_inserted()
        {
            // Given: We have an ATM card
            IAtmCard atmCard = new AtmCard();
            IAtmMachine atmMachine = new AtmMachine();

            // When: we don't inserts the ATM Card

            // Then: The card must be inserted
            Assert.IsFalse(atmMachine.CardInserted);
        }

        [TestMethod]
        public void InsertCard_insert_and_eject_card()
        {
            // Given: We have an ATM card
            IAtmCard atmCard = new AtmCard();
            IAtmMachine atmMachine = new AtmMachine();

            // When: we insert and eject the card
            atmMachine.InsertCard(atmCard);
            atmMachine.EjectCard();

            // Then: The card must be inserted
            Assert.IsFalse(atmMachine.CardInserted);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Cannot enter pin. You must enter your ATM card first")]
        public void EnterPin_cannot_enter_pin_if_theres_no_card()
        {
            // Given: There's no card inserted in the ATM
            IAtmMachine atmMachine = new AtmMachine();

            // When: We try to enter a pin
            atmMachine.EnterPin("1234");

            // Then: Exception

        }

        [TestMethod]
        public void EnterPin_enter_correct_pin()
        {
            // Given: We insert the card in the machine
            ICustomer customer = new Customer();
            IAtmCard atmCard = new AtmCard();
            IAtmMachine atmMachine = new AtmMachine();

            // When: We enter the pin the correct pin
            atmMachine.InsertCard(atmCard);
            atmMachine.EnterPin(customer.MySecretPin);

            // Then: ATM Machine status should be Authenticated
            Assert.IsTrue(atmMachine.Authenticated);
        }

    }
}
