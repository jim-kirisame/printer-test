namespace PrinterTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.inputBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BoldCheckBox = new System.Windows.Forms.CheckBox();
            this.underlineCheckbox = new System.Windows.Forms.CheckBox();
            this.reverseCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grayThresholdBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lineSpacing = new System.Windows.Forms.TextBox();
            this.letterSpacing = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.paddingLeft = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.drawBorder = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.marginBottom = new System.Windows.Forms.TextBox();
            this.marginRight = new System.Windows.Forms.TextBox();
            this.marginTop = new System.Windows.Forms.TextBox();
            this.marginLeft = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.paperHeightBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.paperWidthBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ReGenerate = new System.Windows.Forms.Button();
            this.diffusionMethod = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.errorLevelComboBox = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.barCodeTypeBox = new System.Windows.Forms.ComboBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonBIG5 = new System.Windows.Forms.RadioButton();
            this.radioButtonUnicode = new System.Windows.Forms.RadioButton();
            this.radioButtonBGK = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.fontBox = new System.Windows.Forms.ComboBox();
            this.alignBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端 口：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(55, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // inputBox
            // 
            this.inputBox.AcceptsTab = true;
            this.inputBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inputBox.Font = new System.Drawing.Font("宋体", 12F);
            this.inputBox.Location = new System.Drawing.Point(4, 433);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputBox.Size = new System.Drawing.Size(443, 94);
            this.inputBox.TabIndex = 4;
            this.inputBox.Text = "欢迎使用热敏打印机DEMO测试软件！\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(288, 533);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "打印文本";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 20);
            this.button3.TabIndex = 14;
            this.button3.Text = "初始化";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BoldCheckBox
            // 
            this.BoldCheckBox.AutoSize = true;
            this.BoldCheckBox.Location = new System.Drawing.Point(5, 66);
            this.BoldCheckBox.Name = "BoldCheckBox";
            this.BoldCheckBox.Size = new System.Drawing.Size(48, 16);
            this.BoldCheckBox.TabIndex = 10;
            this.BoldCheckBox.Text = "粗体";
            this.BoldCheckBox.UseVisualStyleBackColor = true;
            this.BoldCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // underlineCheckbox
            // 
            this.underlineCheckbox.AutoSize = true;
            this.underlineCheckbox.Location = new System.Drawing.Point(5, 110);
            this.underlineCheckbox.Name = "underlineCheckbox";
            this.underlineCheckbox.Size = new System.Drawing.Size(60, 16);
            this.underlineCheckbox.TabIndex = 11;
            this.underlineCheckbox.Text = "下划线";
            this.underlineCheckbox.ThreeState = true;
            this.underlineCheckbox.UseVisualStyleBackColor = true;
            this.underlineCheckbox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // reverseCheckBox
            // 
            this.reverseCheckBox.AutoSize = true;
            this.reverseCheckBox.Location = new System.Drawing.Point(5, 88);
            this.reverseCheckBox.Name = "reverseCheckBox";
            this.reverseCheckBox.Size = new System.Drawing.Size(48, 16);
            this.reverseCheckBox.TabIndex = 12;
            this.reverseCheckBox.Text = "反白";
            this.reverseCheckBox.UseVisualStyleBackColor = true;
            this.reverseCheckBox.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "点";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(10, 19);
            this.textBox7.MaxLength = 3;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(39, 21);
            this.textBox7.TabIndex = 20;
            this.textBox7.Text = "0";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(10, 45);
            this.textBox6.MaxLength = 3;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(39, 21);
            this.textBox6.TabIndex = 21;
            this.textBox6.Text = "0";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grayThresholdBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lineSpacing);
            this.groupBox1.Controls.Add(this.letterSpacing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.paddingLeft);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 187);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印设置";
            // 
            // grayThresholdBox
            // 
            this.grayThresholdBox.Location = new System.Drawing.Point(392, 157);
            this.grayThresholdBox.MaxLength = 3;
            this.grayThresholdBox.Name = "grayThresholdBox";
            this.grayThresholdBox.Size = new System.Drawing.Size(39, 21);
            this.grayThresholdBox.TabIndex = 63;
            this.grayThresholdBox.Text = "128";
            this.grayThresholdBox.TextChanged += new System.EventHandler(this.textBox9_TextChanged_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(321, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 62;
            this.label14.Text = "黑白阈值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "绝对左边距：";
            // 
            // lineSpacing
            // 
            this.lineSpacing.Location = new System.Drawing.Point(272, 157);
            this.lineSpacing.MaxLength = 3;
            this.lineSpacing.Name = "lineSpacing";
            this.lineSpacing.Size = new System.Drawing.Size(39, 21);
            this.lineSpacing.TabIndex = 59;
            this.lineSpacing.Text = "0";
            this.lineSpacing.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // letterSpacing
            // 
            this.letterSpacing.Location = new System.Drawing.Point(182, 157);
            this.letterSpacing.MaxLength = 3;
            this.letterSpacing.Name = "letterSpacing";
            this.letterSpacing.Size = new System.Drawing.Size(39, 21);
            this.letterSpacing.TabIndex = 58;
            this.letterSpacing.Text = "0";
            this.letterSpacing.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 57;
            this.label4.Text = "行间距：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 56;
            this.label3.Text = "字间距：";
            // 
            // paddingLeft
            // 
            this.paddingLeft.Location = new System.Drawing.Point(89, 157);
            this.paddingLeft.MaxLength = 3;
            this.paddingLeft.Name = "paddingLeft";
            this.paddingLeft.Size = new System.Drawing.Size(39, 21);
            this.paddingLeft.TabIndex = 60;
            this.paddingLeft.Text = "0";
            this.paddingLeft.TextChanged += new System.EventHandler(this.PrintPosChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.drawBorder);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.marginBottom);
            this.groupBox6.Controls.Add(this.marginRight);
            this.groupBox6.Controls.Add(this.marginTop);
            this.groupBox6.Controls.Add(this.marginLeft);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.paperHeightBox);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.paperWidthBox);
            this.groupBox6.Location = new System.Drawing.Point(10, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 132);
            this.groupBox6.TabIndex = 55;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "纸张设置";
            // 
            // drawBorder
            // 
            this.drawBorder.AutoSize = true;
            this.drawBorder.Location = new System.Drawing.Point(12, 104);
            this.drawBorder.Name = "drawBorder";
            this.drawBorder.Size = new System.Drawing.Size(72, 16);
            this.drawBorder.TabIndex = 52;
            this.drawBorder.Text = "显示边框";
            this.drawBorder.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(104, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 53;
            this.label13.Text = "下边距：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 52;
            this.label12.Text = "上边距：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 50;
            this.label11.Text = "纸高度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 49;
            this.label9.Text = "纸宽度：";
            // 
            // marginBottom
            // 
            this.marginBottom.Location = new System.Drawing.Point(157, 47);
            this.marginBottom.MaxLength = 3;
            this.marginBottom.Name = "marginBottom";
            this.marginBottom.Size = new System.Drawing.Size(39, 21);
            this.marginBottom.TabIndex = 51;
            this.marginBottom.Text = "0";
            this.marginBottom.TextChanged += new System.EventHandler(this.BorderChangedEvent);
            // 
            // marginRight
            // 
            this.marginRight.Location = new System.Drawing.Point(157, 18);
            this.marginRight.MaxLength = 3;
            this.marginRight.Name = "marginRight";
            this.marginRight.Size = new System.Drawing.Size(39, 21);
            this.marginRight.TabIndex = 17;
            this.marginRight.Text = "0";
            this.marginRight.TextChanged += new System.EventHandler(this.BorderChangedEvent);
            // 
            // marginTop
            // 
            this.marginTop.Location = new System.Drawing.Point(61, 47);
            this.marginTop.MaxLength = 3;
            this.marginTop.Name = "marginTop";
            this.marginTop.Size = new System.Drawing.Size(39, 21);
            this.marginTop.TabIndex = 50;
            this.marginTop.Text = "0";
            this.marginTop.TextChanged += new System.EventHandler(this.BorderChangedEvent);
            // 
            // marginLeft
            // 
            this.marginLeft.Location = new System.Drawing.Point(61, 18);
            this.marginLeft.MaxLength = 3;
            this.marginLeft.Name = "marginLeft";
            this.marginLeft.Size = new System.Drawing.Size(39, 21);
            this.marginLeft.TabIndex = 16;
            this.marginLeft.Text = "0";
            this.marginLeft.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "左边距：";
            // 
            // paperHeightBox
            // 
            this.paperHeightBox.Location = new System.Drawing.Point(157, 75);
            this.paperHeightBox.MaxLength = 3;
            this.paperHeightBox.Name = "paperHeightBox";
            this.paperHeightBox.Size = new System.Drawing.Size(39, 21);
            this.paperHeightBox.TabIndex = 48;
            this.paperHeightBox.Text = "320";
            this.paperHeightBox.TextChanged += new System.EventHandler(this.BorderChangedEvent);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "右边距：";
            // 
            // paperWidthBox
            // 
            this.paperWidthBox.Location = new System.Drawing.Point(61, 75);
            this.paperWidthBox.MaxLength = 3;
            this.paperWidthBox.Name = "paperWidthBox";
            this.paperWidthBox.Size = new System.Drawing.Size(39, 21);
            this.paperWidthBox.TabIndex = 45;
            this.paperWidthBox.Text = "320";
            this.paperWidthBox.TextChanged += new System.EventHandler(this.BorderChangedEvent);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton6);
            this.groupBox3.Controls.Add(this.radioButton5);
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.BoldCheckBox);
            this.groupBox3.Controls.Add(this.underlineCheckbox);
            this.groupBox3.Controls.Add(this.reverseCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(317, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 132);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "逆时针旋转打印";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(60, 43);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(41, 16);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.Text = "270";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(5, 43);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(41, 16);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Text = "180";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(60, 18);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(35, 16);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Text = "90";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(5, 18);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(29, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "0";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(227, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(84, 132);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "进纸";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(10, 100);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(62, 23);
            this.button20.TabIndex = 56;
            this.button20.Text = "右黑标";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.ToRightPosBtnClick);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(10, 73);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(62, 23);
            this.button19.TabIndex = 55;
            this.button19.Text = "左黑标";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.ToLeftPosBtnClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "行";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 533);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 33);
            this.button4.TabIndex = 26;
            this.button4.Text = "字体";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Location = new System.Drawing.Point(400, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "字库状态";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(346, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 20);
            this.button5.TabIndex = 24;
            this.button5.Text = "写入字库";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(6, 542);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 23;
            this.checkBox5.Text = "定时打印";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400"});
            this.comboBox3.Location = new System.Drawing.Point(135, 11);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(73, 20);
            this.comboBox3.TabIndex = 24;
            this.comboBox3.Text = "115200";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Location = new System.Drawing.Point(459, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(396, 516);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图片预览";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 490);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(453, 533);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(106, 33);
            this.button14.TabIndex = 28;
            this.button14.Text = "打印图片";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.PrintBufferImageBtnClick);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.ReGenerate);
            this.groupBox8.Controls.Add(this.diffusionMethod);
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.button13);
            this.groupBox8.Controls.Add(this.filePathBox);
            this.groupBox8.Location = new System.Drawing.Point(10, 241);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(317, 186);
            this.groupBox8.TabIndex = 32;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "图片";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 73;
            this.label15.Text = "转换算法：";
            // 
            // ReGenerate
            // 
            this.ReGenerate.Location = new System.Drawing.Point(216, 155);
            this.ReGenerate.Name = "ReGenerate";
            this.ReGenerate.Size = new System.Drawing.Size(84, 24);
            this.ReGenerate.TabIndex = 72;
            this.ReGenerate.Text = "重新生成";
            this.ReGenerate.UseVisualStyleBackColor = true;
            this.ReGenerate.Click += new System.EventHandler(this.ReGenerate_Click);
            // 
            // diffusionMethod
            // 
            this.diffusionMethod.FormattingEnabled = true;
            this.diffusionMethod.Items.AddRange(new object[] {
            "Atkinson",
            "Burkes",
            "Floyd-Steinberg",
            "Jarvis, Judice and Ninke",
            "Random",
            "Sierra",
            "Two Row Sierra",
            "SierraLite",
            "Stucki",
            "无"});
            this.diffusionMethod.Location = new System.Drawing.Point(79, 156);
            this.diffusionMethod.Name = "diffusionMethod";
            this.diffusionMethod.Size = new System.Drawing.Size(131, 20);
            this.diffusionMethod.TabIndex = 71;
            this.diffusionMethod.SelectedIndexChanged += new System.EventHandler(this.DiffusionMethodChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.errorLevelComboBox);
            this.groupBox10.Controls.Add(this.button15);
            this.groupBox10.Location = new System.Drawing.Point(167, 21);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(133, 100);
            this.groupBox10.TabIndex = 70;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "二维码";
            // 
            // errorLevelComboBox
            // 
            this.errorLevelComboBox.FormattingEnabled = true;
            this.errorLevelComboBox.Items.AddRange(new object[] {
            "7%",
            "15%",
            "25%",
            "30%"});
            this.errorLevelComboBox.Location = new System.Drawing.Point(16, 22);
            this.errorLevelComboBox.Name = "errorLevelComboBox";
            this.errorLevelComboBox.Size = new System.Drawing.Size(100, 20);
            this.errorLevelComboBox.TabIndex = 67;
            this.errorLevelComboBox.Text = "纠错等级";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(16, 48);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(100, 23);
            this.button15.TabIndex = 66;
            this.button15.Text = "生成二维码";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.GenerateQRCodeBtnClick);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button6);
            this.groupBox9.Controls.Add(this.barCodeTypeBox);
            this.groupBox9.Controls.Add(this.button16);
            this.groupBox9.Location = new System.Drawing.Point(10, 21);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(151, 100);
            this.groupBox9.TabIndex = 69;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "条形码";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 22);
            this.button6.TabIndex = 68;
            this.button6.Text = "打印条形码";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.PrintCodebarBtnClick);
            // 
            // barCodeTypeBox
            // 
            this.barCodeTypeBox.FormattingEnabled = true;
            this.barCodeTypeBox.Items.AddRange(new object[] {
            "UPCA",
            "UPC-E",
            "EAN8",
            "EAN13",
            "CODE39",
            "INTERLEAVED",
            "CODABAR",
            "CODE93",
            "CODE128"});
            this.barCodeTypeBox.Location = new System.Drawing.Point(12, 20);
            this.barCodeTypeBox.Name = "barCodeTypeBox";
            this.barCodeTypeBox.Size = new System.Drawing.Size(120, 20);
            this.barCodeTypeBox.TabIndex = 57;
            this.barCodeTypeBox.Text = "条码类型";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(12, 71);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(121, 23);
            this.button16.TabIndex = 66;
            this.button16.Text = "生成条码";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.GenerateCodebarBtnClick);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(216, 127);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(84, 23);
            this.button13.TabIndex = 64;
            this.button13.Text = "打开图片";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(10, 128);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(200, 21);
            this.filePathBox.TabIndex = 63;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(176, 533);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(102, 33);
            this.button18.TabIndex = 63;
            this.button18.Text = "生成图像";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.PreviewTextBtnClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonBIG5);
            this.groupBox4.Controls.Add(this.radioButtonUnicode);
            this.groupBox4.Controls.Add(this.radioButtonBGK);
            this.groupBox4.Location = new System.Drawing.Point(333, 241);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 89);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "字符编码";
            // 
            // radioButtonBIG5
            // 
            this.radioButtonBIG5.AutoSize = true;
            this.radioButtonBIG5.Location = new System.Drawing.Point(7, 43);
            this.radioButtonBIG5.Name = "radioButtonBIG5";
            this.radioButtonBIG5.Size = new System.Drawing.Size(83, 16);
            this.radioButtonBIG5.TabIndex = 8;
            this.radioButtonBIG5.Text = "(繁体)BIG5";
            this.radioButtonBIG5.UseVisualStyleBackColor = true;
            // 
            // radioButtonUnicode
            // 
            this.radioButtonUnicode.AutoSize = true;
            this.radioButtonUnicode.Location = new System.Drawing.Point(7, 65);
            this.radioButtonUnicode.Name = "radioButtonUnicode";
            this.radioButtonUnicode.Size = new System.Drawing.Size(101, 16);
            this.radioButtonUnicode.TabIndex = 1;
            this.radioButtonUnicode.Text = "(其他)Unicode";
            this.radioButtonUnicode.UseVisualStyleBackColor = true;
            // 
            // radioButtonBGK
            // 
            this.radioButtonBGK.AutoSize = true;
            this.radioButtonBGK.Checked = true;
            this.radioButtonBGK.Location = new System.Drawing.Point(7, 21);
            this.radioButtonBGK.Name = "radioButtonBGK";
            this.radioButtonBGK.Size = new System.Drawing.Size(77, 16);
            this.radioButtonBGK.TabIndex = 0;
            this.radioButtonBGK.TabStop = true;
            this.radioButtonBGK.Text = "(中文)GBK";
            this.radioButtonBGK.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.fontBox);
            this.groupBox7.Controls.Add(this.alignBox);
            this.groupBox7.Location = new System.Drawing.Point(333, 333);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(120, 94);
            this.groupBox7.TabIndex = 73;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "文本设置";
            // 
            // fontBox
            // 
            this.fontBox.FormattingEnabled = true;
            this.fontBox.Items.AddRange(new object[] {
            "SYSTEM 12x24",
            "SYSTEM 8x16",
            "romatic 26",
            "GBK 24x24",
            "GBK 16*16",
            "BIG5 24x24",
            "BIG5 16x16"});
            this.fontBox.Location = new System.Drawing.Point(7, 18);
            this.fontBox.Name = "fontBox";
            this.fontBox.Size = new System.Drawing.Size(101, 20);
            this.fontBox.TabIndex = 39;
            this.fontBox.Text = "字体";
            this.fontBox.SelectedIndexChanged += new System.EventHandler(this.SetPrinterFont);
            // 
            // alignBox
            // 
            this.alignBox.FormattingEnabled = true;
            this.alignBox.Items.AddRange(new object[] {
            "左对齐",
            "居中",
            "右对齐"});
            this.alignBox.Location = new System.Drawing.Point(7, 44);
            this.alignBox.Name = "alignBox";
            this.alignBox.Size = new System.Drawing.Size(101, 20);
            this.alignBox.TabIndex = 39;
            this.alignBox.Text = "对齐";
            this.alignBox.SelectedIndexChanged += new System.EventHandler(this.TextAlignChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(566, 537);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(275, 24);
            this.label16.TabIndex = 74;
            this.label16.Text = "https://github.com/jiangming1399/Printer-Test\r\n开源许可等信息可在上述链接中找到";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 578);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Name = "Form1";
            this.Text = "打印机测试DEMO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox BoldCheckBox;
        private System.Windows.Forms.CheckBox underlineCheckbox;
        private System.Windows.Forms.CheckBox reverseCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox marginTop;
        private System.Windows.Forms.TextBox paperHeightBox;
        private System.Windows.Forms.TextBox paperWidthBox;
        private System.Windows.Forms.TextBox marginBottom;
        private System.Windows.Forms.CheckBox drawBorder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox marginRight;
        private System.Windows.Forms.TextBox marginLeft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox barCodeTypeBox;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.ComboBox errorLevelComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonBIG5;
        private System.Windows.Forms.RadioButton radioButtonUnicode;
        private System.Windows.Forms.RadioButton radioButtonBGK;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox fontBox;
        private System.Windows.Forms.ComboBox alignBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lineSpacing;
        private System.Windows.Forms.TextBox letterSpacing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox paddingLeft;
        private System.Windows.Forms.TextBox grayThresholdBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ReGenerate;
        private System.Windows.Forms.ComboBox diffusionMethod;
        private System.Windows.Forms.Label label16;
    }
}

