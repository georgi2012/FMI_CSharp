using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class CountDown : IEnumerator 
    {
        protected int limitNum;
        protected int curNum;
        public CountDown(int setNum)
        {
            curNum = limitNum = setNum<=0? 1 : setNum;
        }

        public object Current 
        {
            get
            {
                return curNum;
            }
        }

        public virtual bool MoveNext()
        {
            curNum--;
            return (curNum >= 0);
        }

        public virtual void Reset()
        {
            curNum = limitNum;
        }
    }
}
