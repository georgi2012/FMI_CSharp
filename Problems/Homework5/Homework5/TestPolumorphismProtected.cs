using System;

namespace Homework5
{
    public class TestPolumorphismProtected
    {
        public static void Main(string[] args)
        {
            TextBox[] textBoxes = { new EditTextBox(), new RichTextBox(), new MultiLineTextBox() };

            foreach(TextBox box in textBoxes)
            {
                switch (box)
                {
                    //TypeText can not be accessed because its protection lvl is Protected and is private outside of the derived classes
                    case MultiLineTextBox mltb:
                        // mltb.TypeText()
                        break;
                    case EditTextBox etb:
                        // etb.TypeText()
                        break;
                    case RichTextBox rtb:
                        // rtb.TypeText()
                        break;
                    default:
                        throw new ArgumentException(message: "Box not recognized");
                }

            }

        }
    }
}
