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
        string analysis_mes = "数据解析只能检测出动态区数据一小部分错误，一旦检测出错误，还需要认真看协议！";
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
            width_numericUpDown.Value = 16;
            height_numericUpDown.Value = 16;
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
            if (pictureBoxFont.Width >= pictureBoxFont.Height)
            {
                picSize = pictureBoxFont.Height;
            }
            else
            {
                picSize = pictureBoxFont.Width;
            }
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
                    num = num1 * y + num - 1;
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
            p.Save("D:\\pictrue.bmp");
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
        private void buttonReadFont_Click(object sender, EventArgs e)//读取字库名按钮单击事件
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
        
       


        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)//字模宽度改变事件
        {
            //if (!lockFlag)
            //{
            //    if (GB2312.Checked)
            //    {
            //        width = (int)numericUpDownWidth.Value;
            //    }
            //    else if (ASCII.Checked)
            //    {
            //        /* uni */width = (int)numericUpDownWidth.Value;
            //    }
            //    if ((fontPath != null) && (File.Exists(fontPath)))
            //    {
            //        displayFont();
            //    }
            //    else
            //    {
            //        paintFont();
            //    }
            //}
        }
        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)//字模高度改变事件
        {
            //if (!lockFlag)
            //{
            //    if (GB2312.Checked)
            //    {
            //        height = (int)numericUpDownHeight.Value;
            //    }
            //    else if (ASCII.Checked)
            //    {
            //        /* uni */height = (int)numericUpDownHeight.Value;
            //    }
            //    if ((fontPath != null) && (File.Exists(fontPath)))
            //    {
            //        displayFont();
            //    }
            //    else
            //    {
            //        paintFont();
            //    }
            //}
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
            GB2312.Checked = true;

            this.time1.Interval = 1000;
            this.time1.Tick += new System.EventHandler(this.timer_Tick);
            this.time1.Start();
            textBoxtime.Text = DateTime.Now.ToString();
            this.makefont_DataInFormLoad();
            //this.tabControl.TabPages[4].Parent = null;//设置父容器为null，隐藏解析的TabPage
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
                if (ASCII.Checked == true)
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
                if (GB2312.Checked == true)
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
                if (GBK.Checked == true)
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
                if (ASCII.Checked == true)
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
                if (GB2312.Checked == true)
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
                if (GBK.Checked == true)
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
            if (ASCII.Checked == true)
            {
                numericUpDownIndex.Value = wei;
            }
            if (GB2312.Checked == true)
            {
                numericUpDownIndex.Value = qu * 94 + wei;
            }
            if (GBK.Checked == true)
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



        private void viwer_textBox_TextChanged(object sender, EventArgs e)
        {

            byte[] array = System.Text.Encoding.Default.GetBytes(viwer_textBox.Text);
            if (array.Length == 1)
            {
                if (ASCII.Checked != true)
                {
                    MessageBox.Show("现在选择是中文字库，请不要输入英文或阿拉伯数字");
                }
                else
                {
                    comboBoxWei.Text = (array[0]).ToString("X8").Remove(0, 6);
                }
            }
            if (array.Length == 2)
            {
                if (ASCII.Checked == true)
                {
                    MessageBox.Show("现在选择是英文字库，请不要输入汉字");
                }
                else
                {
                    comboBoxQu.Text = (array[0]).ToString("X8").Remove(0, 6);
                    comboBoxWei.Text = (array[1]).ToString("X8").Remove(0, 6);
                }
            }
        }

        #endregion 字库查看修改的代码


       

        #region 制作字库的代码

        private MakeFont MatCharFont;


        public byte[] BitmapToBytes(Bitmap Bitmap)
        {
            Color srcColor;
            int datalen = 0;
            int num = 0;
            int num1 = 0;
            if (Bitmap.Width % 8 == 0) {
                datalen = (Bitmap.Width / 8) * Bitmap.Height;
            }
            else {
                datalen = (Bitmap.Width / 8 + 1) * Bitmap.Height;
            }
            byte[] data1 = new byte[datalen];
            int temp = 0;
            for (int y = 0; y < Bitmap.Height; y++)
            {
                num1 = 0;
                for (int x = 0; x < Bitmap.Width; x++)
                {
                    //获取像素的ＲＧＢ颜色值
                    srcColor = Bitmap.GetPixel(x, y);
                    if ((srcColor.R == 0xff) && (srcColor.G == 0xff) && (srcColor.B == 0xff))
                    {
                        temp = temp << 1;
                        temp = temp | 0x01;
                    }
                    else
                    {
                        temp = temp << 1;
                    }
                    num1++;
                    if ((num1 == 8) || ((x + 1) == Bitmap.Width))
                    {
                        data[num++] = (byte)temp;
                        num1 = 0;
                        temp = 0;
                    }

                }
            }
                

            return data1;
        }


        //private void font_size_numericUpDown_ValueChanged(object sender, EventArgs e)
        //{
        //    //重新设置选用的字体。
        //    this.MatCharFont.MatFont =
        //        new Font(this.MatCharFont.MatFont.FontFamily,
        //                 (float)this.font_size_numericUpDown.Value,
        //                 this.MatCharFont.MatFont.Style);
        //    //更新字符预览。
        //    BitmapToBytes(this.MatCharFont.MatBitmap);
        //    paintFont();

        //    //更新当前字体信息。
        //    this.font_message_textBox.Clear();
        //    this.font_message_textBox.Text = this.MatCharFont.GetMatFontInfo();
        //}
        /*更新字库预览*/
        private void updata_font_prewiew(object sender, EventArgs e)
        {
            //重新设置选用的字体。
            this.MatCharFont.MatFont =
                new Font(this.MatCharFont.MatFont.FontFamily,
                         (float)this.font_size_numericUpDown.Value,
                         this.MatCharFont.MatFont.Style);
            //更新字符预览。
            BitmapToBytes(this.MatCharFont.MatBitmap);
            paintFont();

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
            //statusStripProc.Visible = true;
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

            if (q_radioButton.Checked == true)//6Q3的字库
            {
                Random rd = new Random();
                int i = rd.Next();
                if (ASCII.Checked == true)
                {
                    this.saveFileDlg.FileName = "E" + (i/100%10).ToString() + (i / 10 % 10).ToString() + (i % 10).ToString();
                }
                else
                {
                    this.saveFileDlg.FileName = "O" + (i / 100 % 10).ToString() + (i / 10 % 10).ToString() + (i % 10).ToString();
                }
                saveFileDlg.Filter = null;

                MessageBox.Show("6Q3字库中文字库名字首字母是O，英文是E。后面3个数字随意。比如系统生成8*16英文字库名字随机生成E025，生成字库完毕你也在windows下重命名为E000，下载进入6Q3控制器中，调用\\FE000，代表调用的是英文8*16的字库。如果你不修改名字，就把E025下载进入控制器，那么调用\\FE025，代表调用的是英文8*16的字库", "系统提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            if (this.saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                //停止UI界面上的控件对 MatCharFont(MatrixFont 类) 对象数据的操作。
                //this.UIEnabled(false);

                //启动点阵数据文件生成的辅助线程。
                
                this.bgwFileBuilder.RunWorkerAsync(this.saveFileDlg.FileName);
            }
        }

        private void bgwFileBuilder_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = (string)e.Argument;

            uint filecheck = 0;

            byte[] filecheck_byte = new byte[4];

            make_font_button.Visible = false;


            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ////将点阵字体的字符宽度和高度写入文件的头部。
                if (q_radioButton.Checked == true)//6Q3的字库
                {
                    fs.WriteByte((byte)0x01);
                    filecheck = filecheck + 0x01;

                    fs.WriteByte((byte)0x80);
                    filecheck = filecheck + 0x80;

                    fs.WriteByte((byte)0x10);
                    filecheck = filecheck + 0x01;

                    for (int i = 0; i < 61; i++)
                    {
                        fs.WriteByte((byte)0x00);
                        filecheck = filecheck + 0x00;
                    }

                    fs.WriteByte((byte)0x00);//标准字库
                    filecheck = filecheck + 0x00;

                    if (GB2312.Checked == true)
                    {
                        fs.WriteByte((byte)0x01);
                        filecheck = filecheck + 0x01;

                        fs.WriteByte((byte)0x01);
                        filecheck = filecheck + 0x01;
                    }
                    if (GBK.Checked == true)
                    {
                        fs.WriteByte((byte)0x02);
                        filecheck = filecheck + 0x02;

                        fs.WriteByte((byte)0x02);
                        filecheck = filecheck + 0x02;
                    }
                    if (ASCII.Checked == true)
                    {
                        fs.WriteByte((byte)0x00);
                        filecheck = filecheck + 0x00;

                        fs.WriteByte((byte)0x00);
                        filecheck = filecheck + 0x00;
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        fs.WriteByte((byte)0x00);
                        filecheck = filecheck + 0x00;
                    }
                    /*字库宽度*/
                    fs.WriteByte((byte)width_numericUpDown.Value);
                    filecheck = filecheck + (uint)width_numericUpDown.Value;

                    fs.WriteByte((byte)0x00);
                    filecheck = filecheck + 0x00;
                    /*字库高度*/
                    fs.WriteByte((byte)height_numericUpDown.Value);
                    filecheck = filecheck + (uint)height_numericUpDown.Value;

                    fs.WriteByte((byte)0x00);
                    filecheck = filecheck + 0x00;

                    for (int i = 0; i < (6+32+16); i++)
                    {
                        fs.WriteByte((byte)0x00);
                        filecheck = filecheck + 0x00;
                    }

                }
                
                if (GB2312.Checked == true)
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
                            filecheck = filecheck + (uint)ba;
                        }

                        //报告文件生成进度。
                        //设置判断条件，可以减少重复的进度报告，提高执行效率。
                        if ((i % 82 == 0) || (i == 8177))
                        {
                            int procPercent = (int)((double)i / 8177 * 100);
                            this.pgbBuilderProc.Value = procPercent;
                            //this.tssLblStatus.Text = String.Format("正在执行文件生成过程({0}%)", procPercent);
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
                            filecheck = filecheck + (uint)ba;
                        }

                        //报告文件生成进度。
                        //设置判断条件，可以减少重复的进度报告，提高执行效率。
                        if ((i % 82 == 0) || (i == 26208))
                        {
                            int procPercent = (int)((double)i / 26208 * 100);
                            this.pgbBuilderProc.Value = procPercent;
                            //this.tssLblStatus.Text = String.Format("正在执行文件生成过程({0}%)", procPercent);
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
                            filecheck = filecheck + (uint)ba;
                        }

                        //报告文件生成进度。
                        //设置判断条件，可以减少重复的进度报告，提高执行效率。
                        if ((i % 82 == 0) || (i == 256))
                        {
                            int procPercent = (int)((double)i / 256 * 100);
                            this.pgbBuilderProc.Value = procPercent;
                            //this.tssLblStatus.Text = String.Format("正在执行文件生成过程({0}%)", procPercent);
                        }
                    }
                }
                if (q_radioButton.Checked == true)//6Q3的字库
                {
                    filecheck_byte[0] = (byte)(filecheck >> (8 * 0) & 0xff);
                    filecheck_byte[1] = (byte)(filecheck >> (8 * 1) & 0xff);
                    filecheck_byte[2] = (byte)(filecheck >> (8 * 2) & 0xff);
                    filecheck_byte[3] = (byte)(filecheck >> (8 * 3) & 0xff);

                    fs.WriteByte(filecheck_byte[0]);
                    fs.WriteByte(filecheck_byte[1]);
                    fs.WriteByte(filecheck_byte[2]);
                    fs.WriteByte(filecheck_byte[3]);
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

            make_font_button.Visible = true;

            //恢复窗口的UI界面。
            //this.UIEnabled(true);
            //this.tssLblStatus.Text = "";
            this.pgbBuilderProc.Value = 0;
            //statusStripProc.Visible = false;
            pgbBuilderProc.Visible = false;
            if (this.MatCharFont.IsEqualWH)
            {
                this.height_numericUpDown.Enabled = false;
            }
        }

        private void UIEnabled(bool isEnabled)
        {
            this.check_font_button.Enabled = isEnabled;           //“选择字体”按钮。
            this.font_size_numericUpDown.Enabled = isEnabled;       //“字体大小：”数字框。

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
                BitmapToBytes(this.MatCharFont.MatBitmap);
                paintFont();

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
                this.viwer_textBox.DataBindings.Add("Text", this.MatCharFont, "DemoChar",
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

                this.radioButton0.DataBindings.Add("Checked", this.MatCharFont, "rotate0",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                this.radioButton90.DataBindings.Add("Checked", this.MatCharFont, "rotate90",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                this.radioButton180.DataBindings.Add("Checked", this.MatCharFont, "rotate180",
                    true, DataSourceUpdateMode.OnPropertyChanged);

                this.radioButton270.DataBindings.Add("Checked", this.MatCharFont, "rotate270",
                    true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else
            {
                this.viwer_textBox.DataBindings.Clear();       //“当前字符：”文本框。
                this.rdBtnStandard.DataBindings.Clear();            //“高宽相等”单选按钮。
                this.width_numericUpDown.DataBindings.Clear();         //字体“宽度：”数字框。
                this.height_numericUpDown.DataBindings.Clear();        //字体“高度：”数字框。
                this.level_numericUpDown.DataBindings.Clear();       //字体“水平偏移：”数字框。
                this.vertical_numericUpDown.DataBindings.Clear();       //字体“垂直偏移：”数字框。
            }
        }

        private void width_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!lockFlag)
            {
                if (GB2312.Checked)
                {
                    width = (int)width_numericUpDown.Value;
                }
                else if (ASCII.Checked)
                {
                    /* uni */
                    width = (int)width_numericUpDown.Value;
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

        private void height_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!lockFlag)
            {
                if (GB2312.Checked)
                {
                    height = (int)height_numericUpDown.Value;
                }
                else if (ASCII.Checked)
                {
                    /* uni */
                    height = (int)height_numericUpDown.Value;
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

        private void GB2312_CheckedChanged(object sender, EventArgs e)
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

        private void GBK_CheckedChanged(object sender, EventArgs e)
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

        private void ASCII_CheckedChanged(object sender, EventArgs e)
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
            groupBoxpic.Text = rm.GetString("groupBoxpic");
            View_mode_Button.Text = rm.GetString("View_mode_Button");
            edit_mode_Button.Text = rm.GetString("edit_mode_Button");
            groupBoxSet.Text = rm.GetString("groupBoxSet");
            labelFontName.Text = rm.GetString("labelFontName");
            textBoxFontName.Text = rm.GetString("textBoxFontName");

            buttonReadFont.Text = rm.GetString("buttonReadFont");
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
            font_groupBox.Text = rm.GetString("font_groupBox");
            check_font_button.Text = rm.GetString("check_font_button");
            font_label.Text = rm.GetString("font_label");

            binama_groupBox.Text = rm.GetString("binama_groupBox");
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


            message_openfile = rm.GetString("mes_openfile");
            analysis_mes = rm.GetString("analysis_mes");

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
            帮助ToolStripMenuItem.Text = rm.GetString("帮助");

            return;
        }
        #endregion UI语言


    }
}
