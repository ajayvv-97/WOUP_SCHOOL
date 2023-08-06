namespace IDCardPrintingwithRFID.Forms
{
    partial class FrmRegistration
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
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Register = new System.Windows.Forms.Button();
            this.txt_Pincode = new System.Windows.Forms.TextBox();
            this.lbl_Pincode = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txt_PhoneNo = new System.Windows.Forms.TextBox();
            this.lbl_PhoneNo = new System.Windows.Forms.Label();
            this.txt_CName = new System.Windows.Forms.TextBox();
            this.lbl_CName = new System.Windows.Forms.Label();
            this.errorProvider_CName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_PhoneNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_Email = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_Pincode = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_CName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_PhoneNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Pincode)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.DarkMagenta;
            this.btn_Reset.Enabled = false;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.ForeColor = System.Drawing.Color.White;
            this.btn_Reset.Location = new System.Drawing.Point(282, 243);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(90, 31);
            this.btn_Reset.TabIndex = 6;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // btn_Register
            // 
            this.btn_Register.BackColor = System.Drawing.Color.Teal;
            this.btn_Register.Enabled = false;
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Register.ForeColor = System.Drawing.Color.White;
            this.btn_Register.Location = new System.Drawing.Point(184, 243);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(90, 31);
            this.btn_Register.TabIndex = 5;
            this.btn_Register.Text = "Get OTP";
            this.btn_Register.UseVisualStyleBackColor = false;
            this.btn_Register.Click += new System.EventHandler(this.Btn_Register_Click);
            // 
            // txt_Pincode
            // 
            this.txt_Pincode.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txt_Pincode.Location = new System.Drawing.Point(184, 192);
            this.txt_Pincode.MaxLength = 6;
            this.txt_Pincode.Name = "txt_Pincode";
            this.txt_Pincode.Size = new System.Drawing.Size(275, 25);
            this.txt_Pincode.TabIndex = 4;
            this.txt_Pincode.TextChanged += new System.EventHandler(this.txt_Pincode_TextChanged);
            this.txt_Pincode.Leave += new System.EventHandler(this.txt_Pincode_Leave);
            // 
            // lbl_Pincode
            // 
            this.lbl_Pincode.AutoSize = true;
            this.lbl_Pincode.Font = new System.Drawing.Font("Candara", 11.25F);
            this.lbl_Pincode.Location = new System.Drawing.Point(42, 192);
            this.lbl_Pincode.Name = "lbl_Pincode";
            this.lbl_Pincode.Size = new System.Drawing.Size(58, 18);
            this.lbl_Pincode.TabIndex = 50;
            this.lbl_Pincode.Text = "Pincode";
            // 
            // txt_Email
            // 
            this.txt_Email.Font = new System.Drawing.Font("Candara", 11.25F);
            this.txt_Email.Location = new System.Drawing.Point(184, 159);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(275, 26);
            this.txt_Email.TabIndex = 3;
            this.txt_Email.TextChanged += new System.EventHandler(this.txt_Email_TextChanged);
            this.txt_Email.Leave += new System.EventHandler(this.txt_Email_Leave);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Candara", 11.25F);
            this.lbl_Email.Location = new System.Drawing.Point(42, 159);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(41, 18);
            this.lbl_Email.TabIndex = 48;
            this.lbl_Email.Text = "Email";
            // 
            // txt_PhoneNo
            // 
            this.txt_PhoneNo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PhoneNo.Location = new System.Drawing.Point(184, 121);
            this.txt_PhoneNo.MaxLength = 10;
            this.txt_PhoneNo.Name = "txt_PhoneNo";
            this.txt_PhoneNo.Size = new System.Drawing.Size(275, 25);
            this.txt_PhoneNo.TabIndex = 2;
            this.txt_PhoneNo.TextChanged += new System.EventHandler(this.txt_PhoneNo_TextChanged);
            this.txt_PhoneNo.Leave += new System.EventHandler(this.txt_PhoneNo_Leave);
            // 
            // lbl_PhoneNo
            // 
            this.lbl_PhoneNo.AutoSize = true;
            this.lbl_PhoneNo.Font = new System.Drawing.Font("Candara", 11.25F);
            this.lbl_PhoneNo.Location = new System.Drawing.Point(42, 121);
            this.lbl_PhoneNo.Name = "lbl_PhoneNo";
            this.lbl_PhoneNo.Size = new System.Drawing.Size(73, 18);
            this.lbl_PhoneNo.TabIndex = 46;
            this.lbl_PhoneNo.Text = "Phone No.";
            // 
            // txt_CName
            // 
            this.txt_CName.Font = new System.Drawing.Font("Candara", 11.25F);
            this.txt_CName.Location = new System.Drawing.Point(184, 83);
            this.txt_CName.Name = "txt_CName";
            this.txt_CName.Size = new System.Drawing.Size(275, 26);
            this.txt_CName.TabIndex = 1;
            this.txt_CName.TextChanged += new System.EventHandler(this.txt_CName_TextChanged);
            // 
            // lbl_CName
            // 
            this.lbl_CName.AutoSize = true;
            this.lbl_CName.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CName.Location = new System.Drawing.Point(42, 86);
            this.lbl_CName.Name = "lbl_CName";
            this.lbl_CName.Size = new System.Drawing.Size(45, 18);
            this.lbl_CName.TabIndex = 44;
            this.lbl_CName.Text = "Name";
            // 
            // errorProvider_CName
            // 
            this.errorProvider_CName.ContainerControl = this;
            // 
            // errorProvider_PhoneNo
            // 
            this.errorProvider_PhoneNo.ContainerControl = this;
            // 
            // errorProvider_Email
            // 
            this.errorProvider_Email.ContainerControl = this;
            // 
            // errorProvider_Pincode
            // 
            this.errorProvider_Pincode.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(40, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 54;
            this.label1.Text = "Registration";
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 296);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.txt_Pincode);
            this.Controls.Add(this.lbl_Pincode);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.txt_PhoneNo);
            this.Controls.Add(this.lbl_PhoneNo);
            this.Controls.Add(this.txt_CName);
            this.Controls.Add(this.lbl_CName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistration";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_CName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_PhoneNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Pincode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.TextBox txt_Pincode;
        private System.Windows.Forms.Label lbl_Pincode;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txt_PhoneNo;
        private System.Windows.Forms.Label lbl_PhoneNo;
        private System.Windows.Forms.TextBox txt_CName;
        private System.Windows.Forms.Label lbl_CName;
        private System.Windows.Forms.ErrorProvider errorProvider_CName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider_PhoneNo;
        private System.Windows.Forms.ErrorProvider errorProvider_Email;
        private System.Windows.Forms.ErrorProvider errorProvider_Pincode;
    }
}