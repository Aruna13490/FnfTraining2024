using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExamples
{
    internal class Ass01
    {
        static SortedDictionary<string,int> GetWordFrequencies(string input)
        {
            SortedDictionary<string, int> WordCount = new SortedDictionary<string, int>();
            char[] additionalChar= new char[] { ' ', '.', ';', '!' ,','};
            string[] words=input.ToLower().Split(additionalChar,StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) {
                if (WordCount.ContainsKey(word))
                {
                    WordCount[word]++;
                }
                else
                {
                    WordCount[word] = 1;
                }
            }
            return WordCount;

        }
        static void Main()
        {
           //improve modularity
           string input = "Hello World. This is a new world!";
            
           
           SortedDictionary<string,int> WordFrequencies = GetWordFrequencies(input);
            if(WordFrequencies.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var sortedwords = WordFrequencies.Reverse();
                foreach (var word in sortedwords)
                {
                    
                    Console.WriteLine($"{word.Value} : {word.Key}");
                }

            }

        }

    }
}
