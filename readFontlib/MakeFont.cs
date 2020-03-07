
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;

namespace readFontlib
{
    /// <summary>
    /// 用于汉字点阵数据生成的类。
    /// 
    /// 概要：
    /// 
    /// 1、通过构造函数初始化类中的各个字段，属性受到修改时，调用
    ///    DIBChanged 方法使数据同步，实现细节请参看各个属性定义
    ///    和 DIBChanged 方法的实现过程。
    /// 2、在点阵字节数据生成上，主要的实现方法为 
    ///    GetDemoCharMatrixBytes 方法，具体请参看其定义。
    /// </summary>
    public class MakeFont
    {
        #region 字段

        /// <summary>
        /// 点阵字体所使用的Font。
        /// </summary>
        private Font m_MatFont;

        /// <summary>
        /// 使用的示例字符。
        /// </summary>
        private string m_DemoChar;

        /// <summary>
        /// 表示生成的点阵字体的宽度（点的数目）。
        /// </summary>
        private int m_CharWidth;

        /// <summary>
        /// 表示生成的点阵字体的高度（点的数目）。
        /// </summary>
        private int m_CharHeight;

        /// <summary>
        /// 表示生成的点阵字体的水平偏移量。
        /// </summary>
        private int m_OffsetX;

        /// <summary>
        /// 表示生成的点阵字体的垂直偏移量。
        /// </summary>
        private int m_OffsetY;

        /// <summary>
        /// 示例字符的位图数据（以DIB位图形式存储）。
        /// </summary>
        private Bitmap m_MatBitmap;


        /// <summary>
        /// 点阵位图顺时针旋转角度。
        /// </summary>
        private int m_rotate_num;




        #endregion 字段

        #region 构造函数

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="matFont">点阵字体所使用的Font。</param>
        /// <param name="demoChar">用于示例的字符。</param>
        /// <param name="charHeight">字符的高度。</param>
        /// <param name="charWidth">字符的宽度。</param>
        /// <param name="offsetX">字符的水平偏移量。</param>
        /// <param name="offsetY">字符的垂直偏移量。</param>
        /// <param name="make_rotate_num">点阵位图顺时针旋转角度。</param>
        public MakeFont(Font matFont, Char demoChar, int charWidth, int charHeight, int offsetX, int offsetY, int make_rotate_num)
        {
            this.m_MatFont = matFont;
            this.m_DemoChar = demoChar.ToString();
            this.m_CharWidth = charWidth;
            this.m_CharHeight = charHeight;
            this.m_OffsetX = offsetX;
            this.m_OffsetY = offsetY;
            this.m_rotate_num = make_rotate_num;

            this.DIBChanged(matFont, demoChar.ToString(), charWidth, charHeight, offsetX, offsetY, make_rotate_num);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置点阵字体使用的Font。
        /// </summary>
        public Font MatFont
        {
            get
            {
                return this.m_MatFont;
            }
            set
            {
                if (this.m_MatFont != null)
                {
                    this.m_MatFont.Dispose();
                }
                this.m_MatFont = value;
                this.DIBChanged(value, this.DemoChar, this.m_CharWidth,
                                this.m_CharHeight, this.m_OffsetX, this.m_OffsetY, m_rotate_num);
            }
        }

        ///// <summary>
        ///// 获取或设置示例所使用的字符。
        ///// </summary>
        public string DemoChar
        {
            get
            {
                return this.m_DemoChar;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.m_DemoChar = value[0].ToString();
                    this.DIBChanged(this.MatFont, value[0].ToString(), this.m_CharWidth,
                                this.m_CharHeight, this.m_OffsetX, this.m_OffsetY, m_rotate_num);
                }
                else
                {
                    this.m_DemoChar = string.Empty;
                    this.DIBChanged(this.MatFont, " ", this.m_CharWidth,
                                this.m_CharHeight, this.m_OffsetX, this.m_OffsetY, m_rotate_num);
                }
            }
        }

        /// <summary>
        /// 获取示例字符的位图数据（以DIB位图形式存储的数据）。
        /// </summary>
        public Bitmap MatBitmap
        {
            get
            {
                return this.m_MatBitmap;
            }
        }
        #endregion 属性

        #region 方法

