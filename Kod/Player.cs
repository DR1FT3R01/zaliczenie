class Player
{

   public Point Position {get; set;}

   private Dictionary<ConsoleKey, Point> directions = new() 
   {
        {ConsoleKey.A, new Point(-1,0)}
   };

   public Player(int x, int y)
   {
    Position = new Point(x, y);
   }

   public Player (Point startingPosition)
   {
        Position = new Point(startingPosition);

        directions[ConsoleKey.D] = new Point(1, 0);
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
    }

    public void Move()
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

        if (directions.ContainsKey(pressedKey.Key))
        {
            Point direction = directions[pressedKey.Key];
            Position.X += direction.X;
            Position.Y += direction.Y;
        }

    }
}