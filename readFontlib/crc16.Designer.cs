namespace readFontlib
{
    partial class crc16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(crc16));
            this.crc_clear_button = new System.Windows.Forms.Button();
            this.crc_check_button = new System.Windows.Forms.Button();
            this.crc_textBox = new System.Windows.Forms.TextBox();
            this.check_groupBox = new System.Windows.Forms.GroupBox();
            this.crc_data_richTextBox = new System.Windows.Forms.RichTextBox();
            this.check_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // crc_clear_button
            // 
            this.crc_clear_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.crc_clear_button.Location = new System.Drawing.Point(448, 320);
            this.crc_clear_button.Name = "crc_clear_button";
            this.crc_clear_button.Size = new System.Drawing.Size(93, 23);
            this.crc_clear_button.TabIndex = 7;
            this.crc_clear_button.Text = "清除";
            this.crc_clear_button.UseVisualStyleBackColor = true;
            this.crc_clear_button.Click += new System.EventHandler(this.crc_clear_button_Click);
            // 
            // crc_check_button
            // 
            this.crc_check_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.crc_check_button.Location = new System.Drawing.Point(210, 320);
            this.crc_check_button.Name = "crc_check_button";
            this.crc_check_button.Size = new System.Drawing.Size(93, 23);
            this.crc_check_button.TabIndex = 6;
            this.crc_check_button.Text = "校验";
            this.crc_check_button.UseVisualStyleBackColor = true;
            this.crc_check_button.Click += new System.EventHandler(this.crc_check_button_Click);
            // 
            // crc_textBox
            // 
            this.crc_textBox.Location = new System.Drawing.Point(329, 321);
            this.crc_textBox.Name = "crc_textBox";
            this.crc_textBox.Size = new System.Drawing.Size(93, 21);
            this.crc_textBox.TabIndex = 5;
            // 
            // check_groupBox
            // 
            this.check_groupBox.Controls.Add(this.crc_data_richTextBox);
            this.check_groupBox.Location = new System.Drawing.Point(22, 22);
            this.check_groupBox.Name = "check_groupBox";
            this.check_groupBox.Size = new System.Drawing.Size(519, 276);
            this.check_groupBox.TabIndex = 4;
            this.check_groupBox.TabStop = false;
            this.check_groupBox.Text = "校验区";
            // 
            // crc_data_richTextBox
            // 
            this.crc_data_richTextBox.Location = new System.Drawing.Point(16, 20);
            this.crc_data_richTextBox.Name = "crc_data_richTextBox";
            this.crc_data_richTextBox.Size = new System.Drawing.Size(487, 249);
            this.crc_data_richTextBox.TabIndex = 0;
            this.crc_data_richTextBox.Text = "01 00 00 80 00 00 00 00 00 00 FE 02 28 00 A3 06 01 23 00 00 01 1F 00 00 00 00 00 " +
    "00 04 00 10 00 00 00 00 02 00 00 00 00 02 02 01 00 00 0A 04 00 00 00 D1 F6 B0 EE" +
    "";
            // 
            // crc16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 364);
            this.Controls.Add(this.crc_clear_button);
            this.Controls.Add(this.crc_check_button);
            this.Controls.Add(this.crc_textBox);
            this.Controls.Add(this.check_groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "crc16";
            this.Text = "CRC计算";
            this.check_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button crc_clear_button;
        private System.Windows.Forms.Button crc_check_button;
        private System.Windows.Forms.TextBox crc_textBox;
        private System.Windows.Forms.GroupBox check_groupBox;
        private System.Windows.Forms.RichTextBox crc_data_richTextBox;
    }
}