﻿using FrameworksExample.Data;
using FrameworksExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworksExample
{
    internal class CsvFileIO
    {
        static void Main(string[] args)
        {
            testForAddingRecord();
            testForReadingRecords();
        }

        private static void testForReadingRecords()
        {
            ICustomerRepo repo = new CsvCustomerRepo();
            var records=repo.GetAllCustomers();
            foreach(var record in records)
            {
                Console.WriteLine($"Mr/Mrs.{record.CustomerName} purchased products with us for an amount of Rs.{record.BillAmount} on {record.BillDate}and the delivery was made to {record.CustomerAddress}");
            }
        }

        private static void testForAddingRecord()
        {
            ICustomerRepo repo = new CsvCustomerRepo();
            var cst = new CustomerFileIO { CustomerID = 111, CustomerAddress = "Bangalore", CustomerName = "Aruna" };
            cst.AddToCart(new Product { Id = 11, Name = "toor dall", Price = 200, Quantity = 2 });
            repo.AddNewCustomer(cst);
        }
    }
}
