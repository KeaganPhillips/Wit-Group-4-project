using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoApp.Interfaces;

namespace DemoApp
{
    public class Account:IAccount
    {
        public decimal Balance
        {
            get { throw new NotImplementedException(); }
        }

        public void Debit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Credit(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
