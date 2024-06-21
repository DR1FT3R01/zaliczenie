class RandomInputComponent : IInputComponent
{
    Random rng;

    public RandomInputComponent()
    {
        rng = new Random();
    }

    public Point GetDirection()
    {
        //TODO delete diagonally walking
        return new Point(rng.Next(-1,2), rng.Next(-1,2));
    }
}