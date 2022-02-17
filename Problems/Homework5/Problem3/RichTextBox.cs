using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3 
{
    public class RichTextBox :TextBox
    {
        protected override void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }
    }
}