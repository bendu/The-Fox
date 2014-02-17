﻿using System;
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

                
                
                InputDecoder id = new InputDecoder(input);

                Animal a = id.GetAnimal();

                if (a == null)
                {
                    Console.WriteLine("unrecognized command");
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
            }
        }
    }
}
