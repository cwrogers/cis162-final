// Author:  Charles Rogers
// Date:    4/13/19
// Abstract: Time format exception class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class TimeFormatException : Exception {
        public TimeFormatException() : base() { }

        public TimeFormatException(String message) : base(message) { }
    }
}
