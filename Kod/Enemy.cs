class Enemy : Character
{
    Random rng;

    public Enemy(char visual, Point startingPosition) : base(visual, startingPosition)
    {
        rng = new Random();
    }
    public override Point GetNextPosition ()
    {
        Point nextPosition = new Point (Position);

        nextPosition.X += rng.Next(-1,2);
        nextPosition.Y += rng.Next(-1,2);

        return nextPosition;
    }
}