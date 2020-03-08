namespace readFontlib
{
    partial class EncodingQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncodingQuery));
            this.str2hex_radioButton = new System.Windows.Forms.RadioButton();
            this.hex2str_radioButton = new System.Windows.Forms.RadioButton();
            this.yima_textBox = new System.Windows.Forms.TextBox();
            this.clear_button = new System.Windows.Forms.Button();
            this.yima_listBox = new System.Windows.Forms.ListBox();
            this.Transfor_button = new System.Windows.Forms.Button();
            this.input_textBox = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // str2hex_radioButton
            // 
            this.str2hex_radioButton.AutoSize = true;
            this.str2hex_radioButton.Checked = true;
            this.str2hex_radioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.str2hex_radioButton.Location = new System.Drawing.Point(178, 21);
            this.str2hex_radioButton.Name = "str2hex_radioButton";
            this.str2hex_radioButton.Size = new System.Drawing.Size(95, 16);
            this.str2hex_radioButton.TabIndex = 16;
            this.str2hex_radioButton.TabStop = true;
            this.str2hex_radioButton.Text = "字符转机内码";
            this.str2hex_radioButton.UseVisualStyleBackColor = true;
            // 
            // hex2str_radioButton
            // 
            this.hex2str_radioButton.AutoSize = true;
            this.hex2str_radioButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hex2str_radioButton.Location = new System.Drawing.Point(316, 21);
            this.hex2str_radioButton.Name = "hex2str_radioButton";
            this.hex2str_radioButton.Size = new System.Drawing.Size(95, 16);
            this.hex2str_radioButton.TabIndex = 15;
            this.hex2str_radioButton.TabStop = true;
            this.hex2str_radioButton.Text = "机内码转字符";
            this.hex2str_radioButton.UseVisualStyleBackColor = true;
            // 
            // yima_textBox
            // 
            this.yima_textBox.Location = new System.Drawing.Point(297, 103);
            this.yima_textBox.Multiline = true;
            this.yima_textBox.Name = "yima_textBox";
            this.yima_textBox.Size = new System.Drawing.Size(247, 232);
            this.yima_textBox.TabIndex = 14;
            // 
            // clear_button
            // 
            this.clear_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clear_button.Location = new System.Drawing.Point(465, 54);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(58, 24);
            this.clear_button.TabIndex = 13;
            this.clear_button.Text = "清除";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // yima_listBox
            // 
            this.yima_listBox.FormattingEnabled = true;
            this.yima_listBox.ItemHeight = 12;
            this.yima_listBox.Location = new System.Drawing.Point(36, 103);
            this.yima_listBox.Name = "yima_listBox";
            this.yima_listBox.Size = new System.Drawing.Size(245, 232);
            this.yima_listBox.TabIndex = 12;
            // 
            // Transfor_button
            // 
            this.Transfor_button.Font = new System.Drawing.Font("宋体", 9F);
            this.Transfor_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Transfor_button.Location = new System.Drawing.Point(403, 55);
            this.Transfor_button.Name = "Transfor_button";
            this.Transfor_button.Size = new System.Drawing.Size(56, 23);
            this.Transfor_button.TabIndex = 11;
            this.Transfor_button.Text = "译码";
            this.Transfor_button.UseVisualStyleBackColor = true;
            this.Transfor_button.Click += new System.EventHandler(this.Transfor_button_Click);
            // 
            // input_textBox
            // 
            this.input_textBox.Location = new System.Drawing.Point(36, 56);
            this.input_textBox.Name = "input_textBox";
            this.input_textBox.Size = new System.Drawing.Size(361, 21);
            this.input_textBox.TabIndex = 10;
            this.input_textBox.Text = "上海仰邦科技股份有限公司";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.message.Location = new System.Drawing.Point(34, 23);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(101, 12);
            this.message.TabIndex = 9;
            this.message.Text = "输入要转码的字符";
            // 
            // EncodingQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 364);
            this.Controls.Add(this.str2hex_radioButton);
            this.Controls.Add(this.hex2str_radioButton);
            this.Controls.Add(this.yima_textBox);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.yima_listBox);
            this.Controls.Add(this.Transfor_button);
            this.Controls.Add(this.input_textBox);
            this.Controls.Add(this.message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EncodingQuery";
            this.Text = "机内码查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton str2hex_radioButton;
        private System.Windows.Forms.RadioButton hex2str_radioButton;
        private System.Windows.Forms.TextBox yima_textBox;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.ListBox yima_listBox;
        private System.Windows.Forms.Button Transfor_button;
        private System.Windows.Forms.TextBox input_textBox;
        private System.Windows.Forms.Label message;
    }
}