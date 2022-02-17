using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class CountDownWithOverride: CountDown
    {
        public CountDownWithOverride(int number) : base(number)
        {
            base.curNum = 0;
        }

        public override void Reset()
        {
            curNum = 0;
        }

        public override bool MoveNext()
        {
            ++curNum;
            return (curNum <= limitNum);
        }
    }
}
