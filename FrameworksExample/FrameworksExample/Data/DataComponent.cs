using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FrameworksExample;
using FrameworksExample.Entities;

namespace FrameworksExample.Data
{
    interface ICustomerRepo
    {
        void AddNewCustomer(Customer cst);
        void DeleteCustomer(int cstId);

        void UpdateCustomer(Customer cst);
        List<Customer> GetAllCustomers();

    }
    class CsvCustomerRepo : ICustomerRepo
    {
        private readonly string? fileName;
        public CsvCustomerRepo()
        {
            AppSettings.Initialize();
            fileName = FileIO.Configuration["FileOptions:CsvFilePath"];
        }

        public void AddNewCustomer(Customer cst)
        {
            if (fileName == null)
            {
                throw new Exception("FilePath is not set,refer Configuration");
            }
            File.AppendAllText(fileName, cst.ToString());
        }

        public void DeleteCustomer(int cstId)
        {
            bool finder(Customer cst) {
                if (cst,CustomerID == cstID)
                    {
                    return true;
                }
                return false;
            }

            var records = GetAllCustomers();
            var foundrec = records.Find(r => r.CustomerID == cstID);
            if (foundrec == null)
            {
                throw new Exception("no record found to elete");
            }
            records.Remove(foundrec);
            saveAll(records);
        }

        public List<Customer> GetAllCustomers()
        {   //create a temp list
            List<Customer> customers = new List<Customer>();
            //check if the file is set from the config
            if (fileName == null)
            {
                throw new Exception("Filepath not set to read the data.Could not read the config file");
            }
            //get all the lines from the file
            var lines = File.ReadAllLines(fileName);
            //iterate through each line
            foreach (var line in lines) {
                //check if the line is empty or null
                if (string.IsNullOrEmpty(line))
                {
                    return customers;
                }
                //split the lines by comma
                var words = line.Split(',');
                //create customer object for each line
                Customer cst = new Customer();
                //fill the object with the data
                cst.BillDate = DateTime.Parse(words[0]);
                cst.CustomerID = int.Parse(words[1]);
                cst.CustomerName = words[2];
                cst.CustomerAddress = words[3];
                cst.BillAmount = int.Parse(words[4]);
                //add the customer object to the temp list
                customers.Add(cst);
            }
            //Finally return the temp list
            return customers;

            static void UpdateCustomer(Customer cst)
            {
                var customers = GetAllCustomers();
                var found = customers.Find(c => c.CustomerID == cst.CustomerID);
                found.CustomerAddress = cst.CustomerAddress;
                found.BillAmount = cst.BillAmount;
                found.BillDate = cst.BillDate;
                found.BillAmount = cst.BillAmount;
                found.CustomerName = cst.CustomerName;
                saveAll(customers);
            }
            private void saveAll(List<Customer> customers)
            {
                File.WriteAllText(fileName," ");
                foreach (var customer in customers)
                {
                    var line = customer.ToString();
                    ZipFile.AppendAllText(fileName, line);

                }
            }
        }
    }
}