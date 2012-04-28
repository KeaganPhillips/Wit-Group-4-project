using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp
{
    public class AtmMachine : IAtmMachine
    {
        private IAtmCard _insertedCard;

        public decimal CheckBalance()
        {
            throw new NotImplementedException();
        }

        public void InsertCard(IAtmCard card)
        {
            _insertedCard = card;
        }

        public void EnterPin(string pinCode)
        {
            throw new ApplicationException("Cannot enter pin. You must enter your ATM card first");
        }

        public bool CardInserted
        {
            get { return _insertedCard != null; }
        }

        public bool Authenticated
        {
            get { throw new NotImplementedException(); }
        }

        public void EjectCard()
        {
            _insertedCard = null;
        }
    }
}
