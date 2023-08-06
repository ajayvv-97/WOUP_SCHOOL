using iTextSharp.text;
using iTextSharp.text.pdf;
using MetroFramework.Forms;
using System.Data.SqlClient;
using QRCodeEncoderDecoderLibrary;
using ReaderSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using MetroFramework;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZXing;
using ZXing.Common;

namespace IDCardPrintingwithRFID.Forms
{
    public partial class frmExcelUpload : MetroFramework.Forms.MetroForm
    {
        #region Declaration
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        string FoldPath = string.Empty;
        string Image_Path = string.Empty;
        public static string Path = Application.StartupPath + "\\Template";
        public static string CardF_Path = Path + "\\CardF.jpg";
        public static string CardFls_Path = Path + "\\StaffF.jpg";
        public static string CardBls_Path = Path + "\\StaffB.jpg";
        public static string Img_Path = Application.StartupPath + "\\Images";
        public static string CardB_Path = Img_Path + "\\StudentB.jpg";
        public static string ImgF_FileName = "", ImgB_FileName = "";
        public static QrCodeEncodingOptions options = null;
        public static string Qr_Content = "", Account_No = "", ID = "";
        public static int imgCount;
        //public static string con = "Data Source=192.168.2.5;Initial Catalog=mPOS_DB;Persist Security Info=True;User ID=sa;Password=JM@2020";
        //SqlConnection cnn = new SqlConnection(con);

        public static string con = Forms.frmlogin.pDBConnStr;
        SqlConnection cnn = new SqlConnection(con);
        SqlDataAdapter adapter;
        public static string qry = "";
        public static int gender = 0, id = 0;
        public static string loyalty = "", employee = "";
        private ACR122 reader;//for reader
        int rcount = 0;
        string first_16;
        string second_16;
        string third_16;
        string read_encodedno;// to hold the encoded number completely
        #endregion
        public frmExcelUpload()
        {
            InitializeComponent();
           
        }
        #region Functions
        private void Writelogs(string Errordesc, string Module)
        {
            try
            {
                string path = "Log.txt";
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("--------------Application Log--------------");
                        sw.WriteLine();
                        sw.WriteLine(System.DateTime.Now);
                        sw.WriteLine("Module: " + Module + string.Empty);
                        sw.WriteLine("Message: " + Errordesc + string.Empty);
                        sw.WriteLine(System.IO.Directory.GetCurrentDirectory());
                        sw.WriteLine("--------------------------------------------");
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("--------------Application Log--------------");
                        sw.WriteLine();
                        sw.WriteLine(System.DateTime.Now);
                        sw.WriteLine("Module: " + Module + string.Empty);
                        sw.WriteLine("Message: " + Errordesc + string.Empty);
                        sw.WriteLine(System.IO.Directory.GetCurrentDirectory());
                        sw.WriteLine("--------------------------------------------");
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearCard()
        {
            if (File.Exists("CardF_A.pdf"))
            {
                File.Delete("CardF_A.pdf");
            }
            if (File.Exists("CardB_A.pdf"))
            {
                File.Delete("CardB_A.pdf");
            }
            if (File.Exists("CardF_P.pdf"))
            {
                File.Delete("CardF_P.pdf");
            }
            if (File.Exists("CardB_P.pdf"))
            {
                File.Delete("CardB_P.pdf");
            }
        }
        private void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    DeleteDirectory(directory);
                }
                //Delete a Directory
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                Directory.Delete(path);
            }
        }
        private System.Drawing.Image GenerateBarcode(string data)
        {
            int W = 1600;
            int H = 115;
            System.Drawing.Image barcode = null;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            // type = BarcodeLib.TYPE.CODE128;
            type = BarcodeLib.TYPE.CODE128;
            b.IncludeLabel = false;
            if (type != BarcodeLib.TYPE.UNSPECIFIED)
            {
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                //string adrno = Data.Replace(" ", "");
                //string ID = "12345678";
                barcode = b.Encode(type, ID, Color.Black, Color.White, W, H);
                barcode.Save(Img_Path + "\\" + ID + "barcode.bmp");

            }
            return barcode;
        }
        private void GenerateQrcode(string Data)
        {
            try
            {
                //Generate QR Contents
                imgCount += 1;
                var qr = new ZXing.BarcodeWriter();
                qr.Options = options;
                qr.Format = ZXing.BarcodeFormat.QR_CODE;
                var resultQR = new Bitmap(qr.Write(Qr_Content));
                //resultQR.Save(Img_Path + "\\" + Qr_Content + "Qr.bmp");

                //string outputFileName = Img_Path + "\\" + ID + "Qr" + imgCount.ToString() + ".bmp";
                string outputFileName = Img_Path + "\\" + ID + "Qr.bmp";
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        Bitmap thumbBMP = new Bitmap(resultQR);
                        thumbBMP.Save(memory, ImageFormat.Bmp);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                        thumbBMP.Dispose();
                    }
                }

