using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp.Exceptions
{
    public class InsufficientException: ApplicationException
    {
        public InsufficientException(string message): base(message)
        {
            
        }
    }
}
