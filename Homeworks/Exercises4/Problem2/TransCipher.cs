using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class TransCipher
    {
        #region Data

        private string keyText;
        private string plainText;
        private char[,] encryptionMatrix;

        #endregion

        #region Properties
        public string KeyText
        {
            get { return keyText; }
            set { keyText = value == null ? "" : value; }
        }
        public string PlainText
        {
            get { return plainText; }
            set { plainText = value == null ? "" : value; }
        }

        #endregion

        #region Constructor
        public TransCipher(string plainText, string keyText)
        {
            PlainText = plainText;
            KeyText = keyText;
        }

        public TransCipher()
        {
            PlainText = "";
            KeyText = "";
        }
        #endregion

        #region Methods

        public string Encrypt()
        {
            if (keyText.Length == 0 || plainText.Length == 0)
            {
                return "";
            }

            int key = keyText.Length;
            int rowNumber = (int)(Math.Ceiling(plainText.Length / (decimal)key));
            char[] plainTextChar = plainText.ToCharArray();
            char[] encrypted = new char[key * rowNumber];

            //matrix rowNum x key
            encryptionMatrix = new char[rowNumber, key];
            
            //filling the matrix
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    if (i * key + j >= plainTextChar.Length)
                    {
                        encryptionMatrix[i, j] = ' ';
                    }
                    else
                    {
                        encryptionMatrix[i, j] = plainTextChar[i * key + j];
                    }
                }
            }

            //encrypt
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < rowNumber; j++)
                {
                    encrypted[i * rowNumber + j] = encryptionMatrix[j, i];
                }
            }

            encryptionMatrix = null; 
            return new string(encrypted);

        }

        //plain text is used as the cipher
        public string Decrypt()
        {
            if (keyText.Length == 0 || plainText.Length == 0)
            {
                return "";
            }

            int key = keyText.Length;
            int rowNumber = (int)(Math.Ceiling(plainText.Length / (decimal)key));
            char[] cipherTextChar = plainText.ToCharArray();
            char[] decrypted = new char[key * rowNumber];

            //matrix rowNum x key
            encryptionMatrix = new char[rowNumber, key];

            //filling the matrix
            for (int j = 0; j < key; j++)
            {//cols
                for (int i = 0; i < rowNumber; i++)
                {//rows
                    if (j * rowNumber + i >= cipherTextChar.Length)
                    {
                        encryptionMatrix[i, j] = ' ';
                    }
                    else
                    {
                        encryptionMatrix[i, j] = cipherTextChar[j * rowNumber + i];
                    }
                   
                }
                
            }

            //decrypt
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    decrypted[i * key + j] = encryptionMatrix[i, j];
                }
            }

            encryptionMatrix = null;
            return new string(decrypted);

        }


        #endregion

    }
}
