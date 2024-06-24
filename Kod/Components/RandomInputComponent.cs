class RandomInputComponent : IInputComponent
{
    Random rng;

    public RandomInputComponent()
    {
        rng = new Random();
    }

    public Point GetDirection()
    {
        int x = rng.Next(-1,2);
        int y = 0;
        if (x == 0)
        {
            y = rng.Next(-1,2);
        }
        return new Point(x, y);
    }
}