using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;



using System.Drawing.Drawing2D;
using System.Threading;
using System.Globalization;

namespace readFontlib
{
    public partial class readFontlib : Form
    {
        int picSize = 383;//!<画布大小，宽383高383
        int spaceSize = 2;//!<间隔2点
        int brushSize = 1;//!<画笔粗细为1
        int startx = 0;
        int starty = 0;//!<初始化矩形的起始位置
        int uniwidth, uniheight, width, height,index;
        int up_flag = 0;
        int down_flag = 0;
        Bitmap bmp;
        Byte[] data = new byte[2048];//!<字模数据
        string fontPath;
        bool lockFlag;
        bool editFlag;
        public bool begin = false;
        string message_openfile = "请首先打开一个字库文件";
        string makefontsize = "大小：";
        string makefontwidth = "宽度：";
        string makefontheight = "高度：";

        System.Windows.Forms.Timer time1 = new System.Windows.Forms.Timer();


        #region 字库查看修改的代码
        private void dataInit()//数据初始化，在读取字库时调用
        {
            int i;
            uniwidth = 10;
            uniheight = 10;
            width = 16;
            height = 16;
            index = 0;
            lockFlag = false;
            editFlag = false;//默认查看状态
            bmp = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            numericUpDownWidth.Value = 16;
            numericUpDownHeight.Value = 16;
            for (i = 0; i < 2048; i++) {
                data[i] = 0;
            }
            for (i = 161; i < 248; i++)
            {
                comboBoxQu.Items.Add(i.ToString("X2").ToUpper());
            }
            for (i = 161; i < 255; i++)
            {
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxQu.SelectedIndex = 0;
            comboBoxWei.SelectedIndex = 0;
            comboBoxQu.Enabled = false;
            comboBoxWei.Enabled = false;
            this.comboBoxQu.SelectedIndexChanged += new System.EventHandler(this.comboBoxQu_SelectedIndexChanged);
            this.comboBoxWei.SelectedIndexChanged += new System.EventHandler(this.comboBoxWei_SelectedIndexChanged);

            // readDefaultFontData();
        }
        public readFontlib()
        {
            InitializeComponent();
            dataInit();
            paintFont();
            textBoxFontName.BackColor = Color.White;
            textBoxFontName.ForeColor = Color.Red;
            richTextBoxData.SelectAll();
            richTextBoxData.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxData.Enabled = false;
            richTextBoxData.BackColor = Color.White;
            richTextBoxData.ForeColor = Color.Red;
        }


        private void writeFontData()//把修改后的字模信息写入字库文件
        {
            int i, startPosition, writeLenth;
            try
            {
                FileStream fs_write = new FileStream(fontPath, FileMode.Open, FileAccess.Write);
                BinaryWriter br = new BinaryWriter(fs_write);
                writeLenth = height * (width / 8 + (((width % 8) != 0) ? 1 : 0));
                startPosition = writeLenth * index;
                br.BaseStream.Seek(startPosition, SeekOrigin.Begin);
                for (i = 0; i < writeLenth; i++)
                {
                     br.Write(data[i]);
                }
                br.Close();
                fs_write.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readFontData()//读指定位置字库数据
        {
            int i, startPosition, readLenth;
            try
            {
                FileStream fs_read = new FileStream(fontPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs_read);
                readLenth = height * (width / 8 + (((width % 8) != 0) ? 1 : 0));
                startPosition = readLenth * index;
                br.BaseStream.Seek(startPosition, SeekOrigin.Begin);
                for (i = 0; i < readLenth; i++)
                {
                    data[i] = br.ReadByte();
                }
                br.Close();
                fs_read.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void paintFont()//显示当前字模数据到字库区域
        {
            int x, y;
            int picSx, picSy;
            int num,num1;
            int num_x, num_y;
            string str;
            int num2;

            Bitmap p = new Bitmap(picSize, picSize);
            Graphics g = Graphics.FromImage(p); //!<创建一个图形类

            Pen blackPen = new Pen(Color.Black, brushSize);    //!<黑色画笔，画笔宽度为1
            Pen whitePen = new Pen(Color.White, brushSize);    //!<白色画笔
            Pen bluePen  = new Pen(Color.Blue, brushSize);      //!<蓝色画笔
            Pen redPen   = new Pen(Color.Red, brushSize);      //!<红色画笔
            Brush blackBrush = blackPen.Brush;
            Brush whiteBrush = whitePen.Brush;

            Rectangle whitePanel = new Rectangle(startx, starty, uniwidth, uniheight);
            Rectangle blackPanel = new Rectangle(startx, starty, uniwidth, uniheight);
            Rectangle bluePanel  = new Rectangle(startx, starty, uniwidth, uniheight);

            picSx = (picSize - width * uniwidth - spaceSize * (width - 1)) / 2;
            picSy = (picSize - height * uniheight - spaceSize * (height - 1)) / 2;

            num_x = picSx - 12;
            num_y = picSy - 12;

            Font f = new Font("Arial", 8, FontStyle.Bold);
            PointF pf = new PointF(num_x, num_y);
            /* 写X轴的数字 */
            num2 = 0;
            for (y = 0; y < width ; y++)
            {
                if(num2 == 8)
                    num2 = 0;
                pf.X += 12;
                str = Convert.ToString(num2);
                g.DrawString(str, f, Brushes.Red, pf);
                num2++;
            }
            /* 写Y轴的数字 */
            pf.X = num_x-2;
            pf.Y = num_y;
            for (x = 0; x < height; x++)
            {
                pf.Y += 12;
                str = Convert.ToString(x+1);
                g.DrawString(str, f, Brushes.Red, pf);
            }
            
            

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    num1 = (width / 8) + ((width % 8 != 0) ? 1 : 0);
                    num = ((x + 1) / 8) + (((x + 1) % 8 != 0) ? 1 : 0);
                    num = num1 * y + num -1;
                    if (((data[num] >> (7 - x % 8)) & 0x01) == 0)
                    {
                        bluePanel.X = x * (uniwidth + spaceSize) + picSx;
                        bluePanel.Y = y * (uniheight + spaceSize) + picSy;
                        g.DrawRectangle(bluePen, bluePanel);
                    }
                    else
                    {
                        blackPanel.X = x * (uniwidth + spaceSize) + picSx;
                        blackPanel.Y = y * (uniheight + spaceSize) + picSy;
                        g.DrawRectangle(blackPen, blackPanel);
                        g.FillRectangle(blackBrush, blackPanel); 
                    }
                }
            }
            pictureBoxFont.Image = p;
            //p.Save("D:\\pictrue.bmp");
        }
        private void displayFont()
        {
            int fileFlag;
            if (fontPath == null)
            {
                fileFlag = 1;
            }
            else if (!File.Exists(fontPath))
            {
                fileFlag = 2;
            }
            else
            {
                fileFlag = 3;
            }
            if (fileFlag==3)
            {
                readFontData();//!<读取指定位置的点阵数据
                paintFont();
            }
            else if (fileFlag == 1)
            {
                textBoxFontName.Clear();
                MessageBox.Show(this, "路径为空！\n请选择文件路径！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBoxFontName.Clear();
                MessageBox.Show(this, "文件不存在！路径及文件名为：" + fontPath + "\n请重新选择文件！文件找不到了。。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getFontName(string path)//读取字库名字
        {
            string a = "";
            string[] strArray = path.Split('\\');
            a = strArray[strArray.Length - 1];
            return a;
        }
        private void buttonReadFont_Click (object sender, EventArgs e)//读取字库名按钮单击事件
        {
            FontStyle style = FontStyle.Regular;
            Font tmpFont = new Font("宋体", 9, style);
            
            OpenFileDialog fontFile = new OpenFileDialog();
            fontFile.Filter = "所有文件|*.*";//!<过滤文件类型
            fontFile.RestoreDirectory = true; //!<记忆上次浏览路径
            if (fontFile.ShowDialog() == DialogResult.OK)
            {
                fontPath = fontFile.FileName;
                textBoxFontName.TextAlign = HorizontalAlignment.Left;
                textBoxFontName.ForeColor = Color.Black;
                textBoxFontName.Font = tmpFont;
                textBoxFontName.Text = getFontName(fontFile.FileName);//获取字库的名字
                numericUpDownIndex.Value = 0;
                displayFont();
            }
        }

        private void numericUpDownIndex_ValueChanged(object sender, EventArgs e)//编号改变事件
        {
            if ((fontPath != null) && (File.Exists(fontPath)))
            {
                index = (int)numericUpDownIndex.Value;
                displayFont();
            }
            else
            {
                MessageBox.Show(message_openfile);
            }
        }
        private void GBK_radioButton_CheckedChanged(object sender, EventArgs e)//选中GBK
        {
            comboBoxQu.Enabled = true;
            comboBoxWei.Enabled = true;
            down_flag = 0;
            up_flag = 0;
            comboBoxWei.Items.Clear();
            for (int i = 64; i < 255; i++)
            {
                if (i == 127)
                {
                    i++;
                }
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxWei.Text = "40";
            comboBoxQu.Items.Clear();
            for (int i = 129; i < 255; i++)
            {
                comboBoxQu.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxQu.Text = "81";
        }
        private void radioButtonFontLib_CheckedChanged(object sender, EventArgs e)//选中GB2312
        {
            lockFlag = true;
            comboBoxQu.Enabled = true;
            comboBoxWei.Enabled = true;
            down_flag = 0;
            up_flag = 0;

            comboBoxQu.Items.Clear();
            for (int i = 161; i < 255; i++)
            {
                comboBoxQu.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxQu.Text = "A1";
            comboBoxWei.Items.Clear();
            for (int i = 161; i < 255; i++)
            {
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxWei.Text = "A1";

            lockFlag = false;
        }
        private void radioButtonUnit_CheckedChanged(object sender, EventArgs e)//选中ASCII
        {
            down_flag = 0;
            up_flag = 0;
            comboBoxQu.Items.Clear();
            for (int i = 0; i < 256; i++)
            {
                comboBoxQu.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxWei.Items.Clear();
            for (int i = 0; i < 256; i++)
            {
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxQu.Enabled = false;
            comboBoxWei.SelectedIndex = 0;
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)//字模宽度改变事件
        {
            if (!lockFlag)
            {
                if (radioButtonFontLib.Checked)
                {
                    width = (int)numericUpDownWidth.Value;
                }
                else if (radioButtonUnit.Checked)
                {
                    /* uni */width = (int)numericUpDownWidth.Value;
                }
                if ((fontPath != null) && (File.Exists(fontPath)))
                {
                    displayFont();
                }
                else
                {
                    paintFont();
                }
            }
        }
        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)//字模高度改变事件
        {
            if (!lockFlag)
            {
                if (radioButtonFontLib.Checked)
                {
                    height = (int)numericUpDownHeight.Value;
                }
                else if (radioButtonUnit.Checked)
                {
                    /* uni */height = (int)numericUpDownHeight.Value;
                }
                if ((fontPath != null) && (File.Exists(fontPath)))
                {
                    displayFont();
                }
                else
                {
                    paintFont();
                }
            }
        }

        private void buttonGetData_Click(object sender, EventArgs e)//读取字模数据按钮单击事件
        {
            int i, readLenth;
            FontStyle style = FontStyle.Regular;
            Font tmpFont = new Font("宋体", 9, style);
            readLenth = height * (width / 8 + (((width % 8) != 0) ? 1 : 0));
            richTextBoxData.Enabled = true;
            richTextBoxData.SelectionAlignment = HorizontalAlignment.Left;
            richTextBoxData.ForeColor = Color.Black;
            richTextBoxData.Font = tmpFont;
            richTextBoxData.Clear();
            for (i = 0; i < readLenth; i++)
            {
                if (check_data_format.Checked == true)
                {
                    richTextBoxData.Text += "0x" + data[i].ToString("X2").ToUpper() + ",";
                } else {
                    richTextBoxData.Text += data[i].ToString("X2").ToUpper() + " ";
                }
                
            }
            labelFontInfo.Text = "字库信息：" + width.ToString() + "*" + height.ToString();
            labelByteNum.Text = readLenth.ToString();
        }

        private void richTextBoxData_DoubleClick(object sender, EventArgs e)//读取出字模数据框双击事件
        {
                string[] strCheckArray = (richTextBoxData.Text.Trim()).Split(' ');
                string temp = string.Empty;
                foreach (var tmp in strCheckArray)
                {
                    temp += ((~System.Convert.ToByte(tmp, 16)) & 0xFF).ToString("X2").ToUpper() + " ";
                }
                richTextBoxData.Text = temp;
        }

        private void readFontlib_Load(object sender, EventArgs e)
        {
            comboBoxQu.Enabled = true;
            comboBoxWei.Enabled = true;
            radioButtonFontLib.Checked = true;

            this.time1.Interval = 1000;
            this.time1.Tick += new System.EventHandler(this.timer_Tick);
            this.time1.Start();
            textBoxtime.Text = DateTime.Now.ToString();
            this.makefont_DataInFormLoad();
        }

        private void pictureBoxFont_MouseDown(object sender, MouseEventArgs e)//字模显示区鼠标左键按下事件
        {
            int wei_num;
            int date_cache;
            if (editFlag == true)
            {
                begin = true;
                Point contextMenuPoint = pictureBoxFont.PointToClient(Control.MousePosition);
                if (e.Button == MouseButtons.Left)//鼠标左键
                {
                    int Y = contextMenuPoint.Y;
                    int X = contextMenuPoint.X;

                    int X_start = (386 - width * 12) / 2;
                    int Y_start = (386 - height * 12) / 2;
                    if ((X > X_start) && (Y > Y_start))
                    {
                        int x_pain = (X - X_start) / 12;
                        int y_pain = (Y - Y_start) / 12;
                        if((width % 8) == 0){
                          date_cache = data[y_pain * (width / 8) + x_pain / 8];
                        }else{
                          date_cache = data[y_pain * ((width / 8) + 1) + x_pain / 8];
                        }
                        
                        if (x_pain > 23)
                        {
                            wei_num = x_pain - 24;
                        }
                        else
                        {
                            if (x_pain > 15)
                            {
                                wei_num = x_pain - 16;
                            }
                            else
                            {
                                if (x_pain > 7)
                                {
                                    wei_num = x_pain - 8;
                                }
                                else
                                {
                                    wei_num = x_pain;
                                }
                            }
                        }
                        date_cache = date_cache ^ (0X80 >> wei_num);
                        if((width % 8) == 0){
                          data[y_pain * (width / 8) + x_pain / 8] = (byte)date_cache;
                        }else{
                          data[y_pain * ((width / 8) + 1) + x_pain / 8] = (byte)date_cache;
                        }
                        paintFont();
                        buttonGetData_Click(this, null);
                    }

                }
                else
                {

                }

            }
        }

        private void logo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//点击公司logo
        {
            //System.Diagnostics.Process.Start("iexplore.exe", "http://www.onbonbx.com");
            System.Diagnostics.Process.Start("http://www.onbonbx.com");
        }

        private void author_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://user.qzone.qq.com/1601438030/main");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            textBoxtime.Text = DateTime.Now.ToString();
        }

        private void pictureBoxFont_MouseMove(object sender, MouseEventArgs e)
        {
            int wei_num;
            int date_cache;
            if (editFlag == true)
            {
                if (begin)
                {
                    Point contextMenuPoint = pictureBoxFont.PointToClient(Control.MousePosition);
                    
                        int Y = contextMenuPoint.Y;
                        int X = contextMenuPoint.X;

                        int X_start = (386 - width * 12) / 2;
                        int Y_start = (386 - height * 12) / 2;
                        if ((X > X_start) && (Y > Y_start))
                        {
                            int x_pain = (X - X_start) / 12;
                            int y_pain = (Y - Y_start) / 12;
                            if ((width % 8) == 0)
                            {
                                date_cache = data[y_pain * (width / 8) + x_pain / 8];
                            }
                            else
                            {
                                date_cache = data[y_pain * ((width / 8) + 1) + x_pain / 8];
                            }

                            if (x_pain > 23)
                            {
                                wei_num = x_pain - 24;
                            }
                            else
                            {
                                if (x_pain > 15)
                                {
                                    wei_num = x_pain - 16;
                                }
                                else
                                {
                                    if (x_pain > 7)
                                    {
                                        wei_num = x_pain - 8;
                                    }
                                    else
                                    {
                                        wei_num = x_pain;
                                    }
                                }
                            }
                        if (e.Button == MouseButtons.Left)//鼠标左键
                        {
                            date_cache = date_cache | (0X80 >> wei_num);
                        }
                        if (e.Button == MouseButtons.Right)//鼠标右键
                        {
                            date_cache &= ~(0X80 >> wei_num);
                        }
                        if ((width % 8) == 0)
                            {
                                data[y_pain * (width / 8) + x_pain / 8] = (byte)date_cache;
                            }
                            else
                            {
                                data[y_pain * ((width / 8) + 1) + x_pain / 8] = (byte)date_cache;
                            }
                            paintFont();
                            buttonGetData_Click(this, null);
                        }
                }

            }
        }

        private void pictureBoxFont_MouseUp(object sender, MouseEventArgs e)
        {
            if (editFlag == true)
            {
                begin = false;
            }
        }

        private void View_mode_Button_CheckedChanged(object sender, EventArgs e)//选中查看模式
        {
            editFlag = false;
            Save_font_button.Enabled = false;
        }

        private void edit_mode_Button_CheckedChanged(object sender, EventArgs e)//选中编辑模式
        {
            editFlag = true;
            Save_font_button.Enabled = true;
        }

        private void check_data_format_CheckedChanged(object sender, EventArgs e)//是否添加0x
        {
            buttonGetData_Click(this, null);
        }


        private void Save_font_button_Click(object sender, EventArgs e)//保存字模按钮单击事件
        {
            writeFontData();
            MessageBox.Show("成功保存这个字模");
        }
        private void up_button_Click(object sender, EventArgs e)
        {
            if ((fontPath != null) && (File.Exists(fontPath)))
            {
                if (radioButtonUnit.Checked == true)
                {
                    if (comboBoxWei.SelectedIndex == 0)
                    {
                        comboBoxWei.Text = "FF";
                    }
                    else
                    {
                        comboBoxWei.Text = (comboBoxWei.SelectedIndex - 1).ToString("X8").Remove(0, 6);
                    }
                }
                if (radioButtonFontLib.Checked == true)
                {
                    comboBoxWei.Text = (comboBoxWei.SelectedIndex + 160).ToString("X8").Remove(0, 6);
                    if (up_flag == 1)
                    {
                        up_flag = 0;
                        comboBoxWei.Text = "FE";
                        comboBoxQu.Text = (comboBoxQu.SelectedIndex + 160).ToString("X8").Remove(0, 6);
                    }
                    if (comboBoxWei.Text == "A1")
                        up_flag = 1;
                }
                if (GBK_radioButton.Checked == true)
                {
                    comboBoxWei.Text = (comboBoxWei.SelectedIndex + 63).ToString("X8").Remove(0, 6);
                    if (up_flag == 1)
                    {
                        up_flag = 0;
                        comboBoxWei.Text = "FE";
                        comboBoxQu.Text = (comboBoxQu.SelectedIndex + 128).ToString("X8").Remove(0, 6);
                    }
                    if (comboBoxWei.Text == "40")
                        up_flag = 1;

                }
            }
            else
            {
                MessageBox.Show(message_openfile);
            }
        }

        private void down_button_Click(object sender, EventArgs e)
        {
            if ((fontPath != null) && (File.Exists(fontPath)))
            {
                if (radioButtonUnit.Checked == true)
                {
                    if (comboBoxWei.SelectedIndex == 255)
                    {
                        comboBoxWei.Text = "00";
                    }
                    else
                    {
                        comboBoxWei.Text = (comboBoxWei.SelectedIndex + 1).ToString("X8").Remove(0, 6);
                    }
                }
                if (radioButtonFontLib.Checked == true)
                {
                    comboBoxWei.Text = (comboBoxWei.SelectedIndex + 162).ToString("X8").Remove(0, 6);
                    if (down_flag == 1)
                    {
                        down_flag = 0;
                        comboBoxWei.Text = "A1";
                        comboBoxQu.Text = (comboBoxQu.SelectedIndex + 162).ToString("X8").Remove(0, 6);
                    }
                    if (comboBoxWei.Text == "FE")
                        down_flag = 1;
                }
                if (GBK_radioButton.Checked == true)
                {
                    comboBoxWei.Text = (comboBoxWei.SelectedIndex + 66).ToString("X8").Remove(0, 6);
                    if (down_flag == 1)
                    {
                        down_flag = 0;
                        comboBoxWei.Text = "40";
                        comboBoxQu.Text = (comboBoxQu.SelectedIndex + 130).ToString("X8").Remove(0, 6);
                    }
                    if (comboBoxWei.Text == "FE")
                        down_flag = 1;
                }
            }
            else
            {
                MessageBox.Show(message_openfile);
            }
        }

        private void check_data_format_Checked(object sender, EventArgs e)
        {
            buttonGetData_Click(this, null);
        }

        private void calIndex()//区位改变时计算字模的位置
        {
            int qu, wei;
            qu = comboBoxQu.SelectedIndex;
            wei = comboBoxWei.SelectedIndex;
            if (qu < 0)
                qu = 0;
            if (wei < 0)
                wei = 0;
            if (radioButtonUnit.Checked == true)
            {
                numericUpDownIndex.Value = wei;
            }
            if (radioButtonFontLib.Checked == true)
            {
                numericUpDownIndex.Value = qu * 94 + wei;
            }
            if (GBK_radioButton.Checked == true)
            {
                numericUpDownIndex.Value = qu * 190 + wei;
            }


        }
        private void comboBoxQu_SelectedIndexChanged(object sender, EventArgs e)//区码改变
        {
            calIndex();
        }
        private void comboBoxWei_SelectedIndexChanged(object sender, EventArgs e)//位码改变
        {
            calIndex();
        }
        #endregion 字库查看修改的代码


        #region 机内码查询的代码

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

        #endregion 机内码查询的代码



        #region CRC16校验的代码

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

        #endregion CRC16校验的代码


        #region 制作字库的代码

        private MakeFont MatCharFont;

        private void font_size_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //重新设置选用的字体。
            this.MatCharFont.MatFont =
                new Font(this.MatCharFont.MatFont.FontFamily,
                         (float)this.font_size_numericUpDown.Value,
                         this.MatCharFont.MatFont.Style);
            //更新字符预览。
            this.font_viwer_panel.BackgroundImage = this.MatCharFont.MatBitmap;

            //更新当前字体信息。
            this.font_message_textBox.Clear();
            this.font_message_textBox.Text = this.MatCharFont.GetMatFontInfo();
        }

        private void rdBtnStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdBtnStandard.Checked)
            {
                this.font_width_label.Text = makefontsize;
                this.font_height_label.Text = "  ";
                this.height_numericUpDown.Enabled = false;
            }
        }

        private void rdBtnNonStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdBtnNonStandard.Checked)
            {
                this.font_width_label.Text = makefontwidth;
                this.font_height_label.Text = makefontheight;
                this.height_numericUpDown.Enabled = true;
            }
        }

        private void make_font_button_Click(object sender, EventArgs e)
        {
            pgbBuilderProc.Visible = true;
            statusStripProc.Visible = true;
            if (ASCII.Checked == true)
            {
                this.saveFileDlg.FileName = "En" + "_" + this.MatCharFont.MatFont.SizeInPoints.ToString("##") + "_"
                                            + width_numericUpDown.Value + height_numericUpDown.Value;
            }
            else
            {
                switch (this.MatCharFont.MatFont.FontFamily.Name)
                {
                    case "宋体": this.saveFileDlg.FileName = "SongTi" + "_"; break;
                    case "黑体": this.saveFileDlg.FileName = "HeiTi" + "_"; break;
                    case "楷体": this.saveFileDlg.FileName = "KaiTi" + "_"; break;
                    case "隶书": this.saveFileDlg.FileName = "LiShu" + "_"; break;
                    default: this.saveFileDlg.FileName = "QiTa" + "_"; break;
                }
                this.saveFileDlg.FileName += this.MatCharFont.MatFont.SizeInPoints.ToString("##") + "_"
                                            + width_numericUpDown.Value + height_numericUpDown.Value + "_"; //--保存的名字
                if (GB2312.Checked == true)
                {
                    this.saveFileDlg.FileName += "GB2312";
                }
                else
                {
                    if (GBK.Checked == true)
                    {
                        this.saveFileDlg.FileName += "GBK";
                    }
                }
            }

            
            if (this.saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                //停止UI界面上的控件对 MatCharFont(MatrixFont 类) 对象数据的操作。
                this.UIEnabled(false);

                //启动点阵数据文件生成的辅助线程。
                
                this.bgwFileBuilder.RunWorkerAsync(this.saveFileDlg.FileName);
            }
        }

        private void bgwFileBuilder_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = (string)e.Argument;
            
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ////将点阵字体的字符宽度和高度写入文件的头部。
                //fs.WriteByte((byte)Math.Min(this.MatCharFont.CharWidth, 100));
                //fs.WriteByte((byte)Math.Min(this.MatCharFont.CharHeight, 100));
                if(GB2312.Checked == true)
                {
                    //在GB2312编码的汉字字库中，共有 8178 个字符；
                    //遍历每一个字符，生成它们的点阵数据文件。
                    for (int i = 0; i < 8178; i++)
                    {
                        //设置汉字的区位码。
                        byte[] bt = new byte[2];
                        bt[0] = (byte)(Math.Floor((double)i / 94) + 161);
                        bt[1] = (byte)(i % 94 + 161);

                        //按照区位码，解码成汉字字符。
                        this.MatCharFont.DemoChar = Encoding.GetEncoding("GB2312").GetString(bt);

                        //获取字符的点阵数据。
                        Byte[] byteArray = this.MatCharFont.GetDemoCharMatrixBytes();

                        //写入文件。
                        foreach (Byte ba in byteArray)
                        {
                            fs.WriteByte(ba);
                        }

                        //报告文件生成进度。
                        //设置判断条件，可以减少重复的进度报告，提高执行效率。
                        if ((i % 82 == 0) || (i == 8177))
                        {
                            int procPercent = (int)((double)i / 8177 * 100);
                            this.pgbBuilderProc.Value = procPercent;
                            this.tssLblStatus.Text = String.Format("正在执行文件生成过程({0}%)", procPercent);
                        }
                    }
                }
                if (GBK.Checked == true)
                {
                    //在GBK编码的汉字字库中，共有 26208 个字符；
                    //遍历每一个字符，生成它们的点阵数据文件。
                    //for (uint i = 0; i < 23940; i++)
                    for (uint i = 0; i < 26208; i++)
                    {
                        //设置汉字的区位码。
                        byte[] bt = new byte[2];
                        bt[0] = (byte)(Math.Floor((double)i / 191) + 129);
                        bt[1] = (byte)(i % 191 + 64);
                        if (bt[1] == 127)
                        {
                            bt[1] += 1;
                            i++;
                        }
                        if (bt[1] == 255)
                        {
                            bt[0] += 1;
                            bt[1]  = 0;
                            i++;
                        }

                        //按照区位码，解码成汉字字符。
                        this.MatCharFont.DemoChar = Encoding.GetEncoding("GBK").GetString(bt);

                        //获取字符的点阵数据。
                        Byte[] byteArray = this.MatCharFont.GetDemoCharMatrixBytes();

                        //写入文件。
                        foreach (Byte ba in byteArray)
                        {
                            fs.WriteByte(ba);
                        }

                        //报告文件生成进度。
                        //设置判断条件，可以减少重复的进度报告，提高执行效率。
                        if ((i % 82 == 0) || (i == 26208))
                        {
                            int procPercent = (int)((double)i / 26208 * 100);
                            this.pgbBuilderProc.Value = procPercent;
                            this.tssLblStatus.Text = String.Format("正在执行文件生成过程({0}%)", procPercent);
                        }
                    }
                }
                if (ASCII.Checked == true)
                {
                    //在ASCII编码的字库中，共有 256 个字符；
                    //遍历每一个字符，生成它们的点阵数据文件。
                    for (int i = 0; i < 256; i++)
                    {
                        System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                        byte[] byte_ascii_Array = new byte[] { (byte)i };
                        this.MatCharFont.DemoChar = asciiEncoding.GetString(byte_ascii_Array);

                        //获取字符的点阵数据。
                        Byte[] byteArray = this.MatCharFont.GetDemoCharMatrixBytes();

                        //写入文件。
                        foreach (Byte ba in byteArray)
                        {
                            fs.WriteByte(ba);
                        }

                        //报告文件生成进度。
                        //设置判断条件，可以减少重复的进度报告，提高执行效率。
                        if ((i % 82 == 0) || (i == 256))
                        {
                            int procPercent = (int)((double)i / 256 * 100);
                            this.pgbBuilderProc.Value = procPercent;
                            this.tssLblStatus.Text = String.Format("正在执行文件生成过程({0}%)", procPercent);
                        }
                    }
                }


                //清除文件流的缓冲区，关闭文件。
                fs.Flush();
                fs.Close();
            }

        }

        private void bgwFileBuilder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("点阵字库文件生成过程结束！", "系统提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //恢复窗口的UI界面。
            this.UIEnabled(true);
            this.tssLblStatus.Text = "";
            this.pgbBuilderProc.Value = 0;
            statusStripProc.Visible = false;
            pgbBuilderProc.Visible = false;
            if (this.MatCharFont.IsEqualWH)
            {
                this.height_numericUpDown.Enabled = false;
            }
        }

        private void UIEnabled(bool isEnabled)
        {
            this.check_font_button.Enabled = isEnabled;           //“选择字体”按钮。
            this.font_viwer_textBox.Enabled = isEnabled;        //“当前字符：”文本框。
            this.font_size_numericUpDown.Enabled = isEnabled;       //“字体大小：”数字框。

            this.font_viwer_panel.Enabled = isEnabled;         //“当前字符预览”下的Panel。

            this.rdBtnStandard.Enabled = isEnabled;     //“高宽相等”单选按钮。
            this.rdBtnNonStandard.Enabled = isEnabled;  //“高宽不相等”单选按钮。

            this.width_numericUpDown.Enabled = isEnabled;          //字体“宽度：”数字框。
            this.height_numericUpDown.Enabled = isEnabled;         //字体“高度：”数字框。
            this.level_numericUpDown.Enabled = isEnabled;        //字体“水平偏移：”数字框。
            this.vertical_numericUpDown.Enabled = isEnabled;        //字体“垂直偏移：”数字框。

            //this.btnBuilderChar.Enabled = isEnabled;        //“生成当前字符点阵数据”按钮。
            this.make_font_button.Enabled = isEnabled;  //“生成字库的点阵数据文件”按钮。

            ////文件生成过程时使用的进度条（确定其是否可见）。
            //this.pgbBuilderProc.Visible = !isEnabled;

            //设置UI控件是否与数据对象(MatrixFont类对象)进行绑定操作。
            this.UIBindingData(isEnabled);
        }



        /// <summary>
        /// 直接初始化字段数据的方法。
        /// </summary>
        private void makefont_DataInFormLoad()
        {
            //创建 MatrixFont 对象。
            Font matFont = new Font(this.Font.FontFamily, (float)this.font_size_numericUpDown.Value);
            this.MatCharFont = new MakeFont(matFont, '陈', (int)this.width_numericUpDown.Value,
                         (int)this.height_numericUpDown.Value, (int)this.level_numericUpDown.Value,
                         (int)this.vertical_numericUpDown.Value, this.rdBtnStandard.Checked);

            //将窗体上的一些控件与 MatCharFont 对象的一些属性绑定，方便操作。
            this.UIBindingData(true);

            //监视 MatCharFont 对象的数据操作是否有误。
            //this.errorProvider.DataSource = this.MatCharFont;

            //初始化窗体的一些控件属性。
            this.font_width_label.Text = "宽度：";
            this.font_height_label.Text = "高度：";
            this.height_numericUpDown.Enabled = true;
            this.font_message_textBox.Text = this.MatCharFont.GetMatFontInfo();
        }

        private void check_font_button_Click(object sender, EventArgs e)
        {
            if (this.fontDlg.ShowDialog() == DialogResult.OK)
            {
                int fontSize = int.Parse(this.fontDlg.Font.SizeInPoints.ToString("##"));
                this.font_size_numericUpDown.Value = fontSize;      //同步设置“字体大小”数字框的值。

                //重新设置选用的字体。
                this.MatCharFont.MatFont =
                    new Font(this.fontDlg.Font.FontFamily, (float)fontSize,
                             this.fontDlg.Font.Style, this.fontDlg.Font.Unit);
                //更新字符预览。
                this.font_viwer_panel.BackgroundImage = this.MatCharFont.MatBitmap;

                //更新当前字体信息。
                this.font_message_textBox.Clear();
                this.font_message_textBox.Text = this.MatCharFont.GetMatFontInfo();
            }

        }


        /// <summary>
        /// 设置窗体UI界面的一些控件是否要绑定到数据对象(MatrixFont类对象)进行交互操作。
        /// </summary>
        /// <param name="isBinding">
        /// UI控件是否要绑定到数据对象(MatrixFont类对象)，值true表示绑定，false表示不绑定。
        /// </param>
        private void UIBindingData(bool isBinding)
        {
            if (isBinding)
            {
                //“当前字符：”文本框。
                this.font_viwer_textBox.DataBindings.Add("Text", this.MatCharFont, "DemoChar",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                //“高宽相等”单选按钮。
                this.rdBtnStandard.DataBindings.Add("Checked", this.MatCharFont, "IsEqualWH",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                //字体“宽度：”数字框。
                this.width_numericUpDown.DataBindings.Add("Value", this.MatCharFont, "CharWidth",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                //字体“高度：”数字框。
                this.height_numericUpDown.DataBindings.Add("Value", this.MatCharFont, "CharHeight",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                //字体“水平偏移：”数字框。
                this.level_numericUpDown.DataBindings.Add("Value", this.MatCharFont, "OffsetX",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                //字体“垂直偏移：”数字框。
                this.vertical_numericUpDown.DataBindings.Add("Value", this.MatCharFont, "OffsetY",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                //“当前字符预览”下的Panel。
                this.font_viwer_panel.DataBindings.Add("BackgroundImage", this.MatCharFont, "MatBitmap",
                    true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else
            {
                this.font_viwer_textBox.DataBindings.Clear();       //“当前字符：”文本框。
                this.rdBtnStandard.DataBindings.Clear();            //“高宽相等”单选按钮。
                this.width_numericUpDown.DataBindings.Clear();         //字体“宽度：”数字框。
                this.height_numericUpDown.DataBindings.Clear();        //字体“高度：”数字框。
                this.level_numericUpDown.DataBindings.Clear();       //字体“水平偏移：”数字框。
                this.vertical_numericUpDown.DataBindings.Clear();       //字体“垂直偏移：”数字框。
                this.font_viwer_panel.DataBindings.Clear();          //“当前字符预览”下的Panel。
                this.font_viwer_panel.BackgroundImage = null;        //清除“当前字符预览”下的Panel的背景图片。
            }
        }
        #endregion 制作字库的代码

        #region UI语言
        private void author_qq_picture_Click(object sender, EventArgs e)
        {
            //string url = "http://wpa.qq.com/msgrd?v=3&uin=" + 1601438030 + "&site=qq&menu=yes";
            string url = "http://wpa.qq.com/msgrd?v=3&uin=1601438030&site=qq&menu=yes";
            System.Diagnostics.Process.Start(url);
        }

        private void 中文繁体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHT");
            UpDataMainFormUILanguage();
        }

        private void 中文简体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            UpDataMainFormUILanguage();
        }



        private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            UpDataMainFormUILanguage();
        }

        //根据当前的语言区域,更新主窗口的语言信息
        private void UpDataMainFormUILanguage()
        {
            ResourceManager rm = new ResourceManager(typeof(readFontlib));
            UpDataMainFormMenuLanguage(rm);
            UpDataMainFormToolBarLanguage(rm);
        }

        //根据当前的语言区域,更新主窗口菜单的语言
        private void UpDataMainFormMenuLanguage(ResourceManager rm)
        {
            #region 查看编辑区域
            tabControl.TabPages[0].Text = rm.GetString("TabPages0"); 
            groupBoxpic.Text = rm.GetString("groupBoxpic");
            View_mode_Button.Text = rm.GetString("View_mode_Button");
            edit_mode_Button.Text = rm.GetString("edit_mode_Button");
            groupBoxSet.Text = rm.GetString("groupBoxSet");
            labelFontName.Text = rm.GetString("labelFontName");
            textBoxFontName.Text = rm.GetString("textBoxFontName");

            buttonReadFont.Text = rm.GetString("buttonReadFont");
            labelWidth.Text = rm.GetString("labelWidth");
            labelHeight.Text = rm.GetString("labelHeight");
            labelIndex.Text = rm.GetString("labelIndex");
            up_button.Text = rm.GetString("up_button");
            down_button.Text = rm.GetString("down_button");

            groupBoxData.Text = rm.GetString("groupBoxData");
            buttonGetData.Text = rm.GetString("buttonGetData");
            Save_font_button.Text = rm.GetString("Save_font_button");
            check_data_format.Text = rm.GetString("check_data_format");
            labelFontInfo.Text = rm.GetString("labelFontInfo");
            labelNum.Text = rm.GetString("labelNum");
            richTextBoxData.Text = "";
            richTextBoxData.AppendText ("\n" + "\n" + "\n" + "\n" + rm.GetString("copyright"));

            #endregion 查看编辑区域


            #region 制作字库区域
            tabControl.TabPages[1].Text = rm.GetString("TabPages1");
            preview_groupBox.Text = rm.GetString("preview_groupBox");
            font_groupBox.Text = rm.GetString("font_groupBox");
            message_groupBox.Text = rm.GetString("message_groupBox");
            check_font_button.Text = rm.GetString("check_font_button");
            font_label.Text = rm.GetString("font_label");
            font_view_label.Text = rm.GetString("font_view_label");

            binama_groupBox.Text = rm.GetString("binama_groupBox");
            set_groupBox.Text = rm.GetString("set_groupBox");
            font_width_label.Text = rm.GetString("font_width_label");
            font_height_label.Text = rm.GetString("font_height_label");
            level_label.Text = rm.GetString("level_label");
            vertical_label.Text = rm.GetString("vertical_label");

            rdBtnNonStandard.Text = rm.GetString("rdBtnNonStandard");
            rdBtnStandard.Text = rm.GetString("rdBtnStandard");
            make_font_button.Text = rm.GetString("make_font_button");
            makefontsize = rm.GetString("makefontsize");
            makefontwidth = rm.GetString("font_width_label"); 
            makefontheight = rm.GetString("font_height_label");
            #endregion 制作字库区域


            #region 机内码查询区域
            tabControl.TabPages[2].Text = rm.GetString("TabPages2");
            message.Text = rm.GetString("message");
            Transfor_button.Text = rm.GetString("Transfor_button");
            clear_button.Text = rm.GetString("clear_button");
            #endregion 机内码查询区域

            #region CRC16校验区域
            tabControl.TabPages[3].Text = rm.GetString("TabPages3");
            check_groupBox.Text = rm.GetString("check_groupBox");
            crc_check_button.Text = rm.GetString("crc_check_button");
            crc_clear_button.Text = rm.GetString("crc_clear_button");
            #endregion CRC16校验区域

            message_openfile = rm.GetString("mes_openfile");

            return;
        }

        //根据当前的语言区域,更新主窗口工具栏的语言
        private void UpDataMainFormToolBarLanguage(ResourceManager rm)
        {
            语言ToolStripMenuItem.Text = rm.GetString("语言");
            中文简体ToolStripMenuItem.Text = rm.GetString("中文简体");
            中文繁体ToolStripMenuItem.Text = rm.GetString("中文繁体");
            英文ToolStripMenuItem.Text = rm.GetString("英文");
            关于ToolStripMenuItem.Text = rm.GetString("关于");

            return;
        }
        #endregion UI语言


        #region 数据解析
        struct PHY0_flag
        {
            public Int16 Rcv_state;                                    //!< 接收状态标志
            public Int16 RCV_data_num;                                 //!< 接收到个数位置
        };


        string[] data_header = { "屏地址", "源地址", "保留字节", "显示模式", "设备类型", "协议版本号", "数据域长度" };
        string[] dynamic_cmd = {"命令分组","命令编号", "控制是否回复", "保留字节", "删除区域个数","删除区域ID","更新区域个数","区域数据长度"};

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == analysis)
            {
                MessageBox.Show("数据解析只适合动态区域数据，而且是正确的数据包！");
            }
            
        }

        private void out_excel_button_Click(object sender, EventArgs e)
        {
            ExportToExecl();

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!p.HasExited)  // 如果程序没有关闭，结束程序
                {
                    p.Kill();
                    p.WaitForExit();
                }
            }

        }




        /// <summary>

        /// 执行导出数据

        /// </summary>

        public void ExportToExecl()

        {

            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();

            sfd.DefaultExt = "xls";

            sfd.Filter = "Excel文件(*.xls)|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)

            {

                DoExport(this.data_listView, sfd.FileName);

            }

        }

        /// <summary>

        /// 具体导出的方法

        /// </summary>

        /// <param name="listView">ListView</param>

        /// <param name="strFileName">导出到的文件名</param>

        private void DoExport(ListView listView, string strFileName)

        {

            int rowNum = listView.Items.Count;

            int columnNum = listView.Items[0].SubItems.Count;

            int rowIndex = 1;

            int columnIndex = 0;


            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))

            {

                return;

            }

            if (rowNum > 0)

            {



                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();

                if (xlApp == null)

                {

                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");

                    return;

                }

                xlApp.DefaultFilePath = "";

                xlApp.DisplayAlerts = true;

                xlApp.SheetsInNewWorkbook = 1;

                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);

                //将ListView的列名导入Excel表第一行

                foreach (ColumnHeader dc in listView.Columns)

                {

                    columnIndex++;

                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;

                }

                //将ListView中的数据导入Excel中

                for (int i = 0; i < rowNum; i++)

                {

                    rowIndex++;

                    columnIndex = 0;

                    for (int j = 0; j < columnNum; j++)

                    {

                        columnIndex++;

                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。

                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";

                    }

                }

                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。

                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                xlApp = null;

                xlBook = null;

                MessageBox.Show("OK");

            }

        }

        string[] area_data   = {"区域类型","X坐标","Y坐标","区域宽度","区域高度","动态区编号","行间距","动态区运行模式","动态区超时时间","是否是能语音","发音人/发音次数","音量","语速","读音数据长度","读音数据","保留字","是否单行显示","是否自动换行","显示方式","退出方式","显示速度","停留时间","数据长度" ,"数据"};

        public string turntring(string s,int i)
        {
            switch (i)
            {
                case 2:
                    s = s.Substring(2, 2) + s.Substring(0, 2);
                    break;
                case 4:
                    s = s.Substring(6, 2) + s.Substring(4, 2)+s.Substring(2, 2) + s.Substring(0, 2);
                    break;
            }
            return s;
        }
        public  int dynamic(byte[] data, int size)
        {
            PHY0_flag PHY0_flag1;
            PHY0_flag1.Rcv_state = 0;
            PHY0_flag1.RCV_data_num = 0;
            byte[] myarray = new byte[size];
            int cmd_group;
            int cmd;
            UInt32 data_num;

            UInt32 i;
            int crc = 0x0;
            byte data_t;
            byte data_cache;
            UInt32 j = 0;
            int num = 0;
            if (data == null)
            {
                return 0;
            }
            for (j = 0; j < size; j++)
            {
                data_t = data[j];
                if (data_t == 0XA5) {
                    PHY0_flag1.Rcv_state = 1;
                }
                else {
                    if (PHY0_flag1.Rcv_state != 0) {
                        switch (data_t)
                        {
                            case 0X5A:break;
                            case 0XA6:
                                PHY0_flag1.Rcv_state = 2;//进入0xA6转义字节状态
                                break;
                            case 0X5B:
                                PHY0_flag1.Rcv_state = 3;//进入0x5B转义字节状态
                                break;
                            case 0X01:
                                if (PHY0_flag1.Rcv_state == 2)
                                {
                                    myarray[PHY0_flag1.RCV_data_num] = 0XA6;
                                    PHY0_flag1.RCV_data_num++;
                                    PHY0_flag1.Rcv_state = 1;
                                }
                                else
                                {
                                    if (PHY0_flag1.Rcv_state == 3)
                                    {
                                        myarray[PHY0_flag1.RCV_data_num] = 0X5B;
                                        PHY0_flag1.RCV_data_num++;
                                        PHY0_flag1.Rcv_state = 1;
                                    }
                                    else
                                    {
                                        myarray[PHY0_flag1.RCV_data_num] = 0x01;
                                        PHY0_flag1.RCV_data_num++;
                                    }
                                }
                                break;
                            case 0X02:
                                if (PHY0_flag1.Rcv_state == 2)
                                {
                                    myarray[PHY0_flag1.RCV_data_num] = 0XA5;
                                    PHY0_flag1.RCV_data_num++;
                                    PHY0_flag1.Rcv_state = 1;
                                }
                                else
                                {
                                    if (PHY0_flag1.Rcv_state == 3)
                                    {
                                        myarray[PHY0_flag1.RCV_data_num] = 0X5A;
                                        PHY0_flag1.RCV_data_num++;
                                        PHY0_flag1.Rcv_state = 1;
                                    }
                                    else
                                    {
                                        myarray[PHY0_flag1.RCV_data_num] = 0x02;
                                        PHY0_flag1.RCV_data_num++;
                                    }
                                }
                                break;
                            default:
                                myarray[PHY0_flag1.RCV_data_num] = data_t;
                                PHY0_flag1.RCV_data_num++;
                                break;
                        }

                    }
                }
                
            }

            string str,str1;
            str = "";
            for (i= 0;i< PHY0_flag1.RCV_data_num;i++)
            {
                if ((myarray[i] == 0X5A) || (myarray[i] == 0XA5)|| (myarray[i] == 0XA6) || (myarray[i] == 0X5B))
                {
                    data_after_transform_richTextBox.SelectionColor = Color.Red;
                }
                else
                {
                    data_after_transform_richTextBox.SelectionColor = Color.Black;
                }
                str1 = myarray[i].ToString("x");
                str = (str1.Length == 1 ? "0" + str1 : str1);
                if (i == 0)
                {
                    str = str.ToUpper();
                }
                else
                {
                    str = " " + str.ToUpper();

                }
                data_after_transform_richTextBox.AppendText(str);
            }

            i = 0;
            j = 0;
            this.data_listView.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度


            ListViewGroup group_data_header = new ListViewGroup();  //创建包头数据分组
            group_data_header.Header = "包头数据";  //设置组的标题。
            //man_lvg.Name = "group_data_header";   //设置组的名称。
            group_data_header.HeaderAlignment = HorizontalAlignment.Left;//设置组标题文本的对齐方式。（默认为Left）
            this.data_listView.Groups.Add(group_data_header);    //把包头数据分组添加到listview中


            /*屏地址*/
            //1、增加第一個Item，在View.Details模式下，有點像第一列中一個值
            data_listView.Items.Add("folder1", data_header[j], 0);
            data_listView.Items["folder1"].Group = group_data_header;
            //2、增加第一個Item的第一個SubItem，在View.Details模式下，有點像第一列中一個值
            data_listView.Items["folder1"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()),2));
            //3、增加第一個Item的第二個SubItem，在View.Details模式下，有點像第一列中一個值
            data_listView.Items["folder1"].SubItems.Add(" ");
            j++;




            /*源地址*/
            data_listView.Items.Add("folder2", data_header[j], 0);
            data_listView.Items["folder2"].Group = group_data_header;
            data_listView.Items["folder2"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder2"].SubItems.Add(" ");
            j++;

            
            /*保留字节*/
            data_listView.Items.Add("folder3", data_header[j], 0);
            data_listView.Items["folder3"].Group = group_data_header;
            data_listView.Items["folder3"].SubItems.Add(myarray[i++].ToString("X2") +" "+ (myarray[i++].ToString("X2").ToUpper())+" "+
                                                        myarray[i++].ToString("X2") +" "+ (myarray[i++].ToString("X2").ToUpper())+" "+
                                                        myarray[i++].ToString("X2")
                                                        );
            data_listView.Items["folder3"].SubItems.Add(" ");
            j++;

            /*显示模式*/
            data_listView.Items.Add("folder4", data_header[j], 0);
            data_listView.Items["folder4"].Group = group_data_header;
            data_cache = myarray[i];
            data_listView.Items["folder4"].SubItems.Add(myarray[i++].ToString("X2"));


            switch (data_cache)
            {
                case 0:
                    data_listView.Items["folder4"].SubItems.Add("普通模式");
                    break;
                case 1:
                    data_listView.Items["folder4"].SubItems.Add("动态模式");
                    break;
                default:
                    data_listView.Items["folder4"].ForeColor = Color.Red;
                    data_listView.Items["folder4"].SubItems.Add("数据错误");
                    break;
            }
            j++;




            /*设备类型*/
            data_listView.Items.Add("folder5", data_header[j], 0);
            data_listView.Items["folder5"].Group = group_data_header;
            data_cache = myarray[i];
            data_listView.Items["folder5"].SubItems.Add(myarray[i++].ToString("X2"));

            switch (data_cache)
            {
                case 0X51:
                    data_listView.Items["folder5"].SubItems.Add("BX-5K1");
                    break;
                case 0X58:
                    data_listView.Items["folder5"].SubItems.Add("BX-5K2");
                    break;
                case 0X53:
                    data_listView.Items["folder5"].SubItems.Add("BX-5MK2");
                    break;
                case 0X54:
                    data_listView.Items["folder5"].SubItems.Add("BX-5MK1");
                    break;
                case 0X5C:
                    data_listView.Items["folder5"].SubItems.Add("BX-5K1Q-YY");
                    break;
                case 0X5D:
                    data_listView.Items["folder5"].SubItems.Add("BX-5KX");
                    break;
                case 0XFE:
                    data_listView.Items["folder5"].SubItems.Add("通配符");
                    break;
                default:
                    data_listView.Items["folder5"].ForeColor = Color.Red;
                    data_listView.Items["folder5"].SubItems.Add("数据错误");
                    break;
            }
            j++;



            /*协议版本号*/
            data_listView.Items.Add("folder6", data_header[j], 0);
            data_listView.Items["folder6"].Group = group_data_header;
            data_listView.Items["folder6"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder6"].SubItems.Add(" ");
            j++;




            /*数据域长度*/
            data_listView.Items.Add("folder7", data_header[j], 0);
            data_listView.Items["folder7"].Group = group_data_header;
            data_listView.Items["folder7"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder7"].SubItems.Add(" ");
            j++;


            j = 0;
            ListViewGroup group_cmd = new ListViewGroup();  //创建命令分组
            group_cmd.Header = "命令";  //设置组的标题。
            group_cmd.HeaderAlignment = HorizontalAlignment.Left;//设置组标题文本的对齐方式。（默认为Left）
            this.data_listView.Groups.Add(group_cmd);    //把命令分组添加到listview中




            
            /*命令分组*/
            cmd_group = myarray[i];
            data_listView.Items.Add("folder8", dynamic_cmd[j], 0);
            data_listView.Items["folder8"].Group = group_cmd;
            data_listView.Items["folder8"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder8"].SubItems.Add(" ");
            j++;



            /*命令编号*/
            cmd = myarray[i];
            data_listView.Items.Add("folder9", dynamic_cmd[j], 0);
            data_listView.Items["folder9"].Group = group_cmd;
            data_listView.Items["folder9"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder9"].SubItems.Add(" ");
            j++;




            /*控制是否回复*/
            data_listView.Items.Add("folder10", dynamic_cmd[j], 0);
            data_listView.Items["folder10"].Group = group_cmd;
            data_cache = myarray[i];
            data_listView.Items["folder10"].SubItems.Add(myarray[i++].ToString("X2"));
            switch (data_cache)
            {
                case 0:
                    data_listView.Items["folder10"].SubItems.Add("控制器必须回复");
                    break;
                case 1:
                    data_listView.Items["folder10"].SubItems.Add("控制器不必回复");
                    break;
                default:
                    data_listView.Items["folder10"].ForeColor = Color.Red;
                    data_listView.Items["folder10"].SubItems.Add("数据错误");
                    break;
            }
            j++;




            /*保留字节*/
            data_listView.Items.Add("folder11", dynamic_cmd[j], 0);
            data_listView.Items["folder11"].Group = group_cmd;
            data_listView.Items["folder11"].SubItems.Add(myarray[i++].ToString("X2") + " " + myarray[i++].ToString("X2"));
            data_listView.Items["folder11"].SubItems.Add(" ");
            j++;



            /*删除区域个数*/
            data_listView.Items.Add("folder12", dynamic_cmd[j], 0);
            data_listView.Items["folder12"].Group = group_cmd;
            data_cache = myarray[i];
            data_listView.Items["folder12"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder12"].SubItems.Add(" ");
            j++;

            if (data_cache == 0)
            {
                j++;
            }
            else
            {
                for (num = 1; num < data_cache+1; num++)
                {
                    /*删除区域ID*/
                    data_listView.Items.Add("folder13"+num, dynamic_cmd[j], 0);
                    data_listView.Items["folder13" + num].Group = group_cmd;
                    data_listView.Items["folder13" + num].SubItems.Add(myarray[i++].ToString("X2"));
                    data_listView.Items["folder13" + num].SubItems.Add("删除的第"+num+"个区域");
                }
                j++;
            }



            /*更新区域个数*/
            data_listView.Items.Add("folder14", dynamic_cmd[j], 0);
            data_listView.Items["folder14"].Group = group_cmd;
            data_listView.Items["folder14"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder14"].SubItems.Add(" ");
            j++;



            /*区域数据长度*/
            data_listView.Items.Add("folder15", dynamic_cmd[j], 0);
            data_listView.Items["folder15"].Group = group_cmd;
            data_listView.Items["folder15"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder15"].SubItems.Add(" ");
            j++;


            j = 0;
            ListViewGroup grou_area_data = new ListViewGroup();  //创建区域数据格式分组
            grou_area_data.Header = "区域数据格式";  //设置组的标题。
            grou_area_data.HeaderAlignment = HorizontalAlignment.Left;//设置组标题文本的对齐方式。（默认为Left）
            this.data_listView.Groups.Add(grou_area_data);    //把区域数据格式分组添加到listview中




            
            /*区域类型*/
            data_listView.Items.Add("folder16", area_data[j], 0);
            data_listView.Items["folder16"].Group = grou_area_data;
            data_listView.Items["folder16"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder16"].SubItems.Add(" ");
            j++;




            /*X坐标*/
            data_listView.Items.Add("folder17", area_data[j], 0);
            data_listView.Items["folder17"].Group = grou_area_data;
            data_listView.Items["folder17"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder17"].SubItems.Add(" ");
            j++;



            /*Y坐标*/
            data_listView.Items.Add("folder18", area_data[j], 0);
            data_listView.Items["folder18"].Group = grou_area_data;
            data_listView.Items["folder18"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder18"].SubItems.Add(" ");
            j++;




            /*区域宽度*/
            data_listView.Items.Add("folder19", area_data[j], 0);
            data_listView.Items["folder19"].Group = grou_area_data;
            data_listView.Items["folder19"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder19"].SubItems.Add(" ");
            j++;




            /*区域高度*/
            data_listView.Items.Add("folder20", area_data[j], 0);
            data_listView.Items["folder20"].Group = grou_area_data;
            data_listView.Items["folder20"].SubItems.Add(turntring(myarray[i++].ToString("X2") + (myarray[i++].ToString("X2").ToUpper()), 2));
            data_listView.Items["folder20"].SubItems.Add(" ");
            j++;


           
            /*动态区编号*/
            data_listView.Items.Add("folder21", area_data[j], 0);
            data_listView.Items["folder21"].Group = grou_area_data;
            data_listView.Items["folder21"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder21"].SubItems.Add(" ");
            j++;




            /*行间距*/
            data_listView.Items.Add("folder22", area_data[j], 0);
            data_listView.Items["folder22"].Group = grou_area_data;
            data_listView.Items["folder22"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder22"].SubItems.Add(" ");
            j++;




            /*动态区运行模式*/
            data_listView.Items.Add("folder23", area_data[j], 0);
            data_listView.Items["folder23"].Group = grou_area_data;
            data_cache = myarray[i];
            data_listView.Items["folder23"].SubItems.Add(myarray[i++].ToString("X2"));
            switch (data_cache)
            {
                case 0:
                    data_listView.Items["folder23"].SubItems.Add("循环显示");
                    break;
                case 1:
                    data_listView.Items["folder23"].SubItems.Add("显示完成停留最后一页");
                    break;
                case 2:
                    data_listView.Items["folder23"].SubItems.Add("超时未更新删除");
                    break;
                default:
                    data_listView.Items["folder23"].ForeColor = Color.Red;
                    data_listView.Items["folder23"].SubItems.Add("数据错误");
                    break;
            }
            j++;



            /*动态区超时时间*/
            data_listView.Items.Add("folder24", area_data[j], 0);
            data_listView.Items["folder24"].Group = grou_area_data;
            data_listView.Items["folder24"].SubItems.Add(turntring(myarray[i++].ToString("X2") + myarray[i++].ToString("X2").ToUpper(), 2));
            data_listView.Items["folder24"].SubItems.Add(" ");
            j++;



            /*是否是能语音*/
            data_listView.Items.Add("folder25", area_data[j], 0);
            data_listView.Items["folder25"].Group = grou_area_data;
            data_cache = myarray[i];
            data_listView.Items["folder25"].SubItems.Add(myarray[i++].ToString("X2"));

            switch (data_cache)
            {
                case 0:
                    data_listView.Items["folder25"].SubItems.Add("不使能语音");
                    break;
                case 1:
                    data_listView.Items["folder25"].SubItems.Add("播放data内容");
                    break;
                case 2:
                    data_listView.Items["folder25"].SubItems.Add("播放sounddata内容");
                    break;
                default:
                    data_listView.Items["folder25"].ForeColor = Color.Red;
                    data_listView.Items["folder25"].SubItems.Add("数据错误");
                    break;
            }
            if (data_cache == 0)
            {
                j = j + 6;
            }
            else
            {
                /*发音人/发音次数*/
                data_listView.Items.Add("folder26", area_data[j], 0);
                data_listView.Items["folder26"].Group = grou_area_data;
                data_listView.Items["folder26"].SubItems.Add(myarray[i++].ToString("X2"));
                data_listView.Items["folder26"].SubItems.Add("Bit0-Bit3发音人，Bit4-Bit7播放次数");
                j++;

                /*音量*/
                data_listView.Items.Add("folder27", area_data[j], 0);
                data_listView.Items["folder27"].Group = grou_area_data;
                data_cache = myarray[i];
                data_listView.Items["folder27"].SubItems.Add(myarray[i++].ToString("X2"));
                data_listView.Items["folder27"].SubItems.Add("音量" + data_cache);
                j++;

                
                /*语速*/
                data_listView.Items.Add("folder28", area_data[j], 0);
                data_listView.Items["folder28"].Group = grou_area_data;
                data_cache = myarray[i];
                data_listView.Items["folder28"].SubItems.Add(myarray[i++].ToString("X2"));
                data_listView.Items["folder28"].SubItems.Add("语速" + data_cache);
                j++;

                if (data_cache == 2)
                {
                
                    /*读音数据长度*/
                    data_listView.Items.Add("folder29", area_data[j], 0);
                    data_listView.Items["folder29"].Group = grou_area_data;
                    data_listView.Items["folder29"].SubItems.Add(turntring(myarray[i++].ToString("X2") +
                                                                            myarray[i++].ToString("X2") +
                                                                            myarray[i++].ToString("X2") +
                                                                            myarray[i++].ToString("X2").ToUpper(), 4));
                    data_listView.Items["folder29"].SubItems.Add(" ");
                    j++;


                    /*读音数据*/
                    data_listView.Items.Add("folder30", area_data[j], 0);
                    data_listView.Items["folder30"].Group = grou_area_data;
                    data_listView.Items["folder30"].SubItems.Add(turntring(myarray[i++].ToString("X2") + myarray[i++].ToString("X2").ToUpper(), 2));
                    data_listView.Items["folder30"].SubItems.Add("语音数据");

                    j++;

                }

            }




            
            /*保留字节*/
            data_listView.Items.Add("folder31", area_data[j], 0);
            data_listView.Items["folder31"].Group = grou_area_data;
            data_listView.Items["folder31"].SubItems.Add(turntring(myarray[i++].ToString("X2") + myarray[i++].ToString("X2").ToUpper(), 2));
            data_listView.Items["folder31"].SubItems.Add(" ");
            j++;


            /*是否单行显示*/
            data_listView.Items.Add("folder32", area_data[j], 0);
            data_listView.Items["folder32"].Group = grou_area_data;
            data_cache = myarray[i];
            data_listView.Items["folder32"].SubItems.Add(myarray[i++].ToString("X2"));
            switch (data_cache)
            {
                case 1:
                    data_listView.Items["folder32"].SubItems.Add("单行显示");
                    break;
                case 2:
                    data_listView.Items["folder32"].SubItems.Add("多行显示");
                    break;
                default:
                    data_listView.Items["folder32"].ForeColor = Color.Red;
                    data_listView.Items["folder32"].SubItems.Add("数据错误");
                    break;
            }
            j++;



            /*是否自动换行*/
            data_listView.Items.Add("folder33", area_data[j], 0);
            data_listView.Items["folder33"].Group = grou_area_data;
            data_cache = myarray[i];
            data_listView.Items["folder33"].SubItems.Add(myarray[i++].ToString("X2"));
            switch (data_cache)
            {
                case 1:
                    data_listView.Items["folder33"].SubItems.Add("不自动换行");
                    break;
                case 2:
                    data_listView.Items["folder33"].SubItems.Add("自动换行");
                    break;
                default:
                    data_listView.Items["folder33"].ForeColor = Color.Red;
                    data_listView.Items["folder33"].SubItems.Add("数据错误");
                    break;
            }
            j++;


            
            /*显示方式*/
            data_listView.Items.Add("folder34", area_data[j], 0);
            data_listView.Items["folder34"].Group = grou_area_data;
            data_cache = myarray[i];
            data_listView.Items["folder34"].SubItems.Add(myarray[i++].ToString("X2"));
            switch (data_cache)
            {
                case 1:
                    data_listView.Items["folder34"].SubItems.Add("静止显示");
                    break;
                case 2:
                    data_listView.Items["folder34"].SubItems.Add("快速打出");
                    break;
                case 3:
                    data_listView.Items["folder34"].SubItems.Add("向左移动");
                    break;
                case 4:
                    data_listView.Items["folder34"].SubItems.Add("向右移动");
                    break;
                case 5:
                    data_listView.Items["folder34"].SubItems.Add("向上移动");
                    break;
                case 26:
                    data_listView.Items["folder34"].SubItems.Add("向下移动");
                    break;
                default:
                    data_listView.Items["folder34"].ForeColor = Color.Red;
                    data_listView.Items["folder34"].SubItems.Add("数据错误");
                    break;
            }
            j++;




            /*退出方式*/
            data_listView.Items.Add("folder35", area_data[j], 0);
            data_listView.Items["folder35"].Group = grou_area_data;
            data_listView.Items["folder35"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder35"].SubItems.Add(" ");
            j++;




            /*显示速度*/
            data_listView.Items.Add("folder36", area_data[j], 0);
            data_listView.Items["folder36"].Group = grou_area_data;
            data_listView.Items["folder36"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder36"].SubItems.Add(" ");
            j++;



            /*停留时间*/
            data_listView.Items.Add("folder37", area_data[j], 0);
            data_listView.Items["folder37"].Group = grou_area_data;
            data_listView.Items["folder37"].SubItems.Add(myarray[i++].ToString("X2"));
            data_listView.Items["folder37"].SubItems.Add(" ");
            j++;


            /*数据长度*/
            data_listView.Items.Add("folder38", area_data[j], 0);
            data_listView.Items["folder38"].Group = grou_area_data;
            data_listView.Items["folder38"].SubItems.Add(turntring(myarray[i++].ToString("X2") +
                                                                    myarray[i++].ToString("X2") +
                                                                    myarray[i++].ToString("X2") +
                                                                    myarray[i++].ToString("X2").ToUpper(), 4));
            data_listView.Items["folder38"].SubItems.Add(" ");
            i = i - 4;
            
            data_num = (UInt32)(myarray[i++]) + (UInt32)(myarray[i++]<< 8) + (UInt32)(myarray[i++] << 16) + (UInt32)(myarray[i++] << 24);
            j++;



            /*数据*/
            data_listView.Items.Add("folder39", area_data[j], 0);
            data_listView.Items["folder39"].Group = grou_area_data;


            string st = string.Empty;
            for (num = 0; num < data_num ; num++)
            {
                st = st + myarray[i++].ToString("X2");
            }

            data_listView.Items["folder39"].SubItems.Add(st);


            i = i - data_num;
            st = string.Empty;
            string result = string.Empty;
            for (num = 0; num < data_num;)
            {
                if (myarray[i] < 0x81)
                {
                    System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                    byte[] byteArray = new byte[] { (byte)myarray[i++] };
                    string strCharacter = asciiEncoding.GetString(byteArray);
                    st = st + strCharacter;
                    num++;
                }
                else
                {
                    byte[] bytes = new byte[2];
                    bytes[0] = myarray[i++];
                    bytes[1] = myarray[i++];
                    System.Text.Encoding chs = System.Text.Encoding.GetEncoding("gb2312");
                    result = chs.GetString(bytes);
                    st = st + result;
                    num = num + 2;
                }
            }
            data_listView.Items["folder39"].SubItems.Add(st);


            ListViewGroup grou_CRC = new ListViewGroup();  //创建CRC校验分组
            grou_CRC.Header = "CRC校验";  //设置组的标题。
            grou_CRC.HeaderAlignment = HorizontalAlignment.Left;//设置组标题文本的对齐方式。（默认为Left）
            this.data_listView.Groups.Add(grou_CRC);    //把CRC校验分组添加到listview中


            /*CRC校验*/
            data_listView.Items.Add("folder40", "CRC校验", 0);
            data_listView.Items["folder40"].Group = grou_CRC;
            data_listView.Items["folder40"].SubItems.Add(myarray[i++].ToString("X2")+ myarray[i++].ToString("X2"));
            data_listView.Items["folder40"].SubItems.Add(" ");



            this.data_listView.EndUpdate();  //结束数据处理，UI界面一次性绘制。


            return crc;
        }

        private void analysis_button_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                string[] strCheckArray = Raw_data_textBox.Text.Split(' ');
                byte[] myarray = new byte[strCheckArray.Length];
                foreach (var tmp in strCheckArray)
                {
                    myarray[i++] = System.Convert.ToByte(tmp, 16);
                }
                data_listView.Items.Clear();//每次点击事件后将ListView中的数据清空，重新显示
                data_after_transform_richTextBox.Clear();//每次点击事件后将data_after_transform_richTextBox中的数据清空，重新显示

                dynamic(myarray, i);
                out_excel_button.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确格式的数据！");
            }
        }
        #endregion 数据解析

    }
}
