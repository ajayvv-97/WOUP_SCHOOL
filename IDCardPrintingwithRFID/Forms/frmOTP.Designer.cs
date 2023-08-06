namespace IDCardPrintingwithRFID.Forms
{
    partial class frmOTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_CName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_PhoneNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ResendOTP = new System.Windows.Forms.Button();
            this.btn_ValidateOTP = new System.Windows.Forms.Button();
            this.txt_OTP = new System.Windows.Forms.TextBox();
            this.errorProvider_otp = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_otp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_CName
            // 
            this.lbl_CName.AutoSize = true;
            this.lbl_CName.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CName.Location = new System.Drawing.Point(42, 18);
            this.lbl_CName.Name = "lbl_CName";
            this.lbl_CName.Size = new System.Drawing.Size(74, 26);
            this.lbl_CName.TabIndex = 0;
            this.lbl_CName.Text = "Name :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_PhoneNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_ResendOTP);
            this.panel1.Controls.Add(this.btn_ValidateOTP);
            this.panel1.Controls.Add(this.txt_OTP);
            this.panel1.Controls.Add(this.lbl_CName);
            this.panel1.Location = new System.Drawing.Point(53, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 242);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Please enter the OTP No. to Activate your Account.";
            // 
            // lbl_PhoneNo
            // 
            this.lbl_PhoneNo.AutoSize = true;
            this.lbl_PhoneNo.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PhoneNo.Location = new System.Drawing.Point(179, 51);
            this.lbl_PhoneNo.Name = "lbl_PhoneNo";
            this.lbl_PhoneNo.Size = new System.Drawing.Size(0, 23);
            this.lbl_PhoneNo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "OTP no. is Send to";
            // 
            // btn_ResendOTP
            // 
            this.btn_ResendOTP.BackColor = System.Drawing.Color.DarkMagenta;
            this.btn_ResendOTP.CausesValidation = false;
            this.btn_ResendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResendOTP.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResendOTP.ForeColor = System.Drawing.Color.White;
            this.btn_ResendOTP.Location = new System.Drawing.Point(161, 178);
            this.btn_ResendOTP.Name = "btn_ResendOTP";
            this.btn_ResendOTP.Size = new System.Drawing.Size(97, 34);
            this.btn_ResendOTP.TabIndex = 2;
            this.btn_ResendOTP.Text = "Resend OTP";
            this.btn_ResendOTP.UseVisualStyleBackColor = false;
            this.btn_ResendOTP.Click += new System.EventHandler(this.Btn_ResendOTP_Click);
            // 
            // btn_ValidateOTP
            // 
            this.btn_ValidateOTP.BackColor = System.Drawing.Color.Teal;
            this.btn_ValidateOTP.Enabled = false;
            this.btn_ValidateOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ValidateOTP.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ValidateOTP.ForeColor = System.Drawing.Color.White;
            this.btn_ValidateOTP.Location = new System.Drawing.Point(47, 178);
            this.btn_ValidateOTP.Name = "btn_ValidateOTP";
            this.btn_ValidateOTP.Size = new System.Drawing.Size(108, 34);
            this.btn_ValidateOTP.TabIndex = 1;
            this.btn_ValidateOTP.Text = "Validate OTP";
            this.btn_ValidateOTP.UseVisualStyleBackColor = false;
            this.btn_ValidateOTP.Click += new System.EventHandler(this.Btn_ValidateOTP_Click);
            // 
            // txt_OTP
            // 
            this.txt_OTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_OTP.Location = new System.Drawing.Point(47, 116);
            this.txt_OTP.MaxLength = 6;
            this.txt_OTP.Name = "txt_OTP";
            this.txt_OTP.Size = new System.Drawing.Size(211, 44);
            this.txt_OTP.TabIndex = 0;
            this.txt_OTP.TextChanged += new System.EventHandler(this.Txt_OTP_TextChanged);
            this.txt_OTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_OTP_KeyPress);
            this.txt_OTP.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_OTP_Validating);
            // 
            // errorProvider_otp
            // 
            this.errorProvider_otp.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "Verification";
            // 
            // frmOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOTP";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOTP_FormClosing);
            this.Load += new System.EventHandler(this.FrmOTP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_otp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_PhoneNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ResendOTP;
        private System.Windows.Forms.Button btn_ValidateOTP;
        private System.Windows.Forms.TextBox txt_OTP;
        private System.Windows.Forms.ErrorProvider errorProvider_otp;
        private System.Windows.Forms.Label label1;
    }
}