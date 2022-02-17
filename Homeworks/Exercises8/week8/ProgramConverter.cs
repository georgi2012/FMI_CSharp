using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_1
{
    public class ProgramConverter : IConvertible
    {
        string IConvertible.ConvertToCSharp(string vbCode)
        {
            return $"PrConverter.ProgrHelper:VB Code {vbCode} converted to C# code";
        }

        string IConvertible.ConvertToVB2015(string csCode)
        {
            return $"PrConverter.ProgrHelper:C# Code {csCode} converted to VB2015 code";
        }
    }
}
