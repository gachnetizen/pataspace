using System;
using System.Collections.Generic;

namespace PataSpaceGradeSystem
{
    class Program
    {
        static List<string> studentNames = new List<string>();
        static List<int> studentMarks = new List<int>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = GetUserInput("Enter your choice: ");

                if (choice == "1")
                {
                    EnterStudentGrades();
                }
                else if (choice == "2")
                {
                    ViewResults();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("\nThank you for choosing PataSpace Grade System.");
                    running = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid choice! Please enter 1, 2, or 3.");
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("   PataSpace Grade System");
            Console.WriteLine("===========================");
            Console.WriteLine("1. Enter Student Grades");
            Console.WriteLine("2. View Results");
            Console.WriteLine("3. Exit");
        }

        static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return "invalid";
            }

            return input.Trim();
        }

        static string GetGrade(int marks)
        {
            switch (marks / 10)
            {
                case 10:
                case 9:
                    return "A";
                case 8:
                    return "B";
                case 7:
                    return "C";
                case 6:
                    return "D";
                default:
                    return "F";
            }
        }

        static void EnterStudentGrades()
        {
            Console.Clear();
            Console.WriteLine("--- Enter Student Grades ---\n");

            while (true)
            {
                string name = GetUserInput("Enter student name (or 'done' to finish): ");

                if (name.ToLower() == "done")
                {
                    break;
                }

                if (name == "invalid")
                {
                    Console.WriteLine("Name cannot be empty. Please try again.");
                    continue;
                }

                Console.Write("Enter marks (0-100): ");
                string marksInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(marksInput))
                {
                    Console.WriteLine("Marks cannot be empty. Please try again.");
                    continue;
                }

                if (int.TryParse(marksInput, out int marks))
                {
                    if (marks >= 0 && marks <= 100)
                    {
                        studentNames.Add(name);
                        studentMarks.Add(marks);
                        Console.WriteLine($"✓ Grade recorded for {name}: {marks} marks\n");
                    }
                    else
                    {
                        Console.WriteLine("Marks must be between 0 and 100. Please try again.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 100.\n");
                }
            }

            if (studentNames.Count > 0)
            {
                Console.WriteLine($"\n✓ Successfully entered {studentNames.Count} student record(s).");
            }
        }

        static void ViewResults()
        {
            Console.Clear();
            Console.WriteLine("--- Student Results ---\n");

            if (studentNames.Count == 0)
            {
                Console.WriteLine("No student records found. Please enter grades first.");
                return;
            }

            int totalMarks = 0;
            int highestMark = int.MinValue;
            int lowestMark = int.MaxValue;
            string highestStudent = "";
            string lowestStudent = "";

            for (int i = 0; i < studentNames.Count; i++)
            {
                string grade = GetGrade(studentMarks[i]);
                Console.WriteLine($"{i + 1}. {studentNames[i]}: {studentMarks[i]} marks - Grade: {grade}");

                totalMarks += studentMarks[i];

                if (studentMarks[i] > highestMark)
                {
                    highestMark = studentMarks[i];
                    highestStudent = studentNames[i];
                }

                if (studentMarks[i] < lowestMark)
                {
                    lowestMark = studentMarks[i];
                    lowestStudent = studentNames[i];
                }
            }

            double average = (double)totalMarks / studentNames.Count;
            Console.WriteLine($"\n--- Summary ---");
            Console.WriteLine($"Total Students: {studentNames.Count}");
            Console.WriteLine($"Average Marks: {average:F2}");
            Console.WriteLine($"Highest Score: {highestStudent} ({highestMark})");
            Console.WriteLine($"Lowest Score: {lowestStudent} ({lowestMark})");
        }
    }
}