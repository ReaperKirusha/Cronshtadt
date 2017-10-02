using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
namespace Root_of_the_equation
{
    public delegate double Function(double X);
    public delegate double RootFinderDelegate(double a, double b, double sigma, Function RootFunction);
    public class RootFinderClass
    {        

        public List<Function> ArrayRootFunction;
        public List<double> Roots;
        public List<double> a, b, sigma;

        
        public RootFinderClass(int Number)
        {
            ArrayRootFunction = new List<Function>();
             Roots = new List<double>(new double[3]);
            a = new List<double>();
            b = new List<double>();
            sigma = new List<double>();
        }

        public void SetRootFunction(List<Function> FuncArray, List<double> aArray, List<double> bArray, List<double> sigmaArray)
        {
            foreach (Function obj in FuncArray)
            {
                ArrayRootFunction.Add(obj);
            }
            foreach (double obj in sigmaArray)
            {
                sigma.Add(obj);
            }
            foreach (double obj in bArray)
            {
                b.Add(obj);
            }
            foreach (double obj in aArray)
            {
                a.Add(obj);
            }
        }

        public double RootFinderFunction(double a, double b, double sigma, Function RootFunction)
        {
           // Console.WriteLine("Root Finder Function");

            double X, Value;
            double minus = 0, plus = 0;
            double abc = RootFunction(a);
            

            if (abc > 0)
            {
                plus = a;
                minus = b;
            }
            else
            {
                plus = b;
                minus = a;
            }

            while (Math.Abs(plus - minus) > sigma)
            {
                X = ((plus + minus) / 2);
                Value = RootFunction(X);
                
                if (Value == 0)
                {
                   return  Math.Round(X, 3);
                }

                if (Value > 0)
                {
                    plus = X;
                }
                else
                {
                    minus = X;
                }

            }
            //Console.WriteLine("Root Finder Function end");
            return Math.Round((double)((plus + minus) / 2), 3);

        }

        public void FindRoots()
        {
            RootFinderDelegate abc = RootFinderFunction;
            
            for (int i = 0; i < 2; i++)
            {
                abc.BeginInvoke(a[i], b[i], sigma[i], ArrayRootFunction[i], endCalculation, i);
            }
                     
        }

        public void endCalculation(IAsyncResult ar)
        {
            int number = (int)ar.AsyncState;
            //Console.WriteLine("end calculation " + number);
            RootFinderDelegate abc = ((RootFinderDelegate)((AsyncResult)ar).AsyncDelegate);
            double root = abc.EndInvoke(ar);
            Roots[number] = root;
            lock (this)
            {
                Console.WriteLine("Корень функции под номером: " + number + ", это: " + root );
            }
        }
    }
}
