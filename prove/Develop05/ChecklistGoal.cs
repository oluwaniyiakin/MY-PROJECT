public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int requiredCount, int bonusPoints) : base(name, points)
    {
        _requiredCount = requiredCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        Console.WriteLine($"{Name} recorded! Earned {Points} points.");

        if (_currentCount == _requiredCount)
        {
            Console.WriteLine($"{Name} completed! Earned bonus of {_bonusPoints} points.");
        }
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} - {Points} points - Completed {_currentCount}/{_requiredCount} times";
    }

    public override bool IsComplete()
    {
        return _currentCount >= _requiredCount;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Points},{_requiredCount},{_currentCount},{_bonusPoints}";
    }

    public static ChecklistGoal Create(string details)
    {
        string[] parts = details.Split(',');
        string name = parts[0];
        int points = int.Parse(parts[1]);
        int requiredCount = int.Parse(parts[2]);
        int currentCount = int.Parse(parts[3]);
        int bonusPoints = int.Parse(parts[4]);

        ChecklistGoal goal = new ChecklistGoal(name, points, requiredCount, bonusPoints)
        {
            _currentCount = currentCount
        };

        return goal;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
}
