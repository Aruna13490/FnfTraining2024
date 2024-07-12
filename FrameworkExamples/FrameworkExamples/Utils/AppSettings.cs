using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace FrameworkExamples.Utils
{
    internal class AppSettings
    {

        public static IConfigurationRoot? Configuration { get; set; }
        public static void Initialize()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\New folder\\FrameworkExamples\\FrameworkExamples")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
    }
}
