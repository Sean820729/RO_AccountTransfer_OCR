using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

using tessnet2;

namespace OCR_ROTransfer
{
    public partial class Form1 : Form
    {
        CookieContainer myCookieContainer = new CookieContainer();

        public Form1()
        {
            InitializeComponent();
        }

        private void FilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // 預設路徑
            ofd.Filter = "Config.txt Files (*.txt)|*.txt; *.cpp|All Files (*.*)|*.*";
            ofd.Title = "請開啟文字檔案";

            if (ofd.ShowDialog(this) == DialogResult.Cancel)
                return;
            FilePath_text.Text = ofd.FileName;

            string[] lines = File.ReadAllLines(FilePath_text.Text, Encoding.UTF8);
            string[][] Account = new string[lines.Length][];

            int Cnt = 1;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    Account[i] = new string[2];
                    //Account[i][0] = lines[i].Split(new string[] { " 帳號:" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] tmp = lines[i].Split(new string[] { " 帳號:" }, StringSplitOptions.RemoveEmptyEntries);
                    tmp = tmp[1].Split(new string[] { " 密碼:" }, StringSplitOptions.RemoveEmptyEntries);
                    Account[i][0] = tmp[0];
                    tmp = tmp[1].Split(new string[] { " 遊戲信箱:" }, StringSplitOptions.RemoveEmptyEntries);
                    Account[i][1] = tmp[0];

                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    item.SubItems[0].Text = (Cnt++).ToString();
                    item.SubItems.Add(Account[i][0]);
                    item.SubItems.Add(Account[i][1]);
                    item.SubItems.Add("");
                    Account_listView.Items.Add(item);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Account_listView.GridLines = true;
            Account_listView.FullRowSelect = true;

            Account_listView.View = View.Details;
            Account_listView.Scrollable = true;
            Account_listView.MultiSelect = false;

            Account_listView.Columns.Add("", 50, HorizontalAlignment.Left);
            Account_listView.Columns.Add("帳號", 160, HorizontalAlignment.Left);
            Account_listView.Columns.Add("密碼", 160, HorizontalAlignment.Left);
            Account_listView.Columns.Add("確認", 50, HorizontalAlignment.Left);
        }

        private void VeriImage_picturebox_Click(object sender, EventArgs e)
        {
            GetValidateImage();

            string Veri = OCR();
            if (Veri != "")
            {
                VeriCode_textbox.Text = Veri;
                button2_Click(null, null);
            }
            else
            {
                VeriImage_picturebox_Click(null, null);
            }
        }