        /// <summary>
        /// 字段值改变时，重新构造示例字符的位图数据。
        /// </summary>
        /// <param name="matFont">点阵字体所使用的Font。</param>
        /// <param name="demoChar">用于示例的字符。</param>
        /// <param name="charHeight">字符的高度。</param>
        /// <param name="charWidth">字符的宽度。</param>
        /// <param name="offsetX">字符的水平偏移量。</param>
        /// <param name="offsetY">字符的垂直偏移量。</param>
        private void DIBChanged(Font matFont, string demoChar,
            int charWidth, int charHeight, int offsetX, int offsetY, int make_rotate_num)
        {
            try
            {
                if (this.m_MatBitmap != null)
                {
                    this.m_MatBitmap.Dispose();
                }
                //创建用于当前字符预览的位图对象（所有像素都为Color.Black）。
                this.m_MatBitmap = (Bitmap)BlackImage(charWidth, charHeight);

                using (Graphics g = Graphics.FromImage(this.m_MatBitmap))
                {

                    //确定字符在图像上的输出起始点。
                    Point txtPoint = new Point(offsetX - 2, offsetY);

                    //确定输出字符的对齐方式（为左对齐）。
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Near;

                    //绘制字符。
                    g.DrawString(demoChar, matFont, Brushes.White, txtPoint, sf);

                    //释放资源。
                    g.Dispose();
                }
                if (make_rotate_num == 1)
                    m_MatBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (make_rotate_num == 2)
                    m_MatBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                if (make_rotate_num == 3)
                    m_MatBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            catch (Exception ecp)   //异常处理。
            {
                throw ecp;
            }
        }

        /// <summary>
        /// 获取MatrixFont的基本信息。
        /// </summary>
        /// <returns>MatrixFont的基本信息。</returns>
        public string GetMatFontInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("字    体：" + this.MatFont.FontFamily.Name);
            sb.AppendLine("字体大小：" + this.MatFont.SizeInPoints.ToString("##"));
            sb.AppendLine("字体样式：" + this.MatFont.Style.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// 获取示例字符的点阵数据（字节数组）。
        /// </summary>
        /// <returns>点阵数据。</returns>
        public Byte[] GetDemoCharMatrixBytes()
        {
            //计算出保存图像的一行点阵数据所需的字节数。
            int aryW = (int)Math.Ceiling((double)this.MatBitmap.Width / 8);

            //创建存储点阵数据的字节数组。
            Byte[] matrixBytes = new Byte[aryW * this.MatBitmap.Height];
            matrixBytes.Initialize();   //初始化字节数组的每一个元素。

            try
            {
                //遍历图像，提取像素以确定对应的点阵数据位（0或1）。
                for (int i = 0; i < this.MatBitmap.Height; i++)
                {
                    for (int j = 0; j < this.MatBitmap.Width; j++)
                    {
                        if (!ColorEquals(this.MatBitmap.GetPixel(j, i), Color.Black))
                        {
                            int iArray = i * aryW + (int)Math.Floor((double)j / 8);
                            matrixBytes[iArray] += (Byte)(1 << (7 - (j % 8)));
                        }
                    }
                }
            }
            catch (Exception ecp)  //异常处理。
            {
                throw ecp;
            }
            //返回结果。
            return matrixBytes;
        }

        /// <summary>
        /// 判断ColorA的RGB值是否与ColorB的相等。
        /// </summary>
        /// <param name="ColorA">ColorA。</param>
        /// <param name="ColorB">ColorB。</param>
        /// <returns>如果两颜色的RGB值相等，返回true，否则返回false。</returns>
        public static bool ColorEquals(Color ColorA, Color ColorB)
        {
            return ((ColorA.R == ColorB.R) & (ColorA.G == ColorB.G) & (ColorA.B == ColorB.B));
        }

        /// <summary>
        /// 通过字节数组转换成指定格式（表格形式）的字符串对象的方法。
        /// </summary>
        /// <param name="bytes">要转换的字节数组。</param>
        /// <param name="width">每行字符包含的的（所指定的字节数组的）字节个数。</param>
        /// <returns>字符串对象。</returns>
        public static string BytesToString(Byte[] bytes, int width)
        {
            //有效性检查。
            if (width < 1)
            {
                MessageBox.Show("转换宽度必须大于 1 !", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            StringBuilder sb = new StringBuilder();

            try
            {
                int indexArray = 0;
                //遍历字节数组，按十六进制格式转换成字符串。
                foreach (byte bt in bytes)
                {
                    //sb.AppendFormat("0x{0,2:X}H\t", bt);
                    if (bt <= 0x0F)
                    {
                        sb.AppendFormat("0x0{0:X}H, ", bt);
                    }
                    else
                    {
                        sb.AppendFormat("0x{0:X}H, ", bt);
                    }
                    indexArray++;
                    if (indexArray % width == 0)
                    {
                        sb.AppendLine("");
                    }
                }
            }
            catch (Exception ecp)       //异常处理。
            {
                throw ecp;
            }
            //返回结果。
            return sb.ToString();
        }

        /// <summary>
        /// 创建一个Image对象，其所有像素都初始化为Color.Black。
        /// </summary>
        /// <param name="width">Image对象的宽度。</param>
        /// <param name="height">Image对象的高度。</param>
        /// <returns></returns>
        public static Image BlackImage(int width, int height)
        {
            //检查有效性。
            if ((width <= 0) || (height <= 0))
            {
                return null;
            }
            //创建Image对象（DIB位图）。
            Bitmap bmp = new Bitmap(width, height);
            //遍历图像，将每一像素赋值成Color.Black。
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    bmp.SetPixel(j, i, Color.Black);
                }
            }
            //返回结果。
            return bmp;
        }

        #endregion 方法
    }
}