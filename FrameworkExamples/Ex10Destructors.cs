using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Destructors are sp functions that are cretaed to be called when the object is destroyed.Opposite of Constructors,Destructores are used to release any memory that is allocated expliciyt for ur object.
 * Destructors in these programming languages  have liottle or o scope.
 *it will be called by the .NET CLr implicitly. whenever the clr feels tahat therer is not enough memory for the new objects creation,then the clr will call a component called GARBAGE COLLECTOR(GC).
 *GC will free all the objects that r not in scope making space for the new objects.
 *
 */
namespace FrameworkExamples
{
    class SimpleClass : IDisposable
    {
        public int Value { get; set; }

        public SimpleClass(int value)
        {
            this.Value = value;
            Console.WriteLine("The class is created with value:{0}", value);
        }
        //The destructors will have atild followed by the classaname it will not have access specifiers no argument with it.u cannont call them internally it is called.
        ~SimpleClass()
        {
            Console.WriteLine($"the simple class destroyed with value{this.Value}");
        }
        public void Dispose()
        {
            Console.WriteLine($"The SimpleClass is destroyed using destructor method with the value{this.Value}");
            GC.SuppressFinalize( this );//GC will not call destructor for the current object.
        }
        internal class Ex10Destructors
        {
            static void CreateAndDestroyObjects()
            {
                for (int i = 0; i < 10; i++)
                {
                    //SimpleClass cls = new SimpleClass(i);
                    ////GC.Collect();//Forces the GC to come and delete the unused objects.
                    ////GC.WaitForPendingFinalizers();
                    //cls.Dispose();

                    using (SimpleClass cls = new SimpleClass(i))
                    {
                        //better way of creating objects in C#. If the objecst class implements IDisposable its dispose method will be called implicitly when the objects goes out of the scope.
                    }
                }
            }
            static void Main(string[] args)
            {
                CreateAndDestroyObjects();
            }
        }
    }
}

