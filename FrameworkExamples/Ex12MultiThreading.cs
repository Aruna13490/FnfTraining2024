using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/*
 * MultiThreading:
 * what is a process:A process is an instance of an executable.Each process has a private address space where all the required units of the programare loaded and executed in the order of the logic defined in the program.
 * Thread defines the path of the execution within the process.
 * Every process must have atleast one thread for the execution.If no threads are running,the process is killed(Terminate).
 * most of the apps can work well with a single thread with good consistency and durability.
 * however,if u want to perform 2 operations parallelly then we go for new thread.These threads are created to perform some task or job and will terminate after the task is completed.
 * Each thread in .NET is represented by a .NET class htread.u create an instnace of the class and pass a function to it as arg using a delegate called as ThreadStart.The function defines the functionality of the thread.It defines what the thread should do when it starts.
 * u can invoke functions asynchronously wihtout creating threads as threads as kernel objects that puts a lot of strain on the cpu.
 */
namespace FrameworkExamples
{

    internal class Ex12MultiThreading
    {
        
        static void NormalFunction()
        {
            Console.WriteLine("The normal function has begun");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Thread Beep #{i}");
                Console.Beep();
            }
            Console.WriteLine("The function has ended");
        }
        static void ParameterisedFunction(object obj)
        {
            //expected int to be passed
            int max = (int)obj;
            Console.WriteLine(
               "The normal function has begun");
            for (int i = 0; i < max; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Thread with argument Beep #{i}");
                Console.Beep();
            }
            Console.WriteLine("The function has ended");

        }
        //This operation is not allowed in console app for core dontnet.it is possible in .net framework.
        //static void AsyncFunction()
        //{
        //    Action action = () =>
        //    {
        //        NormalFunction();
        //    };
        //    action.BeginInvoke((asyncRes) =>
        //    {
        //        while(!asyncRes.IsCompleted)
        //        { 
        //            Console.WriteLine("please wait");
    
        //        Thread.Sleep(200);

        //        }
        //       action.EndInvoke(asyncRes);
        //    }, null);

        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Main has started to execute");
            // NormalFunction();
            //Invoke the NormalFunction as a separate Thread. so that the main can continue to do its tasks.

            //creatingThreads();
            //Thread th = new Thread(NormalFunction);

            //AsyncFunction();
            Thread th = new Thread(NormalFunction);
            Thread th2 = new Thread(new ParameterizedThreadStart(ParameterisedFunction));
            th.Start();
            th2.Start(5);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Main is doing its job");
            }
            Console.WriteLine("Main has ended the functionalities,time to close");
        }
    }
}
