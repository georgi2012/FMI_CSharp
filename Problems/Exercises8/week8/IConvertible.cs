using System;

namespace Lab8_1
{
    public interface IConvertible
    {
        /// <summary>
        /// Converts VB2015 source to C# source code
        /// </summary>
        /// <param name="vbCode"></param>
        /// <returns></returns>
        string ConvertToCSharp(string vbCode);
        /// <summary>
        /// Converts CSharp source code to VS2015 code
        /// </summary>
        /// <param name="csCode"></param>
        /// <returns></returns>
        string ConvertToVB2015(string csCode);

    }

}
