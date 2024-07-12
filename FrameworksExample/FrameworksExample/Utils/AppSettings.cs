using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FrameworksExample.Utils
{
    internal class AppSettings
    {
        public static IConfiguration ? Configuration { get; set; }
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\Users\\6147957\\source\\repos\\FrameworksExample")
                .AddJsonFile("appsettigns.json", OptionalAttribute: false, reloadOnChange: true)
                .Build();
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
    }
}
