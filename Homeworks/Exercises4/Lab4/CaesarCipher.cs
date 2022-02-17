using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class CaesarCipher
    {
        #region Paramethers

        private int shiftLenght;

        #endregion

        #region Constructor
        public CaesarCipher(int shiftLen)
        {
            ShiftLenght = shiftLen;
        }

        #endregion

        #region Properties
        public int ShiftLenght
        {
            get { return shiftLenght; }
            set
            {
                shiftLenght = Math.Abs(value) < 26 ? value : 3;
            }
        }

        #endregion

        #region Methods

        public string Encrypt(string text)
        {
            char[] textChars = text.ToCharArray();
            char[] cipherTextChars = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                cipherTextChars[i] = (char)('A' +
                    (textChars[i] - 'A' + shiftLenght + 26) % 26);
                //+26 and %26 to stay in the alphabet
            }

            return new string(cipherTextChars);
        }

        public string Decrypt(string text)
        {
            char[] textChars = text.ToCharArray();
            char[] decryptTextChars = new char[text.Length];


            for (int i = 0; i < text.Length; i++)
            {
                decryptTextChars[i] = (char)('A' +
                    (textChars[i] - 'A' - shiftLenght + 26) % 26);
                //+26 and %26 to stay in the alphabet
            }

            return new string(decryptTextChars);


        } 
        #endregion

    }
}
