using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. View all goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goalManager);
                    break;
                case "2":
                    ViewGoals(goalManager);
                    break;
                case "3":
                    RecordEvent(goalManager);
                    break;
                case "4":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager goalManager)
    {
        Console.Clear();
        Console.WriteLine("Create a new goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal short name: ");
        string shortName = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for goal: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            SimpleGoal newGoal = new SimpleGoal(shortName, description, points);
            goalManager.AddGoal(newGoal);
            Console.WriteLine("Simple Goal created!");
        }
        else if (goalType == "2")
        {
            EternalGoal newGoal = new EternalGoal(shortName, description, points);
            goalManager.AddGoal(newGoal);
            Console.WriteLine("Eternal Goal created!");
        }
        else if (goalType == "3")
        {
            Console.Write("Enter target for checklist goal: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus for checklist goal: ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal newGoal = new ChecklistGoal(shortName, description, points, target, bonus);
            goalManager.AddGoal(newGoal);
            Console.WriteLine("Checklist Goal created!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static void ViewGoals(GoalManager goalManager)
    {
        Console.Clear();
        Console.WriteLine("Your Goals:");
        List<Goal> goals = goalManager.GetGoals();

        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static void RecordEvent(GoalManager goalManager)
    {
        Console.Clear();
        Console.WriteLine("Which goal did you complete?");
        List<Goal> goals = goalManager.GetGoals();

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.Write("Enter goal number: ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber >= 1 && goalNumber <= goals.Count)
        {
            Goal selectedGoal = goals[goalNumber - 1];
            selectedGoal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }
}