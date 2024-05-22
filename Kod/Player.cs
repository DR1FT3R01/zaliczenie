class Player
{
   public Point Position {get; set;}
   public Point PreviousPosition {get; set;}
    public Map CurrentMap { get; set;}

   private Dictionary<ConsoleKey, Point> directions = new() 
   {
        {ConsoleKey.A, new Point(-1,0)}         //??
   };

   public Player(int x, int y)
   {
    Position = new Point(x, y);
    PreviousPosition = new Point(x, y);
   }

   public Player (Point startingPosition)
   {
        Position = new Point(startingPosition);
        PreviousPosition = new Point(startingPosition);

        directions[ConsoleKey.D] = new Point(1, 0);
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
    }

    public Player (Player other)
    {
        Position = new Point(other.Position);
        PreviousPosition = new Point(other.PreviousPosition);
    }

    public Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);

        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X += directions[pressedKey.Key].X;
            nextPosition.Y += directions[pressedKey.Key].Y;
        }

        return  nextPosition;
    }

    public void Move(Point targetPosition)
    {
        PreviousPosition.X = Position.X;
        PreviousPosition.Y = Position.Y;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(CurrentMap.GetCellVisualAt(Position));
        Position.X = targetPosition.X;
        Position.Y = targetPosition.Y;
        
        // ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        // if (directions.ContainsKey(pressedKey.Key))
        // {
        //     Point direction = directions[pressedKey.Key];
        //     Position.X += direction.X;
        //     Position.Y += direction.Y;
        // }

    }
    public Point GetDirection(ConsoleKey key)
    {
        if (directions.ContainsKey(key))
        {
            return directions[key];
        }
        else
        {
          
            return new Point(0, 0);
        }
    }

}
