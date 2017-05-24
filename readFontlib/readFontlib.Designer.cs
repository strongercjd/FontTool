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
            this.View_mode_Button = new System.Windows.Forms.RadioButton();
            this.edit_mode_Button = new System.Windows.Forms.RadioButton();
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
            this.Save_font_button = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.check_data_format = new System.Windows.Forms.CheckBox();
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.view_edit_fontlib = new System.Windows.Forms.TabPage();
            this.make_fontlib = new System.Windows.Forms.TabPage();
            this.jineima = new System.Windows.Forms.TabPage();
            this.message = new System.Windows.Forms.Label();
            this.input_textBox = new System.Windows.Forms.TextBox();
            this.Transfor_button = new System.Windows.Forms.Button();
            this.yima_listBox = new System.Windows.Forms.ListBox();
            this.clear_button = new System.Windows.Forms.Button();
            this.yima_textBox = new System.Windows.Forms.TextBox();
            this.groupBoxpic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFont)).BeginInit();
            this.groupBoxSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.view_edit_fontlib.SuspendLayout();
            this.jineima.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxpic
            // 
            this.groupBoxpic.Controls.Add(this.View_mode_Button);
            this.groupBoxpic.Controls.Add(this.edit_mode_Button);
            this.groupBoxpic.Controls.Add(this.pictureBoxFont);
            this.groupBoxpic.Location = new System.Drawing.Point(3, 14);
            this.groupBoxpic.Name = "groupBoxpic";
            this.groupBoxpic.Size = new System.Drawing.Size(400, 410);
            this.groupBoxpic.TabIndex = 0;
            this.groupBoxpic.TabStop = false;
            this.groupBoxpic.Text = "字模区";
            // 
            // View_mode_Button
            // 
            this.View_mode_Button.AutoSize = true;
            this.View_mode_Button.Location = new System.Drawing.Point(128, 11);
            this.View_mode_Button.Name = "View_mode_Button";
            this.View_mode_Button.Size = new System.Drawing.Size(71, 16);
            this.View_mode_Button.TabIndex = 2;
            this.View_mode_Button.TabStop = true;
            this.View_mode_Button.Text = "查看模式";
            this.View_mode_Button.UseVisualStyleBackColor = true;
            this.View_mode_Button.CheckedChanged += new System.EventHandler(this.View_mode_Button_CheckedChanged);
            // 
            // edit_mode_Button
            // 
            this.edit_mode_Button.AutoSize = true;
            this.edit_mode_Button.Location = new System.Drawing.Point(215, 11);
            this.edit_mode_Button.Name = "edit_mode_Button";
            this.edit_mode_Button.Size = new System.Drawing.Size(71, 16);
            this.edit_mode_Button.TabIndex = 3;
            this.edit_mode_Button.TabStop = true;
            this.edit_mode_Button.Text = "编辑模式";
            this.toolTipReadFont.SetToolTip(this.edit_mode_Button, "编辑模式下，按住左键可以移动快速绘制，按住右键可以移动快速擦除");
            this.edit_mode_Button.UseVisualStyleBackColor = true;
            this.edit_mode_Button.CheckedChanged += new System.EventHandler(this.edit_mode_Button_CheckedChanged);
            // 
            // pictureBoxFont
            // 
            this.pictureBoxFont.Location = new System.Drawing.Point(8, 33);
            this.pictureBoxFont.Name = "pictureBoxFont";
            this.pictureBoxFont.Size = new System.Drawing.Size(386, 386);
            this.pictureBoxFont.TabIndex = 0;
            this.pictureBoxFont.TabStop = false;
            this.pictureBoxFont.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseDown);
            this.pictureBoxFont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseMove);
            this.pictureBoxFont.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFont_MouseUp);
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
            this.groupBoxSet.Location = new System.Drawing.Point(434, 14);
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
            // Save_font_button
            // 
            this.Save_font_button.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Save_font_button.Location = new System.Drawing.Point(65, 20);
            this.Save_font_button.Name = "Save_font_button";
            this.Save_font_button.Size = new System.Drawing.Size(68, 40);
            this.Save_font_button.TabIndex = 11;
            this.Save_font_button.Text = "保存字模";
            this.Save_font_button.UseVisualStyleBackColor = true;
            this.Save_font_button.Click += new System.EventHandler(this.Save_font_button_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.check_data_format);
            this.groupBoxData.Controls.Add(this.labelByteNum);
            this.groupBoxData.Controls.Add(this.labelNum);
            this.groupBoxData.Controls.Add(this.Save_font_button);
            this.groupBoxData.Controls.Add(this.richTextBoxData);
            this.groupBoxData.Controls.Add(this.labelFontInfo);
            this.groupBoxData.Controls.Add(this.buttonGetData);
            this.groupBoxData.Location = new System.Drawing.Point(434, 114);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(322, 319);
            this.groupBoxData.TabIndex = 2;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "数据区";
            // 
            // check_data_format
            // 
            this.check_data_format.AutoSize = true;
            this.check_data_format.Location = new System.Drawing.Point(146, 20);
            this.check_data_format.Name = "check_data_format";
            this.check_data_format.Size = new System.Drawing.Size(78, 16);
            this.check_data_format.TabIndex = 12;
            this.check_data_format.Text = "添加0x和,";
            this.check_data_format.UseVisualStyleBackColor = true;
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
            this.logo.Location = new System.Drawing.Point(4, 490);
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
            this.author.Location = new System.Drawing.Point(171, 490);
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
            this.textBoxtime.Location = new System.Drawing.Point(659, 490);
            this.textBoxtime.Multiline = true;
            this.textBoxtime.Name = "textBoxtime";
            this.textBoxtime.ReadOnly = true;
            this.textBoxtime.Size = new System.Drawing.Size(118, 21);
            this.textBoxtime.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.view_edit_fontlib);
            this.tabControl.Controls.Add(this.make_fontlib);
            this.tabControl.Controls.Add(this.jineima);
            this.tabControl.Location = new System.Drawing.Point(7, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(774, 475);
            this.tabControl.TabIndex = 4;
            // 
            // view_edit_fontlib
            // 
            this.view_edit_fontlib.Controls.Add(this.groupBoxpic);
            this.view_edit_fontlib.Controls.Add(this.groupBoxSet);
            this.view_edit_fontlib.Controls.Add(this.groupBoxData);
            this.view_edit_fontlib.Location = new System.Drawing.Point(4, 22);
            this.view_edit_fontlib.Name = "view_edit_fontlib";
            this.view_edit_fontlib.Padding = new System.Windows.Forms.Padding(3);
            this.view_edit_fontlib.Size = new System.Drawing.Size(766, 449);
            this.view_edit_fontlib.TabIndex = 0;
            this.view_edit_fontlib.Text = "查看编辑";
            this.view_edit_fontlib.UseVisualStyleBackColor = true;
            // 
            // make_fontlib
            // 
            this.make_fontlib.Location = new System.Drawing.Point(4, 22);
            this.make_fontlib.Name = "make_fontlib";
            this.make_fontlib.Padding = new System.Windows.Forms.Padding(3);
            this.make_fontlib.Size = new System.Drawing.Size(766, 449);
            this.make_fontlib.TabIndex = 1;
            this.make_fontlib.Text = "制作字库";
            this.make_fontlib.UseVisualStyleBackColor = true;
            // 
            // jineima
            // 
            this.jineima.Controls.Add(this.yima_textBox);
            this.jineima.Controls.Add(this.clear_button);
            this.jineima.Controls.Add(this.yima_listBox);
            this.jineima.Controls.Add(this.Transfor_button);
            this.jineima.Controls.Add(this.input_textBox);
            this.jineima.Controls.Add(this.message);
            this.jineima.Location = new System.Drawing.Point(4, 22);
            this.jineima.Name = "jineima";
            this.jineima.Padding = new System.Windows.Forms.Padding(3);
            this.jineima.Size = new System.Drawing.Size(766, 449);
            this.jineima.TabIndex = 2;
            this.jineima.Text = "机内码查询";
            this.jineima.UseVisualStyleBackColor = true;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(53, 37);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(101, 12);
            this.message.TabIndex = 0;
            this.message.Text = "输入要转码的文字";
            // 
            // input_textBox
            // 
            this.input_textBox.Location = new System.Drawing.Point(55, 66);
            this.input_textBox.Name = "input_textBox";
            this.input_textBox.Size = new System.Drawing.Size(361, 21);
            this.input_textBox.TabIndex = 1;
            this.input_textBox.Text = "上海仰邦科技股份有限公司";
            // 
            // Transfor_button
            // 
            this.Transfor_button.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Transfor_button.Location = new System.Drawing.Point(422, 66);
            this.Transfor_button.Name = "Transfor_button";
            this.Transfor_button.Size = new System.Drawing.Size(56, 23);
            this.Transfor_button.TabIndex = 2;
            this.Transfor_button.Text = "译码";
            this.Transfor_button.UseVisualStyleBackColor = true;
            this.Transfor_button.Click += new System.EventHandler(this.Transfor_button_Click);
            // 
            // yima_listBox
            // 
            this.yima_listBox.FormattingEnabled = true;
            this.yima_listBox.ItemHeight = 12;
            this.yima_listBox.Location = new System.Drawing.Point(55, 115);
            this.yima_listBox.Name = "yima_listBox";
            this.yima_listBox.Size = new System.Drawing.Size(245, 232);
            this.yima_listBox.TabIndex = 4;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(484, 66);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(58, 24);
            this.clear_button.TabIndex = 5;
            this.clear_button.Text = "清除";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // yima_textBox
            // 
            this.yima_textBox.Location = new System.Drawing.Point(316, 115);
            this.yima_textBox.Multiline = true;
            this.yima_textBox.Name = "yima_textBox";
            this.yima_textBox.Size = new System.Drawing.Size(247, 232);
            this.yima_textBox.TabIndex = 6;
            // 
            // readFontlib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.textBoxtime);
            this.Controls.Add(this.author);
            this.Controls.Add(this.logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 550);
            this.MinimumSize = new System.Drawing.Size(800, 450);
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
            this.tabControl.ResumeLayout(false);
            this.view_edit_fontlib.ResumeLayout(false);
            this.jineima.ResumeLayout(false);
            this.jineima.PerformLayout();
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
        private System.Windows.Forms.Button Save_font_button;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.RichTextBox richTextBoxData;
        private System.Windows.Forms.Label labelFontInfo;
        private System.Windows.Forms.Button buttonGetData;
        private System.Windows.Forms.ToolTip toolTipReadFont;
        private System.Windows.Forms.Label labelByteNum;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.ComboBox comboBoxWei;
        private System.Windows.Forms.ComboBox comboBoxQu;
        private System.Windows.Forms.RadioButton edit_mode_Button;
        private System.Windows.Forms.RadioButton View_mode_Button;
        private System.Windows.Forms.CheckBox check_data_format;
        private System.Windows.Forms.LinkLabel logo;
        private System.Windows.Forms.LinkLabel author;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBoxtime;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage view_edit_fontlib;
        private System.Windows.Forms.TabPage make_fontlib;
        private System.Windows.Forms.TabPage jineima;
        private System.Windows.Forms.Button Transfor_button;
        private System.Windows.Forms.TextBox input_textBox;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.ListBox yima_listBox;
        private System.Windows.Forms.TextBox yima_textBox;
    }
}

