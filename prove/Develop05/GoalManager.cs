using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        Goal goal = _goals[goalIndex];
        goal.RecordEvent();
        _score += goal.Points;

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            _score += checklistGoal.GetBonusPoints();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string details = parts[1];

            if (type == "SimpleGoal")
            {
                _goals.Add(SimpleGoal.Create(details));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(EternalGoal.Create(details));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(ChecklistGoal.Create(details));
            }
            else if (type == "LevelGoal")
            {
                _goals.Add(LevelGoal.Create(details));
            }
        }
    }

    public int Score { get { return _score; } }
}
