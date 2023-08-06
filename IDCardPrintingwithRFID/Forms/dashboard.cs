//using IDCardPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDCardPrintingwithRFID.Forms
{
    public partial class dashboard : MetroFramework.Forms.MetroForm
    {
        public static string Empolyee = "";
        public static string Loyalty = "";
        public dashboard()
        {
            InitializeComponent();
        }

        private void BtnLoyaltyCard_Click(object sender, EventArgs e)
        { 
            Loyalty = "Loyalty";
            Empolyee = "";
            this.Hide();
            frmExcelUpload fex = new frmExcelUpload();
            fex.ShowDialog();
            fex.Dispose();
        }

        private void BtnEmployeeCard_Click(object sender, EventArgs e)
        {
            Empolyee = "Employee";
            Loyalty = "";
            this.Hide();
            frmExcelUpload fex = new frmExcelUpload();
            fex.ShowDialog();
            fex.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
