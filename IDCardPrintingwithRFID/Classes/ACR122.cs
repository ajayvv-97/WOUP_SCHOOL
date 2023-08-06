using System;
using System.Collections.Generic;
using System.Linq;
using CardSettings;
//using RFIDReadWrite.interfaces;

namespace ReaderSettings
{
    public class ACR122
    {

        int retCode;
        int hCard;
        int hContext;
        int Protocol;
        public bool isConnActive = false;
        public string readername = "ACS ACR122 0";// change depending on reader
        byte[] SendBuff = new byte[263];
        byte[] RecvBuff = new byte[263];
        int SendLen, RecvLen; //Aprotocol;
        Card.SCARD_READERSTATE RdrState;
        Card.SCARD_IO_REQUEST pioSendRequest;
        //int count;
        //public int scount;

        public bool readerInit()
        {
            selectDevice();
            if (connectToReader())
            {
                return true;
            }
            return false;

        }

        public string getDataFromTag(int rcount)//rcount is a parameter added newly
        {
            string value = "";
            if (isCardAvailable())
            {
                value = readBlock(rcount);
                value = value.Split(new char[] { '\0' }, 2, StringSplitOptions.None)[0].ToString();
                return value;
            }
            return "disConnected";


        }

        private string readBlock(int Rcount)
        {
            string tmpStr = "";

            if (Rcount == 0)
            {
                // string tmpStr = "";
                int indx;
                ClearBuffers();
                SendBuff[0] = 0xFF; // CLA   -----255
                SendBuff[1] = 0xB0;// INS -----176
                SendBuff[2] = 0x00;// P1   --------0
                                   // SendBuff[3] = (byte)int.Parse(Block);// P2 : Block No.
                                   //SendBuff[4] = (byte)int.Parse("16");// Le
                SendBuff[3] = 0x04;// P2 : Block No.--------05  "STARTING OF THE BLOCK NUMBER
                                   //  SendBuff[4] = 0x10;    //----16
                SendBuff[4] = 0x10;//12 byte
                SendLen = 5;

                //  RecvLen = SendBuff[4] + 2;
                RecvLen = SendBuff[4] + 2;


                retCode = SendAPDUandDisplay(2);
                //for (indx = 0; indx <= SendLen; indx++)
                ////{
                //    Console.WriteLine(string.Format("{0:X2}", SendBuff[indx]));
                //}
                if (retCode == -200)
                {
                    return "outofrangeexception";
                }

                if (retCode == -202)
                {
                    return "BytesNotAcceptable";
                }

                if (retCode != Card.SCARD_S_SUCCESS)
                {
                    return "FailRead";
                }

                // Display data in text format
                for (indx = 0; indx <= RecvLen - 1; indx++)
                // for (indx = 0; indx <= 25; indx++)//akhil
                {
                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }
                Rcount++;
                //   return (tmpStr);
            }

            else if (Rcount == 1)//second 16 digits
            {
                //   string tmpStr = "";
                int indx;


                ClearBuffers();
                SendBuff[0] = 0xFF; // CLA   -----255
                SendBuff[1] = 0xB0;// INS -----176
                SendBuff[2] = 0x00;// P1   --------0
                                   // SendBuff[3] = (byte)int.Parse(Block);// P2 : Block No.
                                   //SendBuff[4] = (byte)int.Parse("16");// Le
                SendBuff[3] = 0X08;// 0x07;// P2 : Block No.--------05  "STARTING OF THE BLOCK NUMBER
                                   //  SendBuff[4] = 0x10;    //----16
                SendBuff[4] = 0x10;
                SendLen = 5;

                //  RecvLen = SendBuff[4] + 2;
                RecvLen = SendBuff[4] + 2;


                retCode = SendAPDUandDisplay(2);
                //for (indx = 0; indx <= SendLen; indx++)
                ////{
                //    Console.WriteLine(string.Format("{0:X2}", SendBuff[indx]));
                //}
                if (retCode == -200)
                {
                    return "outofrangeexception";
                }

                if (retCode == -202)
                {
                    return "BytesNotAcceptable";
                }

                if (retCode != Card.SCARD_S_SUCCESS)
                {
                    return "FailRead";
                }

                // Display data in text format
                for (indx = 0; indx <= RecvLen - 1; indx++)
                // for (indx = 0; indx <= 25; indx++)//akhil
                {
                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }
                Rcount++;
                //return (tmpStr);
            }
            //third region
            else if (Rcount == 2)//last 16 digits
            {
                //   string tmpStr = "";
                int indx;
                ClearBuffers();
                SendBuff[0] = 0xFF; // CLA   -----255
                SendBuff[1] = 0xB0;// INS -----176
                SendBuff[2] = 0x00;// P1   --------0
                                   // SendBuff[3] = (byte)int.Parse(Block);// P2 : Block No.
                                   //SendBuff[4] = (byte)int.Parse("16");// Le
                SendBuff[3] = 0x0C;// P2 : Block No.--------05  "STARTING OF THE BLOCK NUMBER
                                   //  SendBuff[4] = 0x10;    //----16
                SendBuff[4] = 0x10;
                SendLen = 5;

                //  RecvLen = SendBuff[4] + 2;
                RecvLen = SendBuff[4] + 2;
                retCode = SendAPDUandDisplay(2);
                //for (indx = 0; indx <= SendLen; indx++)
                ////{
                //    Console.WriteLine(string.Format("{0:X2}", SendBuff[indx]));
                //}
                if (retCode == -200)
                {
                    return "outofrangeexception";
                }

                if (retCode == -202)
                {
                    return "BytesNotAcceptable";
                }

                if (retCode != Card.SCARD_S_SUCCESS)
                {
                    return "FailRead";
                }

                // Display data in text format
                for (indx = 0; indx <= RecvLen - 1; indx++)
                // for (indx = 0; indx <= 25; indx++)//akhil
                {
                    tmpStr = tmpStr + Convert.ToChar(RecvBuff[indx]);
                }
              //  Rcount++;
                //return (tmpStr);
            }
            return (tmpStr);
        }


