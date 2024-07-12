using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExamples
{
    class EmployeeData
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary{get;set; }
        public static EmployeeData operator+(EmployeeData lhs,int rhs)
        {
            lhs.EmpSalary +=rhs;
            return lhs;
        }
        public static EmployeeData operator -(EmployeeData lhs, int rhs)
        {
            lhs.EmpSalary -= rhs;
            return lhs;
        }
        //Assignment operator cannot be overloaded.
        //public static EmployeeData operator =(EmployeeData lhs,EmployeeData rhs)
        //{
        //    lhs.EmpId= rhs.EmpId;
        //    lhs.EmpName= rhs.EmpName;
        //}

        public static explicit operator EmployeeData(Cst rhs)
        {
            var emp = new EmployeeData { EmpId = rhs.CstId, EmpName = rhs.CstName, EmpSalary = rhs.CstBaseValue };
            return emp;
        }

        //Implicit casting not recommended
        //public static explicit operator EmployeeData(Cst rhs)
        //{
        //    var emp = new EmployeeData { EmpId = rhs.CstId, EmpName = rhs.CstName, EmpSalary = rhs.CstBaseValue };
        //    return emp;
        //}

    }
    class Cst
    {
        public int CstId { get; set; }
        public string CstName { get; set; }
        public int CstBaseValue { get; set; }
    }

    internal class Ex13OperatorOverloading
    {
        static void Main(string[] args)
        {
            EmployeeData emp = new EmployeeData { EmpId = 111, EmpName = "Aruna", EmpSalary = 5000 };
            emp = emp + 7000;
            Console.WriteLine("The current salary is:{0}",emp.EmpSalary);
            emp -= 2000;
            Console.WriteLine("The current salary is:{0}", emp.EmpSalary);

            EmployeeData emp2 = (EmployeeData) new Cst { CstId = 123, CstName = "Rahul", CstBaseValue = 9000 };
            Console.WriteLine("The Name:" + emp2.EmpName);
            //EmployeeData emp2=new Cst{ CstId=123,CstName="Rahul",CstBaseValue=9000};
            //For implicit converting no need to write employeeData while converting.
        }
    }
}
