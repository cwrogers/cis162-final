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

        private void PopulateData() {
            DataTable shiftsData = new DataTable();
            shiftsData.Columns.Add("Shift");
            shiftsData.Columns.Add("Hours");
            shiftsData.Columns.Add("Rate");
            shiftsData.Columns.Add("Total");

            int i = index % (earningsReports.Count - 1);

            shiftsData.Rows.Add("Regular", earningsReports[i].RegularHours,
                earningsReports[i].RegularHours == 0 ? 0 :earningsReports[i].RegularPay / earningsReports[i].RegularHours, 
                earningsReports[i].RegularPay);
            shiftsData.Rows.Add("Overtime", earningsReports[i].OvertimeHours,
                earningsReports[i].OvertimeHours == 0 ? 0 :earningsReports[i].OvertimePay / earningsReports[i].OvertimeHours, 
                earningsReports[i].OvertimePay);
            shiftsData.Rows.Add("Shift 2", earningsReports[i].Shift2Hours,
                earningsReports[i].Shift2Hours == 0 ? 0 : earningsReports[i].Shift2Pay / earningsReports[i].Shift2Hours,
                earningsReports[i].Shift2Pay);
            shiftsData.Rows.Add("Shift 3", earningsReports[i].Shift2Hours,
                earningsReports[i].Shift3Hours == 0 ? 0 : earningsReports[i].Shift3Pay / earningsReports[i].Shift3Hours,
                earningsReports[i].Shift3Pay);
            shiftsData.Rows.Add("Weekends", earningsReports[i].WeekendHours,
                earningsReports[i].WeekendHours == 0 ? 0 : earningsReports[i].WeekendPay / earningsReports[i].WeekendHours,
                earningsReports[i].WeekendHours);

            shiftsTable.DataSource = shiftsData;

            shiftsTable.Enabled = false;



            grossPayLabel.Text = earningsReports[i].GrossPay.ToString();
            netPayLabel.Text = earningsReports[i].EmployeeNumber.ToString();

        }


        public Form1() {
            InitializeComponent();
            this.LoadEarningsReports();
            foreach (Earnings e in earningsReports) {
                e.DisplayData();
            }
            PopulateData();
            Console.WriteLine("Done");
        }

        private void Button1_Click(object sender, EventArgs e) {
            index++;
            PopulateData();
        }
    }
}
