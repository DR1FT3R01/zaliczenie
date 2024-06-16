internal class KeyboardInputComponent : InputComponent
{
    private Dictionary<ConsoleKey, Point> directions;

    public KeyboardInputComponent()
    {
        directions = new()
        {
            [ConsoleKey.W] = new Point(0, -1),
            [ConsoleKey.A] = new Point(-1, 0),
            [ConsoleKey.S] = new Point(0, 1),
            [ConsoleKey.D] = new Point(1, 0),
        };
    }

    public override Point GetDirection()
    {

        Point nextPosition = new Point(0, 0);

        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X += directions[pressedKey.Key].X;
            nextPosition.Y += directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }
}