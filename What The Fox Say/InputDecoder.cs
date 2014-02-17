using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_The_Fox_Say
{
    class InputDecoder
    {
        private static Dictionary<string, Type> animals;
        private static Random rand = new Random();

        private Animal solvedAnimal;
        private string action;

        public InputDecoder(string toDecode)
        {
            animals = AvailableAnimals();
            // negative for odd values
            bool negative = ScanInputForInformation(toDecode) % 2 != 0;

            if (negative)
            {
                if (animals.Count < 2)
                {
                    solvedAnimal = null;
                }
                else
                {

                    Type t;
                    do
                    {
                        t = animals.ElementAt(rand.Next(0, animals.Count)).Value;
                    } while (solvedAnimal.GetType().Equals(t));

                    solvedAnimal = (Animal)Activator.CreateInstance(t);
                }
            }
        }

        // returns the frequency of negation, updates solvedAnimal regardless of negation result
        private int ScanInputForInformation(string s)
        {
            int freq = 0;

            string[] words = s.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                string lowercase = word.ToLowerInvariant();

                if (solvedAnimal == null && animals.ContainsKey(lowercase))
                {
                    Type t;
                    animals.TryGetValue(lowercase, out t);
                    solvedAnimal = (Animal)Activator.CreateInstance(t);
                }
                else if (lowercase.Contains("n't") || lowercase.Equals("not") || lowercase.Contains("nt"))
                {
                    freq++;
                }

            }

            return freq;
        }

        private Dictionary<string, Type> AvailableAnimals()
        {
            var t = typeof(Animal).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Animal)));
            Dictionary<string, Type> map = new Dictionary<string, Type>();

            foreach (Type i in t)
            {
                map.Add(i.Name.ToLowerInvariant(), i);
            }

            return map;
        }

        public Animal GetAnimal()
        {
            return solvedAnimal;
        }


        public string GetAction()
        {
            return "Speak";
        }
    }
}
