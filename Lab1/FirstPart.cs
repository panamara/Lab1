
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class FirstPart
    {
        

        public FirstPart(double[] myArray) 
        {
            array = new double[myArray.Length];
            for (int i = 0; i < array.Length; i++)
                array[i] = myArray[i];
        }



        private readonly double[] array;

        public FirstPart(int length) 
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new double[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-1, 3) + random.NextDouble();
            }
        }

        public IReadOnlyList<double> Vector
        {
            get
            {
                return array;
            }
        }


        public double GetMinimumElement() 
        {
            double minimum = 1000000;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minimum)
                    minimum = array[i];
            }


            return minimum;
        }


        public double GetSumBetweenPositiveElements()
        {
            int first = -1, last = -1; 
            double sum = 0; 
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    first = i; 
                    break;
                }
            }

            if (first == -1) 
            {
                Console.WriteLine("We have no elements > 0");
                return sum;
            }


            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] > 0) 
                {
                    last = i;
                    break;
                }
            }
            if (first == last)
            {
                Console.WriteLine("\nWe have only one >0 element");
                return sum;
            }


            for (int i = first + 1; i < last; i++) 
            {
                sum += array[i];
            }

            return sum;
        }

        public IEnumerable<double> SortByZeros()
        {

            for (int i = 0, j = 0; i < array.Length; i++)
                if (array[i] <= 1)
                    if (array[i] > -1) 
                    {
                        double temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        j++;
                    }
            return array;
        }
    }
}




