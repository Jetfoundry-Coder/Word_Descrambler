using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Word_Descrambler
{
    class WordFinder
    {
        public List<string> words;
        List<string> lettersUsed;
        public WordFinder(IList<string> perms)
        {
            //keeps track of the letters we've already used so we avoid loading and searching the same dictionary twice
            lettersUsed = new List<string>();
            //stores the matches we find with the dictionary files
            words = new List<string>();

            foreach(var item in perms)
            {
                //gets the letter the word starts with
                string startsWith = item[0].ToString().ToLower();
                //holds the words from the dictionary file based on the letter the word starts with
                List<string> dictionaryWords = new List<string>();
                //if we have already searched words starting with this letter skip this iteration
                if (!lettersUsed.Contains(startsWith))
                {
                    //adds the starting letter to the already used list
                    lettersUsed.Add(startsWith);
                    //open the dictionary file based on the first letter of the word we are searching
                    string folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string fun = "DictionaryFiles\\" + startsWith.ToUpper() + " Words.csv";
                    string filePath = Path.Combine(folder, fun);
                    //read all of the words form the appropriate dictionary file
                    var reader = new StreamReader(File.OpenRead(filePath));
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        dictionaryWords.Add(line);
                    }
                    //get all of the words from the permutations that start with the first letter of the first word
                    //basically if we have permutations that start with a letter we will search all permutations
                    //that start with that letter against the dictionary to avoid reading the same dictionary multiple times
                    List<string> wordsThatStartWithThisLetter = perms.Where(x => x[0].ToString().ToLower() == startsWith).ToList();
                    foreach (string word in wordsThatStartWithThisLetter)
                    {
                        //compare the current permutation against all words in the appropriate dictionary
                        foreach(string dictionaryWord in dictionaryWords)
                        {
                            //if we find a match add it to the list
                            if(dictionaryWord == word && !words.ToList().Contains(word))
                            {
                                words.Add(dictionaryWord);
                            }
                        }
                    }
                }

                



            }

        }

    
    }
}
