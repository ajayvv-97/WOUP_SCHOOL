namespace IDCardPrintingwithRFID.Forms
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.mlblAyj = new MetroFramework.Controls.MetroLabel();
            this.pbcmlog = new System.Windows.Forms.PictureBox();
            this.tmrsplash = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbcmlog)).BeginInit();
            this.SuspendLayout();
            // 
            // mlblAyj
            // 
            this.mlblAyj.AccessibleDescription = " ";
            this.mlblAyj.AutoSize = true;
            this.mlblAyj.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlblAyj.Location = new System.Drawing.Point(0, 428);
            this.mlblAyj.Name = "mlblAyj";
            this.mlblAyj.Size = new System.Drawing.Size(247, 19);
            this.mlblAyj.TabIndex = 93;
            this.mlblAyj.Text = "Anikayaj Software Solutions Pvt.Ltd";
            // 
            // pbcmlog
            // 
            this.pbcmlog.Image = ((System.Drawing.Image)(resources.GetObject("pbcmlog.Image")));
            this.pbcmlog.Location = new System.Drawing.Point(3, 367);
            this.pbcmlog.Name = "pbcmlog";
            this.pbcmlog.Size = new System.Drawing.Size(94, 60);
            this.pbcmlog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcmlog.TabIndex = 94;
            this.pbcmlog.TabStop = false;
            // 
            // tmrsplash
            // 
            this.tmrsplash.Tick += new System.EventHandler(this.tmrsplash_Tick);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.pbcmlog);
            this.Controls.Add(this.mlblAyj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbcmlog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel mlblAyj;
        private System.Windows.Forms.PictureBox pbcmlog;
        private System.Windows.Forms.Timer tmrsplash;
    }
}