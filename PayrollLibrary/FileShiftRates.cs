// Author:   Charles Rogers
// Date:     5/2/19
// Abstract: Class to read/write shift rates File
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollLibrary {
    public class FileShiftRates {
        private ShiftRates data;
        private StreamReader reader;
        private StreamWriter writer;
        private string filename = @"data/shiftrates.csv";
        private bool isOpen = false;
        private bool isEOF = false;

        public bool IsEOF { get => isEOF; set => isEOF = value; }
        public bool IsOpen { get => isOpen; set => isOpen = value; }
        public ShiftRates Data { get => data; set => data = value; }


        public FileShiftRates() {
            data = new ShiftRates();
        }

        public FileShiftRates(String fileName) {
            data = new ShiftRates();
            this.filename = fileName;
        }

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
                throw new FileNotFoundException(this.filename + " was not found");
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
                    data.ShiftCode + "," +
                    data.ShiftRate
                    );
                writer.WriteLine();
                s = true;
            } catch (IOException e) {
                MessageBox.Show(e.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return s;
        }
    }
}
