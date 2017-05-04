﻿namespace readFontlib
{
    partial class readFontlib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(readFontlib));
            this.groupBoxpic = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.pictureBoxFont = new System.Windows.Forms.PictureBox();
            this.groupBoxSet = new System.Windows.Forms.GroupBox();
            this.radioButtonUnit = new System.Windows.Forms.RadioButton();
            this.radioButtonFontLib = new System.Windows.Forms.RadioButton();
            this.comboBoxWei = new System.Windows.Forms.ComboBox();
            this.comboBoxQu = new System.Windows.Forms.ComboBox();
            this.labelIndex = new System.Windows.Forms.Label();
            this.numericUpDownIndex = new System.Windows.Forms.NumericUpDown();
            this.buttonReadFont = new System.Windows.Forms.Button();
            this.labelFontName = new System.Windows.Forms.Label();
            this.textBoxFontName = new System.Windows.Forms.TextBox();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.buttonSaveBMP = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelByteNum = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.richTextBoxData = new System.Windows.Forms.RichTextBox();
            this.labelFontInfo = new System.Windows.Forms.Label();
            this.buttonGetData = new System.Windows.Forms.Button();
            this.toolTipReadFont = new System.Windows.Forms.ToolTip(this.components);
            this.logo = new System.Windows.Forms.LinkLabel();
            this.author = new System.Windows.Forms.LinkLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textBoxtime = new System.Windows.Forms.TextBox();
            this.groupBoxpic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFont)).BeginInit();
            this.groupBoxSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxpic
            // 
            this.groupBoxpic.Controls.Add(this.radioButton1);
            this.groupBoxpic.Controls.Add(this.radioButton3);
            this.groupBoxpic.Controls.Add(this.pictureBoxFont);
            this.groupBoxpic.Location = new System.Drawing.Point(2, 3);
            this.groupBoxpic.Name = "groupBoxpic";
            this.groupBoxpic.Size = new System.Drawing.Size(400, 410);
            this.groupBoxpic.TabIndex = 0;
            this.groupBoxpic.TabStop = false;
            this.groupBoxpic.Text = "字模区";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(128, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "查看模式";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(215, 11);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 16);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "编辑模式";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // pictureBoxFont
            // 
            this.pictureBoxFont.Location = new System.Drawing.Point(8, 33);
            this.pictureBoxFont.Name = "pictureBoxFont";
            this.pictureBoxFont.Size = new System.Drawing.Size(386, 386);
            this.pictureBoxFont.TabIndex = 0;
            this.pictureBoxFont.TabStop = false;
            this.toolTipReadFont.SetToolTip(this.pictureBoxFont, "双击改变模式");
            this.pictureBoxFont.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseDown);
            // 
            // groupBoxSet
            // 
            this.groupBoxSet.Controls.Add(this.radioButtonUnit);
            this.groupBoxSet.Controls.Add(this.radioButtonFontLib);
            this.groupBoxSet.Controls.Add(this.comboBoxWei);
            this.groupBoxSet.Controls.Add(this.comboBoxQu);
            this.groupBoxSet.Controls.Add(this.labelIndex);
            this.groupBoxSet.Controls.Add(this.numericUpDownIndex);
            this.groupBoxSet.Controls.Add(this.buttonReadFont);
            this.groupBoxSet.Controls.Add(this.labelFontName);
            this.groupBoxSet.Controls.Add(this.textBoxFontName);
            this.groupBoxSet.Controls.Add(this.numericUpDownHeight);
            this.groupBoxSet.Controls.Add(this.numericUpDownWidth);
            this.groupBoxSet.Controls.Add(this.labelHeight);
            this.groupBoxSet.Controls.Add(this.labelWidth);
            this.groupBoxSet.Location = new System.Drawing.Point(412, 3);
            this.groupBoxSet.Name = "groupBoxSet";
            this.groupBoxSet.Size = new System.Drawing.Size(322, 100);
            this.groupBoxSet.TabIndex = 1;
            this.groupBoxSet.TabStop = false;
            this.groupBoxSet.Text = "设置";
            // 
            // radioButtonUnit
            // 
            this.radioButtonUnit.AutoSize = true;
            this.radioButtonUnit.Location = new System.Drawing.Point(8, 66);
            this.radioButtonUnit.Name = "radioButtonUnit";
            this.radioButtonUnit.Size = new System.Drawing.Size(53, 16);
            this.radioButtonUnit.TabIndex = 1;
            this.radioButtonUnit.TabStop = true;
            this.radioButtonUnit.Text = "ASCII";
            this.radioButtonUnit.UseVisualStyleBackColor = true;
            this.radioButtonUnit.CheckedChanged += new System.EventHandler(this.radioButtonUnit_CheckedChanged);
            // 
            // radioButtonFontLib
            // 
            this.radioButtonFontLib.AutoSize = true;
            this.radioButtonFontLib.Location = new System.Drawing.Point(8, 42);
            this.radioButtonFontLib.Name = "radioButtonFontLib";
            this.radioButtonFontLib.Size = new System.Drawing.Size(60, 18);
            this.radioButtonFontLib.TabIndex = 0;
            this.radioButtonFontLib.TabStop = true;
            this.radioButtonFontLib.Text = "GB2312";
            this.radioButtonFontLib.UseCompatibleTextRendering = true;
            this.radioButtonFontLib.UseVisualStyleBackColor = true;
            this.radioButtonFontLib.CheckedChanged += new System.EventHandler(this.radioButtonFontLib_CheckedChanged);
            // 
            // comboBoxWei
            // 
            this.comboBoxWei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWei.FormattingEnabled = true;
            this.comboBoxWei.Location = new System.Drawing.Point(253, 70);
            this.comboBoxWei.Name = "comboBoxWei";
            this.comboBoxWei.Size = new System.Drawing.Size(41, 20);
            this.comboBoxWei.TabIndex = 14;
            this.toolTipReadFont.SetToolTip(this.comboBoxWei, "默认GB2312编码");
            // 
            // comboBoxQu
            // 
            this.comboBoxQu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQu.FormattingEnabled = true;
            this.comboBoxQu.Location = new System.Drawing.Point(196, 70);
            this.comboBoxQu.Name = "comboBoxQu";
            this.comboBoxQu.Size = new System.Drawing.Size(39, 20);
            this.comboBoxQu.TabIndex = 13;
            this.toolTipReadFont.SetToolTip(this.comboBoxQu, "默认GB2312编码");
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(194, 42);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(41, 12);
            this.labelIndex.TabIndex = 10;
            this.labelIndex.Text = "编号：";
            // 
            // numericUpDownIndex
            // 
            this.numericUpDownIndex.Location = new System.Drawing.Point(241, 38);
            this.numericUpDownIndex.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownIndex.Name = "numericUpDownIndex";
            this.numericUpDownIndex.Size = new System.Drawing.Size(52, 21);
            this.numericUpDownIndex.TabIndex = 9;
            this.numericUpDownIndex.ValueChanged += new System.EventHandler(this.numericUpDownIndex_ValueChanged);
            // 
            // buttonReadFont
            // 
            this.buttonReadFont.Location = new System.Drawing.Point(253, 13);
            this.buttonReadFont.Name = "buttonReadFont";
            this.buttonReadFont.Size = new System.Drawing.Size(40, 23);
            this.buttonReadFont.TabIndex = 8;
            this.buttonReadFont.Text = "读取";
            this.buttonReadFont.UseVisualStyleBackColor = true;
            this.buttonReadFont.Click += new System.EventHandler(this.buttonReadFont_Click);
            // 
            // labelFontName
            // 
            this.labelFontName.AutoSize = true;
            this.labelFontName.Location = new System.Drawing.Point(6, 17);
            this.labelFontName.Name = "labelFontName";
            this.labelFontName.Size = new System.Drawing.Size(53, 12);
            this.labelFontName.TabIndex = 7;
            this.labelFontName.Text = "字库名：";
            // 
            // textBoxFontName
            // 
            this.textBoxFontName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxFontName.ForeColor = System.Drawing.Color.Red;
            this.textBoxFontName.Location = new System.Drawing.Point(65, 15);
            this.textBoxFontName.Name = "textBoxFontName";
            this.textBoxFontName.ReadOnly = true;
            this.textBoxFontName.Size = new System.Drawing.Size(182, 21);
            this.textBoxFontName.TabIndex = 6;
            this.textBoxFontName.Text = "打开字库";
            this.textBoxFontName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(146, 69);
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(35, 21);
            this.numericUpDownHeight.TabIndex = 5;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(146, 37);
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(35, 21);
            this.numericUpDownWidth.TabIndex = 4;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(109, 78);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(29, 12);
            this.labelHeight.TabIndex = 3;
            this.labelHeight.Text = "高：";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(109, 44);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(29, 12);
            this.labelWidth.TabIndex = 2;
            this.labelWidth.Text = "宽：";
            // 
            // buttonSaveBMP
            // 
            this.buttonSaveBMP.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSaveBMP.Location = new System.Drawing.Point(65, 20);
            this.buttonSaveBMP.Name = "buttonSaveBMP";
            this.buttonSaveBMP.Size = new System.Drawing.Size(68, 40);
            this.buttonSaveBMP.TabIndex = 11;
            this.buttonSaveBMP.Text = "保存字模";
            this.buttonSaveBMP.UseVisualStyleBackColor = true;
            this.buttonSaveBMP.Click += new System.EventHandler(this.buttonSaveBMP_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.checkBox1);
            this.groupBoxData.Controls.Add(this.labelByteNum);
            this.groupBoxData.Controls.Add(this.labelNum);
            this.groupBoxData.Controls.Add(this.buttonSaveBMP);
            this.groupBoxData.Controls.Add(this.richTextBoxData);
            this.groupBoxData.Controls.Add(this.labelFontInfo);
            this.groupBoxData.Controls.Add(this.buttonGetData);
            this.groupBoxData.Location = new System.Drawing.Point(412, 109);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(322, 319);
            this.groupBoxData.TabIndex = 2;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "数据区";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(146, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "添加0X和,";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labelByteNum
            // 
            this.labelByteNum.AutoSize = true;
            this.labelByteNum.ForeColor = System.Drawing.Color.Blue;
            this.labelByteNum.Location = new System.Drawing.Point(299, 51);
            this.labelByteNum.Name = "labelByteNum";
            this.labelByteNum.Size = new System.Drawing.Size(11, 12);
            this.labelByteNum.TabIndex = 4;
            this.labelByteNum.Text = "0";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(241, 51);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(53, 12);
            this.labelNum.TabIndex = 3;
            this.labelNum.Text = "字节数：";
            // 
            // richTextBoxData
            // 
            this.richTextBoxData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxData.Location = new System.Drawing.Point(6, 66);
            this.richTextBoxData.Name = "richTextBoxData";
            this.richTextBoxData.ReadOnly = true;
            this.richTextBoxData.Size = new System.Drawing.Size(308, 247);
            this.richTextBoxData.TabIndex = 2;
            this.richTextBoxData.Text = "\n\n\n\n\n字库读取&修改器权所有（C）2016";
            this.toolTipReadFont.SetToolTip(this.richTextBoxData, "双击取反");
            this.richTextBoxData.DoubleClick += new System.EventHandler(this.richTextBoxData_DoubleClick);
            // 
            // labelFontInfo
            // 
            this.labelFontInfo.AutoSize = true;
            this.labelFontInfo.Location = new System.Drawing.Point(139, 51);
            this.labelFontInfo.Name = "labelFontInfo";
            this.labelFontInfo.Size = new System.Drawing.Size(65, 12);
            this.labelFontInfo.TabIndex = 1;
            this.labelFontInfo.Text = "字库信息：";
            // 
            // buttonGetData
            // 
            this.buttonGetData.Location = new System.Drawing.Point(3, 20);
            this.buttonGetData.Name = "buttonGetData";
            this.buttonGetData.Size = new System.Drawing.Size(61, 40);
            this.buttonGetData.TabIndex = 0;
            this.buttonGetData.Text = "获取数据";
            this.buttonGetData.UseVisualStyleBackColor = true;
            this.buttonGetData.Click += new System.EventHandler(this.buttonGetData_Click);
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Location = new System.Drawing.Point(12, 440);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(149, 12);
            this.logo.TabIndex = 3;
            this.logo.TabStop = true;
            this.logo.Text = "上海仰邦科技股份有限公司";
            this.logo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logo_LinkClicked);
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Location = new System.Drawing.Point(168, 440);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(71, 12);
            this.author.TabIndex = 4;
            this.author.TabStop = true;
            this.author.Text = "Author：CJD";
            this.author.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.author_LinkClicked);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // textBoxtime
            // 
            this.textBoxtime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxtime.Location = new System.Drawing.Point(608, 437);
            this.textBoxtime.Multiline = true;
            this.textBoxtime.Name = "textBoxtime";
            this.textBoxtime.ReadOnly = true;
            this.textBoxtime.Size = new System.Drawing.Size(118, 21);
            this.textBoxtime.TabIndex = 5;
            // 
            // readFontlib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.textBoxtime);
            this.Controls.Add(this.author);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.groupBoxSet);
            this.Controls.Add(this.groupBoxpic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(750, 500);
            this.MinimumSize = new System.Drawing.Size(711, 450);
            this.Name = "readFontlib";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "字库读取&修改器";
            this.Load += new System.EventHandler(this.readFontlib_Load);
            this.groupBoxpic.ResumeLayout(false);
            this.groupBoxpic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFont)).EndInit();
            this.groupBoxSet.ResumeLayout(false);
            this.groupBoxSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxpic;
        private System.Windows.Forms.PictureBox pictureBoxFont;
        private System.Windows.Forms.GroupBox groupBoxSet;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.NumericUpDown numericUpDownIndex;
        private System.Windows.Forms.RadioButton radioButtonUnit;
        private System.Windows.Forms.Button buttonReadFont;
        private System.Windows.Forms.Label labelFontName;
        private System.Windows.Forms.TextBox textBoxFontName;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.RadioButton radioButtonFontLib;
        private System.Windows.Forms.Button buttonSaveBMP;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.RichTextBox richTextBoxData;
        private System.Windows.Forms.Label labelFontInfo;
        private System.Windows.Forms.Button buttonGetData;
        private System.Windows.Forms.ToolTip toolTipReadFont;
        private System.Windows.Forms.Label labelByteNum;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.ComboBox comboBoxWei;
        private System.Windows.Forms.ComboBox comboBoxQu;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel logo;
        private System.Windows.Forms.LinkLabel author;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBoxtime;
    }
}

