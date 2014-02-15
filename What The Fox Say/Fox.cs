using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_The_Fox_Say
{
    class Fox : Animal
    {
        private static Random r = new Random();
        private static string[] sounds = { "Ring-ding-ding-ding-dingeringeding!",
                                         "Wa-pa-pa-pa-pa-pa-pow!",
                                         "Hatee-hatee-hatee-ho!",
                                         "Joff-tchoff-tchoff-tchoffo-tchoffo-tchoff!",
                                         "Jacha-chacha-chacha-chow!",
                                         "Fraka-kaka-kaka-kaka-kow!",
                                         "A-hee-ahee ha-hee!",
                                         "A-oo-oo-oo-ooo!",
                                         "The sound of the fox is an ancient secret mystery"
                                         };
        public override string speak()
        {
            int k = r.Next(sounds.Length);

            return sounds[k];

        }
    }
}
