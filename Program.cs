using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    internal class Program
    {
        // ============= ТЕМА 5: МЕТОДЫ =============

        // Метод для задания 5.1 - вычисление факториала
        static long Factorial(int n)
        {
            if (n < 0) return 0;
            if (n == 0 || n == 1) return 1;
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        // Метод для задания 5.2 - проверка на четное число
        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        // Метод для задания 5.3 - удвоение значения
        static int DoubleValue(int value)
        {
            return value * 2;
        }

        // Метод для задания 5.4 - поиск максимума в массиве
        static int FindMax(int[] arr)
        {
            if (arr.Length == 0) return 0;
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) max = arr[i];
            return max;
        }

        // Перегруженные методы для задания 5.6 - вывод различных типов
        static void Print(int value)
        {
            Console.WriteLine($"Int: {value}");
        }

        static void Print(string value)
        {
            Console.WriteLine($"String: {value}");
        }

        static void Print(double value)
        {
            Console.WriteLine($"Double: {value}");
        }

        // Метод для задания 5.7 - увеличение значения через ref
        static void Increment(ref int value)
        {
            value++;
        }

        // Метод для задания 5.8 - деление с out параметром
        static bool Divide(int dividend, int divisor, out int result)
        {
            if (divisor == 0)
            {
                result = 0;
                return false;
            }
            result = dividend / divisor;
            return true;
        }

        // Метод для задания 5.9 - сортировка методом пузырька
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = 0; j < arr.Length - 1 - i; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        // Метод для задания 5.10 - проверка палиндрома
        static bool IsPalindrome(string str)
        {
            string cleaned = str.ToLower().Replace(" ", "");
            for (int i = 0; i < cleaned.Length / 2; i++)
                if (cleaned[i] != cleaned[cleaned.Length - 1 - i])
                    return false;
            return true;
        }

        // Метод для задания 5.11 - сумма параметров (params)
        static int SumParams(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
                sum += num;
            return sum;
        }

        // ============= ТЕМА 6: РЕКУРСИЯ =============

        // Задание 6.1 - Факториал (рекурсивный)
        static long FactorialRecursive(int n)
        {
            if (n < 0) return 0;
            if (n == 0 || n == 1) return 1;
            return n * FactorialRecursive(n - 1);
        }

        // Задание 6.2 - Числа Фибоначчи (рекурсивные)
        static long FibonacciRecursive(int n)
        {
            if (n <= 1) return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        // Задание 6.3 - Сумма цифр числа (рекурсивная)
        static int SumOfDigits(int n)
        {
            if (n == 0) return 0;
            return (n % 10) + SumOfDigits(n / 10);
        }

        // Задание 6.4 - Степень числа (рекурсивная)
        static long Power(int baseNum, int exp)
        {
            if (exp == 0) return 1;
            if (exp < 0) return 0;
            return baseNum * Power(baseNum, exp - 1);
        }

        // Задание 6.5 - НОД (рекурсивный алгоритм Евклида)
        static int GCDRecursive(int a, int b)
        {
            if (b == 0) return a;
            return GCDRecursive(b, a % b);
        }

        // Задание 6.6 - Переворот строки (рекурсивный)
        static string ReverseString(string str)
        {
            if (str.Length <= 1) return str;
            return ReverseString(str.Substring(1)) + str[0];
        }

        // Задание 6.7 - Бинарный поиск (рекурсивный)
        static int BinarySearchRecursive(int[] arr, int target, int left, int right)
        {
            if (left > right) return -1;
            int mid = (left + right) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] > target) return BinarySearchRecursive(arr, target, left, mid - 1);
            return BinarySearchRecursive(arr, target, mid + 1, right);
        }

        // Задание 6.8 - Сумма элементов массива (рекурсивная)
        static int SumArrayRecursive(int[] arr, int index)
        {
            if (index == arr.Length) return 0;
            return arr[index] + SumArrayRecursive(arr, index + 1);
        }

        // Задание 6.9 - Ханойские башни
        static void TowerOfHanoi(int n, char source, char destination, char auxiliary)
        {
            if (n == 1)
            {
                Console.WriteLine($"Переместить диск со стержня {source} на {destination}");
                return;
            }
            TowerOfHanoi(n - 1, source, auxiliary, destination);
            Console.WriteLine($"Переместить диск со стержня {source} на {destination}");
            TowerOfHanoi(n - 1, auxiliary, destination, source);
        }

        // Задание 6.10 - Проверка палиндрома (рекурсивная)
        static bool IsPalindromeRecursive(string str, int left, int right)
        {
            if (left >= right) return true;
            if (str[left] != str[right]) return false;
            return IsPalindromeRecursive(str, left + 1, right - 1);
        }

        // ============= ТЕМА 7: АЛГОРИТМЫ =============

        // Задание 7.1 - Сортировка выбором
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        // Задание 7.2 - Сортировка вставками
        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        // Задание 7.3 - Быстрая сортировка
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pi = Partition(arr, left, right);
                QuickSort(arr, left, pi - 1);
                QuickSort(arr, pi + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp2;
            return i + 1;
        }

        // Задание 7.4 - Сортировка слиянием
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] leftArr = new int[mid - left + 1];
            int[] rightArr = new int[right - mid];
            Array.Copy(arr, left, leftArr, 0, mid - left + 1);
            Array.Copy(arr, mid + 1, rightArr, 0, right - mid);

            int i = 0, j = 0, k = left;
            while (i < leftArr.Length && j < rightArr.Length)
            {
                if (leftArr[i] <= rightArr[j])
                    arr[k++] = leftArr[i++];
                else
                    arr[k++] = rightArr[j++];
            }
            while (i < leftArr.Length) arr[k++] = leftArr[i++];
            while (j < rightArr.Length) arr[k++] = rightArr[j++];
        }

        // Задание 7.5 - Линейный поиск
        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target)
                    return i;
            return -1;
        }

        // Задание 7.6 - Бинарный поиск (итеративный)
        static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == target) return mid;
                if (arr[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        // Задание 7.7 - Поиск минимума и максимума
        static void FindMinMax(int[] arr, out int min, out int max)
        {
            min = arr[0];
            max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
        }

        // Задание 7.8 - Решето Эратосфена
        static int[] SieveOfEratosthenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++) isPrime[i] = true;
            for (int i = 2; i * i <= n; i++)
                if (isPrime[i])
                    for (int j = i * i; j <= n; j += i)
                        isPrime[j] = false;

            List<int> primes = new List<int>();
            for (int i = 2; i <= n; i++)
                if (isPrime[i]) primes.Add(i);
            return primes.ToArray();
        }

        // Задание 7.9 - Проверка на анаграмму
        static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            char[] arr1 = str1.ToLower().ToCharArray();
            char[] arr2 = str2.ToLower().ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            return new string(arr1) == new string(arr2);
        }

        // Задание 7.10 - Алгоритм Кадане (максимальная подпоследовательность)
        static int MaxSubarraySum(int[] arr)
        {
            int maxSum = arr[0];
            int currentSum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                currentSum = Math.Max(arr[i], currentSum + arr[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }

        // Задание 7.11 - Поиск повторяющихся элементов
        static Dictionary<int, int> FindDuplicates(int[] arr)
        {
            Dictionary<int, int> duplicates = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (duplicates.ContainsKey(num))
                    duplicates[num]++;
                else
                    duplicates[num] = 1;
            }
            return duplicates;
        }

        // ============= ТЕМА 8: ООП =============

        // Задание 8.1 - Класс "Студент"
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double GPA { get; set; }

            public Student(string name, int age, double gpa)
            {
                Name = name;
                Age = age;
                GPA = gpa;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Студент: {Name}, Возраст: {Age}, Средний балл: {GPA}");
            }
        }

        // Задание 8.2 - Класс "Банковский счет" с инкапсуляцией
        class BankAccount
        {
            private double balance;

            public BankAccount(double initialBalance)
            {
                balance = initialBalance;
            }

            public void Deposit(double amount)
            {
                if (amount > 0) balance += amount;
                Console.WriteLine($"Баланс после пополнения: {balance}");
            }

            public void Withdraw(double amount)
            {
                if (amount > 0 && amount <= balance)
                    balance -= amount;
                else
                    Console.WriteLine("Невозможно снять средства");
                Console.WriteLine($"Текущий баланс: {balance}");
            }

            public double GetBalance()
            {
                return balance;
            }
        }

        // Задание 8.3 - Наследование - иерархия "Животные"
        class Animal
        {
            public string Name { get; set; }
            public virtual void MakeSound()
            {
                Console.WriteLine($"{Name} издает звук");
            }
        }

        class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine($"{Name} лает: Гав-гав!");
            }
        }

        class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine($"{Name} мяукает: Мяу!");
            }
        }

        // Задание 8.4 - Конструкторы - класс "Прямоугольник"
        class Rectangle
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle()
            {
                Width = 1;
                Height = 1;
            }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double GetArea()
            {
                return Width * Height;
            }

            public double GetPerimeter()
            {
                return 2 * (Width + Height);
            }
        }

        // Задание 8.5 - Статические члены класса
        class Counter
        {
            private static int count = 0;

            public static void Increment()
            {
                count++;
            }

            public static int GetCount()
            {
                return count;
            }
        }

        // Задание 8.6 - Полиморфизм - геометрические фигуры
        abstract class Shape
        {
            public abstract double GetArea();
            public abstract void Display();
        }

        class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }

            public override void Display()
            {
                Console.WriteLine($"Круг с радиусом {Radius}, площадь: {GetArea():F2}");
            }
        }

        class Square : Shape
        {
            public double Side { get; set; }

            public Square(double side)
            {
                Side = side;
            }

            public override double GetArea()
            {
                return Side * Side;
            }

            public override void Display()
            {
                Console.WriteLine($"Квадрат со стороной {Side}, площадь: {GetArea():F2}");
            }
        }

        // Задание 8.7 - Интерфейсы - IComparable
        class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public int CompareTo(Person other)
            {
                return Age.CompareTo(other.Age);
            }
        }

        // Задание 8.8 - Свойства (Properties) - класс "Книга"
        class Book
        {
            private string title;
            private string author;
            private int pages;

            public string Title
            {
                get { return title; }
                set { title = value ?? "Unknown"; }
            }

            public string Author
            {
                get { return author; }
                set { author = value ?? "Unknown"; }
            }

            public int Pages
            {
                get { return pages; }
                set { pages = value > 0 ? value : 1; }
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Книга: {Title}, Автор: {Author}, Страниц: {Pages}");
            }
        }

        // Задание 8.9 - Перегрузка операторов - ComplexNumber
        class ComplexNumber
        {
            public double Real { get; set; }
            public double Imaginary { get; set; }

            public ComplexNumber(double real, double imaginary)
            {
                Real = real;
                Imaginary = imaginary;
            }

            public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
            }

            public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
            {
                return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
            }

            public override string ToString()
            {
                string sign = Imaginary >= 0 ? "+" : "";
                return $"{Real} {sign} {Imaginary}i";
            }
        }

        // Задание 8.10 - Композиция - класс "Автомобиль"
        class Engine
        {
            public string Type { get; set; }
            public int Power { get; set; }

            public Engine(string type, int power)
            {
                Type = type;
                Power = power;
            }
        }

        class Car
        {
            public string Brand { get; set; }
            public Engine Engine { get; set; }

            public Car(string brand, Engine engine)
            {
                Brand = brand;
                Engine = engine;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Авто: {Brand}, Двигатель: {Engine.Type}, Мощность: {Engine.Power} л.с.");
            }
        }

        // Задание 8.11 - Индексаторы - класс "Список покупок"
        class ShoppingList
        {
            private List<string> items = new List<string>();

            public string this[int index]
            {
                get { return items[index]; }
                set { items[index] = value; }
            }

            public void Add(string item)
            {
                items.Add(item);
            }

            public int Count
            {
                get { return items.Count; }
            }
        }

        // Задание 8.12 - Обработка исключений в классах
        class Calculator
        {
            public static double Divide(double a, double b)
            {
                try
                {
                    if (b == 0)
                        throw new ArgumentException("Делитель не может быть нулем");
                    return a / b;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    return 0;
                }
            }
        }

        // ============= ТЕМА 9: ФАЙЛЫ =============

        // Задание 9.1 - Запись текста в файл
        static void WriteToFile(string filename, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine($"Текст записан в файл {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Задание 9.2 - Чтение текста из файла
        static string ReadFromFile(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return "";
            }
        }

        // Задание 9.3 - Построчное чтение файла
        static void ReadFileLineByLine(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Задание 9.4 - Подсчет количества строк
        static int CountLines(string filename)
        {
            try
            {
                int count = 0;
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (reader.ReadLine() != null)
                        count++;
                }
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return 0;
            }
        }

        // Задание 9.5 - Добавление текста в существующий файл
        static void AppendToFile(string filename, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine($"Текст добавлен в файл {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Задание 9.6 - Копирование содержимого файла
        static void CopyFileContent(string sourceFile, string destinationFile)
        {
            try
            {
                File.Copy(sourceFile, destinationFile, true);
                Console.WriteLine($"Файл скопирован из {sourceFile} в {destinationFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Задание 9.7 - Поиск слова в файле
        static int SearchWordInFile(string filename, string word)
        {
            try
            {
                int count = 0;
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(word))
                            count++;
                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return 0;
            }
        }

        // Задание 9.8 - Запись массива в файл
        static void WriteArrayToFile(string filename, int[] arr)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (int num in arr)
                        writer.WriteLine(num);
                }
                Console.WriteLine($"Массив записан в файл {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Задание 9.9 - Чтение чисел из файла в массив
        static int[] ReadArrayFromFile(string filename)
        {
            try
            {
                List<int> numbers = new List<int>();
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int num))
                            numbers.Add(num);
                    }
                }
                return numbers.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return new int[0];
            }
        }

        // Задание 9.10 - Статистика текстового файла
        static void FileStatistics(string filename)
        {
            try
            {
                int lines = 0, words = 0, chars = 0;
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines++;
                        chars += line.Length;
                        words += line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    }
                }
                Console.WriteLine($"Статистика файла {filename}:");
                Console.WriteLine($"Строк: {lines}, Слов: {words}, Символов: {chars}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("введите число от 1 до 100");
            int choice = int.Parse(Console.ReadLine());
            var random = new Random();

            switch (choice)
            {
                // ============= ТЕМА 1: ОСНОВЫ =============
                case 1:
                    Console.WriteLine("Hello, World!");
                    break;

                case 2:
                    Console.WriteLine("первое число");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("второе число");
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Сумма: {a + b}");
                    Console.WriteLine($"Разность: {a - b}");
                    Console.WriteLine($"Произведение: {a * b}");
                    if (b != 0)
                        Console.WriteLine($"Частное: {a / b}");
                    else
                        Console.WriteLine("Деление на ноль невозможно.");
                    break;

                case 3:
                    Console.Write("Введите температуру в Цельсиях: ");
                    double c = double.Parse(Console.ReadLine());
                    double f = c * 9 / 5 + 32;
                    Console.WriteLine($"Температура в Фаренгейтах: {f}");
                    break;

                case 4:
                    Console.Write("Введите длину: ");
                    double length = double.Parse(Console.ReadLine());
                    Console.Write("Введите ширину: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Площадь: {length * width}");
                    Console.WriteLine($"Периметр: {2 * (length + width)}");
                    break;

                case 5:
                    Console.Write("Введите делимое: ");
                    int dividend = int.Parse(Console.ReadLine());
                    Console.Write("Введите делитель: ");
                    int divisor = int.Parse(Console.ReadLine());
                    if (divisor != 0)
                        Console.WriteLine($"Остаток: {dividend % divisor}");
                    else
                        Console.WriteLine("Деление на ноль невозможно.");
                    break;

                case 6:
                    Console.Write("введите X:");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Введиет Y:");
                    int y = int.Parse(Console.ReadLine());
                    x = x + y;
                    y = x - y;
                    x = x - y;
                    Console.WriteLine($" x = {x}, y = {y}");
                    break;

                case 7:
                    Console.WriteLine("первое число");
                    double d = double.Parse(Console.ReadLine());
                    Console.WriteLine("второе число");
                    double e = double.Parse(Console.ReadLine());
                    Console.WriteLine("третье число");
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Среднее арифметическое: {(d + e + h) / 3}");
                    break;

                case 8:
                    Console.Write("Введите радиус круга: ");
                    double radius = double.Parse(Console.ReadLine());
                    double area = Math.PI * radius * radius;
                    Console.WriteLine($"Площадь круга: {area}");
                    break;

                case 9:
                    Console.Write("Введите возраст в годах: ");
                    int years = int.Parse(Console.ReadLine());
                    int seconds = years * 365 * 24 * 60 * 60;
                    Console.WriteLine($"Возраст в секундах: {seconds}");
                    break;

                case 10:
                    Console.Write("Введите сумму в рублях: ");
                    double rub = double.Parse(Console.ReadLine());
                    double usd = rub / 90;
                    double eur = rub / 98;
                    Console.WriteLine($"В долларах: {usd:F2}");
                    Console.WriteLine($"В евро: {eur:F2}");
                    break;

                // ============= ТЕМА 2: УСЛОВНЫЕ ОПЕРАТОРЫ =============
                case 11:
                    Console.Write("Введите число: ");
                    int num = int.Parse(Console.ReadLine());
                    if (num % 2 == 0)
                        Console.WriteLine("Число четное");
                    else
                        Console.WriteLine("Число нечетное");
                    break;

                case 12:
                    Console.Write("Введите три числа: ");
                    int n1 = int.Parse(Console.ReadLine());
                    int n2 = int.Parse(Console.ReadLine());
                    int n3 = int.Parse(Console.ReadLine());
                    int max = Math.Max(n1, Math.Max(n2, n3));
                    Console.WriteLine($"Максимум: {max}");
                    break;

                case 13:
                    Console.Write("Введите первое число: ");
                    double a1 = double.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    double b1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Выберите операцию (+, -, *, /): ");
                    string op = Console.ReadLine();

                    switch (op)
                    {
                        case "+":
                            Console.WriteLine(a1 + b1);
                            break;
                        case "-":
                            Console.WriteLine(a1 - b1);
                            break;
                        case "*":
                            Console.WriteLine(a1 * b1);
                            break;
                        case "/":
                            if (b1 != 0)
                                Console.WriteLine(a1 / b1);
                            else
                                Console.WriteLine("Ошибка: деление на ноль.");
                            break;
                        default:
                            Console.WriteLine("Неизвестная операция.");
                            break;
                    }
                    break;

                case 14:
                    Console.Write("Введите год: ");
                    int year = int.Parse(Console.ReadLine());
                    bool leap = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
                    Console.WriteLine(leap ? "Високосный год" : "Не високосный год");
                    break;

                case 15:
                    Console.Write("Введите баллы (0-100): ");
                    int score = int.Parse(Console.ReadLine());
                    if (score >= 90) Console.WriteLine("Оценка: A");
                    else if (score >= 80) Console.WriteLine("Оценка: B");
                    else if (score >= 70) Console.WriteLine("Оценка: C");
                    else if (score >= 60) Console.WriteLine("Оценка: D");
                    else Console.WriteLine("Оценка: F");
                    break;

                case 16:
                    Console.Write("Введите час (0-23): ");
                    int hour = int.Parse(Console.ReadLine());
                    if (hour >= 6 && hour < 12) Console.WriteLine("Утро");
                    else if (hour >= 12 && hour < 18) Console.WriteLine("День");
                    else if (hour >= 18 && hour < 23) Console.WriteLine("Вечер");
                    else Console.WriteLine("Ночь");
                    break;

                case 17:
                    Console.WriteLine("Введите три стороны треугольника:");
                    int s1 = int.Parse(Console.ReadLine());
                    int s2 = int.Parse(Console.ReadLine());
                    int s3 = int.Parse(Console.ReadLine());
                    if (s1 == s2 && s2 == s3) Console.WriteLine("Равносторонний");
                    else if (s1 == s2 || s2 == s3 || s1 == s3) Console.WriteLine("Равнобедренный");
                    else Console.WriteLine("Разносторонний");
                    break;

                case 18:
                    Console.Write("Введите возраст: ");
                    int age = int.Parse(Console.ReadLine());
                    if (age < 0) Console.WriteLine("Некорректный возраст");
                    else if (age < 7) Console.WriteLine("Дошкольник");
                    else if (age < 18) Console.WriteLine("Школьник");
                    else if (age < 65) Console.WriteLine("Взрослый");
                    else Console.WriteLine("Пенсионер");
                    break;

                case 19:
                    Console.Write("Введите коэффициенты (a, b, c): ");
                    double qa = double.Parse(Console.ReadLine());
                    double qb = double.Parse(Console.ReadLine());
                    double qc = double.Parse(Console.ReadLine());
                    double d1 = qb * qb - 4 * qa * qc;

                    if (d1 > 0)
                    {
                        double x1 = (-qb + Math.Sqrt(d1)) / (2 * qa);
                        double x2 = (-qb - Math.Sqrt(d1)) / (2 * qa);
                        Console.WriteLine($"Два корня: {x1}, {x2}");
                    }
                    else if (d1 == 0)
                    {
                        double xRoot = -qb / (2 * qa);
                        Console.WriteLine($"Один корень: {xRoot}");
                    }
                    else
                    {
                        Console.WriteLine("Нет действительных корней");
                    }
                    break;

                case 20:
                    Console.Write("Введите сумму: ");
                    double sum = double.Parse(Console.ReadLine());
                    double discount = 0;
                    if (sum >= 10000) discount = 0.2;
                    else if (sum >= 5000) discount = 0.1;
                    double total = sum * (1 - discount);
                    Console.WriteLine($"Сумма со скидкой: {total}");
                    break;

                case 21:
                    Console.Write("Введите номер месяца (1-12): ");
                    int m = int.Parse(Console.ReadLine());
                    string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                        "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
                    if (m >= 1 && m <= 12)
                        Console.WriteLine(months[m - 1]);
                    else
                        Console.WriteLine("Некорректный номер месяца");
                    break;

                case 22:
                    Console.Write("Введите пароль: ");
                    string pass = Console.ReadLine();
                    if (pass.Length >= 8 && pass.IndexOfAny("0123456789".ToCharArray()) >= 0
                        && pass.IndexOfAny("abcdefABCDEF@#!$%".ToCharArray()) >= 0)
                        Console.WriteLine("Надежный пароль");
                    else
                        Console.WriteLine("Слабый пароль");
                    break;

                // ============= ТЕМА 3: ЦИКЛЫ =============
                case 23:
                    Console.Write("Введите N: ");
                    int n4 = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= n4; i++)
                        Console.Write(i + " ");
                    Console.WriteLine();
                    break;

                case 24:
                    Console.Write("Введите N: ");
                    int n5 = int.Parse(Console.ReadLine());
                    int sum1 = 0;
                    for (int i = 1; i <= n5; i++)
                        sum1 += i;
                    Console.WriteLine($"Сумма от 1 до {n5} = {sum1}");
                    break;

                case 25:
                    Console.Write("Введите число для таблицы умножения: ");
                    int t = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= 10; i++)
                        Console.WriteLine($"{t} x {i} = {t * i}");
                    break;

                case 26:
                    Console.Write("Введите число для факториала: ");
                    int f1 = int.Parse(Console.ReadLine());
                    long factorial = 1;
                    for (int i = 2; i <= f1; i++)
                        factorial *= i;
                    Console.WriteLine($"Факториал {f1}! = {factorial}");
                    break;

                case 27:
                    Console.Write("Введите количество чисел Фибоначчи: ");
                    int fibCount = int.Parse(Console.ReadLine());
                    long a3 = 0, b3 = 1;
                    for (int i = 0; i < fibCount; i++)
                    {
                        Console.Write(a3 + " ");
                        long temp = a3;
                        a3 = b3;
                        b3 = temp + b3;
                    }
                    Console.WriteLine();
                    break;

                case 28:
                    Console.Write("Введите число: ");
                    int prime = int.Parse(Console.ReadLine());
                    bool isPrime = prime > 1;
                    for (int i = 2; i <= Math.Sqrt(prime); i++)
                    {
                        if (prime % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    Console.WriteLine(isPrime ? "Простое число" : "Составное число");
                    break;

                case 29:
                    Console.Write("Введите число для переворота: ");
                    int num3 = int.Parse(Console.ReadLine());
                    int reversed = 0;
                    while (num3 > 0)
                    {
                        reversed = reversed * 10 + num3 % 10;
                        num3 /= 10;
                    }
                    Console.WriteLine($"Перевернутое число: {reversed}");
                    break;

                case 30:
                    Console.Write("Введите число: ");
                    int number = int.Parse(Console.ReadLine());
                    int digitSum = 0;
                    int tempNum = number;
                    while (tempNum > 0)
                    {
                        digitSum += tempNum % 10;
                        tempNum /= 10;
                    }
                    Console.WriteLine($"Сумма цифр числа {number} = {digitSum}");
                    break;

                case 31:
                    Console.Write("Введите верхнюю границу для вывода простых чисел: ");
                    int limit = int.Parse(Console.ReadLine());
                    bool[] sieve = new bool[limit + 1];
                    for (int i = 2; i <= limit; i++) sieve[i] = true;
                    for (int i = 2; i * i <= limit; i++)
                        if (sieve[i])
                            for (int j = i * i; j <= limit; j += i)
                                sieve[j] = false;
                    Console.WriteLine("Простые числа:");
                    for (int i = 2; i <= limit; i++)
                        if (sieve[i]) Console.Write(i + " ");
                    Console.WriteLine();
                    break;

                case 32:
                    Random rand = new Random();
                    int secret = rand.Next(1, 101);
                    int guess = 0;
                    Console.WriteLine("Угадай число от 1 до 100.");
                    while (guess != secret)
                    {
                        Console.Write("Введите число: ");
                        guess = int.Parse(Console.ReadLine());
                        if (guess < secret) Console.WriteLine("Больше");
                        else if (guess > secret) Console.WriteLine("Меньше");
                        else Console.WriteLine("Угадали!");
                    }
                    break;

                case 33:
                    Console.Write("Введите количество строк пирамиды: ");
                    int rows = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= rows; i++)
                    {
                        Console.Write(new string(' ', rows - i));
                        Console.WriteLine(new string('*', 2 * i - 1));
                    }
                    break;

                case 34:
                    Console.Write("Введите два числа через пробел: ");
                    string[] inputs = Console.ReadLine().Split();
                    int x3 = int.Parse(inputs[0]);
                    int y3 = int.Parse(inputs[1]);
                    while (y3 != 0)
                    {
                        int tempGCD = y3;
                        y3 = x3 % y3;
                        x3 = tempGCD;
                    }
                    Console.WriteLine($"НОД: {Math.Abs(x3)}");
                    break;

                // ============= ТЕМА 4: МАССИВЫ =============
                case 35:
                    int[] arr1 = new int[10];
                    for (int i = 0; i < arr1.Length; i++)
                        arr1[i] = random.Next(0, 100);
                    Console.WriteLine("Массив:");
                    foreach (int item in arr1)
                        Console.Write(item + " ");
                    Console.WriteLine();
                    break;

                case 36:
                    int[] arr2 = new int[10];
                    for (int i = 0; i < arr2.Length; i++)
                        arr2[i] = random.Next(0, 100);
                    int sum5 = 0;
                    foreach (int item in arr2)
                        sum5 += item;
                    Console.WriteLine("Массив:");
                    Console.WriteLine(string.Join(" ", arr2));
                    Console.WriteLine($"Сумма элементов: {sum5}");
                    break;

                case 37:
                    int[] arr3 = new int[10];
                    for (int i = 0; i < arr3.Length; i++)
                        arr3[i] = random.Next(0, 100);
                    int max1 = arr3[0];
                    int maxIndex = 0;
                    for (int i = 1; i < arr3.Length; i++)
                        if (arr3[i] > max1)
                        {
                            max1 = arr3[i];
                            maxIndex = i;
                        }
                    Console.WriteLine("Массив:");
                    Console.WriteLine(string.Join(" ", arr3));
                    Console.WriteLine($"Максимальный элемент: {max1}, индекс: {maxIndex}");
                    break;

                case 38:
                    int[] arr4 = new int[10];
                    for (int i = 0; i < arr4.Length; i++)
                        arr4[i] = random.Next(0, 100);
                    Console.WriteLine("Исходный массив:");
                    Console.WriteLine(string.Join(" ", arr4));
                    Array.Reverse(arr4);
                    Console.WriteLine("Перевернутый массив:");
                    Console.WriteLine(string.Join(" ", arr4));
                    break;

                case 39:
                    int[] arr5 = new int[10];
                    for (int i = 0; i < arr5.Length; i++)
                        arr5[i] = random.Next(0, 100);
                    Console.WriteLine("Массив:");
                    Console.WriteLine(string.Join(" ", arr5));
                    Console.Write("Введите число для поиска: ");
                    int target = int.Parse(Console.ReadLine());
                    int index = -1;
                    for (int i = 0; i < arr5.Length; i++)
                        if (arr5[i] == target)
                        {
                            index = i;
                            break;
                        }
                    if (index == -1)
                        Console.WriteLine("Элемент не найден");
                    else
                        Console.WriteLine($"Элемент найден на позиции: {index}");
                    break;

                case 40:
                    int[] arr6 = new int[10];
                    for (int i = 0; i < arr6.Length; i++)
                        arr6[i] = random.Next(0, 100);
                    int evenCount = 0, oddCount = 0;
                    foreach (int item in arr6)
                        if (item % 2 == 0)
                            evenCount++;
                        else
                            oddCount++;
                    Console.WriteLine("Массив:");
                    Console.WriteLine(string.Join(" ", arr6));
                    Console.WriteLine($"Четных: {evenCount}, Нечетных: {oddCount}");
                    break;

                case 41:
                    int[] arr7 = new int[10];
                    for (int i = 0; i < arr7.Length; i++)
                        arr7[i] = random.Next(0, 100);
                    Console.WriteLine("Исходный массив:");
                    Console.WriteLine(string.Join(" ", arr7));
                    for (int i = 0; i < arr7.Length - 1; i++)
                        for (int j = 0; j < arr7.Length - 1 - i; j++)
                            if (arr7[j] > arr7[j + 1])
                            {
                                int tempSort = arr7[j];
                                arr7[j] = arr7[j + 1];
                                arr7[j + 1] = tempSort;
                            }
                    Console.WriteLine("Отсортированный массив:");
                    Console.WriteLine(string.Join(" ", arr7));
                    break;

                case 42:
                    int[,] matrix = new int[3, 3];
                    Console.WriteLine("Заполнение матрицы 3x3 случайными числами:");
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            matrix[i, j] = random.Next(0, 10);
                    Console.WriteLine("Матрица:");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Console.Write(matrix[i, j] + " ");
                        Console.WriteLine();
                    }
                    break;

                case 43:
                    int[,] mat = new int[3, 3];
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            mat[i, j] = random.Next(0, 10);
                    Console.WriteLine("Матрица:");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Console.Write(mat[i, j] + " ");
                        Console.WriteLine();
                    }
                    int diagSum = 0;
                    for (int i = 0; i < 3; i++)
                        diagSum += mat[i, i];
                    Console.WriteLine($"Сумма элементов главной диагонали: {diagSum}");
                    break;

                case 44:
                    int[][] jagged = new int[3][];
                    jagged[0] = new int[] { 1, 2, 3 };
                    jagged[1] = new int[] { 4, 5 };
                    jagged[2] = new int[] { 6, 7, 8, 9 };
                    Console.WriteLine("Зубчатый массив:");
                    for (int i = 0; i < jagged.Length; i++)
                    {
                        foreach (int val1 in jagged[i])
                            Console.Write(val1 + " ");
                        Console.WriteLine();
                    }
                    break;

                case 45:
                    int[,] mtx = new int[3, 3];
                    Console.WriteLine("Заполнение матрицы 3x3:");
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            mtx[i, j] = random.Next(0, 10);
                    Console.WriteLine("Исходная матрица:");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Console.Write(mtx[i, j] + " ");
                        Console.WriteLine();
                    }
                    int[,] transposed = new int[3, 3];
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            transposed[j, i] = mtx[i, j];
                    Console.WriteLine("Транспонированная матрица:");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Console.Write(transposed[i, j] + " ");
                        Console.WriteLine();
                    }
                    break;

                case 46:
                    int[] arrA = new int[5] { 1, 3, 5, 7, 9 };
                    int[] arrB = new int[5] { 2, 4, 6, 8, 10 };
                    int[] merged = new int[arrA.Length + arrB.Length];
                    int ia = 0, ib = 0, im = 0;
                    while (ia < arrA.Length && ib < arrB.Length)
                    {
                        if (arrA[ia] < arrB[ib])
                            merged[im++] = arrA[ia++];
                        else
                            merged[im++] = arrB[ib++];
                    }
                    while (ia < arrA.Length) merged[im++] = arrA[ia++];
                    while (ib < arrB.Length) merged[im++] = arrB[ib++];
                    Console.WriteLine("Массив A: " + string.Join(" ", arrA));
                    Console.WriteLine("Массив B: " + string.Join(" ", arrB));
                    Console.WriteLine("Объединенный массив:");
                    Console.WriteLine(string.Join(" ", merged));
                    break;

                // ============= ТЕМА 5: МЕТОДЫ =============
                case 47:
                    Console.Write("Введите первое число: ");
                    int a6 = int.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    int b6 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Сумма: {a6 + b6}");
                    break;

                case 48:
                    Console.Write("Введите число: ");
                    int num7 = int.Parse(Console.ReadLine());
                    Console.WriteLine(IsEven(num7) ? "Четное число" : "Нечетное число");
                    break;

                case 49:
                    Console.Write("Введите число: ");
                    int num8 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Факториал: {Factorial(num8)}");
                    break;

                case 50:
                    Console.Write("Введите число (или Enter для значения по умолчанию): ");
                    string input = Console.ReadLine();
                    int val = string.IsNullOrEmpty(input) ? 10 : int.Parse(input);
                    Console.WriteLine($"Результат: {DoubleValue(val)}");
                    break;

                case 51:
                    int[] arr = { 4, 9, 1, 5, 7 };
                    Console.WriteLine($"Массив: {string.Join(", ", arr)}");
                    Console.WriteLine($"Максимальное значение: {FindMax(arr)}");
                    break;

                case 52:
                    Print(10);
                    Print("Привет");
                    Print(3.14);
                    break;

                case 53:
                    int xInc = 5;
                    Console.WriteLine($"До увеличения: {xInc}");
                    Increment(ref xInc);
                    Console.WriteLine($"После увеличения: {xInc}");
                    break;

                case 54:
                    if (Divide(10, 3, out int res))
                        Console.WriteLine($"Результат деления: {res}");
                    else
                        Console.WriteLine("Деление на ноль невозможно");
                    break;

                case 55:
                    int[] toSort = { 5, 2, 9, 1, 5, 6 };
                    Console.WriteLine("До сортировки: " + string.Join(", ", toSort));
                    BubbleSort(toSort);
                    Console.WriteLine("После сортировки: " + string.Join(", ", toSort));
                    break;

                case 56:
                    Console.Write("Введите строку: ");
                    string s = Console.ReadLine();
                    Console.WriteLine(IsPalindrome(s) ? "Палиндром" : "Не палиндром");
                    break;

                case 57:
                    Console.WriteLine("Сумма: " + SumParams(1, 2, 3, 4, 5));
                    Console.WriteLine("Сумма: " + SumParams(10, 20));
                    Console.WriteLine("Сумма: " + SumParams());
                    break;

                // ============= ТЕМА 6: РЕКУРСИЯ =============
                case 58:
                    Console.Write("Введите число для факториала (рекурсивно): ");
                    int factNum = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Факториал {factNum}! = {FactorialRecursive(factNum)}");
                    break;

                case 59:
                    Console.Write("Введите N-ное число Фибоначчи: ");
                    int fibNum = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Fibonacci({fibNum}) = {FibonacciRecursive(fibNum)}");
                    break;

                case 60:
                    Console.Write("Введите число для суммы цифр: ");
                    int digSum = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Сумма цифр: {SumOfDigits(digSum)}");
                    break;

                case 61:
                    Console.Write("Введите основание: ");
                    int baseNum = int.Parse(Console.ReadLine());
                    Console.Write("Введите показатель степени: ");
                    int expNum = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{baseNum}^{expNum} = {Power(baseNum, expNum)}");
                    break;

                case 62:
                    Console.Write("Введите первое число: ");
                    int gcdA = int.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    int gcdB = int.Parse(Console.ReadLine());
                    Console.WriteLine($"НОД: {GCDRecursive(gcdA, gcdB)}");
                    break;

                case 63:
                    Console.Write("Введите строку для переворота: ");
                    string revStr = Console.ReadLine();
                    Console.WriteLine($"Перевернутая строка: {ReverseString(revStr)}");
                    break;

                case 64:
                    int[] sortedArr = { 1, 3, 5, 7, 9, 11, 13, 15 };
                    Console.Write("Введите число для поиска (бинарный поиск): ");
                    int targetBin = int.Parse(Console.ReadLine());
                    int binRes = BinarySearchRecursive(sortedArr, targetBin, 0, sortedArr.Length - 1);
                    Console.WriteLine(binRes == -1 ? "Не найдено" : $"Найдено на позиции: {binRes}");
                    break;

                case 65:
                    int[] arrSum = { 1, 2, 3, 4, 5 };
                    Console.WriteLine($"Сумма элементов массива: {SumArrayRecursive(arrSum, 0)}");
                    break;

                case 66:
                    Console.Write("Введите количество дисков для Ханойских башен: ");
                    int hanoi = int.Parse(Console.ReadLine());
                    Console.WriteLine("Последовательность ходов:");
                    TowerOfHanoi(hanoi, 'A', 'C', 'B');
                    break;

                case 67:
                    Console.Write("Введите строку для проверки на палиндром: ");
                    string palStr = Console.ReadLine();
                    bool isPal = IsPalindromeRecursive(palStr, 0, palStr.Length - 1);
                    Console.WriteLine(isPal ? "Палиндром" : "Не палиндром");
                    break;

                // ============= ТЕМА 7: АЛГОРИТМЫ =============
                case 68:
                    int[] selArr = { 64, 34, 25, 12, 22, 11, 90 };
                    Console.WriteLine("До сортировки выбором: " + string.Join(", ", selArr));
                    SelectionSort(selArr);
                    Console.WriteLine("После сортировки выбором: " + string.Join(", ", selArr));
                    break;

                case 69:
                    int[] insArr = { 64, 34, 25, 12, 22, 11, 90 };
                    Console.WriteLine("До сортировки вставками: " + string.Join(", ", insArr));
                    InsertionSort(insArr);
                    Console.WriteLine("После сортировки вставками: " + string.Join(", ", insArr));
                    break;

                case 70:
                    int[] quickArr = { 64, 34, 25, 12, 22, 11, 90 };
                    Console.WriteLine("До быстрой сортировки: " + string.Join(", ", quickArr));
                    QuickSort(quickArr, 0, quickArr.Length - 1);
                    Console.WriteLine("После быстрой сортировки: " + string.Join(", ", quickArr));
                    break;

                case 71:
                    int[] mergeArr = { 64, 34, 25, 12, 22, 11, 90 };
                    Console.WriteLine("До сортировки слиянием: " + string.Join(", ", mergeArr));
                    MergeSort(mergeArr, 0, mergeArr.Length - 1);
                    Console.WriteLine("После сортировки слиянием: " + string.Join(", ", mergeArr));
                    break;

                case 72:
                    int[] linArr = { 10, 20, 30, 40, 50, 60 };
                    Console.Write("Введите число для линейного поиска: ");
                    int linTarget = int.Parse(Console.ReadLine());
                    int linRes = LinearSearch(linArr, linTarget);
                    Console.WriteLine(linRes == -1 ? "Не найдено" : $"Найдено на позиции: {linRes}");
                    break;

                case 73:
                    int[] binArr = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
                    Console.Write("Введите число для бинарного поиска: ");
                    int binTarget = int.Parse(Console.ReadLine());
                    int binResIt = BinarySearch(binArr, binTarget);
                    Console.WriteLine(binResIt == -1 ? "Не найдено" : $"Найдено на позиции: {binResIt}");
                    break;

                case 74:
                    int[] minMaxArr = { 45, 23, 67, 12, 89, 34, 56 };
                    FindMinMax(minMaxArr, out int minVal, out int maxVal);
                    Console.WriteLine($"Минимум: {minVal}, Максимум: {maxVal}");
                    break;

                case 75:
                    Console.Write("Введите верхний предел для решета Эратосфена: ");
                    int sieveLimit = int.Parse(Console.ReadLine());
                    int[] primes = SieveOfEratosthenes(sieveLimit);
                    Console.WriteLine("Простые числа: " + string.Join(", ", primes));
                    break;

                case 76:
                    Console.Write("Введите первую строку: ");
                    string str1 = Console.ReadLine();
                    Console.Write("Введите вторую строку: ");
                    string str2 = Console.ReadLine();
                    bool isAna = IsAnagram(str1, str2);
                    Console.WriteLine(isAna ? "Это анаграммы" : "Это не анаграммы");
                    break;

                case 77:
                    int[] kadaneArr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
                    Console.WriteLine($"Максимальная подпоследовательность: {MaxSubarraySum(kadaneArr)}");
                    break;

                case 78:
                    int[] dupArr = { 1, 2, 2, 3, 4, 4, 4, 5 };
                    Dictionary<int, int> dups = FindDuplicates(dupArr);
                    Console.WriteLine("Повторяющиеся элементы:");
                    foreach (var item in dups)
                        if (item.Value > 1)
                            Console.WriteLine($"{item.Key}: встречается {item.Value} раз(а)");
                    break;

                // ============= ТЕМА 8: ООП =============
                case 79:
                    Student st = new Student("Иван", 20, 4.5);
                    st.DisplayInfo();
                    break;

                case 80:
                    BankAccount acc = new BankAccount(1000);
                    acc.Deposit(500);
                    acc.Withdraw(200);
                    Console.WriteLine($"Итоговый баланс: {acc.GetBalance()}");
                    break;

                case 81:
                    Dog dog = new Dog { Name = "Барон" };
                    Cat cat = new Cat { Name = "Муся" };
                    dog.MakeSound();
                    cat.MakeSound();
                    break;

                case 82:
                    Rectangle rect1 = new Rectangle();
                    Rectangle rect2 = new Rectangle(5, 10);
                    Console.WriteLine($"Прямоугольник 1 - Площадь: {rect1.GetArea()}, Периметр: {rect1.GetPerimeter()}");
                    Console.WriteLine($"Прямоугольник 2 - Площадь: {rect2.GetArea()}, Периметр: {rect2.GetPerimeter()}");
                    break;

                case 83:
                    Counter.Increment();
                    Counter.Increment();
                    Counter.Increment();
                    Console.WriteLine($"Количество инкрементов: {Counter.GetCount()}");
                    break;

                case 84:
                    Circle circ = new Circle(5);
                    Square sq = new Square(4);
                    circ.Display();
                    sq.Display();
                    break;

                case 85:
                    List<Person> people = new List<Person>
                    {
                        new Person("Иван", 25),
                        new Person("Петр", 20),
                        new Person("Мария", 30)
                    };
                    people.Sort();
                    Console.WriteLine("Люди отсортированы по возрасту:");
                    foreach (var p in people)
                        Console.WriteLine($"{p.Name}: {p.Age} лет");
                    break;

                case 86:
                    Book book = new Book();
                    book.Title = "C# для начинающих";
                    book.Author = "Герберт Шилдт";
                    book.Pages = 520;
                    book.DisplayInfo();
                    break;

                case 87:
                    ComplexNumber c1 = new ComplexNumber(3, 4);
                    ComplexNumber c2 = new ComplexNumber(2, 5);
                    ComplexNumber sum2 = c1 + c2;
                    ComplexNumber diff = c1 - c2;
                    Console.WriteLine($"c1 = {c1}");
                    Console.WriteLine($"c2 = {c2}");
                    Console.WriteLine($"c1 + c2 = {sum2}");
                    Console.WriteLine($"c1 - c2 = {diff}");
                    break;

                case 88:
                    Engine engine = new Engine("V8", 450);
                    Car car = new Car("BMW", engine);
                    car.DisplayInfo();
                    break;

                case 89:
                    ShoppingList list = new ShoppingList();
                    list.Add("Молоко");
                    list.Add("Хлеб");
                    list.Add("Яйца");
                    Console.WriteLine("Список покупок:");
                    for (int i = 0; i < list.Count; i++)
                        Console.WriteLine($"{i + 1}. {list[i]}");
                    break;

                case 90:
                    double res1 = Calculator.Divide(10, 2);
                    double res2 = Calculator.Divide(10, 0);
                    Console.WriteLine($"10 / 2 = {res1}");
                    Console.WriteLine($"10 / 0 = {res2}");
                    break;

                // ============= ТЕМА 9: ФАЙЛЫ =============
                case 91:
                    WriteToFile("test.txt", "Привет, мир!");
                    break;

                case 92:
                    string content = ReadFromFile("test.txt");
                    Console.WriteLine("Содержимое файла:");
                    Console.WriteLine(content);
                    break;

                case 93:
                    WriteToFile("lines.txt", "Первая строка\nВторая строка\nТретья строка");
                    ReadFileLineByLine("lines.txt");
                    break;

                case 94:
                    int linesCount = CountLines("lines.txt");
                    Console.WriteLine($"Количество строк в файле: {linesCount}");
                    break;

                case 95:
                    AppendToFile("test.txt", "Добавленная строка");
                    break;

                case 96:
                    CopyFileContent("test.txt", "test_copy.txt");
                    break;

                case 97:
                    int wordCount = SearchWordInFile("lines.txt", "строка");
                    Console.WriteLine($"Слово 'строка' найдено {wordCount} раз(а)");
                    break;

                case 98:
                    int[] arrToWrite = { 10, 20, 30, 40, 50 };
                    WriteArrayToFile("array.txt", arrToWrite);
                    break;

                case 99:
                    int[] arrRead = ReadArrayFromFile("array.txt");
                    Console.WriteLine("Прочитанный массив: " + string.Join(", ", arrRead));
                    break;

                case 100:
                    FileStatistics("lines.txt");
                    break;

                default:
                    Console.WriteLine("ошибка ввода");
                    break;
            }

            Console.ReadKey();
        }
    }
}
