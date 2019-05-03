// Author:  Charles Rogers
// Date:    5/2/19
// Abstract: Entry point of final project program,
// This program will read and match employee files to their time sheets


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PayrollLibrary;

namespace CIS162AD_Final_Project {
    class ProcessTimeCards {

        //  Declare class level variables.
        private static FileEmployee employeeFile = new FileEmployee();
        private static FileTimeCard timecardFile = new FileTimeCard();
        private static FilePaySum paySumFile = new FilePaySum();

        static void Main(string[] args) {
            
            //  Do Startup method.
            Startup();

            //  While there are records to process, execute Processing.
            while (!employeeFile.IsEOF || !timecardFile.IsEOF) {
                Processing();
            }

            //  Do Finish method.
            Shutdown();

            Console.WriteLine(PRLib.CalculateShift(16.0f, 0.0f, 22.75f, 6f));

            Console.ReadKey();
        }

        //  Processing method.
        static void Processing() {
            Console.ForegroundColor = ConsoleColor.Red;

            //  If Primary file is at end of file, process the remaining Secondary records.
            if (employeeFile.IsEOF) {
                Console.WriteLine("No matching Primary record");
                ProcessUnmatchedSecondary();
                return;
            }

            //  if Secondary file is at end of file, process the remaining Primary records.
            if (timecardFile.IsEOF) {
                Console.WriteLine("No matching Secondary record");
                ProcessUnmatchedPrimary();
                return;
            }

            //  If the employee numbers match, then process the two records.
            if (employeeFile.Data.EmployeeNumber == timecardFile.Data.EmployeeNumber) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Match " + employeeFile.Data.EmployeeNumber);
                ProcessMatch();
            } else {
                //  If the employee number in the Primary file is LT the
                //  employee number in the Secondary file, then there are
                //  no corresponding Secondary records.
                if (employeeFile.Data.EmployeeNumber < timecardFile.Data.EmployeeNumber) {
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
                timecardFile.OpenRead();
                paySumFile.OpenOutput();
            } catch (FileNotFoundException e) {
                MessageBox.Show(e.Message, "File system error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  IF the files opened, read the first record.
            if (employeeFile.IsOpen && timecardFile.IsOpen) {
                //  Read a record from each file.
                employeeFile.ReadRecord();
                timecardFile.ReadRecord();
            } else {
                //  Files did not open.  Quit the program.
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        //  Finish method.
        static void Shutdown() {
            //  Close files.
            employeeFile.Close();
            timecardFile.Close();
            paySumFile.Close();
        }

        //  ProcessMatch method.
        static void ProcessMatch() {

            PaySum p = new PaySum();
            p.EmployeeNumber = employeeFile.Data.EmployeeNumber;
            if (!employeeFile.Data.PayType.Equals('S')) {
                float[] wkOne = new float[7];
                float[] wkTwo = new float[7];
                Array.Copy(timecardFile.Data.GetDecElapsedTimes(),0, wkOne, 0, 7);
                Array.Copy(timecardFile.Data.GetDecElapsedTimes(),7, wkTwo, 0, 7);

                float wkOneTotalHours = PRLib.CalculateWeeklyHoursWorked(wkOne);
                float wkTwoTotalHours = PRLib.CalculateWeeklyHoursWorked(wkTwo);
                float totalWeekendHours = 0;
                float shiftTwoHours = 0;
                float shiftThreeHours = 0;

                for (int i = 0; i < 14; i++) {
                    totalWeekendHours += PRLib.CalculateWeekendHours(
                        timecardFile.Data.GetDecClockInTimes(i), timecardFile.Data.GetDecClockOutTimes(i), ((i % 7) + 1).ToString()[0]);
                    shiftTwoHours += PRLib.CalculateShift(16.0f, 0.0f,
                        timecardFile.Data.GetDecClockInTimes(i), timecardFile.Data.GetDecClockOutTimes(i));

                    shiftThreeHours += PRLib.CalculateShift(0.0f, 8.0f,
                        timecardFile.Data.GetDecClockInTimes(i), timecardFile.Data.GetDecClockOutTimes(i));
                }

                p.WeekendHours = totalWeekendHours;
                p.RegularHours = PRLib.CalculateRegularHours(wkOneTotalHours) + PRLib.CalculateRegularHours(wkTwoTotalHours);
                p.OvertimeHours = PRLib.CalculateOvertimeHours(wkOneTotalHours) + PRLib.CalculateOvertimeHours(wkTwoTotalHours);
                p.Shift2Hours = shiftTwoHours;
                p.Shift3Hours = shiftThreeHours;
                paySumFile.Data = p;
                paySumFile.WriteRecord();


                timecardFile.Data.DisplayData();
                p.DisplayData();
                //p.RegularHours = PRLib.CalculateRegularHours();
                //timecardFile.Data.DisplayData();
            } else {
                p.RegularHours = 80;
                p.WeekendHours = 0;
                p.Shift2Hours = 0;
                p.Shift3Hours = 0;
                p.OvertimeHours = 0;
                paySumFile.Data = p;
                paySumFile.WriteRecord();
            }

            employeeFile.ReadRecord();
            timecardFile.ReadRecord();
        }

        //  ProcessUnmatchedPrimary method.
        static void ProcessUnmatchedPrimary() {
            //  This is where you put your processing steps for the Primary file record.
            //Console.WriteLine(employeeFile.Data.EmployeeNumber.ToString());
            Console.WriteLine(employeeFile.Data.EmployeeNumber);
            if (employeeFile.Data.PayType.Equals('S')) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee is Salary");
                PaySum p = new PaySum();
                p.EmployeeNumber = employeeFile.Data.EmployeeNumber;
                p.RegularHours = 80;
                p.WeekendHours = 0;
                p.Shift2Hours = 0;
                p.Shift3Hours = 0;
                p.OvertimeHours = 0;
                paySumFile.Data = p;
                paySumFile.WriteRecord();

            } else {
                Console.WriteLine("\n\n\nNo timecard found for employee: ");
                employeeFile.Data.DisplayData();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            //  Read from the Primary file.
            employeeFile.ReadRecord();
        }

        //  ProcessUnmatchedSecondary method.
        static void ProcessUnmatchedSecondary() {
            //  This where you put your processing steps for the Secondary file record.
            Console.WriteLine(timecardFile.Data.EmployeeNumber.ToString() + " " + timecardFile.Data);

            MessageBox.Show("No employee data matching timecard with employee id: " + timecardFile.Data.EmployeeNumber.ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            //  Read from the Secondary file.
            timecardFile.ReadRecord();
        }
    }
}
