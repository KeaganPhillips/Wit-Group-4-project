using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Exceptions;
using DemoApp.Interfaces;

namespace DemoApp
{
    public class Account:IAccount
    {
        #region Private Fields
        private decimal _balance;
        #endregion

        #region Constructor(s)
        public Account()
        {
            _balance = 0;
        }
        #endregion


        public decimal Balance
        {
            get { return _balance; }
        }

        public void Debit(decimal amount)
        {
            if (_balance < amount)
                throw new InsufficientException("Cannot withdraw R" + amount + " The Account balance is R" +
                                                              _balance);

            _balance -= amount;
        }

        public void Credit(decimal amount)
        {
            _balance += amount;
        }
    }
}
