
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace readFontlib
{
    /// <summary>
    /// 为 MatrixFont 类提供一些辅助的静态方法类。
    /// </summary>
    public class MatrixHelp
    {
        #region 方法

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