// Author:  Charles Rogers
// Date:    3/18/19
// Abstract: PaySum object class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class PaySum : DisplayObject, Parser {

        //create properties

        private int employeeNumber;
        private float regularHours;
        private float overtimeHours;
        private float shift2Hours;
        private float shift3Hours;
        private float weekendHours;

        public int EmployeeNumber { get => employeeNumber; set => employeeNumber = value; }
        public float RegularHours { get => regularHours; set => regularHours = value; }
        public float OvertimeHours { get => overtimeHours; set => overtimeHours = value; }
        public float Shift2Hours { get => shift2Hours; set => shift2Hours = value; }
        public float Shift3Hours { get => shift3Hours; set => shift3Hours = value; }
        public float WeekendHours { get => weekendHours; set => weekendHours = value; }


        /// <summary>
        /// display class data
        /// </summary>
        public void DisplayData() {
            Console.WriteLine(this.GetType().FullName);
            Console.WriteLine("Employee number: " + EmployeeNumber);
            Console.WriteLine("Regular hours: " + RegularHours);
            Console.WriteLine("Overtime hours: " + OvertimeHours);
            Console.WriteLine("Shift 2 hours: " + Shift2Hours);
            Console.WriteLine("Shift 3 hours: " + Shift3Hours);
            Console.WriteLine("Weekend hours: " + WeekendHours);
        }

        public void Parse(string str) {
            String[] s = str.Split(',');
            this.EmployeeNumber = int.Parse(s[0]);
            this.RegularHours = float.Parse(s[1]);
            this.OvertimeHours = float.Parse(s[1]);
            this.Shift2Hours = float.Parse(s[1]);
            this.Shift3Hours = float.Parse(s[1]);
            this.WeekendHours = float.Parse(s[1]);
        }
    }
}
