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



        private void dataInit()
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

            readDefaultFontData();
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
        private void readDefaultFontData()
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
                MessageBox.Show(this, e.Message, "小凡", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readFontData()//读字库数据
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
                MessageBox.Show(this, e.Message, "小凡", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void paintFont()
        {
            int x, y;
            int picSx, picSy;
            int num,num1;
            Bitmap p = new Bitmap(picSize, picSize);
            Graphics g = Graphics.FromImage(p); //!<创建一个图形类

            Pen blackPen = new Pen(Color.Black, brushSize);    //!<黑色画笔，画笔宽度为1
            Pen whitePen = new Pen(Color.White, brushSize);    //!<白色画笔
            Pen bluePen = new Pen(Color.Blue, brushSize);      //!<蓝色画笔
            Brush blackBrush = blackPen.Brush;
            Brush whiteBrush = whitePen.Brush;

            Rectangle whitePanel = new Rectangle(startx, starty, width, height);
            Rectangle blackPanel = new Rectangle(startx, starty, uniwidth, uniheight);
            Rectangle bluePanel = new Rectangle(startx, starty, uniwidth, uniheight);

            picSx = (picSize - width * uniwidth - spaceSize * (width - 1)) / 2;
            picSy = (picSize - height * uniheight - spaceSize * (height - 1)) / 2;


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
                        //g.FillRectangle(whiteBrush, bluePanel);
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
            //p.Save("F:\\2.bmp");
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
                MessageBox.Show(this, "路径为空！\n请选择文件路径！", "小凡提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBoxFontName.Clear();
                MessageBox.Show(this, "文件不存在！路径及文件名为：" + fontPath + "\n请重新选择文件！文件找不到了。。", "小凡提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getFontName(string path)
        {
            string a = "";
            string[] strArray = path.Split('\\');
            a = strArray[strArray.Length - 1];
            return a;
        }
        private void recalSize()
        {
            int readLenth;
            FileInfo fontInfo = new FileInfo(fontPath);
            readLenth = height * (width / 8 + (((width % 8) != 0) ? 1 : 0));
            numericUpDownIndex.Maximum = fontInfo.Length / readLenth - 1;
        }
        private void buttonReadFont_Click(object sender, EventArgs e)
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
                textBoxFontName.Text = getFontName(fontFile.FileName);
                numericUpDownIndex.Value = 0;
                recalSize();//!<读完字库文件后需要计算字库内文字的个数
                displayFont();
            }
        }

        private void numericUpDownIndex_ValueChanged(object sender, EventArgs e)
        {
            if ((fontPath != null) && (File.Exists(fontPath)))
            {
                index = (int)numericUpDownIndex.Value;
                displayFont();
            }
            else
            {
                index = (int)numericUpDownIndex.Value;
                readDefaultFontData();
                paintFont();
            }
        }

        private void createBMP()
        {
            int x, y,num,num1;
            int Width = width;
            int Height = height;
            Bitmap textBitmap = new Bitmap(Width, Height);
            Graphics textG = Graphics.FromImage(textBitmap);
            textG.FillRectangle(new SolidBrush(Color.Black), 0, 0, textBitmap.Width, textBitmap.Height);
            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    num1 = (width / 8) + ((width % 8 != 0) ? 1 : 0);
                    num = ((x + 1) / 8) + (((x + 1) % 8 != 0) ? 1 : 0);
                    num = num1 * y + num - 1;
                    if (((data[num] >> (7 - x % 8)) & 0x01) == 1)
                    {
                        textG.FillRectangle(new SolidBrush(Color.White), x, y, 1, 1);
                    }
                }
            }
            bmp = textBitmap;
            //textBitmap.Dispose();不能释放
        }
        private void buttonSaveBMP_Click(object sender, EventArgs e)
        {
            writeFontData();
            MessageBox.Show("成功保存这个字模");
        }

        private void radioButtonFontLib_CheckedChanged(object sender, EventArgs e)//选中GB2312
        {
            lockFlag = true;
            comboBoxQu.Enabled = true;

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
            //lockFlag = true;
            //if (radioButtonUnit.Checked)
            //{
            //    numericUpDownWidth.Maximum = (picSize + spaceSize) / width - spaceSize;
            //    numericUpDownHeight.Maximum = (picSize + spaceSize) / height - spaceSize;
            //    numericUpDownWidth.Value = uniwidth;
            //    numericUpDownHeight.Value = uniheight;
            //}
            //lockFlag = false;
            comboBoxQu.Enabled = false;
            ASCII_Flag = true;
            comboBoxWei.Items.Clear();
            for (int i = 0; i < 256; i++)
            {
                comboBoxWei.Items.Add(i.ToString("X2").ToUpper());
            }
            comboBoxWei.SelectedIndex = 0;
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
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
        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
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

        private void buttonGetData_Click(object sender, EventArgs e)
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
                richTextBoxData.Text += data[i].ToString("X2").ToUpper() + " ";
            }
            labelFontInfo.Text = "字库信息：" + width.ToString() + "*" + height.ToString();
            labelByteNum.Text = readLenth.ToString();
        }

        private void richTextBoxData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string[] strCheckArray = (richTextBoxData.Text.Trim()).Split(' ');
                string temp = string.Empty;
                foreach (var tmp in strCheckArray)
                {
                    temp += ((~System.Convert.ToByte(tmp, 16)) & 0xFF).ToString("X2").ToUpper() + " ";
                }
                richTextBoxData.Text = temp;
            }
            catch (Exception a)
            {
                
            }
        }

        private void numericUpDownIndex_DoubleClick(object sender, EventArgs e)
        {
            //if ((fontPath != null) && (File.Exists(fontPath)))
            //{
            //    if (quWeiFlag)
            //    {
            //        quWeiFlag = true;
            //        comboBoxQu.Enabled = false;
            //        comboBoxWei.Enabled = false;
            //    }
            //    else
            //    {
            //        quWeiFlag = true;
            //        comboBoxQu.Enabled = true;
            //        comboBoxWei.Enabled = true;
            //    }
            //}
        }

        private void readFontlib_Load(object sender, EventArgs e)
        {
            quWeiFlag = true;
            comboBoxQu.Enabled = true;
            comboBoxWei.Enabled = true;

        }

        private void pictureBoxFont_MouseDown(object sender, MouseEventArgs e)
        {
            int wei_num;
            int date_cache;
            if (editFlag == true)
            {
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
                        date_cache = data[y_pain * ((uniwidth / 8) + 1) + x_pain / 8];
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
                        data[y_pain * ((uniwidth / 8) + 1) + x_pain / 8] = (byte)date_cache;
                        paintFont();
                        buttonGetData_Click(this, null);
                    }

                }
                else
                {

                }

            }
        }

        private void calIndex()
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
        private void comboBoxQu_SelectedIndexChanged(object sender, EventArgs e)
        {
            calIndex();
        }

        private void comboBoxWei_SelectedIndexChanged(object sender, EventArgs e)
        {
            calIndex();
        }

        private void pictureBoxFont_DoubleClick(object sender, EventArgs e)
        {
            if (editFlag == false)
            {
                editFlag = true;
                MessageBox.Show("编辑模式");
            }
            else
            {
                editFlag = false;
                MessageBox.Show("查看模式");
            }
        }
    }
}
