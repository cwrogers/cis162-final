using PayrollLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayChecks {
    public partial class Form1 : Form {

        private List<Earnings> earningsReports = new List<Earnings>();
        private FileEarnings earningsFile = new FileEarnings();
        private int index = 0;


        public Form1() {
            InitializeComponent();
            this.LoadEarningsReports();
            foreach (Earnings e in earningsReports) {
                e.DisplayData();
            }
            PopulateData();
        }

        /// <summary>
        /// This method opens the earnings report file
        /// and loads data for each employee into an array
        /// </summary>
        private void LoadEarningsReports() {
            try {
                if (earningsFile.OpenRead()) {
                    while (!earningsFile.IsEOF) {
                        earningsFile.ReadRecord();
                        Earnings earnings = new Earnings();
                        foreach (PropertyInfo property in typeof(Earnings).GetProperties()) {
                            property.SetValue(earnings, property.GetValue(earningsFile.Data, null), null);
                        }
                        earningsReports.Add(earnings);

                    }

                }
            } catch (IOException e) {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// This method populates the screen with data from the earnings report class
        /// </summary>
        private void PopulateData() {
            //calculate working index
            int i = index % (earningsReports.Count - 1);

            //set up data for tabeles
            DataTable shiftsData = new DataTable();
            DataTable deductionsData = new DataTable();


            shiftsData.Columns.Add("Shift");
            shiftsData.Columns.Add("Hours");
            shiftsData.Columns.Add("Rate");
            shiftsData.Columns.Add("Total");

            deductionsData.Columns.Add("Deductions and Taxes");
            deductionsData.Columns.Add("Amount");


            //populate data for tables
            shiftsData.Rows.Add("Regular", earningsReports[i].RegularHours,
                String.Format("{0:C}",earningsReports[i].RegularHours == 0 ? 0 :earningsReports[i].RegularPay / earningsReports[i].RegularHours), 
                String.Format("{0:C}", earningsReports[i].RegularPay));
            shiftsData.Rows.Add("Overtime", earningsReports[i].OvertimeHours,
                String.Format("{0:C}", earningsReports[i].OvertimeHours == 0 ? 0 :earningsReports[i].OvertimePay / earningsReports[i].OvertimeHours), 
                String.Format("{0:C}", earningsReports[i].OvertimePay));
            shiftsData.Rows.Add("Shift 2", earningsReports[i].Shift2Hours,
                String.Format("{0:C}", earningsReports[i].Shift2Hours == 0 ? 0 : earningsReports[i].Shift2Pay / earningsReports[i].Shift2Hours),
                String.Format("{0:C}", earningsReports[i].Shift2Pay));
            shiftsData.Rows.Add("Shift 3", earningsReports[i].Shift2Hours,
                String.Format("{0:C}", earningsReports[i].Shift3Hours == 0 ? 0 : earningsReports[i].Shift3Pay / earningsReports[i].Shift3Hours),
                String.Format("{0:C}", earningsReports[i].Shift3Pay));
            shiftsData.Rows.Add("Weekends", earningsReports[i].WeekendHours,
                String.Format("{0:C}", earningsReports[i].WeekendHours == 0 ? 0 : earningsReports[i].WeekendPay / earningsReports[i].WeekendHours),
                String.Format("{0:C}", earningsReports[i].WeekendHours));


            deductionsData.Rows.Add("Federal withholding:", String.Format("{0:C}", earningsReports[i].FederalWithholding));
            deductionsData.Rows.Add("Social Security withholding:", String.Format("{0:C}", earningsReports[i].SsWithholding));
            deductionsData.Rows.Add("Medicare withholding:", String.Format("{0:C}", earningsReports[i].MedicareWithholding));
            deductionsData.Rows.Add("State withholding:", String.Format("{0:C}", earningsReports[i].StateWithholding));
            deductionsData.Rows.Add("Deductions:", String.Format("{0:C}", earningsReports[i].TotalVoluntaryDeductions));

            shiftsTable.DataSource = shiftsData;
            deductionsTable.DataSource = deductionsData;
            

            shiftsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            deductionsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //shiftsTable.Enabled = false;
            shiftsTable.ReadOnly = true;
            deductionsTable.ReadOnly = true;
            shiftsTable.AllowUserToAddRows = false;
            deductionsTable.AllowUserToAddRows = false;


            //Populate labels
            grossPayLabel.Text = String.Format("{0:C}", earningsReports[i].GrossPay);
            netPayLabel.Text = String.Format("{0:C}", earningsReports[i].NetPay);
            numberLabel.Text = earningsReports[i].EmployeeNumber.ToString();
            departmentLabel.Text = earningsReports[i].DepartmentNumber.ToString();
            nameLabel.Text = DisplayChecks.GetNameById(earningsReports[i].EmployeeNumber);
            checkDateLabel.Text = earningsReports[i].CheckDate;
            checkNumberLabel.Text = earningsReports[i].CheckNumber.ToString();

            this.Text = earningsReports[i].EmployeeNumber + " " + nameLabel.Text;

        }


        

        private void NextButton_Clicked(object sender, EventArgs e) {
            index++;
            PopulateData();
        }

    }
}
