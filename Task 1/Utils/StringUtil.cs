using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Exceptions;

namespace Task_1.Utils
{
    public class StringUtil
    {


        public static string ReverseFirstHalfString(string input)
        {
            int halfStringIndex = input.Length / 2;
            StringBuilder stringBuilder = new StringBuilder(input, halfStringIndex, input.Length - halfStringIndex, input.Length);
            for (int i = 0; i < halfStringIndex; i++)
            {
                stringBuilder.Append(input[i]);
            }
            return stringBuilder.ToString();
        }

        public static string FindStringInMatrix(string keyword, string[][] matrix)
        {
            foreach (string[] array in matrix)
            {
                foreach (string str in array)
                {
                    if (str.Contains(keyword))
                    {
                        return str;
                    }
                }
            }

            throw new KeywordNotFoundException(keyword);
        }
    }
}