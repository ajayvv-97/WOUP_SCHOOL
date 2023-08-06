using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDCardPrintingwithRFID
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
            Application.Run(new IDCardPrintingwithRFID.Forms.dashboard());
            //Application.Run(new IDCardPrintingwithRFID.Forms.frmSplash());
            

        }
    }
}
