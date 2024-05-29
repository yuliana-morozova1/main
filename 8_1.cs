using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Виклики методів через делегати Action
            DisplayTime(() => Console.WriteLine($"Поточний час: {DateTime.Now.ToShortTimeString()}"));
            DisplayDate(() => Console.WriteLine($"Поточна дата: {DateTime.Now.ToShortDateString()}"));
            DisplayDayOfWeek(() => Console.WriteLine($"Поточний день: {DateTime.Now.DayOfWeek}"));

            // Перевірка числа на простоту
            CheckNumber(17, "Просте число:", IsPrime);

            // Перевірка числа на належність до чисел Фібоначчі
            CheckNumber(13, "Число Фібоначчі:", IsFibonacci);

            // Обчислення площі трикутника
            CalculateArea("Площа трикутника:", CalculateTriangleArea, 5, 8);

            // Обчислення площі прямокутника
            CalculateArea("Площа прямокутника:", CalculateRectangleArea, 10, 6);
        }

        // Метод для виведення поточного часу
        public static void DisplayTime(Action action)
        {
            action();
        }

        // Метод для виведення поточної дати
        public static void DisplayDate(Action action)
        {
            action();
        }

        // Метод для виведення поточного дня тижня
        public static void DisplayDayOfWeek(Action action)
        {
            action();
        }

        // Метод для перевірки числа за допомогою предиката
        public static void CheckNumber(int number, string message, Predicate<int> predicate)
        {
            Console.WriteLine($"{message} {predicate(number)}");
        }

        // Метод для обчислення площі фігури за допомогою функції
        public static void CalculateArea(string message, Func<double, double, double> func, double parameter1, double parameter2)
        {
            Console.WriteLine($"{message} {func(parameter1, parameter2)}");
        }

        // Метод для перевірки, чи число є простим
        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        // Метод для перевірки, чи число є числом Фібоначчі
        public static bool IsFibonacci(int number)
        {
            return Square(5 * number * number + 4) || Square(5 * number * number - 4);
        }

        // Внутрішній метод для перевірки, чи число є квадратом ідеального квадрату
        private static bool Square(int number)
        {
            int squareRoot = (int)Math.Sqrt(number);
            return squareRoot * squareRoot == number;
        }

        // Метод для обчислення площі трикутника
        public static double CalculateTriangleArea(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }

        // Метод для обчислення площі прямокутника
        public static double CalculateRectangleArea(double length, double width)
        {
            return length * width;
        }
    }
}
