using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    public class TextBox : IUndoable
    {
        void IUndoable.Undo()
        {
            Undo();
        }
        protected virtual void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }
    }
}