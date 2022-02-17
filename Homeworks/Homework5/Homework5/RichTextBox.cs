using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    public class RichTextBox:TextBox
    {
        private new string text;

        public RichTextBox()
        {
            text = $"{GetType()}:Type text";
        }
        public override void EditTextAllowed()
        {
            //base.TypeText();
            Console.WriteLine(base.text);
            Console.WriteLine(base.baseText);
        }

        public override void EditTextDisAllowed()
        {
            RichTextBox editTextBox = new RichTextBox();
            TextBox upcasted = (TextBox)editTextBox;
            // we cant cast TypeText as text is overwritten with new in derived and we can't access it 
            //and we have no other suitable definition for it as the object type determines the method used

            //upcasted.text is unaccessible as protected variables are private outside of the class and outside of classes that dont inherit them

            //upcasted.baseText is unaccessible for similar reasons as text
        }

        protected override void TypeText()
        {
            Console.WriteLine(text);
        }
    }
}
