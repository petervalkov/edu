namespace _04._Generating_01_Vectors
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int bitCount = int.Parse(Console.ReadLine());

            int[] vector = new int[bitCount];

            GenerateVector(vector, 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    GenerateVector(vector, index + 1);
                }
            }
        }
    }
}
