using System;
using System.Data.SqlClient;

namespace MatrixOperator
{

    class Program
    {
        static void Main()
        {
         
           


            //1st dimmensions
            Console.WriteLine("Enter the dimensions of the first matrix (n x m):");
            Console.Write("Rows: ");
            int rows1 = Validation("Rows");

            Console.Write("Columns: ");
            int columns1 = Validation("Columns");
            //2nd dimensions
            Console.WriteLine("Enter the dimensions of the second matrix (n x m):");
            Console.Write("Rows: ");
            int rows2 = Validation("Rows");
            Console.Write("Columns: ");
            int columns2 = Validation("Columns");


            Matrix firstMatrix = new Matrix(rows1, columns1);

            // 1st Matrix Values
            Console.WriteLine("Enter values for the first matrix:");
            firstMatrix.MatrixFieldsFiller();



            Matrix secondMatrix = new Matrix(rows2, columns2);

            // 2nd Matrix Values
            Console.WriteLine("Enter values for the second matrix:");
            secondMatrix.MatrixFieldsFiller();


            //Display
            Console.WriteLine("\nMatrix 1:");
            firstMatrix.ShowInConsole();
            Console.WriteLine("\nMatrix 2:");
            secondMatrix.ShowInConsole();
            Matrix sum = Matrix.Addition(firstMatrix, secondMatrix);
            Matrix substraction = Matrix.Substraction(firstMatrix, secondMatrix);
            Matrix multiplication = Matrix.Multiplication(firstMatrix, secondMatrix);
            Matrix firstTransposed = firstMatrix.Transpose();
            Matrix secondTransposed = secondMatrix.Transpose();
            Console.WriteLine("\nMatrix output for sum");
            sum.ShowInConsole();
            Console.WriteLine("\nMatrix output for substraction");
            substraction.ShowInConsole();
            Console.WriteLine("\nMatrix output for multiplication");
            multiplication.ShowInConsole();
            Console.WriteLine("\n1st Matrix transposed:");
            firstMatrix.ShowInConsole();
            Console.WriteLine("\n2nd Matrix transposed:");
            secondMatrix.ShowInConsole();
            Console.WriteLine("\nDet of 1st Matrix: " + firstMatrix.Det());
            Console.WriteLine("\nDet of 2nd Matrix: " + secondMatrix.Det());

            Console.ReadLine();
        }
        static int Validation(string matrixDimension)
        {
            int dimension;
            bool isValid = false;
            do
            {
                // Console.WriteLine($"Please enter the number of {matrixDimension}");
                dimension = Convert.ToInt32(Console.ReadLine());
                if (dimension > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"{matrixDimension} cannot be less than 1! Enter correct value:");
                    Console.WriteLine($"{matrixDimension}:");
                    isValid = false;
                }
            }
            while (!isValid);


            return dimension;
        }

    }

}
