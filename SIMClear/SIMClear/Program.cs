using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIMClear
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public enum PurgeLevel
        {
            All = 1,
            History
        };
    }
}
