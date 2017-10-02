using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root_of_the_equation
{
   
    class Program
    {
        static int count1 = 0;
        static int count2 = 0;
        public static double Function1(double x)
        {
            //Console.WriteLine(count1++ + " первое");
            return x*x -25*x +100;
        }

        public static double Function2(double x)
        {
            //Console.WriteLine(count2++ + " второе");
            return (5 * Math.Sin(x) + Math.Sin(6*x)*8*x*Math.Sin(5*x)-1);
        }

        static void Main(string[] args)
        {
            List<Function> abc = new List<Function>();
            List<double> a = new List<double>();
            List<double> b = new List<double>();
            List<double> sigma = new List<double>();
            abc.Add(Function1);
            abc.Add(Function2);

            a.Add(10);
            a.Add(-1);

            b.Add(30);
            b.Add(1);

            sigma.Add(0.0001);
            sigma.Add(0.0001);
                    
            RootFinderClass obj1 = new RootFinderClass(2);
            obj1.SetRootFunction(abc, a , b , sigma);
            obj1.FindRoots();


            //Console.WriteLine("корень 1: " + obj1.Roots[0]);
            //Console.WriteLine("корень 2: " + obj1.Roots[1]);
            Console.ReadLine();
        }
    }
}
