using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_with_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> abc = new MyCollection<int>();
            abc.Cleared += Function;
            abc.Added += Function;
            abc.Removed += Function;
            abc.Add(2);
            abc.Add(3);
            abc.Add(4);
            abc.Add(5);
            abc.Add(6);
            abc.Add(7);
            abc.Add(8);
            abc.Add(9);
            abc.Add(10);

            int[] objArray = new int[10];

            abc.CopyTo(objArray, 0);

            foreach (int objInt in abc)
            {
                //Console.WriteLine(objInt);
            }

            foreach (int objInt in objArray)
            {
                Console.WriteLine(objInt);
            }
            Console.WriteLine(abc.Contains(4));
            Console.WriteLine(abc.Contains(11));
        }

        public static void Function(string message)
        {
            Console.WriteLine(message);
        }
    }
}

