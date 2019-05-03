 // Author:  Charles Rogers
// Date:    3/18/19
// Abstract:Shift Rates Object Class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class ShiftRates : DisplayObject, Parser {
        private char shiftCode;
        private float shiftRate;
        public char ShiftCode { get => shiftCode; set => shiftCode = value; }
        public float ShiftRate { get => shiftRate; set => shiftRate = value; }

        public void DisplayData() {
            Console.WriteLine(this.GetType().FullName);
            Console.WriteLine("Shift code: " + ShiftCode);
            Console.WriteLine("Shift rate: " + ShiftRate);
        }

        public void Parse(string str) {
            String[] s = str.Split(',');
            this.ShiftCode = char.Parse(s[0]);
            this.ShiftRate = float.Parse(s[1]);
        }
    }
}
