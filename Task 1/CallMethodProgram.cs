using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class CallMethodProgram
    {

        public void Test()
        {
            Console.WriteLine("Hello from test method");
        }

        static void Main(string[] args)
        {
            string methodeName = null;
            while (methodeName == null || methodeName.Length == 0)
            {
                Console.Write("Plase insert methode name: ");
                methodeName = Console.ReadLine();
            }

            CallMethodProgram callMethodeProgram = new CallMethodProgram();

            MethodInfo method = null;
            try
            {
                method = callMethodeProgram.GetType().GetMethod(methodeName);
            }
            catch (AmbiguousMatchException e)
            {
                Console.WriteLine(e.Message);
            }

            if (method == null)
            {
                Console.WriteLine("Method doesn't exists");
            }
            else
            {
                method.Invoke(callMethodeProgram, null);
            }
            Console.WriteLine("Press any key for exit");
            Console.ReadKey();
        }
    }
}
