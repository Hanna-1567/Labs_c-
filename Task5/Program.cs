using System;
namespace Task5
{
    //Середній бал у групах студентів (зубчастий масив)

    public class Program
    {
        public static double GetAverage(int[] marks)
        {
            int sum = 0;
            foreach (int mark in marks)
                sum += mark;
            return (double)sum / marks.Length;
        }

        public static int GetMin(int[] marks)
        {
            int min = marks[0];
            foreach (int mark in marks)
                if (mark < min) min = mark;
            return min;
        }

        public static int GetMax(int[] marks)
        {
            int max = marks[0];
            foreach (int mark in marks)
                if (mark > max) max = mark;
            return max;
        }

        public  static void PrintGroupStatistics(int[][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                int[] group = groups[i];
                double avg = GetAverage(group);
                int min = GetMin(group);
                int max = GetMax(group);

                Console.WriteLine(
                    $"Група {i + 1}: Середній = {avg:F2}, Мінімальний = {min}, Максимальний = {max}"
                );
            }
        }

        public static void Main()
        {
            // Приклад даних (3 групи, різна кількість студентів)
            int[][] groups = new int[][]
            {
            new int[] { 80, 95, 60, 70, 100, 85 },
            new int[] { 50, 75, 90, 60, 95 },
            new int[] { 100, 98, 95, 96, 97 }
            };

            PrintGroupStatistics(groups);
        }
    }
}