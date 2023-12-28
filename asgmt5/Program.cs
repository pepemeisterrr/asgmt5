using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace asgmt5
{
    internal class Program
    {
        public static int InputInt() //ввод целых чисел с обработкой исключений
        {
            string input = Console.ReadLine();
            int output = 0;
            bool parsed = int.TryParse(input, out output);
            while (!parsed)
            {
                Log.Error($"Invalid input. Entered \"{input}\" Try again...", 1);
                Log.Error("Please enter an integer", 1);
                Log.Input();
                input = Console.ReadLine();
                parsed = int.TryParse(input, out output);
            }
            return output;
        }
        public static string ConcatenateText(string sourceText, params string[] symbolicValues)
        {
            string result = sourceText;
            foreach (string value in symbolicValues)
            {
                result += value;
            }
            return result;
        }
        public static void Task1() 
        {
            Log.Info("Task #1", 1);
            Log.Info("Please enter the text", 1);
            Log.Input();
            string sourceText = Console.ReadLine();
            string concatenatedText = ConcatenateText(sourceText, " example", " of", " arguments", "!");
            Log.Info(concatenatedText, 1);
        }
        public static int[] FindLargestAndSmallest(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("At least one number must be provided.");
            }

            int largest = numbers[0];
            int smallest = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > largest)
                {
                    largest = numbers[i];
                }

                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }
            }

            return new int[] {largest, smallest};
        }
        public static void Task2()
        {
            Log.Info("Task #2", 1);
            try
            {
                int[] numbers = {5, 2, 9, 1, 7};
                int[] results = FindLargestAndSmallest(numbers);
               Log.Info($"Largest: {results[0]}, Smallest: {results[1]}", 1);
            }
            catch (ArgumentException e)
            {
                Log.Error($"Exception: {e.Message}", 1);
            }
        }
        public static int DoubleFactorial(int n) // двойной факториал
        {
            if (n < 0)
            {
                throw new ArgumentException("Number should not be negative");
            }

            int result = 1;
            for (int i = n; i >= 1; i -= 2)
            {
                result *= i;
            }

            return result;
        }
        public static int DoubleFactorialWithRecursion(int n) //с рекурсией
        {
            if (n < 0)
            {
                throw new ArgumentException("Number should not be negative");
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * DoubleFactorialWithRecursion(n - 2);
        }
        public static void Task3() 
        {
            Log.Info("Task #3", 1);
            int num = 0;
            int num1 = 7;
            do
            {
                Log.Info("Please enter an integer", 1);
                Log.Input();
                num = InputInt();
                if (num < 0) Log.Error("Number should not be negative", 1);
            } while (num < 0);

            Log.Info($"Double factorial of {num} with recursion: {DoubleFactorialWithRecursion(num)}", 1);
            Log.Info($"(Example) Double factorial of {num1} without recursion: {DoubleFactorial(num1)}", 1);
        }

        public static void Task4() 
        {
            Log.Head("List food", 1);
            //список, пример коллекции, в которой можно получать доступ к элементам по их индексу
            List<string> food = ["apple", "chicken", "bread", "car", "meat", "fish"];
            //вывод всех элементов списка через пробел
            foreach (string foodItem in food)
            {
                Log.Info(foodItem + " ", 1);
            }
            //удаление элемента
            food.Remove("car");
            //добавление элемента
            food.Add("potato");

            Log.Head("LINQ", 1);
            //пример использования LINQ - встроенный в C# язык запросов
            List<Product> products = new List<Product> //используя класс из файла Product.cs
            {
                new Product { Id = 1, Name = "PC", Price = 100000},
                new Product { Id = 2, Name = "Laptop", Price = 40000},
                new Product { Id = 3, Name = "Console", Price = 60000},
                new Product { Id = 4, Name = "TV", Price = 70000}
            };
            //подмножество элементов из списка products
            var subset = from theElement in products //передает каждый элемент из products в переменную theElement
                         where theElement.Price > 50000 //фильтрация по цене
                         orderby theElement.Price //упорядочивание по возрастанию цены
                         select theElement; //выбор объекта в создаваемую коллекцию

            foreach (Product theElement in subset) //вывод
            {
                Log.Info(theElement.Name + " - " + theElement.Price, 1);
            }

            //Словарь, пример коллекции, в которой можно получить доступ к элементу по ключу
            Dictionary<int, string> map = new Dictionary<int, string>(); // ключ - целое число, значение - строка
            //добавление элементов
            map.Add(1, "apple");
            map.Add(2, "orange");
            map.Add(3, "pear");
            // другой способ инициализации
            Log.Head("Dictionary carBrands", 1);
            Dictionary<int, string> carBrands = new Dictionary<int, string>()
            {
                [1] = "Audi",
                [2] = "BMW",
                [3] = "Mercedes",
                [4] = "Toyota",
                [5] = "Lada",
                [6] = "Boeing"
            };
            //способ удаления элемента, зная его значение
            string name = "";
            if (carBrands.ContainsValue("Boeing")) //Если существует такое значение
            {
                for (int i = 1; i <= carBrands.Count; i++) // метод Count возращает кол-во элементов
                {
                    carBrands.TryGetValue(i, out name); //вывод значения по ключу, если существует
                    if (name == "Boeing")
                    {
                        carBrands.Remove(i); //удаление элемента по ключу
                    }
                }
            }

            foreach (var brand in carBrands) //перебор всех элементов
            {
                Log.Info($"Key {brand.Key} value {brand.Value}", 1);
            }
        }

        public static void Main(string[] args)
        {
            ConsoleKeyInfo option;
            do
            {
                Log.Input("Select Task [1] - [4] or [esc] to exit >", 0);
                option = Console.ReadKey(true);
                Console.WriteLine();
                switch (option.Key)
                {
                    case ConsoleKey.D1: Task1(); break;
                    case ConsoleKey.D2: Task2(); break;
                    case ConsoleKey.D3: Task3(); break;
                    case ConsoleKey.D4: Task4(); break;

                    case ConsoleKey.NumPad1: Task1(); break;
                    case ConsoleKey.NumPad2: Task2(); break;
                    case ConsoleKey.NumPad3: Task3(); break;
                    case ConsoleKey.NumPad4: Task4(); break;

                    default:
                        if (option.Key != ConsoleKey.Escape)
                        {
                            Log.Error($"[{option.Key}] is out of range [1] to [4]", 1);
                        }
                        break;
                }
            } while (option.Key != ConsoleKey.Escape);
            Log.Info("Goodbye", 1);
        }   
    }
}
