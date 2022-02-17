using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class RouteCipher
    {
        #region Static data
        //[x,y] modifiers for turning directions
        static readonly short[][] directions = { new short[] { 1, 0 } ,//down
                                                 new short[] { 0, +1 } ,//right
                                                 new short[]{- 1, 0 },//up
                                                 new short[]{ 0, -1 } };//left

        #endregion

        #region Data variables
        //data
        private int key;
        // 
        #endregion

        #region Constructors
        //constructor
        public RouteCipher(int key)
        {
            Key = key;
        }
        // 
        #endregion

        #region Properties
        //Properties
        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        // 
        #endregion

        #region Methods 
        private char[] GetCharArrWithoutSpaces(string text)
        {
            //decide the exact size
            //should we remove other symbows as well?
            char[] allChars = text.ToCharArray(); //so we dont use text[] as it's not allowed
            char[] charsWithoutSpace;
            int size = 0;
            int index = 0;
            while (index < text.Length)
            {
                if (allChars[index] != ' ' && allChars[index]!='\t')
                {
                    size++;
                }
                index++;
            }
            charsWithoutSpace = new char[size]; //exact size!
            //fill it
            index = 0;
            size = 0;//we will reuse it as index

            while (index < text.Length)
            {
                if (allChars[index] != ' ')
                {
                    charsWithoutSpace[size++] = allChars[index];
                }
                index++;
            }

            return charsWithoutSpace;
        }
        //remove ? should we work with spaces?

        //methods
        public string Encrypt(string plainText)
        {
            if (key == 0 || plainText==null || plainText.Length==0)
            {//nothing to be done . Inf rows
                return "";
            }

            //vars
            bool startsFromUpperLeft = (key > 0);
            key = Math.Abs(key);
            char[] plainTextChars = GetCharArrWithoutSpaces(plainText);
            int rows = (int)Math.Ceiling((decimal)plainTextChars.Length / key);
            char[][] matrix = new char[rows][];
            char[] cipherText = new char[rows * key];
            int indexOfText = 0;
            int curRow = 0, curCol = 0; //helpers for cipher generation
            int directionIndex = 0; //helps for turning dir in matrix
            bool cellChanged = false;
            int tempRow, tempCol;//used to dir checking
                                 //
                                 //filling matrix and allocating

            if (startsFromUpperLeft)
            {//fill normally
                for (int i = 0; i < rows; i++)
                {
                    matrix[i] = new char[key];
                    for (int j = 0; j < key; j++)
                    {//use the same loop to fill the row as well
                        matrix[i][j] = indexOfText >= plainTextChars.Length ? 'X' : plainTextChars[indexOfText++];
                    }
                }
            }
            else
            {//we will fill it upside down so we can use the same algorithm for starting right bottom
                int index = 0;

                for (int i = 0; i < rows; i++)
                {//allocate
                    matrix[i] = new char[key];
                }

                for (int i = plainTextChars.Length; i < rows * key; i++)
                {//fill 'last' empty with X in first places
                    matrix[0][index++] = 'X';
                }
                for (int i = plainTextChars.Length - 1; i >= 0; i--)
                {//fill the rest
                    matrix[index / key][index % key] = plainTextChars[i];
                    index++;
                }
            }

            //print matrix for tests
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < key; j++)
            //    {
            //        Console.Write(matrix[i][j]);
            //    }
            //    Console.WriteLine();
            //}

            //generate cipher
            for (int i = 0; i < key * rows; i++)
            {//up and counteclockwise
                cipherText[i] = matrix[curRow][curCol];

                cellChanged = false;
                tempCol = curCol;
                tempRow = curRow;
                if (curRow > rows - 1 - curRow)
                {
                    tempRow = rows - 1 - curRow;
                    cellChanged = true;
                }
                if (curCol > key - 1 - curCol)
                {
                    tempCol = key - 1 - curCol;
                    cellChanged = true;
                }
                if (!cellChanged)
                {
                    tempCol -= 1;
                }
                if (tempRow == tempCol)
                {
                    directionIndex = (directionIndex + 1) % 4;
                    //turn direction
                }
                //move to next cell in the right direction
                curRow += directions[directionIndex][0];
                curCol += directions[directionIndex][1];
                //

            }


            if (!startsFromUpperLeft)
            {//restore starting data
                key = -key;
            }
            //
            return new string(cipherText);
        }

        public string Decrypt(string ciphertext)
        {
            if (key == 0 || ciphertext == null || ciphertext.Length == 0)
            {
                return "";
            }
            bool startsFromUpperLeft = (key > 0);
            key = Math.Abs(key);
            char[] cipherTextChars = ciphertext.ToCharArray();
            int rows = (int)Math.Ceiling((decimal)cipherTextChars.Length / key);
            char[][] matrix = new char[rows][];
            char[] plainTextChar; 

            int curRow = 0, curCol = 0; //helpers for cipher generation
            int directionIndex = 0; //helps for turning dir in matrix
            bool cellChanged = false;
            int tempRow, tempCol;
            //allocate matrix
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[key];
            }
            //
     
            //we should place them the way that they have been encrypted
            for (int i = 0; i < key * rows; i++)
            {//up and counteclockwise
                matrix[curRow][curCol] = i>=cipherTextChars.Length? 'X': cipherTextChars[i];
                //there might be case where decryption key is different from encryption . So that will prevent it from crashing

                cellChanged = false;
                tempCol = curCol;
                tempRow = curRow;
                if (curRow > rows - 1 - curRow)
                {
                    tempRow = rows - 1 - curRow;
                    cellChanged = true;
                }
                if (curCol > key - 1 - curCol)
                {
                    tempCol = key - 1 - curCol;
                    cellChanged = true;
                }
                if (!cellChanged)
                {
                    tempCol -= 1;
                }
                if (tempRow == tempCol)
                {
                    directionIndex = (directionIndex + 1) % 4;
                    //turn direction
                }
                //move to next cell in the right direction
                curRow += directions[directionIndex][0];
                curCol += directions[directionIndex][1];
                //

            }

            //if it !startsLeft , the matrix is upside down and last elements are first
            //for precision lets see how many X are there at the end 
            //- we want a text as similar to the text before encrypting so no X at the end
            //that will be a problem is the actual plainText ends on 'X's
            int plainTextExactSize = rows * key; //it will be used as index as well
            if (startsFromUpperLeft)
            {
                //exactsize will be used as index as well
                while (matrix[rows - 1][(plainTextExactSize - 1) % key] == 'X')
                {
                    plainTextExactSize--;
                }
            }
            else
            {//first elements are last for the plainText
                while (matrix[0][rows * key - plainTextExactSize] == 'X')
                {
                    plainTextExactSize--;
                }
            }
            
            plainTextChar = new char[plainTextExactSize];
            //
            if (startsFromUpperLeft)
            {
                for (int i = 0; i < plainTextExactSize; i++)
                {
                    plainTextChar[i] = matrix[i / key][i % key];
                }
            }
            else
            {
                int offset = rows * key - plainTextExactSize;
                for (int i = plainTextExactSize - 1; i >= 0; i--)
                {
                    plainTextChar[plainTextExactSize - 1 - i] = matrix[(i + offset) / key][(i + offset) % key];
                }
            }
            //
            if (!startsFromUpperLeft)
            {//restore value
                key = -key;
            }
            return new string(plainTextChar);//tbd
        }
        //
        public override string ToString()
        {
            return "Route Cipher with key: " + key;
        } 
        #endregion

    }
}
