using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_1
{
    public class ProgramHelper : ProgramConverter, IConvertible, ICodeChecker
    {

        //implementation of interface with explicit name quotation
        bool ICodeChecker.CodeCheckSyntax(string codeToCheck, string language)
        {
            Console.WriteLine($"Syntax check result{(codeToCheck != null ? "OK" : "Errors")}");
            return codeToCheck != null ? true : false;
        }
        string IConvertible.ConvertToCSharp(string vbCode)
        {
            return $"ProgrHelper:VB Code {vbCode} converted to C# code";
        }

        string IConvertible.ConvertToVB2015(string csCode)
        {
            return $"ProgrHelper:C# Code {csCode} converted to VB2015 code";
        }

        //not a very good practise
        //virtual to let override for derived classes
        public virtual string ConvertToCSharp(string vbcode)
        {
            return $"IConvertible:vb code {vbcode} converted to c# code";
        }
        public bool CodeCheckSyntax(string codeToCheck, string language)
        {
            Console.WriteLine($"Syntax check result{(codeToCheck != null ? "OK" : "Errors")}");
            return codeToCheck != null ? true : false;
        }
    }
}
