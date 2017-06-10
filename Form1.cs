using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZXing;

namespace PrinterTest
{
    public partial class Form1 : Form
    {
        Thread thread;
        delegate void SetTextCallback(string text);
        private string FileName;
        int PaperWidth = 320;
        int PaperHeight = 320;
        int topmargin = 0;  //顶边距
        int bottommargin = 0; //底边距
        int leftmargin = 0;  //左边距
        int rightmargin = 0; //右边距
        int PrintWidth = 320;
        int PrintHeight = 320;
        int GrayThreshold = 128; 

        Bitmap myBitmap2 = new Bitmap(320, 320);
        public Form1()
        {
            InitializeComponent();
            thread = new Thread(senddata);
            comboBox7.SelectedIndex = 3;//字体：中文16*16
            comboBox8.SelectedIndex = 0;//对齐方式:左对齐
            comboBox4.SelectedIndex = 2;//打印条形码默认值EAN8
            comboBox5.SelectedIndex = 2;//打印二维码默认值QR-CODE
            label7.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
                {
                    comboBox1.Items.Add(port.Normalize());
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = comboBox1.Text.Normalize();
                serialPort1.BaudRate = Convert.ToInt32(comboBox3.Text.Trim());
                try
                {
                    serialPort1.Open();
                    byte[] sendsuf = new byte[2];
                    sendsuf[0] = 0x1b;//初始化打印机
                    sendsuf[1] = 0x40;
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(sendsuf, 0, sendsuf.Length);
                    }
                    button1.Text = "关闭串口";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                serialPort1.Close();
                button1.Text = "打开串口";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//设置字间距
        {
            if (int.TryParse(textBox1.Text, out int result))
            {
                if (result > 0)
                {
                    byte[] sendsuf = new byte[3];
                    sendsuf[0] = 0x1b;//设置字间距
                    sendsuf[1] = 0x20;
                    sendsuf[2] = (byte)result;
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(sendsuf, 0, sendsuf.Length);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//设置行间距
        {
            byte[] sendsuf = new byte[3];
            if (int.TryParse(textBox2.Text, out int result))
            {
                sendsuf[0] = 0x1b;//设置行间距
                sendsuf[1] = 0x33;
                sendsuf[2] = (byte)result;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(sendsuf, 0, sendsuf.Length);
                }
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)//设置纸宽
        {
            if (int.TryParse(textBox14.Text, out int result))
            {
                if (result < 385)
                {
                    UpdatePaperParam();
                }
            }
        }

        private void UpdatePaperParam()
        {
            int.TryParse(textBox19.Text, out topmargin);
            int.TryParse(textBox20.Text, out bottommargin);
            int.TryParse(textBox3.Text, out leftmargin);
            int.TryParse(textBox4.Text, out rightmargin);
            int.TryParse(textBox14.Text, out PaperWidth);
            int.TryParse(textBox17.Text, out PaperHeight);

            PrintWidth = PaperWidth - leftmargin - rightmargin;
            PrintHeight = PaperHeight - topmargin - bottommargin;
            checkBox6.Text = "打印区域：" + PrintWidth + "*" + PrintHeight;
        }


        private void textBox17_TextChanged(object sender, EventArgs e)//设置纸高
        {
            if (int.TryParse(textBox17.Text, out int result))
            {
                if (result < 600)
                {
                    UpdatePaperParam();
                }
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)//顶边距
        {
            UpdatePaperParam();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)//底边距
        {
            UpdatePaperParam();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//右边距
        {
            UpdatePaperParam();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//设置左边距
        {
            UpdatePaperParam();

            if (int.TryParse(textBox17.Text, out int result))
            {
                byte[] sendsuf = new byte[3];
                sendsuf[0] = 0x1d;//设置左边距
                sendsuf[1] = 0x4c;
                sendsuf[2] = (byte)result;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(sendsuf, 0, sendsuf.Length);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//设置粗体
        {
            byte[] sendsuf = new byte[3];
            sendsuf[0] = 0x1b;
            sendsuf[1] = 0x45;
            sendsuf[2] = (byte)(checkBox1.Checked ? 0x01 : 0x00);

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//设置下划线1
        {
            byte[] sendsuf = new byte[3];
            sendsuf[0] = 0x1b;
            sendsuf[1] = 0x2d;
            sendsuf[2] = (byte)checkBox2.CheckState;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)//设置反白
        {
            byte[] sendsuf = new byte[3];
            sendsuf[0] = 0x1d;
            sendsuf[1] = 0x42;
            sendsuf[2] = (byte)(checkBox3.Checked ? 0x01 : 0x00);

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void button2_Click(object sender, EventArgs e)//打印文字
        {
            byte[] sendsuf = new byte[1024];
            byte temp = 0;
            if (radioButtonUnicode.Checked)
            {
                sendsuf = Encoding.Unicode.GetBytes(textBox5.Text);
                for (int i = 0; i < sendsuf.Length;)
                {
                    temp = sendsuf[i];
                    sendsuf[i] = sendsuf[i + 1];
                    sendsuf[i + 1] = temp;
                    i = i + 2;
                }
            }
            else if (radioButtonBIG5.Checked)
            {
                sendsuf = Encoding.GetEncoding("big5").GetBytes(textBox5.Text);
            }
            else
            {
                /*try
                {
                    sendsuf = Encoding.GetEncoding("GBK").GetBytes(textBox5.Text);

                  
                }
                catch (System.Exception ex)
                {
                    sendsuf = Encoding.Default.GetBytes(textBox5.Text);
                }*/
                //String str = "abcdefg123456ABCDEFG\r\n";
                sendsuf = Encoding.Default.GetBytes(textBox5.Text);
                /*for (int i = 0; i < sendsuf.Length; )
                {
                    temp = sendsuf;
                    sendsuf = sendsuf[i + 1];
                    sendsuf[i + 1] = temp;
                    i = i + 2;
                }*/
            }
            if (serialPort1.IsOpen)
            {

                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void button3_Click(object sender, EventArgs e)//初始化打印机
        {
            byte[] sendsuf = new byte[2];
            sendsuf[0] = 0x1b;//初始化打印机
            sendsuf[1] = 0x40;
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = textBox5.Font;
            //fontDialog1 = new System.Windows.Forms.FontDialog();
            DialogResult dr = fontDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox5.Font = fontDialog.Font;
            }
        }

        /// <summary>
        /// 打印并进纸n行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            byte[] sendsuf = new byte[3];
            if (int.TryParse(textBox7.Text, out int result))
            {
                sendsuf[0] = 0x1b;
                sendsuf[1] = 0x64;
                sendsuf[2] = (byte)result;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(sendsuf, 0, sendsuf.Length);
                }
            }
        }

        /// <summary>
        /// 打印并进纸n点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int result;
            byte[] sendsuf = new byte[3];
            if (int.TryParse(textBox6.Text, out result))
            {
                sendsuf[0] = 0x1b;
                sendsuf[1] = 0x4a;
                sendsuf[2] = (byte)result;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(sendsuf, 0, sendsuf.Length);
                }
            }

        }


        private void textBox8_TextChanged(object sender, EventArgs e)//图片
        {
            byte[] sendsuf = new byte[2];
            sendsuf[0] = 0x1c;
            sendsuf[1] = 0x4b;
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//旋转打印
        {
            byte[] sendsuf = new byte[3];
            sendsuf[0] = 0x1B;
            sendsuf[1] = 0x56;
            if (radioButton3.Checked)
            {
                sendsuf[2] = 0;
            }
            else if (radioButton4.Checked)
            {
                sendsuf[2] = 1;
            }
            else if (radioButton5.Checked)
            {
                sendsuf[2] = 2;
            }
            else if (radioButton6.Checked)
            {
                sendsuf[2] = 3;
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//定时打印
        {

            byte[] sendsuf;
            byte temp = 0;
            if (radioButtonUnicode.Checked)
            {
                sendsuf = Encoding.Unicode.GetBytes(textBox5.Text);
                for (int i = 0; i < sendsuf.Length;)
                {
                    temp = sendsuf[i];
                    sendsuf[i] = sendsuf[i + 1];
                    sendsuf[i + 1] = temp;
                    i = i + 2;
                }
            }
            else if (radioButtonBIG5.Checked)
            {
                sendsuf = Encoding.GetEncoding("big5").GetBytes(textBox5.Text);
            }
            else
            {
                sendsuf = Encoding.Default.GetBytes(textBox5.Text);
            }
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)//定时打印
        {
            if (checkBox5.Checked)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        public void SetText(string text)//刷新字库写入状态
        {
            if (label7.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                label7.Text = text;
            }
        }

        private void senddata()//发送刷写数据
        {
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Byte[] data = new Byte[fs.Length];
            fs.Read(data, 0, data.Length);

            byte[] sendsuf = new byte[3];
            sendsuf[0] = 0x04;
            sendsuf[1] = 0x05;
            sendsuf[2] = 0x01;

            SetText("正在擦除....");
            serialPort1.Write(sendsuf, 0, sendsuf.Length);  //擦除
            while (serialPort1.BytesToRead == 0) { }
            Thread.Sleep(1000);


            sendsuf[2] = 0x02;
            SetText("正在写入....");
            serialPort1.Write(sendsuf, 0, sendsuf.Length);
            serialPort1.Write(data, 0, data.Length);
            SetText("写入成功,请断电");

            thread.Abort();
        }

        private void button5_Click(object sender, EventArgs e)//刷新字库
        {
            if (serialPort1.IsOpen)
            {
                if (!thread.IsAlive)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        FileName = openFileDialog1.FileName;
                        //Selectedchar = (byte)comboBox2.SelectedIndex;                        
                        thread = new Thread(senddata);
                        thread.IsBackground = true;
                        thread.Start();
                    }
                }
            }

        }

        private void PrintCodeBar()//打印条形码
        {
            int length = textBox5.Text.Normalize().Length;

            byte[] sendsuf1 = new byte[length + 1];

            sendsuf1 = Encoding.Default.GetBytes(textBox5.Text.Normalize());

            byte[] sendsuf = new byte[sendsuf1.Length + 3];
            sendsuf[0] = 0x1d;//打印条形码
            sendsuf[1] = 0x6b;
            sendsuf[2] = (byte)comboBox4.SelectedIndex;

            Buffer.BlockCopy(sendsuf1, 0, sendsuf, 3, sendsuf1.Length);
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        byte[] bytes = { 0 };

        private void SelectPic()//选择图片
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Select Picture";
            opd.InitialDirectory = "";
            opd.FilterIndex = 1;
            opd.Filter = "图片文件(*.bmp,*.jpg,*.jpeg,*.gif,*.pn)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (textBox8.Text == "")
            {
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    textBox8.Text = opd.FileName;
                    button13.Text = "预览图片";
                }
                else
                {
                    button13.Text = "打开图片";
                }
            }


            PrintWidth = PaperWidth - leftmargin - rightmargin;
            Bitmap source = new Bitmap(textBox8.Text);
            Bitmap bmp = ImageHelper.MakeThumbnail(source, PrintWidth, source.Height, "W");
            PrintWidth = bmp.Width;
            PrintHeight = bmp.Height;

            PaperHeight = PrintHeight + topmargin + bottommargin;

            DrawToPicbox(bmp);
        }

        private void DrawToPicbox(Bitmap bmp)
        {
            DrawToPicbox(bmp, PaperWidth, PaperHeight);
        }

        private void DrawToPicbox(Bitmap bmp, int width, int height)
        {
            myBitmap2 = new Bitmap(width, height);
            Graphics myGraphics = this.CreateGraphics();
            myGraphics = Graphics.FromImage(myBitmap2);
            myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);//打印纸背景
            myGraphics.DrawImage(bmp, new Point(leftmargin, topmargin));
            pictureBox1.Image = myBitmap2;
        }

        private void GenerateQRCode()//生成二维码
        {
            Bitmap bmp = BarCode.DrawQRCode(textBox5.Text, PrintWidth, comboBox2.SelectedIndex);
            PrintHeight = PrintWidth;
            PaperHeight = PrintHeight + topmargin + bottommargin;
            DrawToPicbox(bmp);
        }
        private void GenerateCodeBar()//生成条形码
        {
            string content = textBox5.Text.Normalize();
            BarcodeFormat[] bfl = { BarcodeFormat.UPC_A, BarcodeFormat.UPC_E, BarcodeFormat.EAN_8, BarcodeFormat.EAN_13, BarcodeFormat.CODE_39, BarcodeFormat.ITF, BarcodeFormat.CODABAR, BarcodeFormat.CODE_93, BarcodeFormat.CODE_128 };
            Bitmap bmp = BarCode.DrawBarCode(content, bfl[comboBox4.SelectedIndex], PrintWidth, 30);
            PrintHeight = bmp.Height + (int)textBox5.Font.Size + 8;
            PaperHeight = PrintHeight + topmargin + bottommargin;
            DrawToPicbox(bmp);

            Graphics myGraphics = this.CreateGraphics();
            myGraphics = Graphics.FromImage(myBitmap2);
            myGraphics.DrawString(content, new Font(textBox5.Font.Name.ToString(), textBox5.Font.Size, textBox5.Font.Style),
                new SolidBrush(Color.Black), new RectangleF((PrintWidth - content.Length * textBox5.Font.Size) / 2 + leftmargin, bmp.Height, PrintWidth, 20));
            pictureBox1.Image = myBitmap2;

            /**
            Bitmap g = new Bitmap(384, 500);
            myBitmap2 = g;
            PrintWidth = PaperWidth - leftmargin - rightmargin;
            string content = textBox10.Text;
            //string content = "47112346";
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.EAN_8, PrintWidth, 80);
            Bitmap bitmap = toBitmap(byteMatrix);
            PrintWidth = bitmap.Width;
            PrintHeight = bitmap.Height;
            Graphics myGraphics = this.CreateGraphics();
            myGraphics = Graphics.FromImage(myBitmap2);
            myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, PaperWidth, 110);//打印纸背景
            myGraphics.DrawImage(bitmap, new Point(leftmargin, 0));
            myGraphics.DrawString(content, new Font(textBox5.Font.Name.ToString(), textBox5.Font.Size, textBox5.Font.Style),
                new SolidBrush(Color.Black), new RectangleF((PrintWidth - 8 * textBox5.Font.Size) / 2 + leftmargin, 80, PrintWidth, 30));
            pictureBox1.Image = myBitmap2;
            **/
        }


        private void TextPreview()//预览文字
        {
            Bitmap g = new Bitmap(PrintWidth, 500);
            myBitmap2 = g;
            string content = textBox5.Text;
            Graphics myGraphics2 = this.CreateGraphics();
            myGraphics2 = Graphics.FromImage(myBitmap2);
            myGraphics2.FillRectangle(new SolidBrush(Color.White), 0, 0, PaperWidth, PaperHeight);//打印纸背景
            myGraphics2.DrawString(content, new Font(textBox5.Font.Name.ToString(), textBox5.Font.Size, textBox5.Font.Style),
                new SolidBrush(Color.Black), new RectangleF(leftmargin + 5, topmargin + 5, PrintWidth - 10, PrintHeight - 10));
            if (checkBox6.Checked)
            {
                Pen pen = new Pen(new SolidBrush(Color.Red), 2);
                myGraphics2.DrawRectangle(pen, new Rectangle(leftmargin + 1, topmargin + 1, PrintWidth - 2, PrintHeight - 2));
                pen.Dispose();
            }
            pictureBox1.Image = myBitmap2;
        }

        private byte[] Bitmapbytes(Bitmap myBitmap2)//图片处理
        {
            byte temp = 0;
            long i = 0;
            Color srcColor = new Color();
            int newWidth = PrintWidth;
            int newHeight = PrintHeight;
            byte[] result = new byte[(long)(newWidth + 6) * 3 * (newHeight / 24 + 1) + 5];

            // 0行距
            result[i++] = 0x1B;
            result[i++] = 0x33;
            result[i++] = 0x00;

            for (int n = 0; n * 24 < newHeight; n++)//按24点高度分割
            {

                // 图片控制符
                result[i++] = (byte)0x1b;
                result[i++] = (byte)0x2a;
                result[i++] = (byte)0x21;

                // 图片宽度
                result[i++] = (byte)(newWidth % 256);
                result[i++] = (byte)(newWidth / 256);

                // 图片数据
                for (int x = 0; x < newWidth; x++)//对于每一行，逐列打印
                {
                    for (int m = 0; m < 3; m++)//每一列24个像素点，分为3个字节存储
                    {
                        for (int y = 0; y < 8; y++)//每个字节表示8个像素点，0表示白色，1表示黑色
                        {
                            if (x < newWidth && n * 24 + m * 8 + y < newHeight)
                            {
                                srcColor = myBitmap2.GetPixel(x, n * 24 + m * 8 + y);
                                byte T = (byte)(srcColor.R * .299 + srcColor.G * .587 + srcColor.B * .114);
                                temp = (byte)((temp << 1) | (byte)(T > GrayThreshold ? 0 : 1));
                            }
                            else
                            {
                                temp = 0;
                            }
                        }
                        result[i++] = temp;
                        temp = 0;
                    }
                }

                if (newWidth < 341) //为啥是340
                {
                    result[i++] = (byte)0x0A; 
                }

            }

            return result;
        }

        private void PrintBuffer()//打印图片
        {
            if (serialPort1.IsOpen)
            {
                byte[] res = Bitmapbytes(myBitmap2);
                serialPort1.Write(res, 0, res.Length);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 走到左黑标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)//打印并走纸到左黑标处
        {
            byte[] sendsuf = new byte[1];
            sendsuf[0] = 0x0C;//打印并走纸到左黑标处
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }
        /// <summary>
        /// 走到右黑标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button20_Click(object sender, EventArgs e)//打印并走纸到右黑标处
        {
            byte[] sendsuf = new byte[1];
            sendsuf[0] = 0x0E;//打印并走纸到右黑标处
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }


        private void GetStatus()//查询设备状态
        {
            byte[] sendsuf = new byte[2];
            sendsuf[0] = 0x1D;//查询设备状态
            sendsuf[1] = 0x99;
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }


        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            PrintCodeBar();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            GenerateCodeBar();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PrintBuffer();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            GenerateQRCode();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            TextPreview();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] sendsuf = new byte[3];
            if (comboBox8.SelectedIndex > 0)
            {
                sendsuf[0] = 0x1b;//对齐方式
                sendsuf[1] = 0x61;
                sendsuf[2] = (byte)comboBox8.SelectedIndex;
            }
            else {; }
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            byte[] sendsuf = new byte[3];
            if (int.TryParse(textBox12.Text, out int result))
            {
                sendsuf[0] = 0x1b;//设置绝对打印位置
                sendsuf[1] = 0x24;
                sendsuf[2] = (byte)result;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(sendsuf, 0, sendsuf.Length);
                }
            }

        }

        private void SetPrinterText(object sender, EventArgs e)
        {
            byte[] sendsuf = new byte[3];
            byte[] fontId = { 0x00, 0x01, 0x04, 0x10, 0x11, 0x12, 0x13 };
            sendsuf[0] = 0x1B;//选择字符字体
            sendsuf[1] = 0x4D;
            sendsuf[2] = fontId[comboBox7.SelectedIndex];

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SelectPic();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {
            int.TryParse(textBox9.Text, out GrayThreshold);
        }
    }
}