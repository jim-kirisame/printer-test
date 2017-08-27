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
using Cyotek.Drawing.Imaging.ColorReduction;

namespace PrinterTest
{
    public partial class Form1 : Form
    {
        Thread thread;
        delegate void SetTextCallback(string text);

        private string FileName;
        /// <summary>
        /// 纸张宽度
        /// </summary>
        int PaperWidth = 320;

        /// <summary>
        /// 纸张高度
        /// </summary>
        int PaperHeight = 320;

        /// <summary>
        /// 顶边距
        /// </summary>
        int topmargin = 0;

        /// <summary>
        /// 底边距
        /// </summary>
        int bottommargin = 0;

        /// <summary>
        /// 左边距
        /// </summary>
        int leftmargin = 0;

        /// <summary>
        /// 右边距
        /// </summary>
        int rightmargin = 0;

        /// <summary>
        /// 打印宽度
        /// </summary>
        int PrintWidth = 320;

        /// <summary>
        /// 打印高度
        /// </summary>
        int PrintHeight = 320;

        /// <summary>
        /// 灰度阈值
        /// </summary>
        int GrayThreshold = 128;

        Bitmap finalBitmap = new Bitmap(320, 320);
        Bitmap orgBitmap = new Bitmap(320, 320);

        EscPosCommand command = new EscPosCommand();

        IErrorDiffusion errorDiffusion;

        public Form1()
        {
            InitializeComponent();
            thread = new Thread(SendROMData);
            comboBox7.SelectedIndex = 3;//字体：中文16*16
            comboBox8.SelectedIndex = 0;//对齐方式:左对齐
            comboBox4.SelectedIndex = 2;//打印条形码默认值EAN8
            comboBox5.SelectedIndex = 2;//打印二维码默认值QR-CODE
            comboBox6.SelectedIndex = 0;//默认扩散方法：Atkinson
            label7.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 串口文本错误问题会在 .net 4 以上版本秀姑，故使用 .net 4 来编译才是最好的
                foreach (string port in SerialPort.GetPortNames())
                {
                    comboBox1.Items.Add(port.Normalize());
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// 打开/关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.PortName = comboBox1.Text.Normalize();
                serialPort1.BaudRate = Convert.ToInt32(comboBox3.Text.Trim());
                try
                {
                    serialPort1.Open();
                    byte[] sendsuf = command.Init();
                    WriteCommand(sendsuf);
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

        /// <summary>
        /// 设置字间距
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(textBox1.Text, out uint result))
            {
                if (result > 0)
                {
                    byte[] sendsuf = command.SetWordSpacing(result);
                    WriteCommand(sendsuf);
                }
            }
        }

        /// <summary>
        /// 设置行间距
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(textBox2.Text, out uint result))
            {
                byte[] sendsuf = command.SetLineSpacing(result);
                WriteCommand(sendsuf);
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

            if (PaperWidth >= 385) PaperWidth = 384; //Why?
            if (PaperHeight >= 600) PaperHeight = 599; //Why?

            PrintWidth = PaperWidth - leftmargin - rightmargin;
            PrintHeight = PaperHeight - topmargin - bottommargin;
            checkBox6.Text = "打印区域：" + PrintWidth + "*" + PrintHeight;
        }

        /// <summary>
        /// 边距改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderChangedEvent(object sender, EventArgs e)
        {
            UpdatePaperParam();
        }

        /// <summary>
        /// 设置左边距
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdatePaperParam();

            if (uint.TryParse(textBox17.Text, out uint result))
            {
                byte[] sendsuf = command.SetLeftPadding(result);
                WriteCommand(sendsuf);
            }
        }

