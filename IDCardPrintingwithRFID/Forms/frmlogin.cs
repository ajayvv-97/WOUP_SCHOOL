using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace IDCardPrintingwithRFID.Forms
{
    public partial class frmlogin : Form
    {
        byte[] PasswordSalt;
        byte[] PasswordHash;
        public static string Folder_path = "C:\\Program Files(x86)\\IDCard Printing";

        //public static string pDBConnStr = @"Data Source = 192.168.2.5; Initial Catalog = mPOS_DB; Persist Security Info = True; User ID = sa; Password =JM@2020";
        public static string pDBConnStr = @"Data Source = 192.168.0.5; Initial Catalog = mPOS_DB; Persist Security Info = True; User ID = sa; Password =,rhsm098";
        //public static string pDBConnStr ="Data Source = .\\SQLEXPRESS;Initial Catalog=mPOS_DB;Integrated Security=SSPI";

        SqlConnection con;
        public frmlogin()
        {
            InitializeComponent();
        }
        #region Functions
        private void GrantAccess(string fp) // GIVE FULL PERMISSION TO FOLDER
        {
            DirectoryInfo dInfo = new DirectoryInfo(fp);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }
        #endregion
        private void frmlogin_Load(object sender, EventArgs e)
        {
            frmSplash frmsplash = new frmSplash();
            frmsplash.Close();
            // txtUsername.Focus();
            this.ActiveControl = txtUsername;


            if (File.Exists(Folder_path))
            {
                //GrantAccess(Folder_path);
            }

        }
       
        public Boolean encrptPassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
            return true;
        }
        public Boolean verifyPassword(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var encryptPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < encryptPasswordHash.Length; i++)
                {
                    if (encryptPasswordHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
        public bool IsUsernameValid()
        {

            con = new SqlConnection(pDBConnStr);
            SqlCommand cmd = new SqlCommand("Select passwordSalt,passwordHash from tblUserAccount where Username = '" + txtUsername.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                PasswordSalt = (byte[])dt.Rows[0]["passwordSalt"];
                PasswordHash = (byte[])dt.Rows[0]["passwordHash"];

                return true;
            }
            else
            {
                return false;
            }


        }
        public bool IsValid()
        {
            Control[] controllist = { txtUsername, txtPAssword };
            if (IsControlNullOrDefault(this, controllist) == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsControlNullOrDefault(Form form, Control[] controllList)
        {
            foreach (var item in controllList)
            {
                if (item.GetType().Name == "TextBox")
                {
                    TextBox curTxt = (TextBox)item;
                    if (string.IsNullOrWhiteSpace(curTxt.Text))
                    {
                        MessageBox.Show(this, "\n" + curTxt.Tag.ToString() + " is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//change
                        curTxt.Focus();
                        return true;
                    }
                }
                else if (item.GetType().Name == "MetroComboBox")
                {
                    ComboBox curCmbBox = (ComboBox)item;
                    if (curCmbBox.SelectedIndex == 0)
                    {
                        MessageBox.Show(this, "\n" + "Please select " + curCmbBox.Tag.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//change
                        curCmbBox.Focus();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsPasswordvalid()
        {
            if (PasswordSalt == null || PasswordHash == null)
            {
                return false;
            }
            bool result = verifyPassword(txtPAssword.Text.Trim(), PasswordSalt, PasswordHash);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    string UsrName = ConfigurationManager.AppSettings["UserID"].ToString();
                    string Password = ConfigurationManager.AppSettings["Password"].ToString();
                    if (txtUsername.Text.Trim() == UsrName && txtPAssword.Text.Trim() == Password)
                    {
                        dashboard db = new dashboard();

                            this.Hide();
                            db.ShowDialog();
                            db.Dispose();
                            Application.Exit();


                            //this.Hide();
                            //layoutForm.ShowDialog();
                        
                    }
                    else
                    {

                        MessageBox.Show("\n invalid username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if (IsUsernameValid())
            //{
            //    if (verifyPassword(txtPAssword.Text, PasswordSalt, PasswordHash))
            //    {
            //        dashboard db = new dashboard();
            //        MessageBox.Show("User login successfully........");
            //        this.Hide();
            //        db.ShowDialog();
            //        db.Dispose();
            //    }

            //    else
            //    {
            //        MessageBox.Show("Your username and password is incorrect");


            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Your username and password is incorrect");


            //}


            //string netBiosName = System.Environment.MachineName;
            //string dnsName = System.Net.Dns.GetHostName();

            //if (txtUsername.Text == "" && txtPAssword.Text == "")
            //{

            //    MessageBox.Show("Please enter the UserName and Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUsername.Focus();
            //}
            //else if (txtUsername.Text != "" && txtPAssword.Text == "")
            //{
            //    MessageBox.Show("Please enter the Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPAssword.Focus();
            //}
            //else if (txtUsername.Text == "" && txtPAssword.Text != "")
            //{
            //    MessageBox.Show("Please enter the UserName", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUsername.Focus();
            //}
            //else
            //{

            //    string UsrName = ConfigurationManager.AppSettings["UserID"].ToString();
            //    string Password = ConfigurationManager.AppSettings["Password"].ToString();
            //    if (txtUsername.Text.Trim() == UsrName && txtPAssword.Text.Trim() == Password)
            //    {
            //        this.Hide();
            //        dashboard db = new dashboard();
            //        db.ShowDialog();
            //        db.Dispose();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid Username and Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtPAssword.Focus();
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPAssword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

       
    }
}
