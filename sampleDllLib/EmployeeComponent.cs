using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using sampleDllLib;

namespace sampleDllLib
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public interface IEmployeeComponent
    {
        void AddNewEmployee(int id, string name, string address);

        Employee FindEmployee(string name);
    }

    public static class EmployeeFactory
    {

        public static IEmployeeComponent CreateComponent(string dirName) => new EmployeeComponent(dirName);
    }

    internal class EmployeeComponent : IEmployeeComponent
    {
        string dirName = string.Empty;
        static IConfigurationRoot  Configuration { get; set; }
        public static void Initialize()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\New folder\\FrameworkExamples\\FrameworkExamples")
                .AddJsonFile("appsettings.json", false)
                .Build();
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
        
        public EmployeeComponent(string dirName)
        {
          
            this.dirName = Configuration["FileOptions:EmpLocationDir"];

            if (string.IsNullOrEmpty(dirName))
            {
                throw new Exception("Directory info is not read from the appsettings");
            }
            this.dirName = dirName;
        }

        public void AddNewEmployee(int id, string name, string address)
        {
            Console.WriteLine("Employee added");

            var emp = createEmployee(id, name, address);
            //Code to add the Employee according to the business requirement
            //todo: Using Json serialization, U should add the Employee to a json file and name should be the empname.json

            var jsonData = JsonSerializer.Serialize<Employee>(emp);
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            var file = Path.Combine(dirName, $"{emp.Name}.json");
            File.WriteAllText(file, jsonData);
        }

        private Employee createEmployee(int id, string name, string address)
        {
            return new Employee { Id = id, Name = name, Address = address };
        }

        public Employee FindEmployee(string name)
        {
            string fileName = Path.Combine(dirName, $"{name}.json");
            if (!File.Exists(fileName))
            {
                throw new Exception("Detail of the Employee not found");
            }
            var json = File.ReadAllText(fileName);
            var emp = JsonSerializer.Deserialize<Employee>(json);
            return emp;
            //U get the json file, deserialize it by reading the file. 
            //U get the object, return it. 
        }
    }
}