        public string WriteCardGeneral(int dataLength, string data)
        {
            string result = "";
            if (dataLength != data.Length)
            {
                return "data and length mismatching";
            }
            else
            {
               
                switch (dataLength)
                {
                    case 4:
                       
                        result = writeDataGeneral(data.Substring(0), 0x04);
                        break;
                    case 8:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        break;
                    case 12:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        break;
                    case 16:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        break;
                    case 20:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        break;
                    case 24:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        result += writeDataGeneral(data.Substring(20), 0x09);


                        break;
                    case 28:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        result += writeDataGeneral(data.Substring(20), 0x09);
                        result += writeDataGeneral(data.Substring(24), 0x0A);
                        break;
                    case 32:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        result += writeDataGeneral(data.Substring(20), 0x09);
                        result += writeDataGeneral(data.Substring(24), 0x0A);
                        result += writeDataGeneral(data.Substring(28), 0x0B);
                        break;

                    case 36:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        result += writeDataGeneral(data.Substring(20), 0x09);
                        result += writeDataGeneral(data.Substring(24), 0x0A);
                        result += writeDataGeneral(data.Substring(28), 0x0B);
                        result += writeDataGeneral(data.Substring(32), 0x0C);

                        break;
                    case 40:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        result += writeDataGeneral(data.Substring(20), 0x09);
                        result += writeDataGeneral(data.Substring(24), 0x0A);
                        result += writeDataGeneral(data.Substring(28), 0x0B);
                        result += writeDataGeneral(data.Substring(32), 0x0C);
                        result += writeDataGeneral(data.Substring(36), 0x0D);
                        break;
                    case 44:
                        result += writeDataGeneral(data.Substring(0), 0x04);
                        result += writeDataGeneral(data.Substring(4), 0x05);
                        result += writeDataGeneral(data.Substring(8), 0x06);
                        result += writeDataGeneral(data.Substring(12), 0x07);
                        result += writeDataGeneral(data.Substring(16), 0x08);
                        result += writeDataGeneral(data.Substring(20), 0x09);
                        result += writeDataGeneral(data.Substring(24), 0x0A);
                        result += writeDataGeneral(data.Substring(28), 0x0B);
                        result += writeDataGeneral(data.Substring(32), 0x0C);
                        result += writeDataGeneral(data.Substring(36), 0x0D);
                        result += writeDataGeneral(data.Substring(40), 0x0E);

                        break;
                    case 48:
                        result += writeDataGeneral(data.Substring(0), 0x04);                       
                        result += writeDataGeneral(data.Substring(4), 0x05);                     
                        result += writeDataGeneral(data.Substring(8), 0x06);                      
                        result += writeDataGeneral(data.Substring(12), 0x07);               
                        result += writeDataGeneral(data.Substring(16), 0x08);                
                        result += writeDataGeneral(data.Substring(20), 0x09);                  
                        result += writeDataGeneral(data.Substring(24), 0x0A);               
                        result += writeDataGeneral(data.Substring(28), 0x0B);                    
                        result += writeDataGeneral(data.Substring(32), 0x0C);                
                        result += writeDataGeneral(data.Substring(36), 0x0D);                 
                        result += writeDataGeneral(data.Substring(40), 0x0E);
                        result += writeDataGeneral(data.Substring(44), 0x0F);                       
                        break;
                    default:

                        result = "unable to write";

                        break;
                }
            }
            return result;

        }

