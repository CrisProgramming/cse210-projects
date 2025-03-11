using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade;
        
        // Validate input
        if (!int.TryParse(input, out grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            return;
        }

        string letter = "";
        string sign = "";
        
        // Determine letter grade
        if (grade >= 90)
            letter = "A";
        else if (grade >= 80)
            letter = "B";
        else if (grade >= 70)
            letter = "C";
        else if (grade >= 60)
            letter = "D";
        else
            letter = "F";
        
        // Determine grade sign (except for A and F cases)
        int lastDigit = grade % 10;
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
                sign = "+";
            else if (lastDigit < 3)
                sign = "-";
        }
        
        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        // Check if the user passed
        if (grade >= 70)
            Console.WriteLine("Congratulations! You passed the course.");
        else
            Console.WriteLine("Keep working hard! You'll do better next time.");
    }
}
