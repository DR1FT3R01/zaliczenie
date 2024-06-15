abstract class Character
{
    public char Visual { get; set; }
    public int Hp
    {
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 100;
    public int MaxHp { get; set; } = 100;
    public Point Position { get; set; }
    public Point PreviousPosition { get; set; }

    public Character (int x, int y)
    {
        Position = new Point (x, y);
        PreviousPosition = new Point (x, y);
    }

    public Character (char visual, Point startingPosition)
    {
        Visual = visual;
        Position = new Point(startingPosition);
        PreviousPosition = new Point(startingPosition);
    }

    //copy constructor
    public Character(Player other)
    {
        MaxHp = other.MaxHp;
        Hp = other.Hp;
        Position = new Point (other.Position);
        PreviousPosition = new Point (other.PreviousPosition);
    }

    public void Heal (int amount)
    {
        Console.WriteLine ("Healing!");
        Hp =+ amount;
    }

    public abstract Point GetNextPosition ();

    public void Move (Point targetPosition)
    {
        PreviousPosition.X = Position.X;
        PreviousPosition.Y = Position.Y;

        Position.X = targetPosition.X;
        Position.Y = targetPosition.Y;
    }
}