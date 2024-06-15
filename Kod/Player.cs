class Player : Character
{
    //public Map CurrentMap { get; set; }

    private Dictionary<ConsoleKey, Point> directions = new()
    {
        {ConsoleKey.A, new Point(-1,0)}         //??
    };

    public Player(char visual, Point startingPosition) : base(visual, startingPosition)
    {
        directions[ConsoleKey.D] = new Point(1, 0);
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
        //CurrentMap = new Map();
    }

    public override Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);

        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X += directions[pressedKey.Key].X;
            nextPosition.Y += directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }

    // public Point GetDirection(ConsoleKey key)
    // {
    //     if (directions.ContainsKey(key))
    //     {
    //         return directions[key];
    //     }
    //     else
    //     {

    //         return new Point(0, 0);
    //     }
    // }

}
