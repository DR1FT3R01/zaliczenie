public class NPC
{
    public char Visual { get; set; } = '*';
    //public int ZnacznikWTablicy { get; set; } = 4;
    public Point Position { get; set; }
    public Point PreviousPosition { get; set; }
    public Map CurrentMap { get; set; }
    public NPC(int x, int y, Map map)
    {

        Position = new Point(x, y);
        PreviousPosition = new Point(x, y);

        CurrentMap = map;
        Dialogue = "";

    }

    public void Draw(Map map)
    {
        if (map.IsPointCorrect(Position))
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            //Console.Write(map.cellVisuals[ZnacznikWTablicy]);
            Console.Write(Visual);
        }
    }
    public void Move(Point targetPosition)
    {


        PreviousPosition.X = Position.X;
        PreviousPosition.Y = Position.Y;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(CurrentMap.GetCellVisualAt(Position));
        Position.X = targetPosition.X;
        Position.Y = targetPosition.Y;
    }

    Dictionary<ConsoleKey, Point> directions = new Dictionary<ConsoleKey, Point>()
{
    { ConsoleKey.W, new Point(0, -1) },  // Up
    { ConsoleKey.A, new Point(-1, 0) },  // Left
    { ConsoleKey.S, new Point(0, 1) },   // Down
    { ConsoleKey.D, new Point(1, 0) },   // Right
    { ConsoleKey.Q, new Point(-1, -1) }, // Up-left
    { ConsoleKey.E, new Point(1, -1) },  // Up-right
    { ConsoleKey.Z, new Point(-1, 1) },  // Down-left
    { ConsoleKey.C, new Point(1, 1) }    // Down-right
};

    private Point GetNextPosition()
    {
        // Generate a random direction for the NPC to move in
        var random = new Random();
        var directionKeys = new List<ConsoleKey>(directions.Keys);
        var randomDirection = directionKeys[random.Next(directionKeys.Count)];

        var nextPosition = new Point(Position.X + directions[randomDirection].X, Position.Y + directions[randomDirection].Y);
        return nextPosition;
    }

    public string Dialogue { get; set; } = "lalalaa dopisac";

    public void Interact(Player player)
    {
        // Wyświetl dialog NPC
        Console.WriteLine(Dialogue);
    }
}