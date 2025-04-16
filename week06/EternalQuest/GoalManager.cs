using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Add a new goal to the list
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    // Get the list of all goals
    public List<Goal> GetGoals()
    {
        return _goals; 
    }

    // List all goals
    public void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    // Record an event for a goal
    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            if (goal is ChecklistGoal checklist && checklist.IsComplete())
            {
                _score += checklist.GetBonusPoints();
            }
            else
            {
                _score += goal.GetPoints();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    // Get the current score
    public int GetScore()
    {
        return _score;
    }

    // Save goals to a file
    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    // Load goals from a file
    public void LoadGoals(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string goalType = parts[0];
            string data = parts[1];

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data));
                    break;
            }
        }
    }
}