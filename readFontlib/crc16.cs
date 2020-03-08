using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace readFontlib
{
    public partial class crc16 : Form
    {
        public crc16()
        {
            InitializeComponent();
        }

        private void crc_check_button_Click(object sender, EventArgs e)
        {
            int mycrc = 0;
            int i = 0;
            try
            {
                string[] strCheckArray = crc_data_richTextBox.Text.Split(' ');
                byte[] myarray = new byte[strCheckArray.Length];
                foreach (var tmp in strCheckArray)
                {
                    myarray[i++] = System.Convert.ToByte(tmp, 16);
                }
                mycrc = CRC.crc16(myarray, i);
                crc_textBox.Text = (mycrc & 0xff).ToString("X2").ToUpper() + " " + ((mycrc >> 8) & 0xff).ToString("X2").ToUpper();


            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确格式的数据！");
            }
        }

        private void crc_clear_button_Click(object sender, EventArgs e)
        {
            crc_data_richTextBox.Clear();
            crc_textBox.Clear();
        }
    }
}
