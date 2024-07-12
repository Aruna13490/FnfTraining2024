//using ConsoleApp1.Entities;
using FrameworkExamples.Utils;
//using FrameworkExamples.Entities;


namespace FrameworkExamples.Data
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
            fileName = AppSettings.Configuration["FileOptions:CsvFilePath"];
        }
        public void AddNewCustomer(Customer cst)
        {
            //Using the file class, we will append the file with the contents of the customer.
            if (fileName == null)
            {
                throw new Exception("FilePath is not set, refer configuration");
            }
            File.AppendAllText(fileName, cst.ToString());
        }

        public void DeleteCustomer(int cstId)
        {
            //Get all the data from the file
            var records = GetAllCustomers();
            //find the required record
            var foundRec = records.Find(r => r.CustomerID == cstId);
            //handle if not found
            if (foundRec == null)
            {
                throw new Exception("No record found to delete");
            }
            //remove the found record
            records.Remove(foundRec);
            //save it back to the file as new set of records
            saveAll(records);
        }

        public List<Customer> GetAllCustomers()
        {
            //create a temporary list
            List<Customer> customers = new List<Customer>();
            //check if the file is set from the confog file or not...
            if (fileName == null)
            {
                throw new Exception("Filepath is not set to read the data. Could not read the config file");
            }
            //Get all the lines from the file
            var lines = File.ReadAllLines(fileName);
            //Iterate thru each line
            foreach (var line in lines)
            {
                //check if the line is empty or null
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        return customers;
                    }
                    //Split the line by comma
                    var words = line.Split(',');//split the line based on comma...
                    //Create customer object for eacxh line
                    Customer cst = new Customer();
                    //Fill the object with the data
                    cst.BillDate = DateTime.Parse(words[0]);
                    cst.CustomerID = int.Parse(words[1]);
                    cst.CustomerName = words[2];
                    cst.CustomerAddress = words[3];
                    cst.BillAmount = int.Parse(words[4]);
                    //Add the customer object to the temporary list
                    customers.Add(cst);
                }
                //finally return the temporary list
            }
            return customers;

        }

        public void UpdateCustomer(Customer cst)
        {
            //get all the values
            var customers = GetAllCustomers();
            //find the matching record in the file
            var found = customers.Find(c => c.CustomerID == cst.CustomerID);
            //set the new values to the record
            found.CustomerAddress = cst.CustomerAddress;
            found.CustomerName = cst.CustomerName;
            found.BillAmount = cst.BillAmount;
            found.BillDate = cst.BillDate;
            //update the file...
            saveAll(customers);
        }

        private void saveAll(List<Customer> customers)
        {
            File.WriteAllText(fileName, "");//WIll erase the data, not the file.
            foreach (var customer in customers)
            {
                var line = customer.ToString();
                File.AppendAllText(fileName, line);
            }
        }
    }
}
