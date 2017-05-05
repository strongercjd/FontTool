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
        Bitmap bmp;
        Byte[] data = new byte[2048];//!<字模数据
        string fontPath;
        bool quWeiFlag;
        bool lockFlag;
        bool editFlag;
        bool ASCII_Flag;
        bool showFlag;//1：获取的字模显示0X00，  0：显示 00 
        public bool begin = false;

        Timer time1 = new Timer();

        private void dataInit()//数据初始化，在读取字库时调用
        {
            int i;
            uniwidth = 10;
            uniheight = 10;
            width = 16;
            height = 16;
            index = 0;
            quWeiFlag = false;
            lockFlag = false;
            editFlag = false;//默认查看状态
            bmp = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            numericUpDownWidth.Value = 16;
            numericUpDownHeight.Value = 16;
            for (i = 0; i < 2048; i++) {
                data[i] = 0;
            }
            for (i = 161; i < 248;i++ )
            {
                comboBoxQu.Items.Add(i.ToString("X2").ToUpper());
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            for (i = 248; i < 255; i++)
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
        private void readDefaultFontData()//读取默认字库数据
        {
            int i;
            numericUpDownIndex.Maximum = 3;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("readFontlib.Resources.ziku");
            for (i = 0; i < index+1;i++ )
            {
                stream.Read(data, 0, 32);
            }
            /*richTextBoxData.Clear();
            for (i = 0; i < 32;i++ )
            {
                richTextBoxData.Text += data[i].ToString("X2").ToUpper() + " ";
            }*/
            stream.Dispose();
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

            Rectangle whitePanel = new Rectangle(startx, starty, width, height);
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
        private void recalSize()//读取字库里字模的个数
        {
            int readLenth;
            FileInfo fontInfo = new FileInfo(fontPath);
            readLenth = height * (width / 8 + (((width % 8) != 0) ? 1 : 0));
            numericUpDownIndex.Maximum = fontInfo.Length / readLenth - 1;
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
                recalSize();//!<读完字库文件后需要计算字库内文字的个数
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
                MessageBox.Show("请首先打开一个字库文件");
            }
        }

        private void buttonSaveBMP_Click(object sender, EventArgs e)//保存字模按钮单击事件
        {
            writeFontData();
            MessageBox.Show("成功保存这个字模");
        }

        private void radioButtonFontLib_CheckedChanged(object sender, EventArgs e)//选中GB2312
        {
            lockFlag = true;
            comboBoxQu.Enabled = true;
            comboBoxWei.Enabled = true;

            ASCII_Flag = false;
            comboBoxWei.Items.Clear();
            for (int i = 161; i < 255; i++)
            {
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            //comboBoxWei.SelectedIndex = 161.ToString("X2");
            if (radioButtonFontLib.Checked)
            {
                numericUpDownWidth.Maximum = (picSize + spaceSize) / (uniwidth + spaceSize);
                numericUpDownHeight.Maximum = (picSize + spaceSize) / (uniheight + spaceSize);
                numericUpDownWidth.Value = width;
                numericUpDownHeight.Value = height;
            }
            lockFlag = false;
        }
        private void radioButtonUnit_CheckedChanged(object sender, EventArgs e)//选中ASCII
        {
            comboBoxQu.Enabled = false;
            ASCII_Flag = true;
            comboBoxWei.Items.Clear();
            for (int i = 0; i < 256; i++)
            {
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
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
                    uniwidth = (int)numericUpDownWidth.Value;
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
                    uniheight = (int)numericUpDownHeight.Value;
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
                if (showFlag) {
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
            quWeiFlag = true;
            comboBoxQu.Enabled = true;
            comboBoxWei.Enabled = true;
            radioButtonFontLib.Checked = true;

            this.time1.Interval = 1000;
            this.time1.Tick += new System.EventHandler(this.timer_Tick);
            this.time1.Start();
            textBoxtime.Text = DateTime.Now.ToString();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//选中查看模式
        {
            editFlag = false;
            buttonSaveBMP.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//选中编辑模式
        {
            editFlag = true;
            buttonSaveBMP.Enabled = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                showFlag = true;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                showFlag = false;
            }
            else
            {
                MessageBox.Show("checkBox1 控件处于不确定状态");
            }
            buttonGetData_Click(this, null);

        }

        private void calIndex()//区位改变时计算字模的位置
        {
            int qu, wei;
            qu = comboBoxQu.SelectedIndex;
            wei = comboBoxWei.SelectedIndex;
            if (ASCII_Flag == true)
            {
                numericUpDownIndex.Value = wei;
            }
            else
            {
                numericUpDownIndex.Value = qu * 94 + wei;
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
    }
}