        private void GetValidateImage()
        {
            myCookieContainer = new CookieContainer();
            string url = "https://gfb.gameflier.com/Billing/s_code/spic.aspx";  //验证码页面
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "*/*";
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0";
            request.CookieContainer = new CookieContainer(); //暂存到新实例
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();//得到验证码数据流
            Bitmap sourcebm = new Bitmap(resStream);//初始化Bitmap图片

            /*--------------------------------------------------------------------*/
            for (int i = 0; i < sourcebm.Width; i++)
            {
                for (int j = 0; j < sourcebm.Height; j++)
                {
                    //获取该点的像素的RGB的颜色  
                    Color color = sourcebm.GetPixel(i, j);
                    //利用公式计算灰度值  
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    sourcebm.SetPixel(i, j, newColor);
                }
            }
            /*--------------------------------------------------------------------*/

            /*--------------------------------------------------------------------*/
            Bitmap Bmp = sourcebm;
            Bitmap NewBmp = sourcebm;

            for (int i = 0; i < Bmp.Height; i++) //Pixel Y
            {
                for (int j = 0; j < Bmp.Width; j++) //Pixel X
                {
                    if (Bmp.GetPixel(j, i).Name == "ff000000" && j < 5 && i > 5)
                    {
                        // 向左平移
                        if (Bmp.GetPixel(0, i).Name == "ff000000")
                        {
                            for (int idxCol = 1; idxCol < Bmp.Width; ++idxCol)
                            {
                                int idxColDst = idxCol - 1;
                                Color crSrc = NewBmp.GetPixel(idxCol, i);
                                NewBmp.SetPixel(idxColDst, i, crSrc);
                            }
                        }
                        // 向右平移
                        if (Bmp.GetPixel(Bmp.Width - 1, i).Name == "ff000000" && j >= 235 && i > 5)
                        {
                            for (int idxCol = Bmp.Width - 2; idxCol >= 0; --idxCol)
                            {
                                int idxColDst = idxCol + 1;
                                Color crSrc = NewBmp.GetPixel(idxCol, i);
                                NewBmp.SetPixel(idxColDst, i, crSrc);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < Bmp.Height; i++) //Pixel Y
            {
                for (int j = 0; j < Bmp.Width; j++) //Pixel X
                {
                    if (Bmp.GetPixel(j, i).Name == "ff000000")
                    {
                        // 向上平移
                        if (Bmp.GetPixel(j, 0).Name == "ff000000")
                        {
                            for (int idxRow = 1; idxRow < Bmp.Height; ++idxRow)
                            {
                                int idxRowDst = idxRow - 1;
                                Color crSrc = NewBmp.GetPixel(j, idxRow);
                                NewBmp.SetPixel(j, idxRowDst, crSrc);
                            }
                        }
                        // 向下平移
                        if (Bmp.GetPixel(j, Bmp.Height - 1).Name == "ff000000")
                        {
                            for (int idxRow = Bmp.Height - 2; idxRow >= 0; --idxRow)
                            {
                                int idxRowDst = idxRow + 1;
                                Color crSrc = NewBmp.GetPixel(j, idxRow);
                                NewBmp.SetPixel(j, idxRowDst, crSrc);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Bmp.Height; i++) //Pixel Y
            {
                for (int j = 0; j < Bmp.Width; j++) //Pixel X
                {
                    if (Bmp.GetPixel(j, i).Name == "ff000000" && j < 5 && i > 5)
                    {
                        // 向左平移
                        if (Bmp.GetPixel(0, i).Name == "ff000000")
                        {
                            for (int idxCol = 1; idxCol < Bmp.Width; ++idxCol)
                            {
                                int idxColDst = idxCol - 1;
                                Color crSrc = NewBmp.GetPixel(idxCol, i);
                                NewBmp.SetPixel(idxColDst, i, crSrc);
                            }
                        }
                        // 向右平移
                        if (Bmp.GetPixel(Bmp.Width - 1, i).Name == "ff000000" && j >= 235 && i > 5)
                        {
                            for (int idxCol = Bmp.Width - 2; idxCol >= 0; --idxCol)
                            {
                                int idxColDst = idxCol + 1;
                                Color crSrc = NewBmp.GetPixel(idxCol, i);
                                NewBmp.SetPixel(idxColDst, i, crSrc);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < Bmp.Height; i++) //Pixel Y
            {
                for (int j = 0; j < Bmp.Width; j++) //Pixel X
                {
                    if (Bmp.GetPixel(j, i).Name == "ff000000")
                    {
                        // 向上平移
                        if (Bmp.GetPixel(j, 0).Name == "ff000000")
                        {
                            for (int idxRow = 1; idxRow < Bmp.Height; ++idxRow)
                            {
                                int idxRowDst = idxRow - 1;
                                Color crSrc = NewBmp.GetPixel(j, idxRow);
                                NewBmp.SetPixel(j, idxRowDst, crSrc);
                            }
                        }
                        // 向下平移
                        if (Bmp.GetPixel(j, Bmp.Height - 1).Name == "ff000000")
                        {
                            for (int idxRow = Bmp.Height - 2; idxRow >= 0; --idxRow)
                            {
                                int idxRowDst = idxRow + 1;
                                Color crSrc = NewBmp.GetPixel(j, idxRow);
                                NewBmp.SetPixel(j, idxRowDst, crSrc);
                            }
                        }
                    }
                }
            }

            string[,] BackColor = new string[120, 45];
            string[] RecordColor = new string[3150];
            int Count = 0;

            for (int i = 0; i < Bmp.Height; i++)
            {
                for (int j = 0; j < Bmp.Width; j++)
                {
                    BackColor[j, i] = Bmp.GetPixel(j, i).Name;
                    if (i < 5 || i > 35 || j < 10 || j > 100)
                    {
                        for (int k = 0; k < RecordColor.Length; k++)
                        {
                            if (Bmp.GetPixel(j, i).Name != RecordColor[k] && RecordColor[k] == null)
                            {
                                RecordColor[k] = Bmp.GetPixel(j, i).Name;
                                Count++;
                                break;
                            }
                            else if (Bmp.GetPixel(j, i).Name == RecordColor[k])
                            {
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < Bmp.Height; i++) //Pixel Y
            {
                for (int j = 0; j < Bmp.Width; j++) //Pixel X
                {
                    for (int k = 0; k < Count; k++)
                    {
                        if (Bmp.GetPixel(j, i).Name == RecordColor[k])
                        {
                            Bmp.SetPixel(j, i, Color.White);
                        }
                    }
                }
            }
            VeriImage_picturebox.Image = Bmp;
            /*--------------------------------------------------------------------*/
            foreach (Cookie cook in response.Cookies)
            {
                //MessageBox.Show(String.Format("{0} = {1}", cook.Name, cook.Value));
                if (cook.Name == "scode")
                {
                    //String 的Cookie　要轉成　Cookie型的　並放入CookieContainer中
                    Cookie ck = new Cookie(cook.Name, cook.Value);
                    ck.Domain = "gfb.gameflier.com";//必須寫對
                    myCookieContainer.Add(ck);
                }
            }
        }

        private string OCR()
        {
            string Veri = "";
            var ocr = new Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"); // If digit only
            //@"C:\OCRTest\tessdata" contains the language package, without this the method crash and app breaks
            ocr.Init(@".\tessdata", "eng", false);
            var result = ocr.DoOCR((Bitmap)VeriImage_picturebox.Image, Rectangle.Empty);
            foreach (Word word in result)
            {
                if (word.Text.Length == 4)
                    Veri = word.Text;
            }
            return Veri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = null;
            string url = "https://gfb.gameflier.com/Billing/Login/login_check.asp";   //登录页面
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            request.Accept = "*/*;";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.93 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = true;
            request.CookieContainer = myCookieContainer;
            request.KeepAlive = true;

            string postData = string.Format("redct=A12&gametype=ROOF&MW2_Argu01=&MW2_Argu02=&oid_game=&oid_method=&my_TRADE_NO=&my_GAME_TNO=" + 
                    "&my_VerifyCode=&my_ReUrl=&my_banksn=&my_bankname=&my_bankprice=&my_projectid=&my_cardtype=&gshop_store=" + 
                    "&web_id={0}&pwd={1}&pcode={2}&Submit3=+%E7%99%BB++%E5%85%A5+",
                    "cMkzUE7id", "m4kquvnwiqp", VeriCode_textbox.Text
                    );
            byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = postdatabyte.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(postdatabyte, 0, postdatabyte.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string strWebData = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                strWebData = reader.ReadToEnd();
            }

            //File.WriteAllText("WebData.txt", strWebData, Encoding.UTF8);

            if (strWebData.Contains("Error"))
            {
                VeriImage_picturebox_Click(null, null);
            }
            else
            {
                MessageBox.Show(request.CookieContainer.Count.ToString());
                // 轉移
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://gfb.gameflier.com/Billing/ONLINE_SERVICES/ROOF/action/20160406/index.aspx");
                req.Method = "GET";
                req.CookieContainer = request.CookieContainer;
                using (WebResponse wr = req.GetResponse())
                {
                    //在這裡對接收到的頁面內容進行處理
                    using (StreamReader myStreamReader = new StreamReader(wr.GetResponseStream()))
                    {

                        string data = myStreamReader.ReadToEnd();

                        //Console.WriteLine("data:" + data);
                        File.WriteAllText("WebData.txt", data, Encoding.UTF8);
                    }
                }

                // 判斷轉移
            }
        }
    }
}