        private string writeDataGeneral(String Text, byte block)
        {
            String tmpStr = Text;
            Console.WriteLine(tmpStr);
            int indx;
            ClearBuffers();
            SendBuff[0] = 0xFF;                             // CLA
            SendBuff[1] = 0xD6;                             // INS
            SendBuff[2] = 0x00;                             // P1
            SendBuff[3] = block;         // P2 : Starting Block No.
            SendBuff[4] = 0x04;          // P3 : Data length
            for (indx = 0; indx <= (tmpStr).Length - 1; indx++)
            {
                SendBuff[indx + 5] = (byte)tmpStr[indx];
            }
            SendLen = SendBuff[4] + 5;
            RecvLen = 0x02;
            retCode = SendAPDUandDisplay(2);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                return "failed to write";
            }
            else
            {
                return "write success";
            }
        }


        public string clearString()// to write data into card
        {
            string result = "";
            string a = string.Empty;

            result+= writeDataGeneral(a, 0x04);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x05);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x06);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x07);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x08);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x09);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x0A);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x0B);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x0C);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x0D);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x0E);
            Console.WriteLine(result);
            result+= writeDataGeneral(a, 0x0F);
            Console.WriteLine(result);
            #region to lock 
            //result = writeData("", 0x02);
            //Console.WriteLine(result);
            #endregion
            return result;
        }

       

        public bool isCardAvailable()
        {
            isConnActive = true;

            retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED,
                      Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != Card.SCARD_S_SUCCESS)
            {

                isConnActive = false;
                return false;
            }
            return true;
        }
        // block authentication
        private bool authenticateBlock(String block)
        {
            ClearBuffers();
            SendBuff[0] = 0xFF;                         // CLA
            SendBuff[2] = 0x00;                         // P1: same for all source types 
            SendBuff[1] = 0x86;                         // INS: for stored key input
            SendBuff[3] = 0x00;                         // P2 : Memory location;  P2: for stored key input
            SendBuff[4] = 0x05;                         // P3: for stored key input
            SendBuff[5] = 0x01;                         // Byte 1: version number
            SendBuff[6] = 0x00;                         // Byte 2
            SendBuff[7] = (byte)int.Parse(block);       // Byte 3: sectore no. for stored key input
            SendBuff[8] = 0x60;                         // Byte 4 : Key A for stored key input
            SendBuff[9] = (byte)int.Parse("1");         // Byte 5 : Session key for non-volatile memory

            SendLen = 0x0A;
            RecvLen = 0x02;

            retCode = SendAPDUandDisplay(0);

            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //MessageBox.Show("FAIL Authentication!");
                return false;
            }

            return true;
        }
        // clear memory buffers
        private void ClearBuffers()
        {
            long indx;

            for (indx = 0; indx <= 262; indx++)
            {
                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;
            }
        }
        // send application protocol data unit : communication unit between a smart card reader and a smart card
        private int SendAPDUandDisplay(int reqType)
        {
            int indx;
            string tmpStr = "";

            //pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            //Display Apdu In
            for (indx = 0; indx <= SendLen - 1; indx++)
            {
                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);



            }
            //   tmpStr = "FF B0 00 04 14";

            retCode = Card.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0],
                                 SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != Card.SCARD_S_SUCCESS)
            {
                return retCode;
            }

            else
            {
                try
                {
                    tmpStr = "";
                    switch (reqType)
                    {
                        case 0:
                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {
                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            if ((tmpStr).Trim() != "90 00")
                            {
                                //MessageBox.Show("Return bytes are not acceptable.");
                                return -202;
                            }

                            break;

                        case 1:

                            for (indx = (RecvLen - 2); indx <= (RecvLen - 1); indx++)
                            {
                                tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            if (tmpStr.Trim() != "90 00")
                            {
                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            else
                            {
                                tmpStr = "ATR : ";
                                for (indx = 0; indx <= (RecvLen - 3); indx++)
                                {
                                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                                }
                            }

                            break;

                        case 2:

                            for (indx = 0; indx <= (RecvLen - 1); indx++)
                            // for (indx = 0; indx <= (21); indx++)
                            {
                                tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                            }

                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    return -200;
                }
            }
            return retCode;
        }
        //disconnect card reader connection
        public void disConnectDevice()
        {
            if (isConnActive)
            {
                retCode = Card.SCardDisconnect(hCard, Card.SCARD_UNPOWER_CARD);
            }
            retCode = Card.SCardReleaseContext(hCard);
        }

        public string getTagUID()//only for mifare 1k cards
        {
            string cardUID = "";
            byte[] receivedUID = new byte[256];
            Card.SCARD_IO_REQUEST request = new Card.SCARD_IO_REQUEST();
            request.dwProtocol = Card.SCARD_PROTOCOL_T1;
            request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Card.SCARD_IO_REQUEST));
            byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //get UID command      for Mifare cards
            int outBytes = receivedUID.Length;
            int status = Card.SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);

            if (status != Card.SCARD_S_SUCCESS)
            {
                //cardUID = "Error";
            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToLower();
            }

            return cardUID;
        }

        public void selectDevice()
        {
            List<string> availableReaders = this.ListReaders();
            this.RdrState = new Card.SCARD_READERSTATE();
            readername = availableReaders[0].ToString();//selecting first device
            this.RdrState.RdrName = readername;
        }

        public void reConnect()
        {
            connectToReader();
        }

        public List<string> ListReaders()
        {
            int ReaderCount = 0;
            List<string> AvailableReaderList = new List<string>();
            Console.WriteLine(AvailableReaderList);
            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            retCode = Card.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                // MessageBox.Show(Card.GetScardErrMsg(retCode));
                //connActive = false;
            }

            byte[] ReadersList = new byte[ReaderCount];

            //Get the list of reader present again but this time add sReaderGroup, retData as 2rd & 3rd parameter respectively.
            retCode = Card.SCardListReaders(hContext, null, ReadersList, ref ReaderCount);
            Console.WriteLine(retCode + "  - output");
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                // MessageBox.Show(Card.GetScardErrMsg(retCode));
            }

            string rName = "";
            int indx = 0;
            if (ReaderCount > 0)
            {
                // Convert reader buffer to string
                while (ReadersList[indx] != 0)
                {

                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }

                    //Add reader name to list
                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;

                }
            }
            return AvailableReaderList;

        }

        internal bool connectToReader()
        {
            retCode = Card.SCardEstablishContext(Card.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                isConnActive = false;
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
