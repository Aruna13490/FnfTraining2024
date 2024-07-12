
using FrameworkExamples.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using FrameworkExamples.Data;

namespace FrameworksExample
{
    internal class Ex06FileIO
    {
        //const string fileName = "TestCode.txt";
        static void WriteToFile(string content)
        {
            if (Configuration != null)
            {
                string? fileName = Configuration["FileOptions:FilePath"];
                Console.WriteLine(fileName);
                if (fileName != null)
                {
                    File.AppendAllText(fileName, content + "\n");
                }
                else
                {
                    Console.WriteLine("Path is not set, cannot write to file");
                }
            }
        }

       
        public static void Initialize()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\New folder\\FrameworkExamples")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
               
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
        public static IConfigurationRoot? Configuration { get; private set; }
        static void Main(string[] args)
        {
            AppSettings.Initialize();
            Configuration = AppSettings.Configuration;
            WriteToFile("Sample Content for the file");
        }
    }
}
