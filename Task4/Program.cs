using System;
using System.Data;
namespace Task4
{
    //Робота з трикутником
    public class Program
    {
        public static bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }

        public static double GetPerimeter(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Error");
            return a + b + c;
        }

        public static double GetArea(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Error"); 
            double p = GetPerimeter(a, b, c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public static string GetTriangleType(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Невалідний трикутник"); 
            
            if (a == b && b == c)
                return "рівносторонній";

            if (a == b || a == c || b == c)
                return "рівнобедрений";

            double a2 = a * a, b2 = b * b, c2 = c * c;
            if (Math.Abs(a2 + b2 - c2) < 0.1 ||
                Math.Abs(a2 + c2 - b2) < 0.1 ||
                Math.Abs(b2 + c2 - a2) < 0.1)
                return "прямокутний";

            return "довільний";
        }

        static void Main()
        {
            Console.Write("Введіть сторону a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введіть сторону b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введіть сторону c: ");
            double c = double.Parse(Console.ReadLine());

            if (IsValidTriangle(a, b, c))
            {
                Console.WriteLine($"Периметр: {GetPerimeter(a, b, c)}");
                Console.WriteLine($"Площа: {GetArea(a, b, c):F2}");
                Console.WriteLine($"Тип трикутника: {GetTriangleType(a, b, c)}");
            }
            else
            {
                Console.WriteLine("Трикутник з такими сторонами не існує!");
            }
        }
    }
}
