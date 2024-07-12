using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExamples
{
    internal class Ass02
    {
        public static List<string> SortedTitles(List<string> titles)
        {
            return titles.Select(title => new
            {
                FullTitle = title,
                Author = GetFirstAuthor(title),
                Title=GetTitle(title)
            }).OrderBy(entry => entry.Author).ThenBy(entry=> entry.Title).Select(entry=> entry.Title).ToList();
        }

        private static string GetFirstAuthor(string author)
        {
            string[] parts = author.Split(new[] {"by"}, StringSplitOptions.None);
            string authors = parts[1];
            string firstAuthor = authors.Split(' ')[0];
            return firstAuthor;
        }

        private static string GetTitle(string entry)
        {
            int startIndex = entry.IndexOf('"') + 1;
            int endIndex = entry.LastIndexOf('"');
            return entry.Substring(startIndex, endIndex - startIndex);
        }

        static void Main(string[] args)
        {
            List<string> bookEntries=new List<string>
            { 
                "\"The Canterbury Tales\" by chaucer",
                "\"Algorithms\"by Sedgewick",
                "\"The C programming Language\"by keringhan and Ritichie"
            };
            List<string>sortedTitles=SortedTitles(bookEntries);
            foreach (string title in sortedTitles)
            {
                Console.WriteLine(title);
            }

        }
    }
}
