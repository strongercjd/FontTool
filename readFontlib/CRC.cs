using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace readFontlib
{
    class CRC
    {
        public static int crc16(byte[] data, int size)
        {
            int crc = 0x0;
            byte data_t;
            int i = 0;
            int j = 0;
            if (data == null)
            {
                return 0;
            }
            for (j = 0; j < size; j++)
            {
                data_t = data[j];
                crc = (data_t ^ (crc));
                for (i = 0; i < 8; i++)
                {
                    if ((crc & 0x1) == 1)
                    {
                        crc = (crc >> 1) ^ 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return crc;
        }
    }
}
