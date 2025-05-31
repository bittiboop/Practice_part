namespace Practice_part;

class Matrix
{
    private int[,] matrix;
    
    public int Rows { get; private set; }
    public int Cols { get; private set; }
    
    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= Rows || j < 0 || j >= Cols)
                throw new IndexOutOfRangeException("Index out of range");
            return matrix[i, j];
        }
        set
        {
            if (i < 0 || i >= Rows || j < 0 || j >= Cols)
                throw new IndexOutOfRangeException("Index out of range");
            matrix[i, j] = value;
        }
    }
    
    public Matrix(int rows, int cols)
    {
        this.Rows = rows;
        this.Cols = cols;
        matrix = new int[rows, cols];
    }
    
    public void FillMatrix()
    {
        Random rand = new Random();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                matrix[i, j] = rand.Next(1, 100);
            }
        }
    }
    
    public void PrintMatrix()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    public int GetMax()
    {
        int max = matrix[0, 0];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }
    
    public int GetMin()
    {
        int min = matrix[0, 0];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }
    
    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new ArgumentException("Matrices must have the same dimensions for addition");
            
        Matrix result = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }
    
    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new ArgumentException("Matrices must have the same dimensions for subtraction");
            
        Matrix result = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }
    
    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows)
            throw new ArgumentException("Number of columns in first matrix must equal number of rows in second matrix");
            
        Matrix result = new Matrix(a.Rows, b.Cols);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Cols; j++)
            {
                for (int k = 0; k < a.Cols; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }
    
    public static Matrix operator *(Matrix a, int scalar)
    {
        Matrix result = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }
        return result;
    }
    
    public static Matrix operator *(int scalar, Matrix a)
    {
        return a * scalar;
    }
    
    public static bool operator ==(Matrix a, Matrix b)
    {
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return ReferenceEquals(a, b);
            
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            return false;
            
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                if (a[i, j] != b[i, j])
                    return false;
            }
        }
        return true;
    }
    
    public static bool operator !=(Matrix a, Matrix b)
    {
        return !(a == b);
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
            
        Matrix other = (Matrix)obj;
        return this == other;
    }
    
    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + Rows.GetHashCode();
        hash = hash * 23 + Cols.GetHashCode();
        
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                hash = hash * 23 + matrix[i, j].GetHashCode();
            }
        }
        
        return hash;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of rows in the matrix:");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter number of columns in the matrix:");
        int cols = Convert.ToInt32(Console.ReadLine());
        Matrix matrix = new Matrix(rows, cols);
        matrix.FillMatrix();
        Console.WriteLine("Matrix:");
        matrix.PrintMatrix();
        Console.WriteLine($"Maximum value in the matrix: {matrix.GetMax()}");
        Console.WriteLine($"Minimum value in the matrix: {matrix.GetMin()}");
        Console.WriteLine("Enter a scalar value to multiply the matrix:");
        int scalar = Convert.ToInt32(Console.ReadLine());
        Matrix scaledMatrix = matrix * scalar;
        Console.WriteLine($"Matrix after multiplying by {scalar}:");
        scaledMatrix.PrintMatrix();
        Console.WriteLine("Enter another matrix to add:");
        Matrix anotherMatrix = new Matrix(rows, cols);
        anotherMatrix.FillMatrix();
        Console.WriteLine("Another Matrix:");
        anotherMatrix.PrintMatrix();
        Matrix sumMatrix = matrix + anotherMatrix;
        Console.WriteLine("Sum of the two matrices:");
        sumMatrix.PrintMatrix();
        Matrix diffMatrix = matrix - anotherMatrix;
        Console.WriteLine("Difference of the two matrices:");
        diffMatrix.PrintMatrix();
        Console.WriteLine("Enter another matrix to multiply:");
        Matrix multiplyMatrix = new Matrix(cols, rows); 
        multiplyMatrix.FillMatrix();
        Console.WriteLine("Matrix to multiply:");
        multiplyMatrix.PrintMatrix();
        Matrix productMatrix = matrix * multiplyMatrix;
        Console.WriteLine("Product of the two matrices:");
        productMatrix.PrintMatrix();
        Console.WriteLine("Checking equality of the original and another matrix:");
        if (matrix == anotherMatrix)
        {
            Console.WriteLine("The matrices are equal.");
        }
        else
        {
            Console.WriteLine("The matrices are not equal.");
        }
        Console.WriteLine("Checking equality of the original matrix with itself:");
        if (matrix == matrix)
        {
            Console.WriteLine("The matrices are equal.");
        }
        else
        {
            Console.WriteLine("The matrices are not equal.");
        }
    }
}