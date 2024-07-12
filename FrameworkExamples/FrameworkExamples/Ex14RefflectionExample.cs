using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace FrameworkExamples
{
    internal class Ex14RefflectionExample
    {
        const string dllName = "C:\\New folder\\FrameworkExamples\\MathComponentLib\\bin\\Debug\\net8.0\\MathComponentLib.dll";
        static void Main(string[] args)
        {
            object instance = null;//represents instamce of the class
            object[] parameters = null;//parameters for the function

            //    if (!File.Exists(dllName))
            //    {
            //        Console.WriteLine("Dll not found to load!!");
            //        return;
            //    }

            var assembly = Assembly.LoadFile(dllName);

           // var assembly = Assembly.GetExecutingAssembly();//to know the dlls present in the project

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                //Console.WriteLine("The list of methods for this class are as follows");
                //foreach(var method in type.GetMethods())
                //{
                //    Console.WriteLine(method.Name);
                //    Console.WriteLine(("Here are the parameters for this method");
                //    foreach(var parameter in method.GetParameters())
                //    {
                //        Console.WriteLine($"{parameter.Name}of the type {parameter.ParameterType.FullName}");

                        
                //    }
                //    Console.WriteLine("The type of this method is"+method.ReturnType.FullName);
                //}
            }
            Console.WriteLine("Enter the type that u want to create the instance");
            string typeName=Console.ReadLine();
            Type selectedType = assembly.GetType(typeName);
            if(selectedType==null)
            {
                Console.WriteLine("invalid type selected");
                return;
            }
            Console.WriteLine("Enter the mehtod name that u want to invoke from the list below:");
            MethodInfo[] methods=selectedType.GetMethods();
            foreach ( MethodInfo method in methods)
            {
            
                    Console.WriteLine(method.Name);
               
            }
            var methodName=Console.ReadLine();
            var selectedMethod = selectedType.GetMethod(methodName);
            if(selectedMethod==null)
            {
                Console.WriteLine("invalid method name");
                return;
            }
            parameters=new object[selectedMethod.GetParameters().Length];
            int index = 0;
            foreach(var parameter in selectedMethod.GetParameters())
            {
                Console.WriteLine($"Please enter the value for{parameter.Name} whose data type is {parameter.ParameterType.Name}");
                string input=Console.ReadLine() ;
                parameters[index] = Convert.ChangeType(input, parameter.ParameterType);

                index++;
            }
            Console.WriteLine("Now all the parameters are set lets invoke the method");
            instance = Activator.CreateInstance(selectedType);
            var result=selectedMethod.Invoke(instance, parameters);
            Console.WriteLine($"The reult of the {selectedMethod.Name} is {result}");
        }
    }
}
