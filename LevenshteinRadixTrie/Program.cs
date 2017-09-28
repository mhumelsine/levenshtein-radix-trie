using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevenshteinRadixTrie
{
    class Program
    {
        public static void Main(string[] args)
        {
            var trie = new LevenshteinRadixTrie();

            trie.Add("Michael", 13);
            trie.Add("Michelle", 25);
            trie.Add("Mike", 23);
            Console.ReadKey();
        }
    }
}
