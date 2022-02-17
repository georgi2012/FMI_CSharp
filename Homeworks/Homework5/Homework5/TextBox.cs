using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    public abstract class TextBox
    {
        protected string text;
        protected string baseText;

        public TextBox()
        {
            baseText = $"{GetType()}:Type baseText"; 
        }
        public abstract void EditTextAllowed();

        public abstract void EditTextDisAllowed();

        protected abstract void TypeText();
    }
}