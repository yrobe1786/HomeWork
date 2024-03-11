using System;

namespace VSKolya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first, second, third;

            // Функция для чтения и проверки введенного значения стороны треугольника
            int ReadAndValidate(string sideName)
            {
                int side;
                do
                {
                    Console.Write($"Введите значение {sideName} стороны: ");
                    if (!int.TryParse(Console.ReadLine(), out side) || side < 1)
                    {
                        Console.WriteLine("Введено некорректное значение. Пожалуйста, введите число больше нуля.");
                    }
                }
                while (side < 1);
                return side;
            }


            // Проверка подходит ли для треугольника значения всех трёх сторон
            bool IfValuesTrue(int a, int b, int c)
            {
                return (a + b > c) && (a + c > b) && (b + c > a);
            }

            try
            {
                first = ReadAndValidate("первой");
                second = ReadAndValidate("второй");
                third = ReadAndValidate("третьей");

                if (!IfValuesTrue(first, second, third))
                {
                    Console.WriteLine("Треугольник с такими сторонами не существует.");
                    return;
                }

                // Функция расчета углов треугольника
                double AgleFunc(int a, int b, int c)
                {
                    // Используем формулу по теореме косинусов
                    return Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * (180 / Math.PI);
                }

                double angleA = AgleFunc(first, second, third);
                double angleB = AgleFunc(second, third, first);
                double angleC = AgleFunc(third, first, second);

                // Проверка на тип треугольника по углам
                if (angleA == 90.0 || angleB == 90.0 || angleC == 90.0)
                {
                    Console.WriteLine("Треугольник прямоугольный.");
                }
                else if (angleA > 90.0 || angleB > 90.0 || angleC > 90.0)
                {
                    Console.WriteLine("Треугольник тупоугольный.");
                }
                else if (angleA < 90.0 && angleB < 90.0 && angleC < 90.0)
                {
                    Console.WriteLine("Треугольник остроугольный.");
                }

                // Проверка на равенство сторон треугольника
                if (first == second && first == third)
                {
                    Console.WriteLine("Треугольник равносторонний.");
                }
                else if (first == second || first == third || second == third)
                {
                    Console.WriteLine("Треугольник равнобедренный.");
                }
                else
                {
                    Console.WriteLine("Треугольник разносторонний.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вводе данных: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}