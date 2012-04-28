using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp
{
    public class AtmCard: IAtmCard
    {
        public string SecretPin
        {
            get { throw new NotImplementedException(); }
        }
    }
}
