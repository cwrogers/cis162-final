using PayrollLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS162AD_Final_Project {
    class ProcessPayroll {
        //  Declare class level variables.
        static private FileEmployee employeeFile = new FileEmployee();
        static private FilePaySum paysumFile = new FilePaySum();
        static private FileEarnings earningsFile = new FileEarnings();
        static private FileShiftRates shiftRatesFile = new FileShiftRates();

        static private ShiftRates[] shiftRates = new ShiftRates[3];

        //  Main method.
        public static void Main(string[] args) {
            //  Sets the text color of the console window.
            Console.ForegroundColor = ConsoleColor.Yellow;

            //  Do Startup method.
            Startup();

            //  While there are records to process, execute Processing.
            while (!employeeFile.IsEOF || !paysumFile.IsEOF) {
                Processing();
            }

            //  Do Finish method.
            Shutdown();
            Console.ReadKey();
        }

        //  Processing method.
        static void Processing() {
            //  If Primary file is at end of file, process the remaining Secondary records.
            if (employeeFile.IsEOF) {
                Console.WriteLine("No matching Primary record");
                ProcessUnmatchedSecondary();
                return;
            }

            //  if Secondary file is at end of file, process the remaining Primary records.
            if (paysumFile.IsEOF) {
                Console.WriteLine("No matching Secondary record");
                ProcessUnmatchedPrimary();
                return;
            }

            //  If the employee numbers match, then process the two records.
            if (employeeFile.Data.EmployeeNumber == paysumFile.Data.EmployeeNumber) {
                Console.WriteLine("Match");
                ProcessMatch();
            } else {
                //  If the employee number in the Primary file is LT the
                //  employee number in the Secondary file, then there are
                //  no corresponding Secondary records.
                if (employeeFile.Data.EmployeeNumber < paysumFile.Data.EmployeeNumber) {
                    Console.WriteLine("No matching Secondary record");
                    ProcessUnmatchedPrimary();
                } else {
                    //  There are no corresponding Primary records. 
                    Console.WriteLine("No matching Primary record");
                    ProcessUnmatchedSecondary();
                }
            }
        }

        //  Startup method.
        static void Startup() {
            //  Open the files.
            try {
                employeeFile.OpenRead();
                paysumFile.OpenRead();
                shiftRatesFile.OpenRead();
                earningsFile.OpenOutput();
            } catch (FileNotFoundException e) {
                    MessageBox.Show(e.Message, "File system error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  IF the files opened, read the first record.
            if (employeeFile.IsOpen && paysumFile.IsOpen && earningsFile.IsOpen) {
                //  Read a record from each file.
                employeeFile.ReadRecord();
                paysumFile.ReadRecord();

                for (int i = 0; i < shiftRates.Length; i++) {
                    if (!shiftRatesFile.IsEOF) {
                        shiftRatesFile.ReadRecord();
                        shiftRates[i] = new ShiftRates();
                        shiftRates[i].ShiftCode = shiftRatesFile.Data.ShiftCode;
                        shiftRates[i].ShiftRate = shiftRatesFile.Data.ShiftRate;
                        shiftRates[i].DisplayData();
                        }
                }

            } else {
                //  Files did not open.  Quit the program.
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        //  Finish method.
        static void Shutdown() {
            //  Close files.
            employeeFile.Close();
            paysumFile.Close();
            shiftRatesFile.Close();
            earningsFile.Close();
        }

        //  ProcessMatch method.
        static void ProcessMatch() {
            //  This is where you put the steps when both are equal.

            //paysumFile.Data.DisplayData();

            Earnings earn = new Earnings();
            earn.DepartmentNumber = employeeFile.Data.DepartmentNumber;
            earn.EmployeeNumber = employeeFile.Data.EmployeeNumber;
            earn.RegularHours = paysumFile.Data.RegularHours;
            earn.OvertimeHours = paysumFile.Data.OvertimeHours;
            earn.Shift2Hours = paysumFile.Data.Shift2Hours;
            earn.Shift3Hours = paysumFile.Data.Shift3Hours;
            earn.WeekendHours = paysumFile.Data.WeekendHours;
            earn.RegularPay = PRLib.CalculatePay(earn.RegularHours, employeeFile.Data.HourlyRate);
            earn.OvertimePay = PRLib.CalculatePay(earn.OvertimeHours, employeeFile.Data.HourlyRate, 1.5f);
            earn.Shift2Pay = GetShiftRate('2') * earn.Shift2Hours;
            earn.Shift3Pay = GetShiftRate('3') * earn.Shift3Hours;
            earn.WeekendPay = GetShiftRate('W') * earn.WeekendHours;
            earn.GrossPay = PRLib.CalculateGrossPay(earn.RegularPay, earn.OvertimePay, earn.Shift2Pay, earn.Shift3Pay, earn.WeekendPay);
            earn.FederalWithholding = PRLib.CalculateFederalWithholdingTax(earn.GrossPay, employeeFile.Data.TaxMaritalStatus, employeeFile.Data.NumExemptions);
            earn.SsWithholding = PRLib.CalculateSocialSecurityTax(earn.GrossPay, employeeFile.Data.YtdGrossEarnings, employeeFile.Data.YtdSSTaxes);
            earn.MedicareWithholding = PRLib.CalculateMedicareTax(earn.GrossPay);
            earn.StateWithholding = PRLib.CalculateStateTax(earn.GrossPay, employeeFile.Data.StateWithholdingPercentage);

            float deductionOne = PRLib.CalculateDeduction(earn.GrossPay, employeeFile.Data.DeductionCodeOne, employeeFile.Data.DeductionValueOne);
            float deductionTwo = 0;
            float deductionThree = 0;


            if (earn.GrossPay - deductionOne > 0) {
                deductionTwo = PRLib.CalculateDeduction(earn.GrossPay, employeeFile.Data.DeductionCodeTwo, employeeFile.Data.DeductionValueTwo);
                if (earn.GrossPay - (deductionOne + deductionTwo) >= 0) {
                    deductionThree = PRLib.CalculateDeduction(earn.GrossPay, employeeFile.Data.DeductionCodeThree, employeeFile.Data.DeductionValueThree);
                    if (earn.GrossPay - (deductionOne + deductionTwo + deductionThree) < 0)
                        deductionThree = 0;
                } else {
                    deductionTwo = 0;
                }
            } else {
                deductionOne = 0;
            }

            earn.TotalVoluntaryDeductions = deductionOne + deductionTwo + deductionThree;
            earn.NetPay = PRLib.CalculateNetPay(earn.GrossPay, earn.FederalWithholding, earn.SsWithholding, earn.MedicareWithholding, deductionOne, deductionTwo, deductionThree);

            earn.DisplayData();
            Console.WriteLine("\n\n\n\n\n");

            employeeFile.ReadRecord();
            paysumFile.ReadRecord();
        }

        private static float GetShiftRate(char code) {
            float rate = 0;
            for (int i = 0; i < shiftRates.Length; i++) {
                if (shiftRates[i].ShiftCode == code) {
                    rate = shiftRates[i].ShiftRate;
                    break;
                }
            }
            return rate;
        }

        //  ProcessUnmatchedPrimary method.
        static void ProcessUnmatchedPrimary() {
            //  This is where you put your processing steps for the Primary file record.
            Console.WriteLine(employeeFile.Data.EmployeeNumber.ToString() + " unmatched employee");

            //  Read from the Primary file.
            employeeFile.ReadRecord();
        }

        //  ProcessUnmatchedSecondary method.
        static void ProcessUnmatchedSecondary() {
            //  This where you put your processing steps for the Secondary file record.
            Console.WriteLine(paysumFile.Data.EmployeeNumber.ToString() + " unmatched paysum file");

            //  Read from the Secondary file.
            paysumFile.ReadRecord();
        }
    }
}
