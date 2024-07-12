using FrameworksExample.Entities;
using FrameworksExample.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FrameworksExample
{
    internal class Ex09Serialization
    {
         static void Main(string[] args)
        {
            testForXmlSerialization();
            testForJsonSerialization();
        }

        private static void testForJsonSerialization()
        {
            jsonSerialization();
            jsonDeserialization();


        }

        private static void jsonDeserialization()
        {
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:JsonFile"];
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);

            var formatter = new JsonSerializer(typeof(Student));
            var student = formatter.Deserialize(fs) as student;
            Console.WriteLine(student.Name);
            fs.Close();
        }

        private static void jsonSerialization()
        {
            //Student student = new Student { Id = 11, Address = "Belgaum", Name = "Aruna" };

            //AppSettings.Initialize();
            //var file = AppSettings.Configuration["FileOptions:JmlFile"];
            //FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);

            //var formatter = new JsonSerializer(typeof(Student));
            //formatter.Serialize(fs, student);
            //fs.Close();
            var student = new Student() { Id = 1, Name = "Aruna", Address = "Bangalore" };
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            var jsonString=JsonSerializer.Serialize(student);
            Console.WriteLine(jsonString);
            var formatter = new XmlSerializer(typeof(Student));
            formatter.Serialize(fs, student);
            fs.Close();
            //save the jsonString to the file taken from the ocnfig...


        }

        private static void testForXmlSerialization()
        {
            xmlSerialization();
            XmlDeserializationEvents();
        }
        private static void XmalDeserialization()
        {
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs=new FileStream(file,FileMode.Open,FileAccess.Read);

            var formatter = new XmlSerializer(typeof(Student));
            var student = formatter.Deserialize(fs) as student;
            Console.WriteLine(student.Name);
            fs.Close();
        }
        private static void xmlSerialization()
        {
            Student student = new Student { Id = 11, Address = "Belgaum", Name = "Aruna" };

            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);

            var formatter=new XmlSerializer(typeof(Student));
            formatter.Serialize(fs, student);
            fs.Close();
        }
       
    }
}
