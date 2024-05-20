public class NPC
{
    public int ZnacznikWTablicy { get; set; } = 4;
    public Point Position { get; set; }

    public NPC(int x, int y, Map map)
    {

        Position = new Point(x, y);
        map.WrzucNPCa(Position, ZnacznikWTablicy);
    }

    public void Draw(Map map)
    {
        if (map.IsPointCorrect(Position))
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(ZnacznikWTablicy);
        }
    }
}