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

            Fox x = new Fox();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(x.speak());
            }

            Console.ReadLine();
        }
    }
}
