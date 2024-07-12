using FrameworkExamples.Utils;
using FrameworkExamples.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    /*
         * Serialization is a concept of persisting the object into a file instad of data of the object.
         * The object itself will be stored and retrieved back to the same state from which it was saved.
         * Unlike the typical file IO, here we save the object and retrive the object. There will be no scope for seeking the contents of the file.
         * In serialization the whole object gets stored or nothing.
         * 
         * todo: You shd implement the IcustomerRepo ineterface into a class called XmlCustomerRepo and provide all the functionalities
         * using factory pattern, you shd load the appropriate implementor 
         */
    internal class Ex09Serialization
    {
        static void Main(string[] args)
        {
            //XmlSerialization();
            //XmlDeserialization();
            testForJsonSerialization();

        }

        private static void testForJsonSerialization()
        {
            jsonSerialization();
          //  jsonDeserialization();
        }

        private static void jsonDeserialization()
        {
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:JsonFile"];

            string fileName = "Student.json";
            string jsonString = File.ReadAllText(file);
            Student student = JsonSerializer.Deserialize<Student>(jsonString)!;

            Console.WriteLine(student.Id);
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Address);


        }

        private static void jsonSerialization()
        {
            //what
            var student = new Student()
            {
                Id = 1,
                Name ="Aruna Allayyanavar",
                Address = "Belagavi"
            };
            //where
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:JsonFile"];


            var jsonString = JsonSerializer.Serialize(student);
            File.WriteAllText(file, jsonString);


            Console.WriteLine(jsonString);

        }

        private static void XmlSerialization()
        {
            Student student = new Student { Id = 11, Address = "Hubballi", Name = "Sakshi" };
            //where to serialize: File location
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            var formatter = new XmlSerializer(typeof(Student));
            formatter.Serialize(fs, student);
            fs.Close();
        }

        private static void XmlDeserialization()
        {
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            var formatter = new XmlSerializer(typeof(Student));
            var student = formatter.Deserialize(fs) as Student;
            Console.WriteLine(student.Name);
            fs.Close();
        }
    }
}