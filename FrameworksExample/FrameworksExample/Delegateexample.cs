
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace FrameworkExamples
{
    /*Delegates:
     * Delegates are like function pointers of C/C++
     * They are reference types that represent functions instead of data types. 
     * This helps in passing functions are args. Imagine, they are like callback functions that are used in programming languages like Python, JavaScript.
     * If a delegate instance is pointing to multiple methods during the invocation, then the object is a multicast delegate. So, with one call, it will internally invoke all the method that are mapped to it. 
     */
    delegate double Operation(double v1, double v2);

    delegate void LogMessageDelegate(string message);
    internal class Ex03DelegatesExample
    {
        //Purpose: To replace traditional math operation methods with function pointers where we can pass the function that we want to call as an arg instead of predefining them. 
        static void PerformMathOperation(double v1, double v2, Operation method)
        {
            var result = method(v1, v2);
            Console.WriteLine("The Result: " + result);
        }

        static void LogInfo(LogMessageDelegate message)
        {
            message("Error Occured while reading the records");
        }

        static void LogToConsole(string message)
        {
            string time = DateTime.Now.ToString("HH-mm-ss");
            var msg = $"[{time}]: {message}";
            Console.WriteLine(msg);
        }
        static void LogToFile(string message)
        {
            string DirName = @"C:\ProgramData\TrainingLogs";
            if (!Directory.Exists(DirName))
                Directory.CreateDirectory(DirName);
            string time = DateTime.Now.ToString("HH-mm-ss");
            var msg = $"[{time}]: {message}\n";
            string date = DateTime.Now.ToShortDateString();
            var fullPath = Path.Combine(DirName, $"{date}.txt");
            File.AppendAllText(fullPath, msg);
        }

        [SupportedOSPlatform("Windows")]
        static void LogToEventViewer(string message)
        {
            EventLog log = new EventLog("TrainingLogs", Environment.MachineName, Process.GetCurrentProcess().ProcessName);
            log.WriteEntry(message, EventLogEntryType.Information);
        }
        static void MulticastDelegateExample()
        {
            LogMessageDelegate logger = new LogMessageDelegate(LogToFile);
            logger += new LogMessageDelegate(LogToEventViewer);
            logger += new LogMessageDelegate(LogToConsole);
            LogInfo(logger);//Calling this only once...

        }
        static void Main(string[] args)
        {
            //BasicFunctionality();
            MulticastDelegateExample();
        }

        private static void BasicFunctionality()
        {
            Operation op = new Operation(addFunc);//v1.0 syntax..
            PerformMathOperation(13, 12, op);//Passing the delegate object as argument..

            PerformMathOperation(31, 12, addFunc);//In v1.1, we could pass the function directly without creating delegate instance.

            //todo: try to call Performmathoperation again for multiply functionality..

            //Anonymous methods that was introduced in C# 2.0  
            PerformMathOperation(13, 12, delegate (double v1, double v2)
            {
                return v1 * v2;
            });//delegate keyword is used for both declaring the delegate as well as defining methods for the delegate instance. 

            //C# 4.0 introduced Lamdba Expressions...
            PerformMathOperation(13, 12, (v1, v2) => v1 / v2);

            PerformMathOperation(5000, 6.5, (p, r) =>
            {
                var interest = p * (r / 100) * 0.25;
                return interest;
            });
        }

        //function created for using it in the delegate instance. 
        static double addFunc(double v1, double v2)
        {
            return v1 + v2;
        }

    }
}
