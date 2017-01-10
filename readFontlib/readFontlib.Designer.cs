namespace readFontlib
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
            this.pictureBoxFont = new System.Windows.Forms.PictureBox();
            this.groupBoxSet = new System.Windows.Forms.GroupBox();
            this.comboBoxWei = new System.Windows.Forms.ComboBox();
            this.comboBoxQu = new System.Windows.Forms.ComboBox();
            this.buttonSaveBMP = new System.Windows.Forms.Button();
            this.labelIndex = new System.Windows.Forms.Label();
            this.numericUpDownIndex = new System.Windows.Forms.NumericUpDown();
            this.radioButtonUnit = new System.Windows.Forms.RadioButton();
            this.buttonReadFont = new System.Windows.Forms.Button();
            this.labelFontName = new System.Windows.Forms.Label();
            this.textBoxFontName = new System.Windows.Forms.TextBox();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.radioButtonFontLib = new System.Windows.Forms.RadioButton();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.labelByteNum = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.richTextBoxData = new System.Windows.Forms.RichTextBox();
            this.labelFontInfo = new System.Windows.Forms.Label();
            this.buttonGetData = new System.Windows.Forms.Button();
            this.toolTipReadFont = new System.Windows.Forms.ToolTip(this.components);
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
            this.groupBoxpic.Controls.Add(this.pictureBoxFont);
            this.groupBoxpic.Location = new System.Drawing.Point(2, 3);
            this.groupBoxpic.Name = "groupBoxpic";
            this.groupBoxpic.Size = new System.Drawing.Size(400, 410);
            this.groupBoxpic.TabIndex = 0;
            this.groupBoxpic.TabStop = false;
            this.groupBoxpic.Text = "字模区";
            // 
            // pictureBoxFont
            // 
            this.pictureBoxFont.Location = new System.Drawing.Point(5, 15);
            this.pictureBoxFont.Name = "pictureBoxFont";
            this.pictureBoxFont.Size = new System.Drawing.Size(386, 386);
            this.pictureBoxFont.TabIndex = 0;
            this.pictureBoxFont.TabStop = false;
            this.toolTipReadFont.SetToolTip(this.pictureBoxFont, "双击改变模式");
            this.pictureBoxFont.DoubleClick += new System.EventHandler(this.pictureBoxFont_DoubleClick);
            this.pictureBoxFont.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseDown);
            // 
            // groupBoxSet
            // 
            this.groupBoxSet.Controls.Add(this.comboBoxWei);
            this.groupBoxSet.Controls.Add(this.comboBoxQu);
            this.groupBoxSet.Controls.Add(this.buttonSaveBMP);
            this.groupBoxSet.Controls.Add(this.labelIndex);
            this.groupBoxSet.Controls.Add(this.numericUpDownIndex);
            this.groupBoxSet.Controls.Add(this.radioButtonUnit);
            this.groupBoxSet.Controls.Add(this.buttonReadFont);
            this.groupBoxSet.Controls.Add(this.labelFontName);
            this.groupBoxSet.Controls.Add(this.textBoxFontName);
            this.groupBoxSet.Controls.Add(this.numericUpDownHeight);
            this.groupBoxSet.Controls.Add(this.numericUpDownWidth);
            this.groupBoxSet.Controls.Add(this.labelHeight);
            this.groupBoxSet.Controls.Add(this.labelWidth);
            this.groupBoxSet.Controls.Add(this.radioButtonFontLib);
            this.groupBoxSet.Location = new System.Drawing.Point(412, 3);
            this.groupBoxSet.Name = "groupBoxSet";
            this.groupBoxSet.Size = new System.Drawing.Size(280, 100);
            this.groupBoxSet.TabIndex = 1;
            this.groupBoxSet.TabStop = false;
            this.groupBoxSet.Text = "设置";
            // 
            // comboBoxWei
            // 
            this.comboBoxWei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWei.FormattingEnabled = true;
            this.comboBoxWei.Location = new System.Drawing.Point(196, 63);
            this.comboBoxWei.Name = "comboBoxWei";
            this.comboBoxWei.Size = new System.Drawing.Size(41, 20);
            this.comboBoxWei.TabIndex = 14;
            this.toolTipReadFont.SetToolTip(this.comboBoxWei, "默认GB2312编码");
            // 
            // comboBoxQu
            // 
            this.comboBoxQu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQu.FormattingEnabled = true;
            this.comboBoxQu.Location = new System.Drawing.Point(146, 64);
            this.comboBoxQu.Name = "comboBoxQu";
            this.comboBoxQu.Size = new System.Drawing.Size(39, 20);
            this.comboBoxQu.TabIndex = 13;
            this.toolTipReadFont.SetToolTip(this.comboBoxQu, "默认GB2312编码");
            // 
            // buttonSaveBMP
            // 
            this.buttonSaveBMP.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSaveBMP.Location = new System.Drawing.Point(241, 38);
            this.buttonSaveBMP.Name = "buttonSaveBMP";
            this.buttonSaveBMP.Size = new System.Drawing.Size(39, 56);
            this.buttonSaveBMP.TabIndex = 11;
            this.buttonSaveBMP.Text = "保存这个字模";
            this.buttonSaveBMP.UseVisualStyleBackColor = true;
            this.buttonSaveBMP.Click += new System.EventHandler(this.buttonSaveBMP_Click);
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(144, 44);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(41, 12);
            this.labelIndex.TabIndex = 10;
            this.labelIndex.Text = "编号：";
            // 
            // numericUpDownIndex
            // 
            this.numericUpDownIndex.Location = new System.Drawing.Point(185, 38);
            this.numericUpDownIndex.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownIndex.Name = "numericUpDownIndex";
            this.numericUpDownIndex.Size = new System.Drawing.Size(52, 21);
            this.numericUpDownIndex.TabIndex = 9;
            this.numericUpDownIndex.ValueChanged += new System.EventHandler(this.numericUpDownIndex_ValueChanged);
            this.numericUpDownIndex.DoubleClick += new System.EventHandler(this.numericUpDownIndex_DoubleClick);
            // 
            // radioButtonUnit
            // 
            this.radioButtonUnit.AutoSize = true;
            this.radioButtonUnit.Location = new System.Drawing.Point(8, 69);
            this.radioButtonUnit.Name = "radioButtonUnit";
            this.radioButtonUnit.Size = new System.Drawing.Size(53, 16);
            this.radioButtonUnit.TabIndex = 1;
            this.radioButtonUnit.TabStop = true;
            this.radioButtonUnit.Text = "ASCII";
            this.radioButtonUnit.UseVisualStyleBackColor = true;
            this.radioButtonUnit.CheckedChanged += new System.EventHandler(this.radioButtonUnit_CheckedChanged);
            // 
            // buttonReadFont
            // 
            this.buttonReadFont.Location = new System.Drawing.Point(240, 12);
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
            this.textBoxFontName.Size = new System.Drawing.Size(169, 21);
            this.textBoxFontName.TabIndex = 6;
            this.textBoxFontName.Text = "打开字库";
            this.textBoxFontName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(103, 65);
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
            this.numericUpDownWidth.Location = new System.Drawing.Point(103, 38);
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
            this.labelHeight.Location = new System.Drawing.Point(80, 71);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(29, 12);
            this.labelHeight.TabIndex = 3;
            this.labelHeight.Text = "高：";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(80, 44);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(29, 12);
            this.labelWidth.TabIndex = 2;
            this.labelWidth.Text = "宽：";
            // 
            // radioButtonFontLib
            // 
            this.radioButtonFontLib.AutoSize = true;
            this.radioButtonFontLib.Location = new System.Drawing.Point(8, 42);
            this.radioButtonFontLib.Name = "radioButtonFontLib";
            this.radioButtonFontLib.Size = new System.Drawing.Size(59, 16);
            this.radioButtonFontLib.TabIndex = 0;
            this.radioButtonFontLib.TabStop = true;
            this.radioButtonFontLib.Text = "GB2312";
            this.radioButtonFontLib.UseVisualStyleBackColor = true;
            this.radioButtonFontLib.CheckedChanged += new System.EventHandler(this.radioButtonFontLib_CheckedChanged);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.labelByteNum);
            this.groupBoxData.Controls.Add(this.labelNum);
            this.groupBoxData.Controls.Add(this.richTextBoxData);
            this.groupBoxData.Controls.Add(this.labelFontInfo);
            this.groupBoxData.Controls.Add(this.buttonGetData);
            this.groupBoxData.Location = new System.Drawing.Point(412, 109);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(280, 299);
            this.groupBoxData.TabIndex = 2;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "数据区";
            // 
            // labelByteNum
            // 
            this.labelByteNum.AutoSize = true;
            this.labelByteNum.ForeColor = System.Drawing.Color.Blue;
            this.labelByteNum.Location = new System.Drawing.Point(239, 20);
            this.labelByteNum.Name = "labelByteNum";
            this.labelByteNum.Size = new System.Drawing.Size(11, 12);
            this.labelByteNum.TabIndex = 4;
            this.labelByteNum.Text = "0";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(175, 20);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(65, 12);
            this.labelNum.TabIndex = 3;
            this.labelNum.Text = "字节个数：";
            // 
            // richTextBoxData
            // 
            this.richTextBoxData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxData.Location = new System.Drawing.Point(8, 44);
            this.richTextBoxData.Name = "richTextBoxData";
            this.richTextBoxData.ReadOnly = true;
            this.richTextBoxData.Size = new System.Drawing.Size(263, 247);
            this.richTextBoxData.TabIndex = 2;
            this.richTextBoxData.Text = "\n\n\n\n\n字库读取&修改器权所有（C）2016";
            this.toolTipReadFont.SetToolTip(this.richTextBoxData, "双击取反");
            this.richTextBoxData.DoubleClick += new System.EventHandler(this.richTextBoxData_DoubleClick);
            // 
            // labelFontInfo
            // 
            this.labelFontInfo.AutoSize = true;
            this.labelFontInfo.Location = new System.Drawing.Point(73, 20);
            this.labelFontInfo.Name = "labelFontInfo";
            this.labelFontInfo.Size = new System.Drawing.Size(65, 12);
            this.labelFontInfo.TabIndex = 1;
            this.labelFontInfo.Text = "字库信息：";
            // 
            // buttonGetData
            // 
            this.buttonGetData.Location = new System.Drawing.Point(6, 15);
            this.buttonGetData.Name = "buttonGetData";
            this.buttonGetData.Size = new System.Drawing.Size(61, 23);
            this.buttonGetData.TabIndex = 0;
            this.buttonGetData.Text = "获取数据";
            this.buttonGetData.UseVisualStyleBackColor = true;
            this.buttonGetData.Click += new System.EventHandler(this.buttonGetData_Click);
            // 
            // readFontlib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 411);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.groupBoxSet);
            this.Controls.Add(this.groupBoxpic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(711, 450);
            this.MinimumSize = new System.Drawing.Size(711, 450);
            this.Name = "readFontlib";
            this.Text = "字库读取&修改器";
            this.Load += new System.EventHandler(this.readFontlib_Load);
            this.groupBoxpic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFont)).EndInit();
            this.groupBoxSet.ResumeLayout(false);
            this.groupBoxSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

