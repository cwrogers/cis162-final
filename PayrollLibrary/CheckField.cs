// Author:  Charles Rogers
// Date:    4/13/19
// Abstract: Class to check if times are valid 24hr format.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class CheckField {
        /// <summary>
        /// Checks if time is valid
        /// </summary>
        /// <param name="time">time</param>
        /// <returns>time string validity</returns>
        public static void IsValidTime(String time) {
            if(!new Regex(@"^(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$").Match(time).Success)
                throw new TimeFormatException("Invalid time string");
        }
    }
}
