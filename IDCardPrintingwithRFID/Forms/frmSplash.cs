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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            tmrsplash.Interval = 1000;
            tmrsplash.Tick += new EventHandler(tmrsplash_Tick);
            tmrsplash.Start();

            
        }

        private void tmrsplash_Tick(object sender, EventArgs e)
        {
            tmrsplash.Stop();
            Forms.frmlogin frmLogin = new frmlogin();
            this.Hide();
          
            
            
            frmLogin.ShowDialog();
            


         

        }
    }
}
