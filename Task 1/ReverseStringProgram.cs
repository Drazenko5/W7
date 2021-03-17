using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Utils;

namespace Task_1
{
    public class ReverseStringProgram
    {
        static void Main(string[] args)
        {

            Console.Write("Plase insert string: ");

            string str = Console.ReadLine();

            Console.WriteLine(string.Format("Reverse input is: {0}", StringUtil.ReverseFirstHalfString(str)));

            Console.WriteLine("Press any key for exit");
            Console.ReadKey();
        }
    }
}
