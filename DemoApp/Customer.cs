using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp
{
    public class Customer : ICustomer
    {
        public string MySecretPin
        {
            get { throw new NotImplementedException(); }
        }
    }
}
