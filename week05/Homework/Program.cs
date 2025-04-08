using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Assignment
        Assignment assignment = new Assignment("Elizabeth Hernandez", "Biology");
        Console.WriteLine(assignment.GetSummary());

        Console.WriteLine();

        // Test MathAssignment
        MathAssignment mathAssignment = new MathAssignment("Carlos Rivera", "Algebra", "5.2", "1-10, 15-18");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        Console.WriteLine();

        // Test WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Ana Martinez", "Literature", "The Symbolism in Modern Poetry");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}