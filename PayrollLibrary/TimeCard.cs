// Author:  Charles Rogers
// Date:    3/18/19
// Abstract: TimeCard object class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class TimeCard : DisplayObject, Parser {
        //init vars
        private int employeeNumber;

        public int EmployeeNumber {
            get { return employeeNumber; }
            set {
                this.employeeNumber = value;
            }
        }


        private string[,] rawClockTimes = new string[14, 2];
        private float[,] decClockTimes = new float[14, 2];
        private float[] decElapsedTimes = new float[14];



        /*
        private string[] clockInTimes = new string[14];
        private string[] clockOutTimes = new string[14];
        private float[] decClockInTimes = new float[14];
        private float[] decClockOutTimes = new float[14];
*/


        /// <summary>
        /// Set clock in time at index
        /// </summary>
        /// <param name="time"></param>
        /// <param name="index"></param>
        public void SetClockInTimes(string time, int index) {
            if (IsValidIndex(index)) {
                this.rawClockTimes[index, 0] = time;
                this.decClockTimes[index, 0] = PRLib.ConvertAndRoundTime(time);
            } else {
                Console.WriteLine("Error: index out of bounds");
            }
        }



        /// <summary>
        /// get clock in time at specific day/index
        /// </summary>
        /// <param name="index">array indedx</param>
        /// <returns>clock in time</returns>
        public string GetClockInTimes(int index) {
            return IsValidIndex(index) ? rawClockTimes[index, 0] : "Error: index out of bounds";
        }

        /// <summary>
        /// set clock out time at index
        /// </summary>
        /// <param name="time">clock out time</param>
        /// <param name="index">clock out time</param>
        public void SetClockOutTimes(string time, int index) {
            if (IsValidIndex(index)) {
                this.rawClockTimes[index, 1] = time;
                this.decClockTimes[index, 1] = PRLib.ConvertAndRoundTime(time);
            } else {
                Console.WriteLine("Error: index out of bounds");
            }
        }

        /// <summary>
        /// get clock out time at specific day/index
        /// </summary>
        /// <param name="index">array indedx</param>
        /// <returns>clock out time</returns>
        public string GetClockOutTimes(int index) {
            return IsValidIndex(index) ? rawClockTimes[index, 1] : "Error: index out of bounds";
        }

        /// <summary>
        /// get dec elapsed times as array
        /// </summary>
        /// <returns>dec elapsed times</returns>
        public float[] GetDecElapsedTimes() {
            return decElapsedTimes;
        }

        /// <summary>
        /// get dec elapsed times at index
        /// </summary>
        /// <param name="index">array index</param>
        /// <returns>dec elapsed times</returns>
        public float GetDecElapsedTimes(int index) {
            return decElapsedTimes[index];
        }

        /// <summary>
        /// get dec clock in time at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float GetDecClockInTimes(int index) {
            return decClockTimes[index, 0];
        }


        /// <summary>
        /// get dec clock out time at index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>clock out time</returns>
        public float GetDecClockOutTimes(int index) {
            return decClockTimes[index, 1];
        }

        //worker methods

        /// <summary>
        /// checks to be sure that indexes are between 0-13
        /// </summary>
        /// <param name="index">index to be checked</param>
        /// <returns>whether a given index is valid or not</returns>
        private Boolean IsValidIndex(int index) {
            return (index >= 0 && index < 14);
        }



        /// <summary>
        /// calculate elapsed time between two dec time values
        /// </summary>
        /// <param name="timeOne">clock in time</param>
        /// <param name="timeTwo">clock out time</param>
        /// <returns>elapsed amount of time</returns>
        private float CalculateElapsedTime(float timeOne, float timeTwo) {
            //if overnight
            if (timeOne > timeTwo) {
                timeTwo += 24;
            }
            //subtract and return
            return timeTwo - timeOne;
        }

        /// <summary>
        /// calculates elapsed times for whole clock-in/out array.
        /// </summary>
        public void CalculateElapsedTimes() {
            for (int i = 0; i < rawClockTimes.GetLength(0); i++) {
                if (!string.IsNullOrEmpty(rawClockTimes[i,0]) ||
                    !string.IsNullOrEmpty(rawClockTimes[i,1])) {
                    decClockTimes[i,0] = PRLib.ConvertAndRoundTime(GetClockInTimes(i));
                    decClockTimes[i,1] = PRLib.ConvertAndRoundTime(GetClockOutTimes(i));
                    decElapsedTimes[i] = CalculateElapsedTime(decClockTimes[i,0], decClockTimes[i,1]);
                }
            }
            
        }



        /// <summary>
        /// display class data
        /// </summary>
        public void DisplayData() {
            Console.WriteLine(this.GetType().FullName);
            Console.WriteLine("Employee number: {0}", this.EmployeeNumber);
            Console.WriteLine("Raw clock times:      [{0}]", string.Join(", ", this.rawClockTimes.Cast<string>()));
            Console.WriteLine("Dec Clock times: [{0}])", string.Join(", ", this.decClockTimes.Cast<float>()));
            Console.WriteLine("Elapsed times:       [{0}]", string.Join(", ", this.GetDecElapsedTimes()));
        }

        public void Parse(string str) {
            string[] s = str.Split(',');
            this.EmployeeNumber = int.Parse(s[0]);
            for (int i = 1; i < s.Length; i++) {
                int index = (int)(Math.Ceiling((double)i / 2) - 1);
                if (i % 2 == 1) {
                    rawClockTimes[index, 0] = s[i];
                } else {
                    rawClockTimes[index, 1] = s[i];
                }
            }
            CalculateElapsedTimes();
        }
    }
}
