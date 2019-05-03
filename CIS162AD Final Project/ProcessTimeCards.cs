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

        //  Main method.
        static void Main(string[] args) {
            
            //  Do Startup method.
            Startup();

            //  While there are records to process, execute Processing.
            while (!employeeFile.IsEOF || !timecardFile.IsEOF) {
                Processing();
            }

            //  Do Finish method.
            Shutdown();
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
        }

        //  ProcessMatch method.
        static void ProcessMatch() {
            //  This is where you put the steps when both are equal.
            //Console.WriteLine("Match!");
            //Console.WriteLine(employeeFile.Data.EmployeeNumber.ToString() + " " + employeeFile.Data.otherData);
            //Console.WriteLine(timecardFile.Data.EmployeeNumber.ToString() + " " + timecardFile.Data);
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
                //generate paysum file
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
