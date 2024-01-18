// Plik: Macierz.cs

using System;
using System.Globalization;

public class Matrix
{
    private int[,] data;

    public Matrix(int rows, int columns)
    {
        data = new int[rows, columns];
    }

    public void SetValue(int i, int j, int value)
    {
        if (i >= 0 && i < data.GetLength(0) && j >= 0 && j < data.GetLength(1))
        {
            data[i, j] = value;
        }

        else
        {
            Console.WriteLine("Error: Invalid matrix dimensions.");
        }
    }

    public int GetValue(int i, int j)
    {
        if (i >= 0 && i < data.GetLength(0) && j >= 0 && j < data.GetLength(1))
        {
            return data[i, j];
        }
        else
        {
            Console.WriteLine("Error: Invalid matrix dimensions.");
            return -1;
        }
    }

    public void ShowInConsole()
    {

        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    public void MatrixFieldsFiller()
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write($"Enter value for [{i + 1},{j + 1}]: ");
                int value = Convert.ToInt32(Console.ReadLine());
                SetValue(i, j, value);
            }
        }
    }
    public static Matrix Addition(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.data.GetLength(0) != matrix2.data.GetLength(0) || matrix1.data.GetLength(1) != matrix2.data.GetLength(1))
        {
            Console.WriteLine("Error: Unable to Sum, dimensions are not the same");
            return new Matrix(0, 0); 
        }
        Matrix result = new Matrix(matrix1.data.GetLength(0), matrix1.data.GetLength(1));

        for (int i = 0; i < matrix1.data.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.data.GetLength(1); j++)
            {
                int sum = matrix1.data[i, j] + matrix2.data[i, j];
                result.SetValue(i, j, sum);
            }

        }
        return result;

    }
    public static Matrix Substraction(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.data.GetLength(0) != matrix2.data.GetLength(0) || matrix1.data.GetLength(1) != matrix2.data.GetLength(1))
        {
            Console.WriteLine("Error: Unable to Substract, dimensions are not the same");
            return new Matrix(0, 0);
        }

        Matrix result = new Matrix(matrix1.data.GetLength(0), matrix1.data.GetLength(1));

        for (int i = 0; i < matrix1.data.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.data.GetLength(1); j++)
            {
                int sum = matrix1.data[i, j] - matrix2.data[i, j];
                result.SetValue(i, j, sum);
            }

        }
        return result;

    }
    public static Matrix Multiplication(Matrix matrix1, Matrix matrix2)
    {
        {
            if (matrix1.data.GetLength(1) != matrix2.data.GetLength(0))
            {
                Console.WriteLine("Error: Inner matrix dimensions must be the same for multiplication.");
                return new Matrix(0, 0);
            }

            Matrix result = new Matrix(matrix1.data.GetLength(0), matrix2.data.GetLength(1));

            for (int i = 0; i < matrix1.data.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.data.GetLength(1); j++)
                {
                    int multiplication = 0;

                    for (int k = 0; k < matrix1.data.GetLength(1); k++)
                    {
                        multiplication += matrix1.GetValue(i, k) * matrix2.GetValue(k, j);
                    }

                    result.SetValue(i, j, multiplication);
                }
            }

            return result;
        }
    }
    public Matrix Transpose()
    {
        int newRows = data.GetLength(1);
        int newColumns = data.GetLength(0);

        Matrix transposedMatrix = new Matrix(newRows, newColumns);

        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                transposedMatrix.SetValue(j, i, data[i, j]);
            }
        }

        return transposedMatrix;
    }
    private int Det2x2()
    {
        return data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0];
    }
    private int Det3x3()
    {
        int determinant = 0;

        for (int i = 0; i < 3; i++)
        {
            determinant += data[0, i] * (data[1, (i + 1) % 3] * data[2, (i + 2) % 3] - data[1, (i + 2) % 3] * data[2, (i + 1) % 3]);
        }

        return determinant;
    }
    public int Det()
    {
        int rows = data.GetLength(0);
        int columns = data.GetLength(1);

        if (rows != columns)
        {
            Console.WriteLine("Error: Determinant can only be calculated for a square matrix.");
            return 0;
        }

        switch (rows)
        {
            case 1:
                return data[0, 0];

            case 2:
                return Det2x2();

            case 3:
                return Det3x3();

            default:
                Console.WriteLine("Error: Determinant calculation is supported only for matrix with following dimensions 1x1, 2x2, and 3x3.");
                return 0;
        }
    }
}