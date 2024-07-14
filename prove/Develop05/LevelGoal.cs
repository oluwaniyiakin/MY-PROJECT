public class LevelGoal : Goal
{
    private int _level;
    private int _currentLevel;

    public LevelGoal(string name, int points, int level) : base(name, points)
    {
        _level = level;
        _currentLevel = 0;
    }

    public override void RecordEvent()
    {
        _currentLevel++;
        Console.WriteLine($"{Name} progress recorded! Earned {Points} points.");

        if (_currentLevel == _level)
        {
            Console.WriteLine($"{Name} level completed!");
        }
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} - {Points} points - Level {_currentLevel}/{_level}";
    }

    public override bool IsComplete()
    {
        return _currentLevel >= _level;
    }

    public override string GetStringRepresentation()
    {
        return $"LevelGoal:{Name},{Points},{_level},{_currentLevel}";
    }

    public static LevelGoal Create(string details)
    {
        string[] parts = details.Split(',');
        string name = parts[0];
        int points = int.Parse(parts[1]);
        int level = int.Parse(parts[2]);
        int currentLevel = int.Parse(parts[3]);

        LevelGoal goal = new LevelGoal(name, points, level)
        {
            _currentLevel = currentLevel
        };

        return goal;
    }
}
