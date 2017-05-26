
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
    public class MatrixFont
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
        /// 点阵位图的高宽是否相等。
        /// </summary>
        private bool m_IsEqualWH;

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
        /// <param name="isEqualWH">点阵位图的高宽是否相等，值高宽true表示相等，false表示高宽不相等。</param>
        public MatrixFont(Font matFont, Char demoChar, int charWidth, int charHeight, int offsetX, int offsetY, bool isEqualWH)
        {
            this.m_MatFont = matFont;
            this.m_DemoChar = demoChar.ToString();
            this.m_CharWidth = charWidth;
            this.m_CharHeight = charHeight;
            this.m_OffsetX = offsetX;
            this.m_OffsetY = offsetY;
            this.m_IsEqualWH = isEqualWH;

            this.DIBChanged(matFont, demoChar.ToString(), charWidth, charHeight, offsetX, offsetY);
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
                this.DIBChanged(value, this.DemoChar, this.CharWidth,
                                this.CharHeight, this.OffsetX, this.OffsetY);
            }
        }

        /// <summary>
        /// 获取或设置示例所使用的字符。
        /// </summary>
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
                    this.DIBChanged(this.MatFont, value[0].ToString(), this.CharWidth,
                                this.CharHeight, this.OffsetX, this.OffsetY);
                }
                else
                {
                    this.m_DemoChar = string.Empty;
                    this.DIBChanged(this.MatFont, " ", this.CharWidth,
                                this.CharHeight, this.OffsetX, this.OffsetY);
                }
            }
        }

        /// <summary>
        /// 获取或设置点阵字体的高度（点的数目）。
        /// </summary>
        public int CharHeight
        {
            get
            {
                return this.m_CharHeight;
            }
            set
            {
                this.m_CharHeight = value;
                if (this.IsEqualWH)
                {
                    this.m_CharWidth = value;
                    this.DIBChanged(this.MatFont, this.DemoChar, value,
                                value, this.OffsetX, this.OffsetY);
                }
                else
                {
                    this.DIBChanged(this.MatFont, this.DemoChar, this.CharWidth,
                                    value, this.OffsetX, this.OffsetY);
                }
            }
        }

        /// <summary>
        /// 获取或设置点阵字体的宽度（点的数目）。
        /// </summary>
        public int CharWidth
        {
            get
            {
                return this.m_CharWidth;
            }
            set
            {
                this.m_CharWidth = value;
                if (this.IsEqualWH)
                {
                    this.m_CharHeight = value;
                    this.DIBChanged(this.MatFont, this.DemoChar, value,
                                value, this.OffsetX, this.OffsetY);
                }
                else
                {
                    this.DIBChanged(this.MatFont, this.DemoChar, value,
                                    this.CharHeight, this.OffsetX, this.OffsetY);
                }
            }
        }

        /// <summary>
        /// 获取或设置点阵字体的水平偏移量。
        /// </summary>
        public int OffsetX
        {
            get
            {
                return this.m_OffsetX;
            }
            set
            {
                this.m_OffsetX = value;
                this.DIBChanged(this.MatFont, this.DemoChar, this.CharWidth,
                                this.CharHeight, value, this.OffsetY);
            }
        }

        /// <summary>
        /// 获取或设置点阵字体的垂直偏移量。
        /// </summary>
        public int OffsetY
        {
            get
            {
                return this.m_OffsetY;
            }
            set
            {
                this.m_OffsetY = value;
                this.DIBChanged(this.MatFont, this.DemoChar, this.CharWidth,
                                this.CharHeight, this.OffsetX, value);
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

        /// <summary>
        /// 获取或设置点阵位图高宽是否相等，值高宽true表示相等，false表示高宽不相等。
        /// </summary>
        public bool IsEqualWH
        {
            get
            {
                return this.m_IsEqualWH;
            }
            set
            {
                this.m_IsEqualWH = value;
                if (value)
                {
                    this.CharHeight = this.CharWidth;
                }
                else
                {
                    this.DIBChanged(this.MatFont, this.DemoChar, this.CharWidth,
                                this.CharHeight, this.OffsetX, this.OffsetY);
                }
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
            int charWidth, int charHeight, int offsetX, int offsetY)
        {
            try
            {
                if (this.m_MatBitmap != null)
                {
                    this.m_MatBitmap.Dispose();
                }
                //创建用于当前字符预览的位图对象（所有像素都为Color.Black）。
                this.m_MatBitmap = (Bitmap)MatrixHelp.BlackImage(charWidth, charHeight);

                using (Graphics g = Graphics.FromImage(this.m_MatBitmap))
                {
                    //if (!this.IsEqualWH)
                    //{
                    ////创建用于缩放变换操作的Matrix对象。
                    //Matrix matrix = new Matrix();
                    //matrix.Scale((float)(charWidth) / (matFont.Height),
                    //             (float)(charHeight) / (matFont.Height));
                    //g.Transform = matrix;
                    //}

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

            sb.AppendLine("字体：" + this.MatFont.FontFamily.Name);
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
                        if (!MatrixHelp.ColorEquals(this.MatBitmap.GetPixel(j, i), Color.Black))
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

        #endregion 方法
    }
}