        /// <summary>
        /// 设置粗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            byte[] sendsuf = command.SetBold(checkBox1.Checked);
            WriteCommand(sendsuf);
        }

        /// <summary>
        /// 向打印机写出数据
        /// </summary>
        /// <param name="sendsuf"></param>
        private void WriteCommand(byte[] sendsuf)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(sendsuf, 0, sendsuf.Length);
            }
        }

        /// <summary>
        /// 设置下划线1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            byte[] sendsuf = command.SetUnderline((byte)checkBox2.CheckState);
            WriteCommand(sendsuf);
        }

        /// <summary>
        /// 设置反白
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            byte[] sendsuf = command.SetReverse(checkBox3.Checked);
            WriteCommand(sendsuf);
        }

        /// <summary>
        /// 打印文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] sendsuf;
            byte temp = 0;
            if (radioButtonUnicode.Checked)
            {
                sendsuf = Encoding.Unicode.GetBytes(textBox5.Text);
                for (int i = 0; i < sendsuf.Length; i += 2)
                {
                    temp = sendsuf[i];
                    sendsuf[i] = sendsuf[i + 1];
                    sendsuf[i + 1] = temp;
                }
            }
            else if (radioButtonBIG5.Checked)
            {
                sendsuf = Encoding.GetEncoding("big5").GetBytes(textBox5.Text);
            }
            else
            {
                // 默认编码
                sendsuf = Encoding.Default.GetBytes(textBox5.Text);
            }
            WriteCommand(sendsuf);
        }

        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] sendsuf = command.Init();
            WriteCommand(sendsuf);
        }

        /// <summary>
        /// 选择字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = textBox5.Font;
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
            if (uint.TryParse(textBox7.Text, out uint result))
            {
                byte[] sendsuf = command.PrintAndMoveLines(result);
                WriteCommand(sendsuf);
            }
        }

        /// <summary>
        /// 打印并进纸n点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(textBox6.Text, out uint result))
            {
                byte[] sendsuf = command.PrintAndMovePoints(result);
                WriteCommand(sendsuf);
            }
        }

        /*
        private void textBox8_TextChanged(object sender, EventArgs e)//图片
        {
            byte[] sendsuf = new byte[2];
            sendsuf[0] = 0x1c;
            sendsuf[1] = 0x4b;
            WriteCommand(sendsuf);
        }
        */

        /// <summary>
        /// 旋转打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            byte type = 0;

            if (radioButton3.Checked) type = 0;
            else if (radioButton4.Checked) type = 1;
            else if (radioButton5.Checked) type = 2;
            else if (radioButton6.Checked) type = 3;

            byte[] sendsuf = command.SetRotate(type);
            WriteCommand(sendsuf);
        }

        /// <summary>
        /// 定时打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        /// <summary>
        /// 定时打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox5.Checked;
        }

        /// <summary>
        /// 刷新字库写入状态
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
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

        /// <summary>
        /// 发送刷写数据
        /// </summary>
        private void SendROMData()
        {
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Byte[] data = new Byte[fs.Length];
            fs.Read(data, 0, data.Length);

            byte[] sendsuf = new byte[3];
            sendsuf[0] = 0x04;
            sendsuf[1] = 0x05;
            sendsuf[2] = 0x01;

            SetText("正在擦除....");
            WriteCommand(sendsuf);  //擦除
            while (serialPort1.BytesToRead == 0) { }
            Thread.Sleep(1000);

            sendsuf[2] = 0x02;
            SetText("正在写入....");
            WriteCommand(sendsuf);
            WriteCommand(data);
            SetText("写入成功,请断电");

            thread.Abort();
        }

        /// <summary>
        /// 刷新字库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
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
                        thread = new Thread(SendROMData);
                        thread.IsBackground = true;
                        thread.Start();
                    }
                }
            }

        }
        /// <summary>
        /// 打印条形码
        /// </summary>
        private void PrintCodeBar()
        {
            byte[] data = Encoding.Default.GetBytes(textBox5.Text.Normalize());
            byte[] sendsuf = command.PrintBarCode((byte)comboBox4.SelectedIndex, data);
            WriteCommand(sendsuf);
        }

        byte[] bytes = { 0 };

        private void SelectPic()//选择图片
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Select Picture";
            opd.InitialDirectory = "";
            opd.FilterIndex = 1;
            opd.Filter = "图片文件(*.bmp,*.jpg,*.jpeg,*.gif,*.pn)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = opd.FileName;
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
            orgBitmap = bmp;
            var bwBmp =  ImageHelper.DitteringImage(errorDiffusion, bmp);

            finalBitmap = new Bitmap(width, height);
            Graphics myGraphics = this.CreateGraphics();
            myGraphics = Graphics.FromImage(finalBitmap);
            myGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);//打印纸背景
            myGraphics.DrawImage(bwBmp, new Point(leftmargin, topmargin));
            pictureBox1.Image = finalBitmap;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        private void GenerateQRCode()
        {
            Bitmap bmp = BarCode.DrawQRCode(textBox5.Text, PrintWidth, comboBox2.SelectedIndex);
            PrintHeight = PrintWidth;
            PaperHeight = PrintHeight + topmargin + bottommargin;
            DrawToPicbox(bmp);
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        private void GenerateCodeBar()
        {
            string content = textBox5.Text.Normalize();
            BarcodeFormat[] bfl = { BarcodeFormat.UPC_A, BarcodeFormat.UPC_E, BarcodeFormat.EAN_8, BarcodeFormat.EAN_13, BarcodeFormat.CODE_39, BarcodeFormat.ITF, BarcodeFormat.CODABAR, BarcodeFormat.CODE_93, BarcodeFormat.CODE_128 };
            Bitmap bmp = BarCode.DrawBarCode(content, bfl[comboBox4.SelectedIndex], PrintWidth, 30);
            PrintHeight = bmp.Height + (int)textBox5.Font.Size + 8;
            PaperHeight = PrintHeight + topmargin + bottommargin;
            DrawToPicbox(bmp);

            Graphics myGraphics = this.CreateGraphics();
            myGraphics = Graphics.FromImage(finalBitmap);
            myGraphics.DrawString(content, new Font(textBox5.Font.Name.ToString(), textBox5.Font.Size, textBox5.Font.Style),
                new SolidBrush(Color.Black), new RectangleF((PrintWidth - content.Length * textBox5.Font.Size) / 2 + leftmargin, bmp.Height, PrintWidth, 20));
            pictureBox1.Image = finalBitmap;
        }

        /// <summary>
        /// 预览文字
        /// </summary>
        private void TextPreview()
        {
            Bitmap g = new Bitmap(PrintWidth, 500);
            finalBitmap = g;
            string content = textBox5.Text;
            Graphics myGraphics2 = this.CreateGraphics();
            myGraphics2 = Graphics.FromImage(finalBitmap);
            myGraphics2.FillRectangle(new SolidBrush(Color.White), 0, 0, PaperWidth, PaperHeight);//打印纸背景
            myGraphics2.DrawString(content, new Font(textBox5.Font.Name.ToString(), textBox5.Font.Size, textBox5.Font.Style),
                new SolidBrush(Color.Black), new RectangleF(leftmargin + 5, topmargin + 5, PrintWidth - 10, PrintHeight - 10));
            if (checkBox6.Checked)
            {
                Pen pen = new Pen(new SolidBrush(Color.Red), 2);
                myGraphics2.DrawRectangle(pen, new Rectangle(leftmargin + 1, topmargin + 1, PrintWidth - 2, PrintHeight - 2));
                pen.Dispose();
            }
            pictureBox1.Image = finalBitmap;
        }

        private byte[] Bitmap2Bytes(Bitmap myBitmap2)//图片处理
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
                                // 转为灰度图像
                                byte T = (byte)(srcColor.R * .299 + srcColor.G * .587 + srcColor.B * .114);
                                // 转为黑白点阵
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

                if (newWidth <= 340) //为啥是340
                {
                    result[i++] = (byte)0x0A;
                }

            }

            return result;
        }

        private void PrintBuffer()//打印图片
        {
            WriteCommand(Bitmap2Bytes(finalBitmap));
            Thread.Sleep(1000);
        }

        /// <summary>
        /// 走到左黑标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToLeftPosBtnClick(object sender, EventArgs e)
        {
            WriteCommand(command.ToLeftBlackPos());
        }

        /// <summary>
        /// 走到右黑标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToRightPosBtnClick(object sender, EventArgs e)
        {
            WriteCommand(command.ToRightBlackPos());
        }

        /// <summary>
        /// 查询设备状态
        /// </summary>
        private void GetStatus()
        {
            byte[] sendsuf = command.GetStatus();
            WriteCommand(sendsuf);
        }

        private void PrintCodebarBtnClick(object sender, EventArgs e)
        {
            PrintCodeBar();
        }

        private void GenerateCodebarBtnClick(object sender, EventArgs e)
        {
            GenerateCodeBar();
        }

        private void PrintBufferImageBtnClick(object sender, EventArgs e)
        {
            PrintBuffer();
        }

        private void GenerateQRCodeBtnClick(object sender, EventArgs e)
        {
            GenerateQRCode();
        }

        private void PreviewTextBtnClick(object sender, EventArgs e)
        {
            TextPreview();
        }

        private void TextAlignChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex > 0)
            {
                byte[] sendsuf = command.SetAlign((byte)comboBox8.SelectedIndex);
                WriteCommand(sendsuf);
            }
        }

        private void PrintPosChanged(object sender, EventArgs e)
        {
            if (uint.TryParse(textBox12.Text, out uint result))
            {
                byte[] sendsuf = command.SetPrintPos(result);
                WriteCommand(sendsuf);
            }
        }

        private void SetPrinterFont(object sender, EventArgs e)
        {
            byte[] fontId = { 0x00, 0x01, 0x04, 0x10, 0x11, 0x12, 0x13 };
            byte[] sendsuf = command.SetFont(fontId[comboBox7.SelectedIndex]);
            WriteCommand(sendsuf);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SelectPic();
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {
            int.TryParse(textBox9.Text, out GrayThreshold);
            ImageHelper.GrayThreshold = (uint)GrayThreshold;
            // 重新生成图像
            ReGenerate_Click(null, null);
        }

        private void DiffusionMethodChanged(object sender, EventArgs e)
        {
            switch(comboBox6.SelectedIndex)
            {
                case 0:
                    errorDiffusion = new AtkinsonDithering();
                    break;
                case 1:
                    errorDiffusion = new BurksDithering();
                    break;
                case 2:
                    errorDiffusion = new FloydSteinbergDithering();
                    break;
                case 3:
                    errorDiffusion = new JarvisJudiceNinkeDithering();
                    break;
                case 4:
                    errorDiffusion = new RandomDithering();
                    break;
                case 5:
                    errorDiffusion = new Sierra2Dithering();
                    break;
                case 6:
                    errorDiffusion = new Sierra3Dithering();
                    break;
                case 7:
                    errorDiffusion = new SierraLiteDithering();
                    break;
                case 8:
                    errorDiffusion = new StuckiDithering();
                    break;
                case 9:
                default:
                    errorDiffusion = null;
                    break;
            }
            ReGenerate_Click(null, null);
        }

        private void ReGenerate_Click(object sender, EventArgs e)
        {
            DrawToPicbox(orgBitmap);
        }
    }
}