using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintable printer = PrinterCreator.create(PrinterType.CONSOLE);

            printer.print("Input count of elements in vector:");
            int n = UserInput.inputInt();

            double[] doubleArray = new double[n];

            for (int i = 0; i < n; i++)
            {
                printer.print("Input element №" + i);
                doubleArray[i] = UserInput.inputDouble();
            }

            Vector vector = new Vector(doubleArray);
            double sumOfNegative = Calculator.sumOfNegativeElem(vector);
            double prodOfElem = Calculator.prodOfElemBetweenMinAndMax(vector);
            int indexMax = Calculator.indexOfMaxElem(vector);
            int indexMin = Calculator.indexOfMinElem(vector);

            printer.print("sum of negative elements = " + sumOfNegative);
            printer.print("product of elements between min and max = " + prodOfElem);
            printer.print("max index = " + indexMax);
            printer.print("min index = " + indexMin);

            Console.ReadKey();
        }
    }
    public class Vector
    {
        private double[] elements;

        public Vector(double[] elements)
        {
            this.elements = elements;
        }

        public override bool Equals(object obj)

        {
            var vector = obj as Vector;
            return vector != null &&
                   EqualityComparer<double[]>.Default.Equals(elements, vector.elements);
        }

        public double[] getElements()
        {
            return elements;
        }

        public override int GetHashCode()
        {
            return 272633004 + EqualityComparer<double[]>.Default.GetHashCode(elements);
        }

        public void setElements(double[] elements)
        {
            if (elements != null)
            {
                this.elements = elements;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Calculator
    {
        public static double sumOfNegativeElem(Vector vector)
        {
            double sum = 0.0;

            if (vector == null)
            {
                return sum;
            }

            double[] doubleArray = vector.getElements();

            if (doubleArray == null)
            {
                return sum;
            }

            foreach (double d in doubleArray)
            {
                if (d < 0)
                {
                    sum += d;
                }
            }
            return sum;
        }

        public static double prodOfElemBetweenMinAndMax(Vector vector)
        {
            double prodOfElem = 1;

            if (vector == null)
            {
                return prodOfElem;
            }

            double[] doubleArray = vector.getElements();

            if (doubleArray == null)
            {
                return prodOfElem;
            }

            int indexMax = indexOfMaxElem(vector);
            int indexMin = indexOfMinElem(vector);

            if (indexMax == -1 || indexMin == -1)
            {
                return prodOfElem;
            }

            if (indexMax > indexMin)
            {
                for (int i = indexMin + 1; i < indexMax; i++)
                {
                    prodOfElem *= doubleArray[i];
                }

            }
            else if (indexMax < indexMin)
            {
                for (int i = indexMax + 1; i < indexMin; i++)
                {
                    prodOfElem *= doubleArray[i];
                }

            }
            else
            {
                prodOfElem = doubleArray[indexMax];
            }

            return prodOfElem;
        }

        public static int indexOfMaxElem(Vector vector)
        {
            int indexMax = -1;

            if (vector == null)
            {
                return indexMax;
            }

            double[] doubleArray = vector.getElements();

            if (doubleArray == null || doubleArray.Length < 1)
            {
                return indexMax;
            }

            double max = doubleArray[0];
            indexMax = 0;

            for (int i = 0; i < doubleArray.Length; i++)
            {
                if (doubleArray[i] > max)
                {
                    max = doubleArray[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }

        public static int indexOfMinElem(Vector vector)
        {
            int indexMin = -1;

            if (vector == null)
            {
                return indexMin;
            }

            double[] doubleArray = vector.getElements();

            if (doubleArray == null || doubleArray.Length < 1)
            {
                return indexMin;
            }

            double min = doubleArray[0];
            indexMin = 0;

            for (int i = 0; i < doubleArray.Length; i++)
            {
                if (doubleArray[i] < min)
                {
                    min = doubleArray[i];
                    indexMin = i;
                }
            }
            return indexMin;
        }
    }
    public class UserInput
    {
        public static double inputDouble()
        {
            return double.Parse(Console.ReadLine());
        }

        public static int inputInt()
        {
            return int.Parse(Console.ReadLine());
        }
    }
    public class PrinterCreator
    {
        public static IPrintable create(PrinterType printerType)
        {
            IPrintable printer = null;

            switch (printerType)
            {
                case PrinterType.CONSOLE:
                    {
                        printer = new ConsolePrint();
                        break;
                    }
            }

            return printer;
        }
    }
    public interface IPrintable
    {
        void print(Object o);
    }
    public enum PrinterType
    {
        CONSOLE
    }
    public class ConsolePrint : IPrintable
    {

        public void print(Object o)
        {
            if (o == null)
            {
                return;
            }
            Console.WriteLine(o);
        }
    }
}

