﻿// Author:  Charles Rogers
// Date:    4/17/19
// Abstract: Class to read/write PaySum File

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollLibrary {
    public class FilePaySum {

        //  vars and properties
        private PaySum data;
        private StreamReader reader;
        private StreamWriter writer;
        private string filename = @"data/paysum.csv";
        private bool isOpen = false;
        private bool isEOF = false;

        public FilePaySum() {
            data = new PaySum();
        }

        public FilePaySum(String fileName) {
            data = new PaySum();
            this.filename = fileName;
        }

        public bool IsOpen { get => isOpen; set => isOpen = value; }
        public bool IsEOF { get => isEOF; set => isEOF = value; }
        public PaySum Data { get => data; set => data = value; }

        /// <summary>
        /// Opens the file for reading
        /// </summary>
        /// <returns>operation success</returns>
        public bool OpenRead() {
            bool s = false;

            if (File.Exists(filename)) {
                try {
                    reader = new StreamReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read));
                    IsOpen = true;
                    s = true;
                } catch (IOException e) {
                    MessageBox.Show(e.Message, "File system error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsOpen = false;
                }
            } else {
                throw new FileNotFoundException(this.filename + " was not found");
            }

            return s;
        }

        /// <summary>
        /// Opens file for writing
        /// </summary>
        /// <returns>operation success</returns>
        public bool OpenAppend() {
            bool s = false;

            if (File.Exists(filename)) {
                try {
                    writer = new StreamWriter(filename, true);
                    IsOpen = true;
                    s = true;
                } catch (IOException e) {
                    MessageBox.Show(e.Message, "File system error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsOpen = false;
                }
            } else {
                throw new FileNotFoundException(this.filename + " was not found");
            }

            return s;
        }

        /// <summary>
        /// Opens file for writing
        /// </summary>
        /// <returns>operation success</returns>
        public bool OpenOutput() {
            bool s = false;

            if (File.Exists(filename)) {
                try {
                    writer = new StreamWriter(filename, false);
                    IsOpen = true;
                    s = true;
                } catch (IOException e) {
                    MessageBox.Show(e.Message, "File system error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsOpen = false;
                }
            } else {
                throw new FileNotFoundException(this.filename + " was not found.");
            }

            return s;
        }

        /// <summary>
        /// Closes the file
        /// </summary>
        /// <returns>operation success</returns>
        public bool Close() {
            bool s = false;
            try {
                if (reader != null)
                    reader.Close();
                if (writer != null)
                    writer.Close();
                s = true;
                IsOpen = false;
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return s;
        }


        public bool ReadRecord() {
            bool s = false;

            String line = reader.ReadLine();

            if (String.IsNullOrEmpty(line)) {
                IsEOF = true;
            } else {
                Data = new PaySum();
                Data.Parse(line);
                s = true;
            }

            return s;
        }

        /// <summary>
        /// writes to file
        /// </summary>
        /// <returns>operation success</returns>
        public bool WriteRecord() {
            bool s = false;

            try {
                writer.Write(
                    Data.EmployeeNumber + ", " +
                    Data.RegularHours + ", " +
                    Data.OvertimeHours + ", " +
                    Data.Shift2Hours + ", " +
                    Data.Shift3Hours + ", " +
                    Data.WeekendHours
                );
                writer.WriteLine();
                s = true;
            } catch (IOException e) {
                MessageBox.Show(e.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch {

                MessageBox.Show("An error has occured", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return s;
        }



    }
}
