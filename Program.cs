using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Matrix Interface");

        // Get dimensions for the first matrix
        int rows1 = Validation("rows");
        int columns1 = Validation("columns");

        // Create and fill the first matrix
        Matrix matrix1 = new Matrix(rows1, columns1);
        Console.WriteLine("Fill the first matrix:");
        matrix1.MatrixFieldsFiller();

        // Display the first matrix
        Console.WriteLine("First Matrix:");
        matrix1.ShowInConsole();

        // Choose operation
        Console.WriteLine("Choose operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Transpose");
        Console.WriteLine("5. Determinant");
        Console.WriteLine("Enter the corresponding number for the operation:");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                // Get dimensions for the second matrix
                int rows2 = Validation("rows");
                int columns2 = Validation("columns");

                // Create and fill the second matrix
                Matrix matrix2 = new Matrix(rows2, columns2);
                Console.WriteLine("Fill the second matrix:");
                matrix2.MatrixFieldsFiller();

                // Display the second matrix
                Console.WriteLine("Second Matrix:");
                matrix2.ShowInConsole();

                // Perform addition
                Matrix additionResult = Matrix.Addition(matrix1, matrix2);

                // Display result
                Console.WriteLine("Result of Addition:");
                additionResult.ShowInConsole();
                break;

            case 2:
                // Get dimensions for the second matrix
                int rowsSub = Validation("rows");
                int columnsSub = Validation("columns");

                // Create and fill the second matrix
                Matrix matrixSub = new Matrix(rowsSub, columnsSub);
                Console.WriteLine("Fill the second matrix:");
                matrixSub.MatrixFieldsFiller();

                // Display the second matrix
                Console.WriteLine("Second Matrix:");
                matrixSub.ShowInConsole();

                // Perform subtraction
                Matrix subtractionResult = Matrix.Substraction(matrix1, matrixSub);

                // Display result
                Console.WriteLine("Result of Subtraction:");
                subtractionResult.ShowInConsole();
                break;

            case 3:
                // Get dimensions for the second matrix
                int rowsMul = Validation("rows");
                int columnsMul = Validation("columns");

                // Create and fill the second matrix
                Matrix matrixMul = new Matrix(rowsMul, columnsMul);
                Console.WriteLine("Fill the second matrix:");
                matrixMul.MatrixFieldsFiller();

                // Display the second matrix
                Console.WriteLine("Second Matrix:");
                matrixMul.ShowInConsole();

                // Perform multiplication
                Matrix multiplicationResult = Matrix.Multiplication(matrix1, matrixMul);

                // Display result
                Console.WriteLine("Result of Multiplication:");
                multiplicationResult.ShowInConsole();
                break;

            case 4:
                // Perform transpose
                Matrix transposeResult = matrix1.Transpose();

                // Display result
                Console.WriteLine("Result of Transpose:");
                transposeResult.ShowInConsole();
                break;

            case 5:
                // Perform determinant
                int determinant = matrix1.Det();

                // Display result
                Console.WriteLine($"Determinant: {determinant}");
                break;

            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                break;
        }

        // Wait for a key press before closing the console window
        Console.ReadKey();
    }

    static int Validation(string matrixDimension)
    {
        int dimension;
        bool isValid = false;

        do
        {
            Console.WriteLine($"Please enter the number of {matrixDimension}");
            dimension = Convert.ToInt32(Console.ReadLine());

            if (dimension > 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine($"{matrixDimension} cannot be less than 1! Enter correct value:");
                isValid = false;
            }
        }
        while (!isValid);

        return dimension;
    }
}

