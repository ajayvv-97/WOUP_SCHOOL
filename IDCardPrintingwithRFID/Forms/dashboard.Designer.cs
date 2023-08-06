namespace IDCardPrintingwithRFID.Forms
{
    partial class dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoyaltyCard = new System.Windows.Forms.Button();
            this.btnEmployeeCard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(2, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 70);
            this.panel1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dashboard";
            // 
            // btnLoyaltyCard
            // 
            this.btnLoyaltyCard.BackColor = System.Drawing.Color.White;
            this.btnLoyaltyCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoyaltyCard.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnLoyaltyCard.FlatAppearance.BorderSize = 2;
            this.btnLoyaltyCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoyaltyCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLoyaltyCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLoyaltyCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoyaltyCard.Location = new System.Drawing.Point(2, 128);
            this.btnLoyaltyCard.Name = "btnLoyaltyCard";
            this.btnLoyaltyCard.Size = new System.Drawing.Size(357, 125);
            this.btnLoyaltyCard.TabIndex = 0;
            this.btnLoyaltyCard.Text = "STAFF CARDS";
            this.btnLoyaltyCard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnLoyaltyCard.UseVisualStyleBackColor = false;
            this.btnLoyaltyCard.Click += new System.EventHandler(this.BtnLoyaltyCard_Click);
            // 
            // btnEmployeeCard
            // 
            this.btnEmployeeCard.BackColor = System.Drawing.Color.White;
            this.btnEmployeeCard.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnEmployeeCard.FlatAppearance.BorderSize = 2;
            this.btnEmployeeCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEmployeeCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmployeeCard.Location = new System.Drawing.Point(2, 287);
            this.btnEmployeeCard.Name = "btnEmployeeCard";
            this.btnEmployeeCard.Size = new System.Drawing.Size(357, 125);
            this.btnEmployeeCard.TabIndex = 1;
            this.btnEmployeeCard.Text = "STUDENT CARDS";
            this.btnEmployeeCard.UseVisualStyleBackColor = false;
            this.btnEmployeeCard.Click += new System.EventHandler(this.BtnEmployeeCard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IDCardPrintingwithRFID.Properties.Resources.together22;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(365, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(378, 284);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(747, 457);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoyaltyCard);
            this.Controls.Add(this.btnEmployeeCard);
            this.Name = "dashboard";
            this.Resizable = false;
            //this.Load += new System.EventHandler(this.dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoyaltyCard;
        private System.Windows.Forms.Button btnEmployeeCard;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}