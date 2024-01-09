using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SecondPart
    {

        public SecondPart(int[,] myArray) 
        {
            matrix = new int[myArray.GetLength(0), myArray.GetLength(1)];
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                    matrix[i, j] = myArray[i, j];
            }
        }



        private readonly int[,] matrix;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public void GetSumInRows(int rows, int cols)
        {

            for (int i = 0; i < rows; i++)
            {
                bool hasNegative = false;
                int sumInRow = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                    }
                    sumInRow += matrix[i, j];
                }

                if (hasNegative)
                {
                    Console.WriteLine($"Сумма в строке {i}: {sumInRow}");
                }
            }
        }


        public void GetSedlPoints(int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                int minInRow = matrix[i, 0]; 
                int columnOfMin = 0; 
                for (int j = 1; j < cols; j++) 
                {
                    if (matrix[i, j] < minInRow) 
                    {
                        minInRow = matrix[i, j]; 
                        columnOfMin = j; 
                    }
                }

                bool isMaxInColumn = true; 

                for (int k = 0; k < rows; k++) 
                {
                    if (matrix[k, columnOfMin] > minInRow)
                    {
                        isMaxInColumn = false;
                        break;
                    }
                }

                if (isMaxInColumn) 
                {
                    Console.WriteLine("Седловая точка: [{0}, {1}]", i, columnOfMin);
                }
            }

        }
    }
}

