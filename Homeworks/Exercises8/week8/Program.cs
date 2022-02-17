using System;

namespace Lab8_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramHelper ph = new ProgramHelper();
            Console.WriteLine(ph.ConvertToCSharp("VB code")); //runs public implementation
            Console.WriteLine(((IConvertible)ph).ConvertToCSharp("VB code to convert"));//explicit implementation

            ICodeChecker ic = ph;
            if (ic is ProgramHelper code)
            {
                Console.WriteLine(code.ConvertToCSharp("ProgramHelper: VB code"));
            }
            //or
            ProgramHelper helper = ic as ProgramHelper;
            if (helper != null)
            {
                Console.WriteLine( helper.ConvertToCSharp("PHelper code-> test as operator"));
            }

            ICodeChecker checker = ph;
            Console.WriteLine(checker.ConvertToCSharp("VS code tp check CodeChecker"));

            ProgramConverter pc = ph;
            IConvertible icon = pc;
            Console.WriteLine(icon.ConvertToCSharp("Convertible to ProgramConv"));

            ProgramConverter pc2 = new ProgramConverter();
            IConvertible icon2 = pc2;
            Console.WriteLine(icon2.ConvertToCSharp("Icon to prConv"));
        }
    }
    



}
