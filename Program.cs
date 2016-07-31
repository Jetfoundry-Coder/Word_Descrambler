using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Descrambler
{
    class Program
    {
        static void Main(string[] args)
        {

            bool finished = false;
            List<string> characters;
            while (!finished)
            {
                characters = new List<string>();
                string input = string.Empty;
                Console.WriteLine("Enter Letters");
                input = Console.ReadLine();
                char[] charactList = input.ToCharArray();
                foreach(char character in charactList)
                {
                    characters.Add(character.ToString());
                }
                PermutationGenerator generator = new PermutationGenerator(characters);
                WordFinder words = new WordFinder(generator.words);
                Console.WriteLine("Found " + words.words.Distinct().Count() + " in the sequence.");
                foreach (string word in words.words)
                {
                    Console.WriteLine(word);
                }

                Console.WriteLine("Do you wish to descramble another word y / n");
                if(Console.ReadLine() == "n")
                {
                    finished = true;
                }
            }

      
           
        }
    }
}