                resultQR.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintCard()        
        {
            try
            {
                #region old code
                string oldFile = string.Empty, newFile = string.Empty;
                oldFile = @"template\CardFB_Portrait.pdf";
                newFile = Img_Path + @"\CardFB_New.pdf";

                
                // open the reader
                PdfReader reader = new PdfReader(oldFile);
                iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
                Document document_A = new Document(size);

                // open the writer
                FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
                PdfWriter writer_A = PdfWriter.GetInstance(document_A, fs);
                document_A.Open();

                // the pdf content
                PdfContentByte cb = writer_A.DirectContent;

                // create the new page and add it to the pdf
                PdfImportedPage page = writer_A.GetImportedPage(reader, 1);
                cb.AddTemplate(page, 0, 0);

                //----------       ADD CONTENTS TO TEMPLATE ------------     //

                //Front Page//
                string Front_Page = FoldPath + "\\" + ImgF_FileName;
                if (File.Exists(Front_Page))
                {
                    using (Stream inputImageStream = new FileStream(Front_Page, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        iTextSharp.text.Image Profile = iTextSharp.text.Image.GetInstance(inputImageStream);
                        cb.AddImage(Profile, 153, 0, 0, 242, 0, 0);
                    }
                }

                //-----------------------------------------------------------//

                // import contents to the second page //

                document_A.NewPage();
                PdfImportedPage page2 = writer_A.GetImportedPage(reader, 2);
                cb.AddTemplate(page2, 0, 0);
                string Back_Page = FoldPath + "\\" + ImgB_FileName;
                if (File.Exists(Back_Page))
                {
                    //create an object that we can use to examine an image file
                    using (System.Drawing.Image img = System.Drawing.Image.FromFile(Back_Page))
                    {
                        //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        img.Save(CardB_Path, System.Drawing.Imaging.ImageFormat.Jpeg);

                    }
                    using (Stream inputImageStream = new FileStream(CardB_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        iTextSharp.text.Image Profile = iTextSharp.text.Image.GetInstance(inputImageStream);
                        //cb.AddImage(Profile, 250, 0, 0, 160, 0, 0);//(width,right rotation,left rotation,height,x,y)

                        cb.AddImage(Profile, 153, 0, 0, 245, 0, 0);//(width,right rotation,left rotation,height,x,y)
                    }
                }

                //---------------------------------//
                document_A.Dispose();
                writer_A.Dispose();
                fs.Dispose();
                reader.Dispose();
                #endregion

                /* string oldFile = @"template\CardFB_Portrait.pdf";
                string newFile = Path.Combine(Img_Path, "CardFB_New.pdf");
                // Open the reader
                using (PdfReader reader = new PdfReader(oldFile))
                {
                    iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
                    using (Document document_A = new Document(size))
                    {
                        // Open the writer
                        using (FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
                        {
                            PdfWriter writer_A = PdfWriter.GetInstance(document_A, fs);
                            document_A.Open();
                            // The pdf content
                            PdfContentByte cb = writer_A.DirectContent;

                            // create the new page and add it to the pdf
                            PdfImportedPage page = writer_A.GetImportedPage(reader, 1);
                            cb.AddTemplate(page, 0, 0);

                            //----------       ADD CONTENTS TO TEMPLATE ------------     //

                            //Front Page//
                            string Front_Page = Path.Combine(FoldPath, ImgF_FileName);
                            if (File.Exists(Front_Page))
                            {
                                using (Stream inputImageStream = new FileStream(Front_Page, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                                {
                                    iTextSharp.text.Image Profile = iTextSharp.text.Image.GetInstance(inputImageStream);
                                    cb.AddImage(Profile, 153, 0, 0, 242, 0, 0);
                                }
                            }

                            //-----------------------------------------------------------//

                            // import contents to the second page //

                            document_A.NewPage();
                            PdfImportedPage page2 = writer_A.GetImportedPage(reader, 2);
                            cb.AddTemplate(page2, 0, 0);

                            string Back_Page = Path.Combine(FoldPath, ImgB_FileName);
                            if (File.Exists(Back_Page))
                            {
                                //create an object that we can use to examine an image file
                                using (System.Drawing.Image img = System.Drawing.Image.FromFile(Back_Page))
                                {
                                    //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    img.Save(CardB_Path, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }

                                using (Stream inputImageStream = new FileStream(CardB_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                                {
                                    iTextSharp.text.Image Profile = iTextSharp.text.Image.GetInstance(inputImageStream);
                                    //cb.AddImage(Profile, 250, 0, 0, 160, 0, 0);//(width,right rotation,left rotation,height,x,y)
                                    cb.AddImage(Profile, 153, 0, 0, 245, 0, 0);//(width,right rotation,left rotation,height,x,y)
                                }
                            }

                            //---------------------------------//
                            // Dispose resources
                            document_A.Close();
                            writer_A.Close();
                        }
                    }
                }*/


                axAcroPDF1.LoadFile(Img_Path + @"\CardFB_New.pdf");
                axAcroPDF1.setZoom(100);
                axAcroPDF1.setView("Fit");
                axAcroPDF1.setPageMode("none");
                axAcroPDF1.setLayoutMode("TwoColumnLeft");
                axAcroPDF1.setShowToolbar(false);
                axAcroPDF1.Show();
                axAcroPDF1.Update();
            }
            catch (Exception Ex)
            {
               
            }
        }
        private void ListHeader()
        {
            listView1.View = View.Details;

            if (chk_Portrait.Checked == true)


            {
                listView1.Items.Clear();
                listView1.Columns.Add("id", 0);
                listView1.Columns.Add("gender", 0);
                listView1.Columns.Add("Code", 150);
                listView1.Columns.Add("Customer Name", 200);
                listView1.Columns.Add("Mobile No", 150);
                listView1.Columns.Add("Icard", 0);

            }

            else
            {
                //listView1.Items.Clear();
                //listView1.Columns.Add("id", 0);
                //listView1.Columns.Add("gender", 0);
                //listView1.Columns.Add("Code", 150);
                //listView1.Columns.Add("Employee Name", 200);
                //listView1.Columns.Add("Mobile No", 150);
                //listView1.Columns.Add("Icard",150);
                //listView1.Columns.Add("eAdd1", 150);
                //listView1.Columns.Add("eAdd2", 150);
                //listView1.Columns.Add("eAdd3", 150);
                //listView1.Columns.Add("dob", 150);
                //listView1.Columns.Add("blood", 150);

                listView1.Items.Clear();
                listView1.Columns.Add("id", 0);
                listView1.Columns.Add("Employee Name", 200);
                listView1.Columns.Add("Code", 150);
                listView1.Columns.Add("Department", 150);
                listView1.Columns.Add("Designation", 150);
                listView1.Columns.Add("Mobile No", 150);              
                listView1.Columns.Add("eAdd2", 150);
                listView1.Columns.Add("eAdd3", 150);
                listView1.Columns.Add("dob", 150);
                listView1.Columns.Add("blood", 150);


            }

        }
        public void ListCustomerData()
        {
            cnn.Close();
            cnn.Open();

            adapter = new SqlDataAdapter(qry, cnn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["id"].ToString());
                listitem.SubItems.Add(dr["gender"].ToString());
                listitem.SubItems.Add(dr["ccode"].ToString());
                listitem.SubItems.Add(dr["cname"].ToString());
                listitem.SubItems.Add(dr["mobileno"].ToString());
                listitem.SubItems.Add(dr["icardno"].ToString());
                listView1.Items.Add(listitem);

            }
            cnn.Close();
        }
        public void ListEmployeeData()
        {
            cnn.Close();
            cnn.Open();


            adapter = new SqlDataAdapter(qry, cnn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["emp_id"].ToString());
                // listitem.SubItems.Add(dr["gender"].ToString());
                listitem.SubItems.Add(dr["ename"].ToString());
                listitem.SubItems.Add(dr["ecode"].ToString());
                listitem.SubItems.Add(dr["Department"].ToString());
                listitem.SubItems.Add(dr["Designation"].ToString());
                listitem.SubItems.Add(dr["mobno"].ToString());
                //listitem.SubItems.Add(dr["icardno"].ToString());
                //listitem.SubItems.Add(dr["eAdd1"].ToString());
                listitem.SubItems.Add(dr["eAdd2"].ToString());
                listitem.SubItems.Add(dr["eAdd3"].ToString());
                listitem.SubItems.Add(dr["dob"].ToString());
                listitem.SubItems.Add(dr["blood"].ToString());
               

                listView1.Items.Add(listitem);

            }
            cnn.Close();
        }
        public string ReadFromCard()
        {
            try
            {
                while (rcount < 3)
                {
                    if (rcount == 0)//to read company branch and location 
                    {
                        string text = reader.getDataFromTag(rcount);
                        if (text != "" && text != "c" && text != "disConnected")//for fresh card the read value will be null
                        {
                            first_16 = new string(text.Where(c => !char.IsControl(c)).ToArray()); //to remove /u0090
                            rcount++;
                        }
                        //else
                        //{
                        //    rcount = 0;//setting to zero if not read properly
                        //}
                    }
                    if (rcount == 1)// second 16 digits
                    {
                        string text = reader.getDataFromTag(rcount);

                        if (text != "" && text != "c" && text != "disConnected")//for fresh card the read value will be null
                        {
                            second_16 = new string(text.Where(c => !char.IsControl(c)).ToArray()); //to remove /u0090

                            rcount++;
                        }
                        //else
                        //{
                        //    rcount = 0;//setting to zero if not read properly
                        //}
                    }

                    if (rcount == 2)// last 16 digit
                    {
                        string text = reader.getDataFromTag(rcount);

                        if (text != "" && text != "c" && text != "disConnected")//for fresh card the read value will be null
                        {
                            third_16 = new string(text.Where(c => !char.IsControl(c)).ToArray()); //to remove /u0090             
                            rcount++;//setting to zero if not read properly
                        }
                        //else
                        //{
                        //    rcount = 0;
                        //}
                    }
                    read_encodedno = string.Concat(first_16, second_16, third_16);

                    if (read_encodedno == "")
                    {
                        read_encodedno = "empty";
                        return read_encodedno;
                    }
                    return read_encodedno;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                read_encodedno = "X";
                return read_encodedno;
            }
            return read_encodedno;
        }//logic to read data from card

        #endregion
        public StringFormat StringFormat { get; set; }
        //public RectangleF rect1 { get; set; }
        private void FrmExcelUpload_Load(object sender, EventArgs e)
        {
            txtFile.Text = @"C:\Users\ajay\OneDrive\Desktop\woup Test file\mts.xlsx";
            txt_ImgPath.Text = @"C:\Users\ajay\OneDrive\Desktop\woup Test file\student Photos\";
            txt_ImgPath.Text = ConfigurationManager.AppSettings["IMGPath"].ToString();
            BtnGenerate.Enabled = true;
            CmbCardType.SelectedIndex = 0;
            loyalty = dashboard.Loyalty;
            employee = dashboard.Empolyee;
            try
            {
                if (loyalty == "Loyalty")
                {
                    chk_Portrait.Checked = true;
                    chk_Portrait.Text = "Staff Card";
                    this.Size = new Size(1209, 655);
                    Grddetails.Size = new Size(950, 471);
                    this.CenterToScreen();
                    groupBox_Ls.Visible = true;


                }
                if (employee == "Employee")
                {

                    chk_Portrait.Checked = false;
                    chk_Portrait.Text = "Student Card";
                    this.Size = new Size(1209, 655);
                    Grddetails.Size = new Size(950, 471);
                    this.CenterToScreen();                   
                    groupBox_Portrait.Visible = true;
                }
                DeleteDirectory(Img_Path);

                if (!Directory.Exists(Img_Path))
                {
                    Directory.CreateDirectory(Img_Path);
                    DirectoryInfo dInfo = new DirectoryInfo(Img_Path);
                    DirectorySecurity dSecurity = dInfo.GetAccessControl();
                    dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                    dInfo.SetAccessControl(dSecurity);
                }

             
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                //DeleteDirectory(Img_Path);
                OpenFileDialog fileOpen = new OpenFileDialog();
                fileOpen.Title = "Open Excel file";
               fileOpen.Filter = "Excel files|*.xls;*.csv;*.xlsx;.*;";
                string fileName;
                if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                    fileName = fileOpen.FileName;
                    txtFile.Text = fileName;
                    DataTable dt = new DataTable("dataTable");
                    DataSet dsSource = new DataSet("dataSet");
                    dt.Reset();

                    Microsoft.Office.Interop.Excel.Workbook ExWorkbook;
                    Microsoft.Office.Interop.Excel.Worksheet ExWorksheet;
                    Microsoft.Office.Interop.Excel.Range ExRange;
                    Microsoft.Office.Interop.Excel.Application ExObj = new Microsoft.Office.Interop.Excel.Application();


                    ExWorkbook = ExObj.Workbooks.Open(fileOpen.FileName, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    ExWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)ExWorkbook.Sheets.get_Item(1);
                    ExRange = ExWorksheet.UsedRange;

                    for (int Cnum = 1; Cnum <= ExRange.Columns.Count; Cnum++)
                    {
                        if ((ExRange.Cells[1, Cnum] as Microsoft.Office.Interop.Excel.Range).Value2.ToString() != "")
                            dt.Columns.Add(new DataColumn((ExRange.Cells[1, Cnum] as Microsoft.Office.Interop.Excel.Range).Value2.ToString()));
                    }
                    dt.AcceptChanges();

                    string[] columnNames = new String[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        columnNames[0] = dt.Columns[i].ColumnName;
                    }
                    //string[] columnNames = (from dc in dt.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
                    if ((chk_Portrait.Checked == false && dt.Columns.Count == 8) || chk_Portrait.Checked == true && dt.Columns.Count == 8)
                    {
                        for (int Rnum = 2; Rnum <= ExRange.Rows.Count; Rnum++)
                        {
                            DataRow dr = dt.NewRow();
                            for (int Cnum = 1; Cnum <= ExRange.Columns.Count; Cnum++)
                            {
                                if ((ExRange.Cells[Rnum, Cnum] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                                {
                                    dr[Cnum - 1] = (ExRange.Cells[Rnum, Cnum] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                                }
                            }
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();
                        }
                        ExWorkbook.Close(true, Missing.Value, Missing.Value);
                        ExObj.Quit();
                        Grddetails.DataSource = dt;
                        fileOpen.Dispose();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Excel file is not in correct format", "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        Grddetails.DataSource = null;
                        txtFile.Text = "";
                    }
                }
            }
            catch (Exception Ex)
            {
                MetroMessageBox.Show(this, Ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void Btn_BrwsImg_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result1 = folderBrowserDialog1.ShowDialog();
                if (result1 == DialogResult.OK)
                {
                    Image_Path = folderBrowserDialog1.SelectedPath;
                    txt_ImgPath.Text = Image_Path;
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void BtnListData_Click(object sender, EventArgs e)
        {
            try
            {
                ListHeader();
                pnlList.Visible = true;
                txtSearch.Focus();
                if (chk_Portrait.Checked == true)
                {
                    qry = "select LedgerId as id,gender,LedgerCode as ccode,LedgerName as cname,Mobile as mobileno,icardno as icardno from  tblAccountLedger where  cardtype=143 ORDER BY LedgerId desc ";
                    ListCustomerData();
                }

                else
                {

                  
                    qry = "select e.EmployeeId as emp_id,e.EmployeeName as ename,e.EmployeeCode as ecode,dp.DepartmentName as Department,ds.DesignationName as Designation,Mobile as mobno,'' as eAdd2,'' as eAdd3,FORMAT(e.DOB, 'dd/MM/yyyy') as DOB,'' as blood,icardno as icardno " +
                           "from tblEmployee e left join tblDepartment dp on e.DepartmentId = dp.DepartmentId left join tblDesignation ds on e.DesignationId = ds.DesignationId ORDER BY EmployeeId desc";
                    ListEmployeeData();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //DeleteDirectory(Img_Path);
                if (File.Exists("Printfile.jpg"))
                {
                    File.Delete("Printfile.jpg");
                }
                if (!Directory.Exists(Img_Path))
                {
                    Directory.CreateDirectory(Img_Path);
                    DirectoryInfo dInfo = new DirectoryInfo(Img_Path);
                    DirectorySecurity dSecurity = dInfo.GetAccessControl();
                    dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                    dInfo.SetAccessControl(dSecurity);
                }
                if (Grddetails.Rows.Count >= 1 && (Image_Path != string.Empty || txt_ImgPath.Text != string.Empty))
                {
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        FoldPath = folderBrowserDialog1.SelectedPath;

                        for (int i = 0; i < Grddetails.Rows.Count; i++) 
                        {

                            #region Student card    
                            //Student card

                            //---------------------Front Side----------------------------------------//

                            if (chk_Portrait.Checked == false && Grddetails.Columns.Count == 8 || chk_Portrait.Checked == false && Grddetails.Columns.Count == 8)
                               {
                                System.Drawing.Image image = Properties.Resources.CardF; //Image.FromFile(strprintfile);
                                Graphics graphics = Graphics.FromImage(image);

                                {
                                    #region Name
                                    if (Grddetails.Rows[i].Cells[0].Value.ToString() != "")//NAME
                                    {
                                        using (System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 2.6f, FontStyle.Bold, GraphicsUnit.Point))
                                        {
                                            string Col_Head1 = Grddetails.Columns[0].HeaderText.Substring(0, 4);
                                            System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold);
                                            PointF SlNopoint = new PointF(150, 457);
                                            ID = Grddetails.Rows[i].Cells[1].Value.ToString();
                                            graphics.DrawString(Grddetails.Rows[i].Cells[0].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);


                                        }

                                    }
                                    #endregion

                                    #region ADDMISSION No
                                    if (Grddetails.Rows[i].Cells[1].Value.ToString() != "") // ADDMISSION NO
                                    {
                                        string Col_Head1 = Grddetails.Columns[1].HeaderText.Substring(0, 4);
                                        System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 22f, FontStyle.Bold);
                                        PointF SlNopoint = new PointF(262, 550);

                                        // Convert hexadecimal color code to System.Drawing.Color
                                        Color foreColor = System.Drawing.ColorTranslator.FromHtml("#1c1213");

                                        // Create a SolidBrush with the specified color
                                        SolidBrush foreColorBrush = new SolidBrush(foreColor);

                                        // Draw the text with the specified forecolor
                                        graphics.DrawString(Grddetails.Rows[i].Cells[1].Value.ToString(), SlNoFont, foreColorBrush, SlNopoint);
                                    }
                                    #endregion

                                    #region DOB
                                    if (Grddetails.Rows[i].Cells[2].Value.ToString() != "")//DOB
                                    {
                                        using (System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 2.6f, FontStyle.Bold, GraphicsUnit.Point))
                                        {

                                            System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 22f, FontStyle.Bold);
                                            PointF SlNopoint = new PointF(262, 576);
                                            graphics.DrawString(Grddetails.Rows[i].Cells[2].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);                                                                                      

                                        }

                                    }
                                    #endregion

                                    #region Issue Date
                                    if (Grddetails.Rows[i].Cells[3].Value.ToString() != "")//Issue Date
                                    {
                                        
                                        System.Drawing.Font SlNoFont1 = new System.Drawing.Font("Calibri", 22f, FontStyle.Bold);
                                        PointF SlNopoint1 = new PointF(262, 603);
                                        graphics.DrawString(Grddetails.Rows[i].Cells[3].Value.ToString(), SlNoFont1, Brushes.Black, SlNopoint1);

                                    }
                                    #endregion

                                    #region Class
                                    if (Grddetails.Rows[i].Cells[4].Value.ToString() != "")//Class
                                    {
                                        using (System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 2.6f, FontStyle.Bold, GraphicsUnit.Point))
                                        {
                                          
                                            System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 22f, FontStyle.Bold);
                                            PointF SlNopoint = new PointF(262, 628);                                         
                                            graphics.DrawString(Grddetails.Rows[i].Cells[4].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);

               

                                        }

                                    }
                                    #endregion

                                    #region Phone Number
                                    if (Grddetails.Rows[i].Cells[5].Value.ToString() != "")//phone number
                                    {
                                        using (System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 2.6f, FontStyle.Bold, GraphicsUnit.Point))
                                        {
                                            
                                            System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 22f, FontStyle.Bold);
                                            PointF SlNopoint = new PointF(262, 657);
                                            graphics.DrawString(Grddetails.Rows[i].Cells[5].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);

                                        }
                                    }
                                    #endregion


                                    #region Address
                                    string[] addarray = new string[10];
                                    addarray[0] = Grddetails.Rows[i].Cells[6].Value.ToString().Trim();
                                    addarray[1] = Grddetails.Rows[i].Cells[7].Value.ToString().Trim();
                                 
                                    string address = "";
                                    for (int j = 0; j < addarray.Count(); j++)
                                    {
                                        if (addarray[j] != null)
                                        {
                                            address = addarray[j].ToString();
                                            String[] arr = address.Trim().Split(' ');
                                            if (address.Trim().Length > 26 && arr.Count() > 1)
                                            {

                                                int l = arr.Count();

                                                address = "";
                                                for (int ij = 0; ij < l - 1; ij++)
                                                {
                                                    address = address + " " + arr[ij].ToString();
                                                }
                                                addarray[j] = address;
                                                addarray[j + 1] = arr[l - 1] + " " + addarray[j + 1];
                                                j--;
                                            }
                                        }
                                    }

                                    

                                    if (Grddetails.Rows[i].Cells[6].Value.ToString() != "")//Address 1
                                    {
                                        int y = 686;
                                        using (System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 2.6f, FontStyle.Bold, GraphicsUnit.Point))
                                        {
                                            System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 22f, FontStyle.Bold);
                                            for (int j = 0; j < addarray.Count(); j++)
                                            {
                                                if (addarray[j] != null)
                                                {
                                                    PointF SlNopoint1 = new PointF(262, y);
                                                    graphics.DrawString(addarray[j].ToString(), SlNoFont, Brushes.Black, SlNopoint1);
                                                    y = y + 29;
                                                }
                                            }


                                        }

                                    }//address finish

                                    #endregion


                                    #region PHOTO
                                    if (Grddetails.Rows[i].Cells[1].Value.ToString() != "")  //students photo
                                    {
                                        string tem_image;


                                        if (File.Exists(Image_Path + "\\" + Grddetails.Rows[i].Cells[1].Value.ToString() + ".jpg"))
                                        {

                                            tem_image = txt_ImgPath.Text + "\\" + Grddetails.Rows[i].Cells[1].Value.ToString() + ".jpg";
                                            System.Drawing.Image newImage = null;
                                            newImage = System.Drawing.Image.FromFile(tem_image);
                                            // Define the new center coordinates of the circular shape
                                            int centerX = 306; // New X-coordinate
                                            int centerY = 332; // New Y-coordinate
                                            int radius = 112;
                                            // Calculate the top-left coordinates of the rectangle
                                            int px = centerX - radius;
                                            int py = centerY - radius;
                                            // Create a circular region using a rectangle
                                            System.Drawing.Rectangle circleRect = new System.Drawing.Rectangle(px, py, 2 * radius, 2 * radius);
                                            // Create a circular graphics path
                                            System.Drawing.Drawing2D.GraphicsPath circularPath = new System.Drawing.Drawing2D.GraphicsPath();
                                            circularPath.AddEllipse(circleRect);
                                            // Set the region to the circular path
                                            graphics.SetClip(circularPath);
                                            // Draw the image within the circular region
                                            graphics.DrawImage(newImage, circleRect);
                                            // Reset the region
                                            graphics.ResetClip();


                                        }
                                        else
                                        {
                                            if (gender == 1)
                                            {
                                                System.Drawing.Image newImage = Properties.Resources.Blank_M;
                                                System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(218, 285, 235, 263);
                                                graphics.DrawImage(newImage, destRect_Photo);
                                            }
                                            else if (gender == 2)
                                            {
                                                System.Drawing.Image newImage = Properties.Resources.Blank_F;
                                                System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(218, 285, 235, 263);
                                                graphics.DrawImage(newImage, destRect_Photo);
                                            }
                                            else if (gender != 1 || gender != 2)
                                            {
                                                System.Drawing.Image newImage = Properties.Resources.Blank_I;
                                                System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(218, 285, 235, 263);
                                                graphics.DrawImage(newImage, destRect_Photo);
                                            }
                                            else
                                            {
                                                MetroMessageBox.Show(this, "Must upload Image file for Account No " + Grddetails.Rows[i].Cells[1].Value.ToString(), "Image Upload", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                            }
                                        }

                                    }
                                    #endregion

                                    #region ID Bracode
                                    if (Grddetails.Rows[i].Cells[1].Value.ToString() != "")  //ID Bracode
                                    {                                        
                                        
                                        GenerateBarcode_ID(Convert.ToString(Grddetails.Rows[i].Cells[1].Value));
                                        var folderPath = Application.StartupPath + "\\ID_Barcode\\"+ Convert.ToString(Grddetails.Rows[i].Cells[1].Value)+".png";
                                        if (File.Exists(folderPath))
                                        {                                         
                                            System.Drawing.Image newImage = null;
                                            newImage = System.Drawing.Image.FromFile(folderPath);
                                            System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(135, 850, 310, 80);
                                            graphics.DrawImage(newImage, destRect_Photo);
                                        }
                                    }
                                    #endregion        
                                    if (File.Exists(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_0F" + ".jpg"))
                                    {
                                        File.Delete(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_0F" + ".jpg");
                                    }
                                    else
                                    {
                                        image.Save(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_0F" + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }

                                    image.Dispose();




                                    //---------------------Back Side----------------------------------------//

                                    System.Drawing.Image imageB = Properties.Resources.StudentB; //image from file  
                                    Graphics graphics1 = Graphics.FromImage(imageB);

                                    //------- generate QRCode and write--------//

                                    //GenerateQrcode(Qr_Content);
                                    // Create image.
                                    //System.Drawing.Image Qrcode1 = System.Drawing.Image.FromFile(Img_Path + "\\" + ID + "Qr.bmp");
                                    // Create rectangle for displaying image.
                                    //System.Drawing.Rectangle destRect1 = new System.Drawing.Rectangle(235, 117, 170, 150);

                                    // Draw image to screen.
                                    //graphics1.DrawImage(Qrcode1, destRect1);
                                    //Qrcode1.Dispose();
                                    //-----------------------------------------------------------//

                                    if (File.Exists(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_1B" + ".jpg"))
                                    {
                                        File.Delete(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_1B" + ".jpg");
                                    }

                                    imageB.Save(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_1B" + ".jpg");
                                    imageB.Dispose();

                                    //---------------------------------------------------------------------------//
                                }
                            }
                            #endregion

                            #region Landscape STAFF

                            else if (chk_Portrait.Checked == true && Grddetails.Columns.Count == 8)    // Template Landscape
                            {
                                //System.Drawing.Image image = System.Drawing.Image.FromFile(Path + "\\StaffF.jpg");
                                //Properties.Resources.CardF;
                                System.Drawing.Image image = Properties.Resources.StaffF;
                                Graphics graphics = Graphics.FromImage(image);

                                if (Grddetails.Rows[i].Cells[0].Value.ToString() != "")
                                {

                                    if (Grddetails.Rows[i].Cells[0].Value.ToString() != "")//name
                                    {

                                        string Col_Head1 = Grddetails.Columns[0].HeaderText.Substring(0, 4);
                                        System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold);
                                        PointF SlNopoint = new PointF(230, 518);
                                        ID = Grddetails.Rows[i].Cells[0].Value.ToString();
                                        graphics.DrawString(Grddetails.Rows[i].Cells[0].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);

                                        SlNopoint = new PointF(131, 518);
                                        graphics.DrawString("NAME :", SlNoFont, Brushes.Black, SlNopoint);

                                    }

                                    if (Grddetails.Rows[i].Cells[1].Value.ToString() != "")//designation
                                    {
                                        string Col_Head1 = Grddetails.Columns[1].HeaderText.Substring(0, 4);
                                        System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold);
                                        PointF SlNopoint = new PointF(230, 567);
                                        ID = Grddetails.Rows[i].Cells[1].Value.ToString();
                                        graphics.DrawString(Grddetails.Rows[i].Cells[1].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);

                                        SlNopoint = new PointF(36, 567);
                                        graphics.DrawString("DESIGNATION :", SlNoFont, Brushes.Black, SlNopoint);


                                    }

                                    //ADDRESS STARTING 


                                    string[] addarray = new string[10];
                                    addarray[0] = Grddetails.Rows[i].Cells[2].Value.ToString().Trim();
                                    addarray[1] = Grddetails.Rows[i].Cells[3].Value.ToString().Trim();
                                    addarray[2] = Grddetails.Rows[i].Cells[4].Value.ToString().Trim();
                                    string address = "";
                                    for (int j = 0; j < addarray.Count(); j++)
                                    {
                                        if (addarray[j] != null)
                                        {
                                            address = addarray[j].ToString();
                                            String[] arr = address.Trim().Split(' ');
                                            if (address.Trim().Length > 26 && arr.Count() > 1)
                                            {

                                                int l = arr.Count();

                                                address = "";
                                                for (int ij = 0; ij < l - 1; ij++)
                                                {
                                                    address = address + " " + arr[ij].ToString();
                                                }
                                                addarray[j] = address;
                                                addarray[j + 1] = arr[l - 1] + " " + addarray[j + 1];
                                                j--;
                                            }
                                        }
                                    }

                                    int y = 616;

                                    if (Grddetails.Rows[i].Cells[2].Value.ToString() != "")//Address 1 2 3
                                    {

                                        using (System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold, GraphicsUnit.Point))
                                        {
                                            System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold);
                                            for (int j = 0; j < addarray.Count(); j++)
                                            {
                                                if (addarray[j] != null)
                                                {
                                                    string Col_Head1 = Grddetails.Columns[3].HeaderText.Substring(0, 4);

                                                    PointF SlNopoint1 = new PointF(230, y);
                                                    graphics.DrawString(addarray[j].ToString(), SlNoFont, Brushes.Black, SlNopoint1);
                                                    y = y + 36;
                                                }
                                            }
                                            PointF SlNopoint = new PointF(96, 616);
                                            graphics.DrawString("ADDRESS :", SlNoFont, Brushes.Black, SlNopoint);

                                        }

                                    }//address finish

                                    y = y +13;

                                    if (Grddetails.Rows[i].Cells[5].Value.ToString() != "")//CONTNO
                                    {

                                        string Col_Head1 = Grddetails.Columns[5].HeaderText.Substring(0, 4);
                                        System.Drawing.Font SlNoFont = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold);
                                        PointF SlNopoint = new PointF(234, y);

                                        ID = Grddetails.Rows[i].Cells[5].Value.ToString();
                                        graphics.DrawString(Grddetails.Rows[i].Cells[5].Value.ToString(), SlNoFont, Brushes.Black, SlNopoint);

                                        SlNopoint = new PointF(96, y);
                                        graphics.DrawString("CONT NO :", SlNoFont, Brushes.Black, SlNopoint);

                                    }





                                    if (Grddetails.Rows[i].Cells[6].Value.ToString() != "")//blood group
                                    {
                                        System.Drawing.Font SlNoFont1 = new System.Drawing.Font("Calibri", 30f, FontStyle.Bold, GraphicsUnit.Point);
                                        PointF SlNopoint1 = new PointF(450, 270);//645
                                        graphics.DrawString(Grddetails.Rows[i].Cells[6].Value.ToString(), SlNoFont1, Brushes.Black, SlNopoint1);
                                    }
                                    if (Grddetails.Rows[i].Cells[7].Value.ToString() != "")  // PHOTO
                                    {
                                        Image_Path = txt_ImgPath.Text;
                                        if (File.Exists(Image_Path + "\\" + Grddetails.Rows[i].Cells[7].Value.ToString() + ".jpg"))
                                        {
                                            // Create image.
                                            //System.Drawing.Image newImage = System.Drawing.Image.FromFile(Grddetails.Rows[i].Cells[9].Value.ToString());
                                            System.Drawing.Image newImage = null;

                                            newImage = System.Drawing.Image.FromFile(Image_Path + "\\" + Grddetails.Rows[i].Cells[7].Value.ToString() + ".jpg");
                                            // Create rectangle for displaying image.
                                            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(200, 240, 220, 270);

                                            // Draw image to screen.
                                            graphics.DrawImage(newImage, destRect);
                                        }
                                        else
                                        {
                                            if (gender == 1)
                                            {
                                                System.Drawing.Image newImage = Properties.Resources.Blank_M;
                                                System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(200, 240, 220, 270);
                                                graphics.DrawImage(newImage, destRect_Photo);
                                            }
                                            else if (gender == 2)
                                            {
                                                System.Drawing.Image newImage = Properties.Resources.Blank_F;
                                                System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(200, 240, 220, 270);
                                                graphics.DrawImage(newImage, destRect_Photo);
                                            }
                                            else if (gender != 1 || gender != 2)
                                            {
                                                System.Drawing.Image newImage = Properties.Resources.Blank_I;
                                                System.Drawing.Rectangle destRect_Photo = new System.Drawing.Rectangle(200, 240, 220, 270);
                                                graphics.DrawImage(newImage, destRect_Photo);
                                            }
                                            else
                                            {
                                                MetroMessageBox.Show(this, "Must upload Image file for Account No " + Grddetails.Rows[i].Cells[1].Value.ToString(), "Image Upload", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                            }
                                        }
                                    }

                                }
                                if (File.Exists(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_0F" + ".jpg"))
                                {
                                    File.Delete(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_0F" + ".jpg");
                                }
                                image.Save(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_0F" + ".jpg");
                                image.Dispose();

                                //---------------------Back Side-----------------------//

                                System.Drawing.Image imageB = System.Drawing.Image.FromFile(Path + "\\StaffB.jpg"); //Properties.Resources.CardB; //image from file  
                                Graphics graphics1 = Graphics.FromImage(imageB);

                                //------- generate barcode and write--------//

                                //GenerateBarcode(ID);
                                //// Create image.
                                //System.Drawing.Image Barcode1 = System.Drawing.Image.FromFile(Img_Path + "\\" + ID + "barcode.bmp");
                                //// Create rectangle for displaying image.
                                //System.Drawing.Rectangle destRect1 = new System.Drawing.Rectangle(265, 152, 1160, 110);

                                // Draw image to screen.
                                //graphics1.DrawImage(Barcode1, destRect1);

                                //-----------------------------------------------------------//

                                //------------ADD CUSTOMER ACCOUNT NUMBER ---------------//

                                using (System.Drawing.Font font1 = new System.Drawing.Font("Army Thin", 5.5f, FontStyle.Bold, GraphicsUnit.Point))
                                {
                                    System.Drawing.Rectangle rect1 = new System.Drawing.Rectangle(265, 285, 1100, 80);

                                    // Create a StringFormat object with the each line of text, and the block
                                    // of text centered on the page.
                                    StringFormat stringFormat = new StringFormat();
                                    stringFormat.Alignment = StringAlignment.Center;
                                    stringFormat.LineAlignment = StringAlignment.Center;

                                    // Draw the text and the surrounding rectangle.
                                    graphics1.DrawString(Account_No, font1, Brushes.Black, rect1, stringFormat);
                                    graphics1.DrawRectangle(Pens.Transparent, rect1);
                                }

                                //------------------------------------------------------//

                                Qr_Content = Grddetails.Rows[i].Cells[4].Value.ToString();

                                //------- generate QRCode and write--------//

                                GenerateQrcode(Qr_Content);
                                // Create image.
                                System.Drawing.Image Qrcode2 = System.Drawing.Image.FromFile(Img_Path + "\\" + ID + "Qr.bmp");
                                // Create rectangle for displaying image
                                System.Drawing.Rectangle destRect_QR2 = new System.Drawing.Rectangle(1265, 515, 270, 240);

                                // Draw image to screen.
                                graphics1.DrawImage(Qrcode2, destRect_QR2);
                                Qrcode2.Dispose();
                                //-----------------------------------------------------------//


                                if (File.Exists(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_1B" + ".jpg"))
                                {
                                    File.Delete(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_1B" + ".jpg");
                                }

                                imageB.Save(folderBrowserDialog1.SelectedPath + "\\" + Grddetails.Rows[i].Cells[0].Value.ToString() + "_1B" + ".jpg");
                                imageB.Dispose();
                            }

                            #endregion

                            else
                            {
                                MetroMessageBox.Show(this, "Upload excel file in Correct format " + folderBrowserDialog1.SelectedPath, "Excel Upload", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                        }
                    }
                    MetroMessageBox.Show(this, "Card Geneated Successfully at " + folderBrowserDialog1.SelectedPath, "Excel Upload", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this, "Must upload Excel file or choose data from list ", "File Upload", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
             
                 
            }
        }
        private void GenerateBarcode_ID(string barcodeText)
        {
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Height = 60,
                        Width = 600,
                        Margin = 2
                    }
                };
                var barcodeBitmap = writer.Write(barcodeText);

                var folderPath = Application.StartupPath + "\\ID_Barcode";
                var filePath = folderPath + "\\" + barcodeText + ".png";

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                /*else
                {
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }*/
                if (File.Exists(filePath))
                    File.Delete(filePath);

                barcodeBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {

            }
        }
        
        private void Btn_PrintCard_Click(object sender, EventArgs e)
        {
            string Print_filename = Img_Path + @"\CardFB_New.pdf";
            try
            {
                if (File.Exists(Print_filename))
                {
                    axAcroPDF1.LoadFile(Print_filename);
                    axAcroPDF1.printWithDialog();

                }
                else
                {
                    MetroMessageBox.Show(this, "Must select a row from the table ", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //writelogs(ex.ToString(), "Print Card");
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = FoldPath + "\\";
                string cmd = "explorer.exe";
                string arg = "/select, " + folderPath;
                Process.Start(cmd, arg);

            }
            catch (Exception Ex)
            {
                MetroMessageBox.Show(this, Ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard db = new dashboard();
            db.ShowDialog();
            loyalty = "";
            employee = "";
            db.Dispose();
        }
        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            DeleteDirectory(Img_Path);
            frmExcelUpload fr = new frmExcelUpload();
            this.Hide();
            fr.ShowDialog();
            fr.Dispose();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                pnlList.Visible = false;
                if (chk_Portrait.Checked == true)
                {
                    id = Int32.Parse(listView1.SelectedItems[0].Text);
                    gender = Int32.Parse(listView1.FocusedItem.SubItems[1].Text);
                    string querry = "select LedgerName as 'Customer Name',LedgerCode  as 'Account No',FORMAT(vfrom,'MMM/yy') as 'Valid From'," +
                        "FORMAT(vto,'MMM/yy') as 'Valid Upto','WWW.JOSHMALL.COM' AS 'qr Content', age as Age,LedgerId from tblAccountLedger where LedgerId=" + id + "";
                    SqlCommand cmd = new SqlCommand(querry, cnn);
                    cnn.Open();
                    adapter = new SqlDataAdapter(querry, cnn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Grddetails.DataSource = dataTable;
                    cnn.Close();
                    cmd.Dispose();
                }
                else
                {
                    id = Int32.Parse(listView1.SelectedItems[0].Text);
                    //gender = Int32.Parse(listView1.FocusedItem.SubItems[1].Text);
                    //string querry = "select e.EmployeeName as 'Employee Name',e.EmployeeCode as 'Code',e.Gender as Gender,dp.DepartmentId as 'Department',ds.DesignationId as 'Designation',e.Mobile as 'Phone No'," +
                    //                 "FORMAT(e.DOB, 'dd/MM/yyyy') as DOB,'WWW.JOSHMALL.COM' AS 'qr Content' from tblEmployee e " +
                    //                 "left join tblDepartment dp on e.DepartmentId = dp.DepartmentId " +
                    //                 "left join tblDesignation ds on e.DesignationId = ds.DesignationId where e.EmployeeId= '" + id + "'";

                    
                    string querry = "select e.EmployeeName as 'Employee Name',e.EmployeeCode as 'Code',dp.DepartmentName as 'Department',ds.DesignationName as 'Designation',e.Mobile as 'Phone No','' as eAdd2,'' as eAdd3," +
                                   "FORMAT(e.DOB, 'dd/MM/yyyy') as DOB,'' as blood,'WWW.JOSHMALL.COM' AS 'qr Content' from tblEmployee e " +
                                   "left join tblDepartment dp on e.DepartmentId = dp.DepartmentId " +
                                   "left join tblDesignation ds on e.DesignationId = ds.DesignationId where e.EmployeeId= '" + id + "'";
                    SqlCommand cmd = new SqlCommand(querry, cnn);
                    cnn.Open();
                    adapter = new SqlDataAdapter(querry, cnn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Grddetails.DataSource = dataTable;
                    cnn.Close();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void ListView1_MouseClick(object sender, MouseEventArgs e)
         {
            try
            {
                if (chk_Portrait.Checked == true)
                {
                    lblCname.Text = listView1.FocusedItem.SubItems[3].Text;
                    txtReadCardData.Text = listView1.FocusedItem.SubItems[5].Text;
                    id = Int32.Parse(listView1.SelectedItems[0].Text);
                }
                else
                {
                    lblCname.Text = listView1.FocusedItem.SubItems[3].Text;
                    txtReadCardData.Text = listView1.FocusedItem.SubItems[5].Text;
                    id = Int32.Parse(listView1.SelectedItems[0].Text);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_Portrait.Checked == true)
                {

                    //qry = "select id,gender,ccode,cname,mobileno from icardinfo where CAST(concat(ccode,cname,mobileno) AS CHAR) like '%" + txtSearch.Text + "%'";
                    listView1.Items.Clear();
                    qry = "select LedgerId as id,gender,LedgerCode as ccode,LedgerName as cname,Mobile as mobileno,icardno as icardno from  tblAccountLedger where CAST(concat(LedgerCode,LedgerName,Mobile) AS CHAR) like '%" + txtSearch.Text + "%' and cardtype=143";
                    ListCustomerData();
                }
                else
                {
                    listView1.Items.Clear();
                    //qry = "select emp_id,gender,ecode,ename,mobno from emp where CAST(concat(ecode,ename,mobno) AS CHAR) like '%" + txtSearch.Text + "%'";
                    qry = "select EmployeeId as emp_id,gender,EmployeeCode as ecode,EmployeeName as ename,'' as eAdd1,'' as eAdd2,'' as eAdd3,DOB as dob,'' as blood,Mobile as mobno,icardno as icardno from tblEmployee where CAST(concat(EmployeeCode,EmployeeName,Mobile) AS CHAR) like '%" + txtSearch.Text + "%'";
                    ListEmployeeData();
                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
                cnn.Close();
            }
        }
        private void BtnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = "";
                txtReadCardData.Clear();
                str1 = AYJ_CardLib_Mi.AYJ_ReadCardLib_Mi.ReadCard_Mi();
                if (str1 == "" || string.IsNullOrWhiteSpace(str1) || str1 == "FailAuthenticationFailAuthenticationFailAuthentication")
                {
                    MessageBox.Show("Reading");
                    //MessageBox.Show(AYJ_CardLib_Ul.AYJ_ReadCardLib_Ul.ReadCard_Ul());
                    str1 = AYJ_CardLib_Ul.AYJ_ReadCardLib_Ul.ReadCard_Ul();

                    //if (reader.isCardAvailable())
                    //{
                    //    txtReadCardData.Clear();
                    //    txtReadCardData.Text = ReadFromCard();
                    //    rcount = 0;//setting value to zero after complete reading
                    //    first_16 = "";
                    //    second_16 = "";
                    //    third_16 = "";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Card not in contact", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}



                }
                else
                {
                    //MessageBox.Show(AYJ_CardLib_Mi.AYJ_ReadCardLib_Mi.ReadCard_Mi());
                    str1 = AYJ_CardLib_Mi.AYJ_ReadCardLib_Mi.ReadCard_Mi();

                }

                txtReadCardData.Text = str1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TxtReadCardData_TextChanged(object sender, EventArgs e)
        {
            if (txtReadCardData.Text != "")
                btnSaveRFID.Enabled = true;
            else
                btnSaveRFID.Enabled = false;
        }
        private void BtnSaveRFID_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Portrait.Checked == true)
                {


                    string Query = "update tblAccountLedger set ICardNo='" + txtReadCardData.Text + "' where LedgerId='" + id + "';";
                    SqlConnection connection = new SqlConnection(con);
                    connection.Open();
                    SqlDataAdapter SQLAdapter = new SqlDataAdapter();
                    SQLAdapter.UpdateCommand = new SqlCommand(Query, connection);
                    SQLAdapter.UpdateCommand.ExecuteNonQuery();
                    connection.Close();

                    //string Query = "update inv_jm.icardinfo set rfid='" + txtReadCardData.Text + "' where id='" + id + "';";
                    //SqlCommand MyCommand2 = new SqlCommand(Query, cnn);
                    //SqlDataReader MyReader2;
                    //cnn.Open();
                    //MyReader2 = MyCommand2.ExecuteReader();
                    //cnn.Close();
                    //MyCommand2.Dispose();
                }
                else
                {

                    string Query = "update tblEmployee set ICardNo='" + txtReadCardData.Text + "' where EmployeeId='" + id + "';";
                    SqlConnection connection = new SqlConnection(con);
                    connection.Open();
                    SqlDataAdapter SQLAdapter = new SqlDataAdapter();
                    SQLAdapter.UpdateCommand = new SqlCommand(Query, connection);
                    SQLAdapter.UpdateCommand.ExecuteNonQuery();
                    connection.Close();

                    //string Query = "update inv_jm.emp set rfid='" + txtReadCardData.Text + "' where emp_id='" + id + "';";
                    //SqlCommand MyCommand2 = new SqlCommand(Query, cnn);
                    //SqlDataReader MyReader2;
                    //cnn.Open();
                    //MyReader2 = MyCommand2.ExecuteReader();
                    //cnn.Close();
                    //MyCommand2.Dispose();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
            txtReadCardData.Text = "";
        }
        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // var lvwColumnSorter = new ListViewColumnSorter();
            //if (e.Column == lvwColumnSorter.SortColumn)
            //{
            // Reverse the current sort direction for this column.
            //if (lvwColumnSorter.Order == SortOrder.Ascending)
            //{
            //  lvwColumnSorter.Order = SortOrder.Descending;
            // }
            // else
            // {
            // lvwColumnSorter.Order = SortOrder.Ascending;
            // }
            // }
            // else
            //  {
            // Set the column number that is to be sorted; default to ascending.
            // lvwColumnSorter.SortColumn = e.Column;
            // lvwColumnSorter.Order = SortOrder.Ascending;
            // }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
        private void BtnPnlClose_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            txtSearch.Clear();
            txtReadCardData.Clear();
            lblCname.Text = "";
            pnlList.Visible = false;
            listView1.Columns.Clear();

        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }


        private void Chk_Portrait_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DeleteDirectory(Img_Path);
                picBox_CardF.Image = Properties.Resources.CardF;
                picBox_CardB.Image = Properties.Resources.StudentB;
                picBox_Ls_CardF.Image = Properties.Resources.StaffF;
                picBox_Ls_CardB.Image = Properties.Resources.StaffB;

                if (txtFile.Text != "" || txt_ImgPath.Text != "")
                {
                    txtFile.Text = "";
                    // txt_ImgPath.Text = "";
                    Grddetails.DataSource = null;
                }

                if (chk_Portrait.Checked == false)
                {
                    chk_Portrait.Text = "Staff Card";//Properties.Resources.CardF;
                    this.Size = new Size(1209, 655);
                    Grddetails.Size = new Size(947, 520);
                    this.CenterToScreen();
                }
                else
                {
                    chk_Portrait.Text = "Student Card";
                    this.Size = new Size(975, 655);
                    Grddetails.Size = new Size(947, 270);
                    this.CenterToScreen();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void Grddetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string CellValue = Grddetails.CurrentRow.Cells[0].Value.ToString();
                ImgF_FileName = CellValue + "_0F.jpg";
                ImgB_FileName = CellValue + "_1B.jpg";
                string folderPath = FoldPath + "\\";

                if (File.Exists(folderPath + ImgF_FileName) && File.Exists(folderPath + ImgB_FileName))
                {
                    PrintCard();
                }
                if (chk_Portrait.Checked == false)
                {
                    if (File.Exists(folderPath + ImgF_FileName))
                    {
                        picBox_CardF.Image = System.Drawing.Image.FromFile(folderPath + ImgF_FileName);

                        // fit image in picture box 
                        var imageSize = picBox_CardF.Image.Size;
                        var fitSize = picBox_CardF.ClientSize;
                        picBox_CardF.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.StretchImage;
                    }
                    if (File.Exists(folderPath + ImgB_FileName))
                    {
                        picBox_CardB.BackgroundImage = System.Drawing.Image.FromFile(folderPath + ImgB_FileName);

                        // fit image in picture box 
                        var imageSize = picBox_CardB.BackgroundImage.Size;
                        var fitSize = picBox_CardB.ClientSize;
                        picBox_CardB.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
                    }
                }
                else
                {
                    if (File.Exists(folderPath + ImgF_FileName))
                    {
                        picBox_Ls_CardF.Image = System.Drawing.Image.FromFile(folderPath + ImgF_FileName);

                        // fit image in picture box 
                        var imageSize = picBox_Ls_CardF.Image.Size;
                        var fitSize = picBox_Ls_CardF.ClientSize;
                        picBox_Ls_CardF.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
                    }
                    if (File.Exists(folderPath + ImgB_FileName))
                    {
                        picBox_Ls_CardB.Image = System.Drawing.Image.FromFile(folderPath + ImgB_FileName);

                        // fit image in picture box 
                        var imageSize = picBox_Ls_CardB.Image.Size;
                        var fitSize = picBox_Ls_CardB.ClientSize;
                        picBox_Ls_CardB.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
                    }

                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            }
        }
        private void Grddetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DeleteDirectory(Img_Path);
        }
        private void FrmExcelUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    switch (e.CloseReason)
            //    {
            //        case CloseReason.UserClosing:
            //            if (MetroMessageBox.Show(this, "Are you sure you want to exit?", "IDCard Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk & MessageBoxIcon.Information) == DialogResult.Yes)
            //            {

            //                e.Cancel = true;
            //                this.Hide();
            //                Forms.dashboard frmdash = new dashboard();
            //                frmdash.ShowDialog();


            //            }
            //            else
            //            {


            //                Application.Exit();

            //            }

            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MetroMessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Asterisk & MessageBoxIcon.Information);
            //}
        }

        private void FrmExcelUpload_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteDirectory(Img_Path);

            if (MetroMessageBox.Show(this, "Are you sure you want to exit?", "IDCard Printing", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk & MessageBoxIcon.Information) == DialogResult.Yes)
            {

                //e.Cancel = true;
                this.Hide();
                Forms.dashboard frmdash = new dashboard();
                frmdash.ShowDialog();
            }
            else
            {
                //Application.Exit();
            }



        }



    }

}