using FrameworksExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworksExample
{
    internal class CustomerFileIO
    {
        static void WriteCustomerInfo(Customer cst)
        {
            try
            {
                var fileName = FileIO.Configuration["FileOptions:FilePath"];
                File.AppendAllText(fileName, cst.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            FileIO.Initialize();
            Customer cst = new Customer
            {
                CustomerAddress = "Bangalore",
                CustomerID = 1,
                CustomerName = "Phaniraj"
            };
            cst.AddToCart(new Product
            {
                Id = 1,
                Name = "Nokia Phone",
                Price = 1300,
                Quantity = 1
            });
            cst.AddToCart(new Product
            {
                Id = 2,
                Name = "IPhone 15 Pro",
                Price = 111300,
                Quantity = 1
            });
            cst.AddToCart(new Product
            {
                Id = 3,
                Name = "Biscuits Pack",
                Price = 13,
                Quantity = 4
            });

            WriteCustomerInfo(cst);
        }
    }
}