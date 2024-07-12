using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleDimensionalArray();
        }
        private static void SingleDimensionalArray()
        {
            int[] array = new int[5];
            
            for (int i=0;i<array.Length;i++)
            {
                Console.WriteLine("enter the value for posiotion",i);
                 array[i] = int.Parse(Console.ReadLine());

            }
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
