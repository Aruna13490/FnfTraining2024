using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace FrameworkExamples
{
     
    internal class Library
    {
        public static List<string> SortedTitles(List<string> titles)
        {
            //use IComparable
            return titles;
        }
        public static void Main(string[] args)
        {
            List<string> bookEntries = new List<string>
            {
                "\"The Canterbury Tales\" by chaucer",
                "\"Algorithms\"by Sedgewick",
                "\"The C programming Language\"by keringhan and Ritichie"
            };

            List<string> sortedTitles = SortedTitles(bookEntries);
            foreach (string title in sortedTitles)
            {
                Console.WriteLine(title);
            }

        }
    }
}
