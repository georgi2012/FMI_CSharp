using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3
{
    public class IntBits
    {
        private int bits;

        public IntBits(int bit)
        {
            bits = bit;
        }

        public bool this[int index]
        {
            get
            {
                if(index>=0 && index<sizeof(int)*8)
                {
                    return (bits & (1 << index)) != 0;
                }
                return false;
            }
            set
            {
                if (index >= 0 && index < sizeof(int) * 8)
                {
                    if(value)
                    {
                        bits |= 1 << index;
                    }
                    else
                    {
                        bits &= ~(1 << index);
                    }
                }
            }
        }


        public override string ToString()
        {
            int mask = 1 << sizeof(int) * 8 - 1;
            var output = "";
            var data = bits;
            for(int i = 0; i < 32; i++)
            {
                output += (data & mask) == 0 ? "0" : "1";
                data <<= 1;
            }
            return output;
        }
    }
}
