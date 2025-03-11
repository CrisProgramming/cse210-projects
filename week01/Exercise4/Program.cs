using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            
            if (num == 0)
                break;
            
            numbers.Add(num);
        }

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int maxNumber = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {maxNumber}");
            
            // Stretch Challenge
            int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
