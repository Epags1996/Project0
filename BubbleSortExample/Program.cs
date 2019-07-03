using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 8, 4, 1, 10, 14 };
            int b;
            Console.WriteLine("We start with this set of numbers");
            foreach (int aa in a)
            {
                Console.WriteLine(aa + " ");
            }
            for (int c = 0; c <= a.Length - 2; c++)
            {
                for (int i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        b = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = b;
                    }
                }
            }
            Console.WriteLine("\n" + "We end with the set of numbers sorted from smallest to largest");
            foreach (int aa in a)
            {
                Console.WriteLine(aa + " ");
            }
            Console.ReadLine();

        }
    }
}
