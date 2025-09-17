using System;
namespace Task1
{

    //Парність числа
    public class Program
    {
       public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
       public static string GetMessage(int number)
        {
            if (IsEven(number))
                return "Двері відкриваються!";
            else
                return "Двері зачинені...";
        }

       public static void Main()
        {
            Console.Write("Введіть число: ");
            int num = int.Parse(Console.ReadLine());

            string message = GetMessage(num);
            Console.WriteLine(message);
        }
    }
}