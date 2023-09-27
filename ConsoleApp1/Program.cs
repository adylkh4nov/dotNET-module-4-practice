using dotNET_module_4_practice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            example3Setup();
        }

        private static void example1Setup()
        {
            Student student1 = new Student("Adylkhanov", "AOK", 1, new int[5] { 4, 4, 4, 4, 5 });
            Student student2 = new Student("Idrisov", "IAN", 1, new int[5] { 5, 4, 4, 2, 1 });
            Student student3 = new Student("Shopalov", "SIA", 2, new int[5] { 2, 1, 5, 5, 5 });
            Student student4 = new Student("Isaev", "IEF", 2, new int[5] { 5, 5, 5, 5, 5 });
            Student student5 = new Student("Sabitov", "SAM", 2, new int[5] { 2, 2, 2, 2, 2 });
            Student student6 = new Student("Ukenov", "UIA", 3, new int[5] { 4, 4, 4, 4, 4 });
            Student student7 = new Student("Omirzak", "ODA", 3, new int[5] { 5, 4, 4, 5, 5 });
            Student student8 = new Student("Kalibek", "KSK", 3, new int[5] { 3, 3, 3, 4, 4 });
            Student student9 = new Student("Zhumagaliev", "ZAM", 4, new int[5] { 5, 5, 5, 5, 4 });
            Student student10 = new Student("Bimzhanov", "BTB", 4, new int[5] { 4, 4, 4, 5, 5 });

            Student[] students = {student1,student2,student3
                    ,student4,student5,student6
                    ,student7,student8,student9
                    ,student10};

            Student[] sortedStudents = sortStudentsByAverage(students);
            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(student.Lastname);
            }
            Console.WriteLine("<<< Have score upper then 3 >>>");
            foreach (Student student in sortedStudents)
            {
                if (student.isGoodStudent())
                {
                    Console.WriteLine(student.Lastname + " group: " + student.groupNumber);
                }
            }
            Console.ReadLine();
        }
        private static void example2Setup()
        {
            Animal[] animals = new Animal[]
         {
            new Carnivore(1, "Лев"),
            new Omnivore(2, "Медведь"),
            new Herbivore(3, "Корова"),
            new Omnivore(4, "Белка"),
            new Carnivore(5, "Волк"),
            new Herbivore(6, "Лошадь"),
            new Carnivore(7, "Рысь"),
            new Omnivore(8, "Акула"),
            new Herbivore(9, "Коза"),
            new Carnivore(10, "Тигр"),
        };
            for (int i = 0; i < animals.Length - 1; i++)
            {
                for (int j = i+1; j < animals.Length; j++)
                {
                    if(animals[i].CalculateFoodAmount() < animals[j].CalculateFoodAmount() ||
                        (animals[i].CalculateFoodAmount() == animals[j].CalculateFoodAmount() 
                        && string.Compare(animals[i].Name, animals[j].Name) > 0))
                    {
                        var temp = animals[i];
                        animals[i] = animals[j];
                        animals[j] = temp;
                        
                    }
                }
            }
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine(animals[i].Id + " " + animals[i].Type + " "+animals[i].Name + " " + animals[i].CalculateFoodAmount());
            }

            // Вывод первых 5 имен животных
            Console.WriteLine("\nПервые 5 имен животных:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + 1 +" "+ animals[i].Name);
            }

            // Вывод последних 3 идентификаторов животных
            Console.WriteLine("\nПоследние 3 идентификатора животных:");
            foreach (var animal in animals.Skip(animals.Length - 3))
            {
                Console.WriteLine(animal.Id);
            }

            // Запись коллекции в файл
            foreach (var animal in animals)
            {
                SaveAnimalToFile(animal, @"D:\Projects\c#\dotNET-module-4-practice\animal.txt");
            }
            // Чтение коллекции из файла
            Animal[] loadedAnimals = LoadAnimalsFromFile("animals.txt");
            Console.WriteLine("Чтение из файла");
            foreach (var animal in loadedAnimals)
            {
                Console.WriteLine(animal.Id + " " + animal.Name + " " + animal.Type);
            }
            Console.ReadLine();

        }
        private static void example3Setup()
        {
            Library myLibrary = new Library();
            myLibrary.AddBook(new Book("Как помыть дождь", "Джон Уик", 2020));
            myLibrary.AddBook(new Book("Как развести огонь", "Пещерный человек", 0));
            myLibrary.AddBook(new Book("О чем думают коты", "Гарфилд", 2010));
            myLibrary.AddBook(new Book("Как мы выглядим", "Брэд Питт", 2005));
            myLibrary.AddBook(new Book("Как написать свою игру","Гейб", 2000));
            myLibrary.SortBooksByYear();
            Console.WriteLine("Сортировка по Году");
            myLibrary.DisplayBooks();
            myLibrary.SortBooksByAuthor();
            Console.WriteLine("Сортировка по Автору");

            myLibrary.DisplayBooks();
            myLibrary.SortBooksByTitle();
            Console.WriteLine("Сортировка по Заголовку");

            myLibrary.DisplayBooks();
        }
        static void SaveAnimalToFile(Animal animal, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine($"{animal.Id},{animal.Name},{animal.Type}");
            }
        }
        static Animal[] LoadAnimalsFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return new Animal[0];
            }

            string[] lines = File.ReadAllLines(filename);
            Animal[] loadedAnimals = new Animal[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                int id = int.Parse(parts[0]);
                string name = parts[1];
                string type = parts[2];

                // Создаем животное в зависимости от типа
                if (type == "Хищник")
                {
                    loadedAnimals[i] = new Carnivore(id, name);
                }
                else if (type == "Всеядное")
                {
                    loadedAnimals[i] = new Omnivore(id, name);
                }
                else if (type == "Травоядное")
                {
                    loadedAnimals[i] = new Herbivore(id, name);
                }
            }

            return loadedAnimals;
        }
        private static Student[] sortStudentsByAverage(Student[] students)
        {
            Student[] sortedStudents = new Student[students.Length];
            bool[] added = new bool[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                double minAverage = double.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < students.Length; j++)
                {
                    if (!added[j] && students[j].Average() < minAverage)
                    {
                        minAverage = students[j].Average();
                        minIndex = j;
                    }
                }

                sortedStudents[i] = students[minIndex];
                added[minIndex] = true;
            }

            return sortedStudents;
        }
    }
}
