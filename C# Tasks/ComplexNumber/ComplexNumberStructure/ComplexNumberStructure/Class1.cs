using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumberStructure
{
    public struct ComplexNumber
    {
        double real, imaginary;

        ComplexNumber(double A, double B) {
            real = A;
            imaginary = B;
        }

        ComplexNumber(ComplexNumber obj)
        {
            real = obj.real;
            imaginary = obj.imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.real + b.real, a.imaginary + b.imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.real - b.real, a.imaginary - b.imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber((a.real * b.real - a.imaginary * b.imaginary),
                (a.imaginary * b.real - a.real * b.imaginary));
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(((a.real * b.real + a.imaginary * b.imaginary) / (a.imaginary * a.imaginary + b.imaginary * b.imaginary)),
                ((a.imaginary * b.real + a.real * b.imaginary) / (a.imaginary * a.imaginary + b.imaginary * b.imaginary)));
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return ((a.real == b.real) && (a.imaginary == b.imaginary));
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !((a.real == b.real) && (a.imaginary == b.imaginary));
        }

        public static ComplexNumber Sum(ComplexNumber[] NumbersToSum) {
            ComplexNumber NewComplex = new ComplexNumber(0,0);
            foreach(ComplexNumber obj in NumbersToSum)
            {
                NewComplex = NewComplex + obj;
            }
            return NewComplex;
        }
        public ComplexNumber Summarize(ComplexNumber[] NumbersToSum)
        {
            ComplexNumber NewComplex = new ComplexNumber(real, imaginary);
            foreach (ComplexNumber obj in NumbersToSum)
            {
                NewComplex = NewComplex + obj;
            }
            return NewComplex;
        }
        public static ComplexNumber Sum(ComplexNumber a, ComplexNumber b)
        {
            return (a + b);
        }
        public ComplexNumber Sum(double a, double b)
        {
            return new ComplexNumber(real + a, imaginary + b);
        }

        public static ComplexNumber Sub(ComplexNumber[] NumbersToSum)
        {
            ComplexNumber NewComplex = new ComplexNumber(0, 0);
            foreach (ComplexNumber obj in NumbersToSum)
            {
                NewComplex = NewComplex - obj;
            }
            return NewComplex;
        }
        public ComplexNumber Subtraction(ComplexNumber[] NumbersToSum)
        {
            ComplexNumber NewComplex = new ComplexNumber(real, imaginary);
            foreach (ComplexNumber obj in NumbersToSum)
            {
                NewComplex = NewComplex - obj;
            }
            return NewComplex;
        }
        public static ComplexNumber Sub(ComplexNumber a , ComplexNumber b)
        {
            return (a - b);
        }
        public ComplexNumber Sub(double a, double b)
        {
            return new ComplexNumber(real - a, imaginary - b);
        }

        public static ComplexNumber Multiply(ComplexNumber a, ComplexNumber b)
        {
            return (a * b);
        }

        public static ComplexNumber division(ComplexNumber a, ComplexNumber b)
        {
            return (a / b);
        }

        public static explicit operator double(ComplexNumber obj)
        {
            return Math.Sqrt(obj.real * obj.real + obj.imaginary * obj.imaginary);
        }

        public override string ToString()
        {
            return "real: " + real + " + " + "imaginary: " + imaginary;
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                return this.Equals((ComplexNumber)obj);
            }
            return false;
        }

        public bool Equals(ComplexNumber CompObj)
        {
            return (real == CompObj.real) && (imaginary == CompObj.imaginary);
        }

        public override int GetHashCode()
        {
            return real.GetHashCode() * 397 ^ imaginary.GetHashCode();
        }


    }

    public class Class1
    {
    }
}
