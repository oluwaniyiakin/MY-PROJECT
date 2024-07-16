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

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();

            _score += goal.Points;

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonusPoints();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
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
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetType().Name);
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void Load(string filename)
    {
        _goals.Clear();
        _score = 0;

        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                string type = reader.ReadLine();
                string details = reader.ReadLine();

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
    }

    public int Score { get { return _score; } }
}
