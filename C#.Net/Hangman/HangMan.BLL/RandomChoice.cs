using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.BLL
{
    public class RandomChoice : IChoiceGetter
    {
        private Random _rng = new Random();
        public string GetChoice()
        {
            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader("wordlist.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); 
                }
            }
            return list[_rng.Next(1, list.Count)];
        }
    }
}
