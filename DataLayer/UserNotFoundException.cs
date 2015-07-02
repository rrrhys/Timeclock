using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class UserNotFoundException : Exception
    {
        private string p;

        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
