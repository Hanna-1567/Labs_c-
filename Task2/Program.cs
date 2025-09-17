using System;
namespace Task2
{
    //Масив і підрахунок

    public class Program
    {
        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random rnd = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(min, max + 1);
            }
            return arr;
        }
        public static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public static double GetAverage(int[] numbers)
        {
            return (double)GetSum(numbers) / numbers.Length;
        }

        public static int GetMin(int[] numbers)
        {
            int min = numbers[0];
            foreach (int num in numbers)
            {
                if (num < min)
                    min = num;
            }
            return min;
        }

        public static int GetMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        public static void Main()
        {
            int[] array = GenerateRandomArray(10, 1, 100);

            Console.WriteLine("Згенерований масив:");
            Console.WriteLine(string.Join(", ", array));

            Console.WriteLine($"\nСума: {GetSum(array)}");
            Console.WriteLine($"Середнє: {GetAverage(array):F2}");
            Console.WriteLine($"Мінімум: {GetMin(array)}");
            Console.WriteLine($"Максимум: {GetMax(array)}");
        }
    }
}