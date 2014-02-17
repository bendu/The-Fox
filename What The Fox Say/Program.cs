using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace What_The_Fox_Say
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Type in a string or press return to exit");
                string input = Console.ReadLine();
                
                if (input.Equals(""))
                    break;
                
                InputDecoder id = new InputDecoder(input);

                Animal a = id.GetAnimal();
                
                Type thisType = a.GetType();

                if (thisType != null)
                {
                    MethodInfo theMethod = thisType.GetMethod(id.GetAction());

                    string output = (string)theMethod.Invoke(a, null);
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine("Could not figure out query");

                }
            }
        }
    }
}
