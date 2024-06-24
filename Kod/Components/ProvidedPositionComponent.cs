public class ProvidedPositionComponent : IPositionComponent
{
    Point position;

    public ProvidedPositionComponent (Point startingPosition)
    {
        position = startingPosition;
    }

    public Point GetPosition()
    {
        return position;
    }
}