// Author:  Charles Rogers
// Date:    3/18/19
// Abstract: Earnings object class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class Earnings : DisplayObject, Parser {

        private short departmentNumber;
        private int employeeNumber;
        private float regularHours;
        private float overtimeHours;
        private float shift2Hours;
        private float shift3Hours;
        private float weekendHours;
        private float regularPay;
        private float overtimePay;
        private float shift2Pay;
        private float shift3Pay;
        private float weekendPay;
        private float grossPay;
        private float federalWithholding;
        private float ssWithholding;
        private float medicareWithholding;
        private float stateWithholding;
        private float totalVoluntaryDeductions;
        private float netPay;
        private string checkDate;
        private int checkNumber;

        public short DepartmentNumber { get => departmentNumber; set => departmentNumber = value; }
        public int EmployeeNumber { get => employeeNumber; set => employeeNumber = value; }
        public float RegularHours { get => regularHours; set => regularHours = value; }
        public float OvertimeHours { get => overtimeHours; set => overtimeHours = value; }
        public float Shift2Hours { get => shift2Hours; set => shift2Hours = value; }
        public float Shift3Hours { get => shift3Hours; set => shift3Hours = value; }
        public float WeekendHours { get => weekendHours; set => weekendHours = value; }
        public float RegularPay { get => regularPay; set => regularPay = value; }
        public float OvertimePay { get => overtimePay; set => overtimePay = value; }
        public float Shift2Pay { get => shift2Pay; set => shift2Pay = value; }
        public float Shift3Pay { get => shift3Pay; set => shift3Pay = value; }
        public float WeekendPay { get => weekendPay; set => weekendPay = value; }
        public float GrossPay { get => grossPay; set => grossPay = value; }
        public float FederalWithholding { get => federalWithholding; set => federalWithholding = value; }
        public float SsWithholding { get => ssWithholding; set => ssWithholding = value; }
        public float MedicareWithholding { get => medicareWithholding; set => medicareWithholding = value; }
        public float StateWithholding { get => stateWithholding; set => stateWithholding = value; }
        public float TotalVoluntaryDeductions { get => totalVoluntaryDeductions; set => totalVoluntaryDeductions = value; }
        public float NetPay { get => netPay; set => netPay = value; }
        public string CheckDate { get => checkDate; set => checkDate = value; }
        public int CheckNumber { get => checkNumber; set => checkNumber = value; }

        /// <summary>
        /// display class data
        /// </summary>
        public void DisplayData() {
            Console.WriteLine(this.GetType().FullName);
            Console.WriteLine("Department Number: {0}", this.DepartmentNumber);
            Console.WriteLine("Employee Number: {0}", this.EmployeeNumber);
            Console.WriteLine("Regular Hours: {0}", this.RegularHours);
            Console.WriteLine("Overtime Hours: {0}", this.OvertimeHours);
            Console.WriteLine("Shift 2 hours: {0}", this.Shift2Hours);
            Console.WriteLine("Shift 3 hours: {0}", this.Shift3Hours);
            Console.WriteLine("Weekend hours: {0}", this.WeekendHours);
            Console.WriteLine("Regular Pay: {0}", this.RegularPay);
            Console.WriteLine("Overtime Pay: {0}", this.OvertimePay);
            Console.WriteLine("Shift 2 Pay: {0}", this.Shift2Pay);
            Console.WriteLine("Shift 3 Pay: {0}", this.Shift3Pay);
            Console.WriteLine("Weekend Pay: {0}", this.WeekendPay);
            Console.WriteLine("Gross Pay: {0}", this.GrossPay);
            Console.WriteLine("Federal Withholding: {0}", this.FederalWithholding);
            Console.WriteLine("Social Security Withholding: {0}", this.SsWithholding);
            Console.WriteLine("Medicare Withholding: {0}", this.MedicareWithholding);
            Console.WriteLine("State Withholding: {0}", this.StateWithholding);
            Console.WriteLine("Total Voluntary Deductions: {0}", this.TotalVoluntaryDeductions);
            Console.WriteLine("Net Pay: {0}", this.NetPay);
            Console.WriteLine("Check Date: {0}", this.CheckDate);
            Console.WriteLine("Check Number: {0}", this.CheckNumber);
        }

        public void Parse(string str) {
            String[] s = str.Split(',');
            this.DepartmentNumber = short.Parse(s[0]);
            this.EmployeeNumber = int.Parse(s[1]);
            this.RegularHours = float.Parse(s[2]);
            this.OvertimeHours = float.Parse(s[3]);
            this.Shift2Hours = float.Parse(s[4]);
            this.Shift3Hours = float.Parse(s[5]);
            this.WeekendHours = float.Parse(s[6]);
            this.RegularPay = float.Parse(s[7]);
            this.OvertimePay = float.Parse(s[8]);
            this.Shift2Pay = float.Parse(s[9]);
            this.Shift3Pay = float.Parse(s[10]);
            this.WeekendPay = float.Parse(s[11]);
            this.GrossPay = float.Parse(s[12]);
            this.FederalWithholding = float.Parse(s[13]);
            this.SsWithholding = float.Parse(s[14]);
            this.MedicareWithholding = float.Parse(s[15]);
            this.StateWithholding = float.Parse(s[16]);
            this.TotalVoluntaryDeductions = float.Parse(s[17]);
            this.NetPay = float.Parse(s[18]);
            this.CheckDate = s[19];
            this.CheckNumber = int.Parse(s[20]);
        }
    }
}
