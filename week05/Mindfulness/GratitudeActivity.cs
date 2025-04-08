using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Gratitude", "This activity helps you practice gratitude by writing things you are thankful for.") { }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Think of things you’re grateful for. Type one per line.");
        Countdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            if (!string.IsNullOrEmpty(Console.ReadLine()))
                count++;
        }

        Console.WriteLine($"You listed {count} grateful thoughts.");
        DisplayEndingMessage();
    }
}