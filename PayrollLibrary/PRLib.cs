// Author:  Charles Rogers
// Date:    3/18/19
// Abstract:Library with methods for calculating payroll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary {
    public class PRLib {

        /// <summary>
        /// convert and rount time strings to dec
        /// </summary>
        /// <param name="str">time string</param>
        /// <returns>time dec</returns>
        public static float ConvertAndRoundTime(String str) {
            //split string into hrs and minutes.
            String[] splitStr = str.Split(':');
            float hrs = float.Parse(splitStr[0]);
            float mm = float.Parse(splitStr[1]);

            if (mm <= 7) {
                mm = 0f;
            } else if (mm <= 22) {
                mm = 0.25f;
            } else if (mm <= 37) {
                mm = 0.5f;
            } else if (mm <= 52) {
                mm = 0.75f;
            } else {
                mm = 1f;
            }
            return hrs + mm;
        }

        /// <summary>
        /// calculate elapsed time between two dec time values
        /// </summary>
        /// <param name="timeOne">clock in time</param>
        /// <param name="timeTwo">clock out time</param>
        /// <returns>elapsed amount of time</returns>
        private static float CalculateElapsedTime(float timeOne, float timeTwo) {
            //if overnight
            if (timeOne > timeTwo) {
                timeTwo += 24;
            }
            //subtract and return
            return timeTwo - timeOne;
        }

        /// <summary>
        /// returns calculated pay
        /// </summary>
        /// <param name="hours">hours worked</param>
        /// <param name="rate">pay rate</param>
        /// <returns></returns>
        public static float CalculatePay(float hours, float rate) {
            return rate * hours;
        }

        /// <summary>
        /// returns calculated pay with multiplier
        /// </summary>
        /// <param name="hours">hours worked</param>
        /// <param name="hours">hours worked</param>
        /// <param name="rate">pay rate</param>
        /// <param name="multiplier">multiplier</param>
        /// <returns></returns>
        public static float CalculatePay(float hours, float rate, float multiplier) {
            return rate * hours * multiplier;
        }

        /// <summary>
        /// returns calculated gross pay
        /// </summary>
        /// <param name="regularPay">regular pay</param>
        /// <param name="overtimePay">overtime pay</param>
        /// <param name="shift2Pay">shift 2 pay</param>
        /// <param name="shift3Pay">shift 3 pay</param>
        /// <param name="weekendPay">weekend pay</param>
        /// <returns>gross pay</returns>
        public static float CalculateGrossPay(float regularPay, float overtimePay, float shift2Pay, float shift3Pay, float weekendPay) {
            return regularPay + overtimePay + shift2Pay + shift3Pay + weekendPay;
        }


        /// <summary>
        /// returns calculated social security tax
        /// </summary>
        /// <param name="grossPay">gross pay</param>
        /// <param name="y2dEarnings">year to date earnings</param>
        /// <param name="y2dSocialSecurityWithheld">year to date social security whthheld</param>
        /// <returns></returns>
        public static float CalculateSocialSecurityTax(float grossPay, float y2dEarnings, float y2dSocialSecurityWithheld) {
            float ssBaseLimit = 132900f;
            float taxRate = 0.062f;
            float ssTax;
            if (y2dEarnings > ssBaseLimit) {
                ssTax = 0;
            } else if (y2dEarnings + grossPay < ssBaseLimit) {
                ssTax = grossPay * taxRate;
            } else {
                ssTax = (ssBaseLimit - y2dEarnings) * taxRate;
            }
            return ssTax;
        }

        /// <summary>
        /// returns calculated medicare tax
        /// </summary>
        /// <param name="grossPay">gross pay</param>
        /// <returns>medicare tax</returns>
        public static float CalculateMedicareTax(float grossPay) {
            return grossPay * 0.0145f;
        }

        /// <summary>
        /// returns calculated state tax
        /// </summary>
        /// <param name="grossPay">gross pay</param>
        /// <param name="stateWithholdingPercentage">state withholding percentage</param>
        /// <returns>state tax</returns>
        public static float CalculateStateTax(float grossPay, float stateWithholdingPercentage) {
            return grossPay * stateWithholdingPercentage;
        }

        /// <summary>
        /// returns calculated deduction
        /// </summary>
        /// <param name="grossPay">gross pay</param>
        /// <param name="deductionCode">deduciton code</param>
        /// <param name="deductionValue">deduction value</param>
        /// <returns></returns>
        public static float CalculateDeduction(float grossPay, char deductionCode, float deductionValue) {
            float deduction;

            switch (deductionCode) {
                case 'N':
                    deduction = 0;
                    break;
                case 'F':
                    deduction = deductionValue;
                    break;
                case 'P':
                    deduction = grossPay * deductionValue;
                    break;
                default:
                    deduction = 0;
                    break;
            }

            return deduction > grossPay ? grossPay : deduction;
        }

        /// <summary>
        /// return calculated weekly hours worked
        /// </summary>
        /// <param name="weeklyHours">weekly hours array</param>
        /// <returns>total of weekly hours worked</returns>
        public static float CalculateWeeklyHoursWorked(float[] weeklyHours) {
            float sum = 0;
            foreach (float hours in weeklyHours)
                sum += hours;
            return sum;
        }

        /// <summary>
        /// returns regular hours worked
        /// </summary>
        /// <param name="hours">hours worked</param>
        /// <returns>regular horus worked</returns>
        public static float CalculateRegularHours(float hours) {
            return hours > 40 ? 40 : hours;
        }

        /// <summary>
        /// returns overtime hours worked
        /// </summary>
        /// <param name="hours">hours</param>
        /// <returns>overtime hours</returns>
        public static float CalculateOvertimeHours(float hours) {
            return hours <= 40 ? 0 : hours - 40;
        }

        /// <summary>
        /// returns calculated weekend hours
        /// </summary>
        /// <param name="clockIn">clock in time</param>
        /// <param name="clockOut">clock out time</param>
        /// <param name="day">clock in day</param>
        /// <returns></returns>
        public static float CalculateWeekendHours(float clockIn, float clockOut, char day) {
            switch (day) {
                case '5':
                    //Friday
                    if (clockOut < clockIn)
                        return clockOut;
                    else
                        return 0;
                case '6':
                    //Saturday
                    if (clockOut < clockIn)
                        return (clockOut + 24) - clockIn;
                    else
                        return clockOut - clockIn;
                case '7':
                    if (clockOut < clockIn)
                        return 24 - clockIn;
                    else
                        return clockOut - clockIn;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// returns calculated federal withholding tax
        /// </summary>
        /// <param name="grossPay">gross pay</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="numExemptions">number of exemptions</param>
        /// <returns>federal withholding tax</returns>
        public static float CalculateFederalWithholdingTax(float grossPay, char maritalStatus, int numExemptions) {
            float taxableEarnings = grossPay - (numExemptions * 161.5f);
            float tax;
            if (maritalStatus == 'm') {
                if (taxableEarnings > 454 && taxableEarnings <= 1200) {
                    tax = (taxableEarnings - 454) * .1f;
                } else if (taxableEarnings > 1200 && taxableEarnings <= 3490) {
                    tax = (taxableEarnings - 1200) * .12f;
                    tax += 74.6f;
                } else if (taxableEarnings > 3490 && taxableEarnings <= 6931) {
                    tax = (taxableEarnings - 3490) * .22f;
                    tax += 349.6f;
                } else if (taxableEarnings > 6931 && taxableEarnings <= 12817) {
                    tax = (taxableEarnings - 6931) * .24f;
                    tax += 1106.42f;
                } else if (taxableEarnings > 12817 && taxableEarnings <= 16154) {
                    tax = (taxableEarnings - 12817) * .32f;
                    tax += 2519.06f;
                } else if (taxableEarnings > 16154 && taxableEarnings <= 24006) {
                    tax = (taxableEarnings - 16154) * .35f;
                    tax += 3586.9f;
                } else if (taxableEarnings > 24006) {
                    tax = (taxableEarnings - 24006) * .37f;
                    tax += 6335.1f;
                } else {
                    tax = 0;
                }
            } else {
                if (taxableEarnings > 146 && taxableEarnings <= 519) {
                    tax = (taxableEarnings - 146) * .1f;
                } else if (taxableEarnings > 519 && taxableEarnings <= 1664) {
                    tax = (taxableEarnings - 519) * .12f;
                    tax += 37.3f;
                } else if (taxableEarnings > 1664 && taxableEarnings <= 3385) {
                    tax = (taxableEarnings - 1664) * .22f;
                    tax += 174.7f;
                } else if (taxableEarnings > 3385 && taxableEarnings <= 6328) {
                    tax = (taxableEarnings - 3385) * .24f;
                    tax += 553.32f;
                } else if (taxableEarnings > 6328 && taxableEarnings <= 7996) {
                    tax = (taxableEarnings - 6328) * .33f;
                    tax += 1259.64f;
                } else if (taxableEarnings > 7996 && taxableEarnings <= 19773) {
                    tax = (taxableEarnings - 7996) * .35f;
                    tax += 1793.4f;
                } else if (taxableEarnings > 19773) {
                    tax = (taxableEarnings - 19773) * .37f;
                    tax += 5915.35f;
                } else {
                    tax = 0;
                }
            }
            return tax;
        }


        //public static float CalculateWeeklyShiftHours(float[] weekHours)

        public static float CalculateShift(float startTime, float endTime,
    float clockIn, float clockOut) {
            //  Declare variables.
            float shiftHours;
            bool overnightClock = false;
            bool overnightShift = false;


            //  If the shift endTime is less than the shift startTime, 
            //  add 24 hours to the shift endTime.
            if (endTime < startTime) {
                endTime += 24.00f;
                overnightShift = true;
            }

            //  If the clockOut time is greater than the clockIn time, 
            //  add 24 hours to the clockOut time.
            if (clockOut < clockIn) {
                clockOut += 24.00f;
                overnightClock = true;
            }


            //  If not overnight shift, but overnight clock, 
            //  subtract 24.0 hours from both the clock in and clock out.
            if (!overnightShift) {
                if (overnightClock) {
                    clockIn -= 24.0f;
                    clockOut -= 24.0f;
                }
            }

            //  If the clockIn time is before the shift startTime, 
            //  set the clockIn time to the startTime.
            if (clockIn < startTime) {
                clockIn = startTime;
            }

            //  If the clockOut time exceeds the shift endTime, 
            //  set the clockOut time to the endTime.
            if (clockOut > endTime) {
                clockOut = endTime;
            }

            //  ShiftHours is the difference between clockOut and clockIn.
            shiftHours = clockOut - clockIn;

            //  if the shiftHours are negative, set shiftHours to zero.
            if (shiftHours < 0) {
                shiftHours = 0;
            }

            //  Return the shiftHours.
            return shiftHours;
        }





        /// <summary>
        /// returns calculated net pay
        /// </summary>
        /// <param name="grossPay">gross pay</param>
        /// <param name="fedWithholding">federal withholding</param>
        /// <param name="ssWithholding">social security withholding</param>
        /// <param name="medicareWithholding">medicare withholding</param>
        /// <param name="deductionOneAmount">deductionAmount</param>
        /// <param name="deductionTwoAmount">deductionTwoAmount</param>
        /// <param name="deductionThreeAmount">deductionThreeAmount</param>
        /// <returns>net pay</returns>
        public static float CalculateNetPay(float grossPay, float fedWithholding, float ssWithholding, float medicareWithholding,
                                        float deductionOneAmount, float deductionTwoAmount, float deductionThreeAmount) {

            return grossPay - (fedWithholding + ssWithholding + medicareWithholding + deductionOneAmount + deductionTwoAmount + deductionThreeAmount);

        }

    }
}
