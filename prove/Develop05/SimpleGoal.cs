public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"{Name} completed! Earned {Points} points.");
    }

    public override string GetDetails()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} - {Points} points";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Points},{_isComplete}";
    }

    public static SimpleGoal Create(string details)
    {
        string[] parts = details.Split(',');
        string name = parts[0];
        int points = int.Parse(parts[1]);
        bool isComplete = bool.Parse(parts[2]);

        SimpleGoal goal = new SimpleGoal(name, points)
        {
            _isComplete = isComplete
        };

        return goal;
    }
}
