using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command___IDE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (args.Length > 0)
                {
                    Application.Run(new mainWindow(args[0]));
                }
                else { Application.Run(new mainWindow()); }
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
    }
}
