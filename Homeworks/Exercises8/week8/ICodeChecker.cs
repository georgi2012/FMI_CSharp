using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8_1
{
    //base interface methods are added to new the interface
    public interface ICodeChecker: IConvertible
    {
        /// <summary>
        /// Syntax check for codeToCheck with respect to language
        /// </summary>
        /// <param name="codeToCheck"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        bool CodeCheckSyntax(string codeToCheck, string language);
    }

}
