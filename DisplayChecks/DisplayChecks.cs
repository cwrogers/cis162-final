using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayChecks {
    public static class DisplayChecks {
        private static List<Tuple<int, string>> idNames = new List<Tuple<int, string>>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void AddIDName(int id, string name) {
            idNames.Add(new Tuple<int, string>(id, name));
        }

        public static string GetNameById(int id) {
            string name = "Unknown";
            foreach (Tuple<int, string> t in idNames) {
                if (t.Item1 == id)
                    name = t.Item2;
            }
            return name;

        }
    }
}
