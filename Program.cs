using System;
using CampusLinkApp.Models;
using CampusLinkApp.Services;

#nullable enable

namespace CampusLinkApp
{
    class Program
    {
        static void Main()
        {
            var manager = new StudentManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("CampusLink Student Management:");
                Console.WriteLine("1. Register New Student");
                Console.WriteLine("2. View Student Roster");
                Console.WriteLine("3. Edit Student Details");
                Console.WriteLine("4. Delete Student Record");
                Console.WriteLine("5. Sort Students (Name/Age)");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option (1–6): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterStudent(manager);
                        break;
                    case "2":
                        ViewStudents(manager);
                        break;
                    case "3":
                        EditStudent(manager);
                        break;
                    case "4":
                        DeleteStudent(manager);
                        break;
                    case "5":
                        SortStudents(manager);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.\n");
                        break;
                }
            }
        }

        static void RegisterStudent(StudentManager manager)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            string gender;
            while (true)
            {
                Console.Write("Gender (Male/Female): ");
                gender = Console.ReadLine()!;
                if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                    gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                    break;
                Console.WriteLine("Invalid gender. Please enter Male or Female.");
            }

            int age;
            while (true)
            {
                Console.Write("Age: ");
                if (int.TryParse(Console.ReadLine(), out age))
                    break;
                Console.WriteLine("Invalid age. Please enter a number.");
            }

            manager.Add(new Student(name, gender, age, ""));
        }

        static void ViewStudents(StudentManager manager)
        {
            var list = manager.List();
            if (list.Count == 0)
            {
                Console.WriteLine("No students registered.\n");
                return;
            }

            Console.WriteLine("\nStudent Roster:");
            Console.WriteLine("ID\tName\tGender\tAge");
            foreach (var s in list)
                Console.WriteLine($"{s.StudentID}\t{s.Name}\t{s.Gender}\t{s.Age}");
            Console.WriteLine();
        }

        static void EditStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID to edit: ");
            string id = Console.ReadLine()!;

            Console.Write("New Name: ");
            string name = Console.ReadLine()!;

            string gender;
            while (true)
            {
                Console.Write("New Gender (Male/Female): ");
                gender = Console.ReadLine()!;
                if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                    gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                    break;
                Console.WriteLine("Invalid gender. Please enter Male or Female.");
            }

            int age;
            while (true)
            {
                Console.Write("New Age: ");
                if (int.TryParse(Console.ReadLine(), out age))
                    break;
                Console.WriteLine("Invalid age. Please enter a number.");
            }

            manager.Edit(new Student(name, gender, age, id));
        }

        static void DeleteStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID to delete: ");
            string id = Console.ReadLine()!;
            manager.Delete(id);
        }

        static void SortStudents(StudentManager manager)
        {
            Console.Write("Sort by Name or Age? (N/A): ");
            string option = Console.ReadLine()!.ToUpper();

            var sorted = option == "A"
                ? manager.List().OrderBy(s => s.Age).ToList()
                : manager.List(); 

            Console.WriteLine("\nSorted Student Roster:");
            Console.WriteLine("ID\tName\tGender\tAge");
            foreach (var s in sorted)
                Console.WriteLine($"{s.StudentID}\t{s.Name}\t{s.Gender}\t{s.Age}");
            Console.WriteLine();
        }
    }
}
