using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utilities.Exception.Input
{
    public class InputNullException : System.Exception
    {
        public InputNullException(string message) : base(message)
        {

        }
    }
}
