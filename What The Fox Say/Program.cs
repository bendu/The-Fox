using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_The_Fox_Say
{
    class Program
    {
        static void Main(string[] args)
        {

            Animal a = new Dog();

            Animal b = new Cat();

            Console.WriteLine("Dog goes " + a.speak());
            Console.WriteLine("Cat goes " + b.speak());

            Console.ReadLine();
        }
    }
}
