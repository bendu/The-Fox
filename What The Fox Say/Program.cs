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
                Console.Write("Command (return for exit): ");
                string input = Console.ReadLine();

                if (input.Equals("") || input.Equals("exit", StringComparison.OrdinalIgnoreCase)
                    || input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (input.Equals("about", StringComparison.OrdinalIgnoreCase))
                {
                    printAboutMessage();
                    continue;
                }

                if (input.Contains("help") || input.Contains("halp") )
                {
                    printHelpMessage();
                    continue;
                }
                
                InputDecoder id = new InputDecoder(input);

                Animal a = id.GetAnimal();

                if (a == null)
                {
                    Console.WriteLine("unrecognized command");
                    Console.WriteLine("Need help? Try typing 'halp'");
                    Console.WriteLine();
                    continue;
                }

                Type thisType = a.GetType();

                string action = id.GetAction();

                if (action != null)
                {
                    MethodInfo theMethod = thisType.GetMethod(action);

                    string output = (string)theMethod.Invoke(a, null);
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine("Could not figure out action for " + a.GetType().Name);
                }

                Console.WriteLine();
            }
        }

        static void printAboutMessage()
        {
            Console.WriteLine("Created by Ben Du as a fun GitHub project");
            Console.WriteLine();
            Console.WriteLine("Pls follow me on GitHub: bendu");
            Console.WriteLine();
            Console.WriteLine("Tip: try asking what the fox says multiple times.");
            Console.WriteLine();
        }

        static void printHelpMessage()
        {
            Console.WriteLine("Type in freeform input and (hopefully) get a meaningful response!");
            Console.WriteLine();
            Console.WriteLine("Example: Cat says?");
            Console.WriteLine();
        }
    }
}
