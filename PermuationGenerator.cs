using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Descrambler
{
    class PermutationGenerator
    {
        public IList<IList<string>> perms;
        public List<string> words;
        public PermutationGenerator(List<string> list)
        {
            words = new List<string>();
            perms = Permutations(list);
        }

        //NOT MY ALGORITHM
        //CREDIT TO Mitja Bonca https://www.daniweb.com/programming/software-development/threads/349926/c-string-permutation
        private IList<IList<T>> Permutations<T>(IList<T> list)
        {

            List<IList<T>> perms = new List<IList<T>>();
            if (list.Count == 0)
                return perms; 
            int factorial = 1;
            for (int i = 2; i <= list.Count; i++)
                factorial *= i;
            for (int v = 0; v < factorial; v++)
            {
                string word = string.Empty;
                List<T> s = new List<T>(list);
                int k = v;
                for (int j = 2; j <= list.Count; j++)
                {
                    int other = (k % j);
                    T temp = s[j - 1];
                    s[j - 1] = s[other];
                    s[other] = temp;
                    k = k / j;
                }
                
                perms.Add(s);
                foreach(var character in s)
                {
                    word += character;
                }
                words.Add(word);
            }
            return perms;
        }

    }
}
