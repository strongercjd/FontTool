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
    public partial class EncodingQuery : Form
    {
        public EncodingQuery()
        {
            InitializeComponent();
        }

        private void Transfor_button_Click(object sender, EventArgs e)
        {
            int m = 0;
            int n = 0;

            yima_textBox.Clear();
            yima_listBox.Items.Clear();

            if (input_textBox.Text == "")
            {
                MessageBox.Show("请输入译码文字");
                return;
            }

            if (str2hex_radioButton.Checked == true)
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(input_textBox.Text);
                for (int i = 0; i < array.Length; i = m + n)
                {
                    string jinei;
                    if (array[i] < 0x81)
                    {
                        jinei = Convert.ToString(array[i], 16);

                        yima_listBox.Items.Add(input_textBox.Text.Substring(m + n / 2, 1) + "   的机内码是：" + jinei);
                        yima_textBox.Text += array[i].ToString("X2").ToUpper() + " ";

                        m++;
                    }
                    else
                    {
                        jinei = Convert.ToString(array[i], 16) + Convert.ToString(array[i + 1], 16);
                        yima_listBox.Items.Add(input_textBox.Text.Substring(m + n / 2, 1) + "  的机内码是：" + jinei);
                        yima_textBox.Text += array[i].ToString("X2").ToUpper() + " " + array[i + 1].ToString("X2").ToUpper() + " ";

                        n = n + 2;
                    }
                }
                yima_textBox.Text = yima_textBox.Text.Substring(0, yima_textBox.Text.Length - 1);
            }
            if (hex2str_radioButton.Checked == true)
            {
                int i = 0;
                string st = string.Empty;
                string result = string.Empty;

                try
                {
                    string[] strCheckArray = input_textBox.Text.Split(' ');
                    byte[] myarray = new byte[strCheckArray.Length];
                    foreach (var tmp in strCheckArray)
                    {
                        myarray[i++] = System.Convert.ToByte(tmp, 16);
                    }

                    for (int j = 0; j < i;)
                    {
                        if (myarray[j] < 0x81)
                        {
                            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                            byte[] byteArray = new byte[] { (byte)myarray[j++] };
                            string strCharacter = asciiEncoding.GetString(byteArray);
                            //yima_listBox.Items.Add(myarray[j].ToString() + "   的机内码是：" + strCharacter);
                            st = st + strCharacter;
                        }
                        else
                        {
                            byte[] bytes = new byte[2];
                            bytes[0] = myarray[j++];
                            bytes[1] = myarray[j++];
                            System.Text.Encoding chs = System.Text.Encoding.GetEncoding("gb2312");
                            result = chs.GetString(bytes);
                            st = st + result;
                        }
                    }

                    yima_textBox.Text = st;
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入正确格式的数据！");
                }
            }

        }



        private void clear_button_Click(object sender, EventArgs e)
        {
            yima_listBox.Items.Clear();
            input_textBox.Clear();
            yima_textBox.Clear();
        }
    }
}
