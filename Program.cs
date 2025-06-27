using System;
using System.Collections.Generic;
using System.IO;

class StudentGradeCalculator
{
    private List<string> subjects = new List<string>();
    private List<int> grades = new List<int>();

    public void InputGrades()
    {
        Console.Write("Введіть кількість предметів: ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.WriteLine("Помилка! Введіть додатне ціле число.");
            Console.Write("Введіть кількість предметів: ");
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Назва предмета #{i + 1}: ");
            string subject = Console.ReadLine();

            int grade;
            while (true)
            {
                Console.Write($"Оцінка з предмета \"{subject}\" (0-100): ");
                if (int.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100)
                    break;
                else
                    Console.WriteLine("Некоректна оцінка. Введіть число від 0 до 100.");
            }

            subjects.Add(subject);
            grades.Add(grade);
        }
    }

    public double CalculateAverage()
    {
        if (grades.Count == 0) return 0;
        int sum = 0;
        foreach (int grade in grades)
            sum += grade;
        return (double)sum / grades.Count;
    }

    public void DisplayResults()
    {
        Console.WriteLine("\nРезультати:");
        for (int i = 0; i < subjects.Count; i++)
        {
            Console.WriteLine($"{subjects[i]}: {grades[i]}");
        }

        Console.WriteLine($"Середній бал: {CalculateAverage():F2}");
    }

    public void SaveToFile()
    {
        string filename = "StudentGrades.txt";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Оцінки студента:");
            for (int i = 0; i < subjects.Count; i++)
            {
                writer.WriteLine($"{subjects[i]}: {grades[i]}");
            }
            writer.WriteLine($"Середній бал: {CalculateAverage():F2}");
        }
        Console.WriteLine($"Результати збережено у файл {filename}");
    }
}

class Program
{
    static void Main()
    {
        do
        {
            StudentGradeCalculator calc = new StudentGradeCalculator();
            calc.InputGrades();
            calc.DisplayResults();
            calc.SaveToFile();

            Console.Write("\nБажаєте розрахувати ще раз? (так/ні): ");
            string answer = Console.ReadLine().ToLower();
            if (answer != "так")
                break;

            Console.Clear();
        } while (true);

        Console.WriteLine("Дякуємо за використання програми!");
    }
}
