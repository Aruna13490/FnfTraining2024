using FrameworkExamples.Utils;
//using MathComponentLib;
using sampleDllLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Dlls are referenced into the EXE projects. DLLs cannot run by themselves
namespace FrameworkExamples
{
    internal class Ex11UsingDll
    {
        static void Main(string[] args)
        {
            // simpleExample();
            //usingEmployeeComponent();
            //usingEmployeeReading();
        }

        //    private static void usingEmployeeReading()
        //    {
        //        var empComponent = EmployeeFactory.CreateComponent(" ");
        //        var emp = empComponent.FindEmployee("Phaniraj");
        //        if (emp != null)
        //        {
        //            Console.WriteLine($"{emp.Name} from {emp.Address}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Employee not found");
        //        }
        //    }

        //    private static void usingEmployeeComponent()
        //    {
        //        AppSettings.Initialize();
        //        var dirName = AppSettings.Configuration["FileOptions:EmpLocationDir"];
        //        var empComponent = EmployeeFactory.CreateComponent(dirName);
        //        empComponent.AddNewEmployee(124, "Rajesh", "Mysore");
        //    }

        //    private static void simpleExample()
        //    {
        //        //MathOperation math = new MathOperation();
        //        //var res = math.AddFunc(123, 23);
        //        //Console.WriteLine(res);
        //    }
        //}
    }
}
