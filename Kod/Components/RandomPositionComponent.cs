internal class RandomPositionComponent : IPositionComponent
{
    Random rng;
    Point position;
    Map map;

    public RandomPositionComponent(Map currentMap)
    {
        rng = new Random();
        map = currentMap;
        do
        {
            position = new Point(rng.Next(-1, map.Size.X), rng.Next(-1, map.Size.Y));

        } while (!map.IsPointCorrect(position));
    }

    public Point GetPosition()
    {
        return position;
    }
}