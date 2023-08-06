using ReaderSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDCardPrintingwithRFID
{
    public partial class Form1 : Form
    {

        private ACR122 reader;//for reader
        int rcount = 0;
        string first_16;
        string second_16;
        string third_16;
        string read_encodedno;// to hold the encoded number completely
        public Form1()
        {
            InitializeComponent();
            reader = new ACR122();
            try
            {
                reader.readerInit();
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Index"))
                {
                    MessageBox.Show("\n\nInstall proper driver first\n Application exiting", "Intercard Encoding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("\n\n" + ex.Message, "Intercard Encoding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (reader.isCardAvailable())
                {
                    txtCardData.Clear();
                    txtCardData.Text = ReadFromCard();
                    rcount = 0;//setting value to zero after complete reading
                    first_16 = "";
                    second_16 = "";
                    third_16 = "";
                }
                else
                {
                    MessageBox.Show("Card not in contact");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
