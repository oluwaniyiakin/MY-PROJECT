public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"{Name} recorded! Earned {Points} points.");
    }

    public override string GetDetails()
    {
        return $"{Name} - {Points} points (Eternal)";
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Points}";
    }

    public static EternalGoal Create(string details)
    {
        string[] parts = details.Split(',');
        string name = parts[0];
        int points = int.Parse(parts[1]);

        return new EternalGoal(name, points);
    }
}
