using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_The_Fox_Say
{
    class Dog : Animal
    {
        private static Random r = new Random();

        override public string Speak()
        {
            if (r.Next(1) == 1)
                return "Woof";
            else
                return "Arf";
        }
    }
}
