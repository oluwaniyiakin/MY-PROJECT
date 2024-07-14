public abstract class Goal
{
    protected string _name;
    protected int _points;

    public string Name { get { return _name; } }
    public int Points { get { return _points; } }

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetDetails();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
}
