internal class RandomPositionComponent
{
    Random rng;

    public Point Position { get; set; }


    public RandomPositionComponent(Map map)
    {
        rng = new Random();
        do
        {

            Position = new Point(rng.Next(-1, map.Size.X), rng.Next(-1, map.Size.Y));

        } while (!map.IsPointCorrect(Position));
    }
}