class NPC : Character
{
    // public char Visual { get; set; } = '*';
    // public Point Position { get; set; }
    // public Point PreviousPosition { get; set; }
    Random rng;

        public NPC(char visual, Point startingPoint) : base(visual, startingPoint)
    {
        rng = new Random();

        //CurrentMap = map;
        //Dialogue = "";
    }
    public override Point GetNextPosition()
    {
        Point nextPosition = new Point (Position);

        nextPosition.X += rng.Next(-1,2);
        nextPosition.Y += rng.Next(-1,2);

        return nextPosition;
    }

    public string Dialogue { get; set; } = "lalalaa dopisac";

    public void Interact(Player player)
    {
        // Wyświetl dialog NPC
        Console.WriteLine(Dialogue);
    }
}