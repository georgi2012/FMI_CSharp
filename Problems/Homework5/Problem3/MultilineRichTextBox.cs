using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    public class MultilineRichTextBox:RichTextBox
    {
        static void Main(string[] args)
        {
            MultilineRichTextBox multilineRichTextBox = new MultilineRichTextBox();
            multilineRichTextBox.PolyTest();
            
        }
        public void PolyTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            MultilineRichTextBox multilineRichTextBox = new MultilineRichTextBox();

            IUndoable undoable1 = richTextBox;
            IUndoable undoable2 = multilineRichTextBox;

            undoable1.Undo();
            Console.WriteLine("-RichTextBox.Undo is called even though the base is IUndoable \nbecause" +
                " with upcasting from RichTextBox Undo is already overriden for base class IUndoable\n");
            undoable2.Undo();
            Console.WriteLine("-MultilineRichTextBox.Undo is called even though the base is IUndoable \nbecause" +
                " with upcasting from MultilineRichTextBox Undo is already overriden \n");
        }
        protected override void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }

    }
}