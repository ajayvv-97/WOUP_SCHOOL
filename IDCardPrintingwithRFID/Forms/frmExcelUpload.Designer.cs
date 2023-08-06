namespace IDCardPrintingwithRFID.Forms
{
    partial class frmExcelUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcelUpload));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.btn_BrwsImg = new System.Windows.Forms.Button();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox_Portrait = new System.Windows.Forms.GroupBox();
            this.picBox_CardF = new System.Windows.Forms.PictureBox();
            this.groupBox_Ls = new System.Windows.Forms.GroupBox();
            this.picBox_Ls_CardB = new System.Windows.Forms.PictureBox();
            this.picBox_Ls_CardF = new System.Windows.Forms.PictureBox();
            this.chk_Portrait = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ChooseExcel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btn_PrintCard = new System.Windows.Forms.Button();
            this.txt_ImgPath = new System.Windows.Forms.TextBox();
            this.btnListData = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btnBackHome = new System.Windows.Forms.Button();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnHome = new System.Windows.Forms.Button();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.CmbCardType = new MetroFramework.Controls.MetroComboBox();
            this.txt_CardData1 = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.Grddetails = new System.Windows.Forms.DataGridView();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnPnlClose = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCname = new System.Windows.Forms.Label();
            this.btnSaveRFID = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.txtReadCardData = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.picBox_CardB = new System.Windows.Forms.PictureBox();
            this.groupBox_Portrait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_CardF)).BeginInit();
            this.groupBox_Ls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Ls_CardB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Ls_CardF)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grddetails)).BeginInit();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_CardB)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.BtnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBrowse.BackgroundImage")));
            this.BtnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBrowse.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnBrowse.FlatAppearance.BorderSize = 0;
            this.BtnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBrowse.Location = new System.Drawing.Point(784, 10);
            this.BtnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(55, 39);
            this.BtnBrowse.TabIndex = 11;
            this.toolTip1.SetToolTip(this.BtnBrowse, "Browse Excel File...");
            this.BtnBrowse.UseVisualStyleBackColor = false;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btn_BrwsImg
            // 
            this.btn_BrwsImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BrwsImg.BackgroundImage")));
            this.btn_BrwsImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BrwsImg.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_BrwsImg.FlatAppearance.BorderSize = 0;
            this.btn_BrwsImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BrwsImg.Location = new System.Drawing.Point(787, 55);
            this.btn_BrwsImg.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BrwsImg.Name = "btn_BrwsImg";
            this.btn_BrwsImg.Size = new System.Drawing.Size(55, 39);
            this.btn_BrwsImg.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btn_BrwsImg, "Browse Excel File...");
            this.btn_BrwsImg.UseVisualStyleBackColor = true;
            this.btn_BrwsImg.Click += new System.EventHandler(this.Btn_BrwsImg_Click);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.BackColor = System.Drawing.Color.Black;
            this.BtnGenerate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGenerate.BackgroundImage")));
            this.BtnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGenerate.FlatAppearance.BorderSize = 0;
            this.BtnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGenerate.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.BtnGenerate.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnGenerate.Location = new System.Drawing.Point(872, 10);
            this.BtnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(121, 39);
            this.BtnGenerate.TabIndex = 15;
            this.toolTip1.SetToolTip(this.BtnGenerate, "Generate Card");
            this.BtnGenerate.UseVisualStyleBackColor = false;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackgroundImage = global::IDCardPrintingwithRFID.Properties.Resources.open_file_icon;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(1191, 10);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(55, 39);
            this.btnOpen.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnOpen, "Open Folder");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // groupBox_Portrait
            // 
            this.groupBox_Portrait.Controls.Add(this.picBox_CardB);
            this.groupBox_Portrait.Controls.Add(this.picBox_CardF);
            this.groupBox_Portrait.Location = new System.Drawing.Point(1291, 48);
            this.groupBox_Portrait.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Portrait.Name = "groupBox_Portrait";
            this.groupBox_Portrait.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Portrait.Size = new System.Drawing.Size(288, 727);
            this.groupBox_Portrait.TabIndex = 22;
            this.groupBox_Portrait.TabStop = false;
            this.groupBox_Portrait.Visible = false;
            // 
            // picBox_CardF
            // 
            this.picBox_CardF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBox_CardF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_CardF.Image = global::IDCardPrintingwithRFID.Properties.Resources.CardF;
            this.picBox_CardF.Location = new System.Drawing.Point(11, 22);
            this.picBox_CardF.Margin = new System.Windows.Forms.Padding(4);
            this.picBox_CardF.Name = "picBox_CardF";
            this.picBox_CardF.Size = new System.Drawing.Size(266, 344);
            this.picBox_CardF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_CardF.TabIndex = 0;
            this.picBox_CardF.TabStop = false;
            // 
            // groupBox_Ls
            // 
            this.groupBox_Ls.Controls.Add(this.picBox_Ls_CardB);
            this.groupBox_Ls.Controls.Add(this.picBox_Ls_CardF);
            this.groupBox_Ls.Location = new System.Drawing.Point(1291, 49);
            this.groupBox_Ls.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Ls.Name = "groupBox_Ls";
            this.groupBox_Ls.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Ls.Size = new System.Drawing.Size(288, 763);
            this.groupBox_Ls.TabIndex = 24;
            this.groupBox_Ls.TabStop = false;
            this.groupBox_Ls.Visible = false;
            // 
            // picBox_Ls_CardB
            // 
            this.picBox_Ls_CardB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Ls_CardB.Image = global::IDCardPrintingwithRFID.Properties.Resources.StaffB1;
            this.picBox_Ls_CardB.Location = new System.Drawing.Point(11, 372);
            this.picBox_Ls_CardB.Margin = new System.Windows.Forms.Padding(4);
            this.picBox_Ls_CardB.Name = "picBox_Ls_CardB";
            this.picBox_Ls_CardB.Size = new System.Drawing.Size(266, 344);
            this.picBox_Ls_CardB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Ls_CardB.TabIndex = 0;
            this.picBox_Ls_CardB.TabStop = false;
            // 
            // picBox_Ls_CardF
            // 
            this.picBox_Ls_CardF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_Ls_CardF.Image = global::IDCardPrintingwithRFID.Properties.Resources.StaffF1;
            this.picBox_Ls_CardF.Location = new System.Drawing.Point(11, 23);
            this.picBox_Ls_CardF.Margin = new System.Windows.Forms.Padding(4);
            this.picBox_Ls_CardF.Name = "picBox_Ls_CardF";
            this.picBox_Ls_CardF.Size = new System.Drawing.Size(266, 344);
            this.picBox_Ls_CardF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Ls_CardF.TabIndex = 0;
            this.picBox_Ls_CardF.TabStop = false;
            // 
            // chk_Portrait
            // 
            this.chk_Portrait.AutoSize = true;
            this.chk_Portrait.Checked = true;
            this.chk_Portrait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Portrait.Enabled = false;
            this.chk_Portrait.Font = new System.Drawing.Font("Candara", 13.25F, System.Drawing.FontStyle.Bold);
            this.chk_Portrait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(224)))));
            this.chk_Portrait.Location = new System.Drawing.Point(7, 10);
            this.chk_Portrait.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Portrait.Name = "chk_Portrait";
            this.chk_Portrait.Size = new System.Drawing.Size(166, 32);
            this.chk_Portrait.TabIndex = 20;
            this.chk_Portrait.Text = "Card Printing";
            this.chk_Portrait.UseVisualStyleBackColor = true;
            this.chk_Portrait.CheckedChanged += new System.EventHandler(this.Chk_Portrait_CheckedChanged);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.panel1);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.btnHome);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.CmbCardType);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(7, 42);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1266, 112);
            this.metroPanel1.TabIndex = 21;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_ChooseExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.btn_PrintCard);
            this.panel1.Controls.Add(this.txt_ImgPath);
            this.panel1.Controls.Add(this.btnListData);
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.BtnBrowse);
            this.panel1.Controls.Add(this.btn_BrwsImg);
            this.panel1.Controls.Add(this.btnBackHome);
            this.panel1.Controls.Add(this.BtnGenerate);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 111);
            this.panel1.TabIndex = 37;
            // 
            // lbl_ChooseExcel
            // 
            this.lbl_ChooseExcel.AutoSize = true;
            this.lbl_ChooseExcel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChooseExcel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChooseExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_ChooseExcel.Location = new System.Drawing.Point(45, 10);
            this.lbl_ChooseExcel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ChooseExcel.Name = "lbl_ChooseExcel";
            this.lbl_ChooseExcel.Size = new System.Drawing.Size(166, 23);
            this.lbl_ChooseExcel.TabIndex = 28;
            this.lbl_ChooseExcel.Text = "Choose Excel File :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "Choose Image Folder :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(1275, 96);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 17);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Card Type";
            this.metroLabel1.Visible = false;
            // 
            // btn_PrintCard
            // 
            this.btn_PrintCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(95)))), ((int)(((byte)(224)))));
            this.btn_PrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PrintCard.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btn_PrintCard.ForeColor = System.Drawing.Color.White;
            this.btn_PrintCard.Location = new System.Drawing.Point(872, 55);
            this.btn_PrintCard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PrintCard.Name = "btn_PrintCard";
            this.btn_PrintCard.Size = new System.Drawing.Size(121, 39);
            this.btn_PrintCard.TabIndex = 16;
            this.btn_PrintCard.Text = "Print Card";
            this.btn_PrintCard.UseVisualStyleBackColor = false;
            this.btn_PrintCard.Click += new System.EventHandler(this.Btn_PrintCard_Click);
            // 
            // txt_ImgPath
            // 
            this.txt_ImgPath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_ImgPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ImgPath.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_ImgPath.Location = new System.Drawing.Point(225, 55);
            this.txt_ImgPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ImgPath.Name = "txt_ImgPath";
            this.txt_ImgPath.ReadOnly = true;
            this.txt_ImgPath.Size = new System.Drawing.Size(550, 27);
            this.txt_ImgPath.TabIndex = 26;
            // 
            // btnListData
            // 
            this.btnListData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnListData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListData.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btnListData.ForeColor = System.Drawing.Color.White;
            this.btnListData.Location = new System.Drawing.Point(1191, 63);
            this.btnListData.Margin = new System.Windows.Forms.Padding(4);
            this.btnListData.Name = "btnListData";
            this.btnListData.Size = new System.Drawing.Size(60, 39);
            this.btnListData.TabIndex = 30;
            this.btnListData.Text = "List";
            this.btnListData.UseVisualStyleBackColor = false;
            this.btnListData.Visible = false;
            this.btnListData.Click += new System.EventHandler(this.BtnListData_Click);
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFile.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFile.Location = new System.Drawing.Point(225, 10);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(550, 27);
            this.txtFile.TabIndex = 3;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.Snow;
            this.btn_Refresh.BackgroundImage = global::IDCardPrintingwithRFID.Properties.Resources.Refresh_2;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(1035, 55);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(135, 39);
            this.btn_Refresh.TabIndex = 27;
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // btnBackHome
            // 
            this.btnBackHome.BackgroundImage = global::IDCardPrintingwithRFID.Properties.Resources.Home_icon;
            this.btnBackHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackHome.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnBackHome.FlatAppearance.BorderSize = 0;
            this.btnBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackHome.Location = new System.Drawing.Point(1063, 10);
            this.btnBackHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(55, 39);
            this.btnBackHome.TabIndex = 22;
            this.btnBackHome.UseVisualStyleBackColor = true;
            this.btnBackHome.Click += new System.EventHandler(this.BtnBackHome_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(11, 69);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(0, 0);
            this.metroLabel5.TabIndex = 25;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(1183, 55);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(61, 47);
            this.btnHome.TabIndex = 21;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(848, 57);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(0, 0);
            this.metroLabel4.TabIndex = 14;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(11, 23);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(0, 0);
            this.metroLabel2.TabIndex = 1;
            // 
            // CmbCardType
            // 
            this.CmbCardType.FormattingEnabled = true;
            this.CmbCardType.ItemHeight = 23;
            this.CmbCardType.Items.AddRange(new object[] {
            "Select",
            "Provisional",
            "Associate"});
            this.CmbCardType.Location = new System.Drawing.Point(1229, 69);
            this.CmbCardType.Margin = new System.Windows.Forms.Padding(4);
            this.CmbCardType.Name = "CmbCardType";
            this.CmbCardType.Size = new System.Drawing.Size(12, 29);
            this.CmbCardType.TabIndex = 10;
            this.CmbCardType.UseSelectable = true;
            this.CmbCardType.Visible = false;
            // 
            // txt_CardData1
            // 
            this.txt_CardData1.Location = new System.Drawing.Point(220, 15);
            this.txt_CardData1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CardData1.Name = "txt_CardData1";
            this.txt_CardData1.Size = new System.Drawing.Size(185, 22);
            this.txt_CardData1.TabIndex = 26;
            this.txt_CardData1.TabStop = false;
            this.txt_CardData1.Visible = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.ForeColor = System.Drawing.Color.Black;
            this.metroLabel3.Location = new System.Drawing.Point(547, 20);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(98, 17);
            this.metroLabel3.TabIndex = 23;
            this.metroLabel3.Text = "Open Location";
            this.metroLabel3.Visible = false;
            // 
            // Grddetails
            // 
            this.Grddetails.AllowUserToAddRows = false;
            this.Grddetails.AllowUserToDeleteRows = false;
            this.Grddetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grddetails.BackgroundColor = System.Drawing.Color.White;
            this.Grddetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grddetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grddetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grddetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grddetails.Location = new System.Drawing.Point(7, 158);
            this.Grddetails.Margin = new System.Windows.Forms.Padding(4);
            this.Grddetails.Name = "Grddetails";
            this.Grddetails.RowHeadersVisible = false;
            this.Grddetails.RowHeadersWidth = 51;
            this.Grddetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grddetails.Size = new System.Drawing.Size(1267, 580);
            this.Grddetails.TabIndex = 31;
            this.Grddetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grddetails_CellValueChanged);
            this.Grddetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Grddetails_MouseDoubleClick);
            // 
            // pnlList
            // 
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Controls.Add(this.btnPnlClose);
            this.pnlList.Controls.Add(this.listView1);
            this.pnlList.Controls.Add(this.label3);
            this.pnlList.Controls.Add(this.lblCname);
            this.pnlList.Controls.Add(this.btnSaveRFID);
            this.pnlList.Controls.Add(this.btnReadCard);
            this.pnlList.Controls.Add(this.txtReadCardData);
            this.pnlList.Controls.Add(this.txtSearch);
            this.pnlList.Location = new System.Drawing.Point(7, 160);
            this.pnlList.Margin = new System.Windows.Forms.Padding(4);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(166, 109);
            this.pnlList.TabIndex = 32;
            this.pnlList.TabStop = true;
            this.pnlList.Visible = false;
            // 
            // btnPnlClose
            // 
            this.btnPnlClose.BackColor = System.Drawing.Color.Red;
            this.btnPnlClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPnlClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPnlClose.ForeColor = System.Drawing.Color.White;
            this.btnPnlClose.Location = new System.Drawing.Point(1220, -1);
            this.btnPnlClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnPnlClose.Name = "btnPnlClose";
            this.btnPnlClose.Size = new System.Drawing.Size(37, 38);
            this.btnPnlClose.TabIndex = 36;
            this.btnPnlClose.Text = "x";
            this.btnPnlClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPnlClose.UseVisualStyleBackColor = false;
            this.btnPnlClose.Click += new System.EventHandler(this.BtnPnlClose_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightGray;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(37, 107);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1189, 468);
            this.listView1.TabIndex = 35;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "Search :";
            // 
            // lblCname
            // 
            this.lblCname.AutoSize = true;
            this.lblCname.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCname.ForeColor = System.Drawing.Color.Black;
            this.lblCname.Location = new System.Drawing.Point(500, 7);
            this.lblCname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCname.Name = "lblCname";
            this.lblCname.Size = new System.Drawing.Size(106, 37);
            this.lblCname.TabIndex = 33;
            this.lblCname.Text = "Name";
            // 
            // btnSaveRFID
            // 
            this.btnSaveRFID.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSaveRFID.Enabled = false;
            this.btnSaveRFID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRFID.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveRFID.ForeColor = System.Drawing.Color.Black;
            this.btnSaveRFID.Location = new System.Drawing.Point(1099, 60);
            this.btnSaveRFID.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveRFID.Name = "btnSaveRFID";
            this.btnSaveRFID.Size = new System.Drawing.Size(128, 39);
            this.btnSaveRFID.TabIndex = 32;
            this.btnSaveRFID.Text = "Save RFID";
            this.btnSaveRFID.UseVisualStyleBackColor = false;
            this.btnSaveRFID.Click += new System.EventHandler(this.BtnSaveRFID_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadCard.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btnReadCard.ForeColor = System.Drawing.Color.White;
            this.btnReadCard.Location = new System.Drawing.Point(963, 60);
            this.btnReadCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(128, 39);
            this.btnReadCard.TabIndex = 31;
            this.btnReadCard.Text = "Read Card Data";
            this.btnReadCard.UseVisualStyleBackColor = false;
            this.btnReadCard.Click += new System.EventHandler(this.BtnReadCard_Click);
            // 
            // txtReadCardData
            // 
            this.txtReadCardData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtReadCardData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadCardData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadCardData.Location = new System.Drawing.Point(303, 60);
            this.txtReadCardData.Margin = new System.Windows.Forms.Padding(4);
            this.txtReadCardData.Name = "txtReadCardData";
            this.txtReadCardData.ReadOnly = true;
            this.txtReadCardData.Size = new System.Drawing.Size(651, 30);
            this.txtReadCardData.TabIndex = 21;
            this.txtReadCardData.TabStop = false;
            this.txtReadCardData.TextChanged += new System.EventHandler(this.TxtReadCardData_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearch.Location = new System.Drawing.Point(37, 60);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 30);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(13, 137);
            this.axAcroPDF1.Margin = new System.Windows.Forms.Padding(4);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(240, 240);
            this.axAcroPDF1.TabIndex = 28;
            this.axAcroPDF1.TabStop = false;
            this.axAcroPDF1.Visible = false;
            // 
            // picBox_CardB
            // 
            this.picBox_CardB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBox_CardB.Location = new System.Drawing.Point(13, 373);
            this.picBox_CardB.Margin = new System.Windows.Forms.Padding(4);
            this.picBox_CardB.Name = "picBox_CardB";
            this.picBox_CardB.Size = new System.Drawing.Size(266, 331);
            this.picBox_CardB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_CardB.TabIndex = 1;
            this.picBox_CardB.TabStop = false;
            this.picBox_CardB.Visible = false;
            // 
            // frmExcelUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 761);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.Grddetails);
            this.Controls.Add(this.groupBox_Portrait);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.groupBox_Ls);
            this.Controls.Add(this.chk_Portrait);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.txt_CardData1);
            this.Controls.Add(this.metroLabel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExcelUpload";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExcelUpload_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmExcelUpload_FormClosed);
            this.Load += new System.EventHandler(this.FrmExcelUpload_Load);
            this.groupBox_Portrait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_CardF)).EndInit();
            this.groupBox_Ls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Ls_CardB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Ls_CardF)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grddetails)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_CardB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_BrwsImg;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.GroupBox groupBox_Portrait;
        private System.Windows.Forms.PictureBox picBox_CardF;
        private System.Windows.Forms.GroupBox groupBox_Ls;
        private System.Windows.Forms.PictureBox picBox_Ls_CardB;
        private System.Windows.Forms.PictureBox picBox_Ls_CardF;
        private System.Windows.Forms.CheckBox chk_Portrait;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Button btnListData;
        private System.Windows.Forms.Button btn_PrintCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ChooseExcel;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.TextBox txt_ImgPath;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Button btnHome;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox txtFile;
        private MetroFramework.Controls.MetroComboBox CmbCardType;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txt_CardData1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.DataGridView Grddetails;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Button btnPnlClose;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCname;
        private System.Windows.Forms.Button btnSaveRFID;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.TextBox txtReadCardData;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBox_CardB;
    }
}