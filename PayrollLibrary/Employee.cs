// Author:  Charles Rogers
// Date:    3/18/19
// Abstract:Employee Object Class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class Employee : DisplayObject, Parser {

        // create employee properties

        private int employeeNumber;
        private short departmentNumber;
        private string lastName;
        private string firstName;
        private char payType;
        private float hourlyRate;
        private char taxMaritalStatus;
        private byte numExemptions;
        private float stateWithholdingPercentage;
        private float ytdGrossEarnings;
        private float ytdFedTaxes;
        private float ytdSSTaxes;
        private float ytdMedicareTaxes;
        private float ytdStateTaxes;
        private float ytdDeductions;
        private char deductionCodeOne;
        private float deductionValueOne;
        private char deductionCodeTwo;
        private float deductionValueTwo;
        private char deductionCodeThree;
        private float deductionValueThree;

        public int EmployeeNumber { get => employeeNumber; set => employeeNumber = value; }
        public short DepartmentNumber { get => departmentNumber; set => departmentNumber = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public char PayType { get => payType; set => payType = value; }
        public float HourlyRate { get => hourlyRate; set => hourlyRate = value; }
        public char TaxMaritalStatus { get => taxMaritalStatus; set => taxMaritalStatus = value; }
        public byte NumExemptions { get => numExemptions; set => numExemptions = value; }
        public float StateWithholdingPercentage { get => stateWithholdingPercentage; set => stateWithholdingPercentage = value; }
        public float YtdGrossEarnings { get => ytdGrossEarnings; set => ytdGrossEarnings = value; }
        public float YtdFedTaxes { get => ytdFedTaxes; set => ytdFedTaxes = value; }
        public float YtdSSTaxes { get => ytdSSTaxes; set => ytdSSTaxes = value; }
        public float YtdMedicareTaxes { get => ytdMedicareTaxes; set => ytdMedicareTaxes = value; }
        public float YtdStateTaxes { get => ytdStateTaxes; set => ytdStateTaxes = value; }
        public float YtdDeductions { get => ytdDeductions; set => ytdDeductions = value; }
        public char DeductionCodeOne { get => deductionCodeOne; set => deductionCodeOne = value; }
        public float DeductionValueOne { get => deductionValueOne; set => deductionValueOne = value; }
        public char DeductionCodeTwo { get => deductionCodeTwo; set => deductionCodeTwo = value; }
        public float DeductionValueTwo { get => deductionValueTwo; set => deductionValueTwo = value; }
        public char DeductionCodeThree { get => deductionCodeThree; set => deductionCodeThree = value; }
        public float DeductionValueThree { get => deductionValueThree; set => deductionValueThree = value; }

        /// <summary>
        /// display class data
        /// </summary>
        public void DisplayData() {
            Console.WriteLine(this.GetType().FullName);
            Console.WriteLine("Employee number: " + this.EmployeeNumber);
            Console.WriteLine("Last name: " + this.LastName);
            Console.WriteLine("First name: " + this.FirstName);
            Console.WriteLine("Pay type: " + this.PayType);
            Console.WriteLine("Hourly rate: " + this.HourlyRate);
            Console.WriteLine("Marital status: " + this.TaxMaritalStatus);
            Console.WriteLine("number exemptions: " + this.NumExemptions);
            Console.WriteLine("State withholding percentage: " + this.StateWithholdingPercentage);
            Console.WriteLine("y2d gross earnings: " + this.YtdGrossEarnings);
            Console.WriteLine("y2d federal taxes: " + this.YtdFedTaxes);
            Console.WriteLine("y2d social security taxes: " + this.YtdSSTaxes);
            Console.WriteLine("y2d medicare taxes: " + this.YtdMedicareTaxes);
            Console.WriteLine("y2d state taxes: " + this.YtdStateTaxes);
            Console.WriteLine("y2d deductions: " + this.YtdDeductions);
            Console.WriteLine("deduction code one: " + this.DeductionCodeOne);
            Console.WriteLine("deduction one: " + this.DeductionCodeOne);
            Console.WriteLine("deduction code two: " + this.DeductionCodeTwo);
            Console.WriteLine("deduction two: " + this.DeductionCodeTwo);
            Console.WriteLine("deduction code three: " + this.DeductionCodeThree);
            Console.WriteLine("deduction three: " + this.DeductionValueThree);


        }

        public void Parse(string str) {
            String[] s = str.Split(',');
            this.EmployeeNumber = int.Parse(s[0]);
            this.DepartmentNumber = short.Parse(s[1]);
            this.LastName = s[2];
            this.FirstName = s[3];
            this.PayType = char.Parse(s[4]);
            this.HourlyRate = float.Parse(s[5]);
            this.TaxMaritalStatus = char.Parse(s[6]);
            this.NumExemptions = Byte.Parse(s[7]);
            this.StateWithholdingPercentage = float.Parse(s[8]);
            this.YtdGrossEarnings = float.Parse(s[9]);
            this.YtdFedTaxes = float.Parse(s[10]);
            this.YtdSSTaxes = float.Parse(s[11]);
            this.YtdMedicareTaxes = float.Parse(s[12]);
            this.YtdStateTaxes = float.Parse(s[13]);
            this.YtdDeductions = float.Parse(s[14]);
            this.DeductionCodeOne = char.Parse(s[15]);
            this.DeductionValueOne = float.Parse(s[16]);
            this.DeductionCodeTwo = char.Parse(s[17]);
            this.DeductionValueTwo = float.Parse(s[18]);
            this.DeductionCodeThree = char.Parse(s[19]);
            this.DeductionValueThree = float.Parse(s[20]);
        }
    }
}
