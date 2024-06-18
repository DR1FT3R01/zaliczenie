class RandomInputComponent : InputComponent
{
    Random rng;

    public RandomInputComponent()
    {
        rng = new Random();
    }

    public override Point GetDirection()
    {
        //TODO delete diagonally walking
        return new Point(rng.Next(-1,2), rng.Next(-1,2));
    }
}