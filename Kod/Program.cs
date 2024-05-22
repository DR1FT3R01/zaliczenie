
// idk

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
        Map map = new Map();

        Point playerPosition = new Point(6, 5);
        Player player = new Player(playerPosition);
        player.CurrentMap = map;
        NPC npc = new NPC(14, 16, map);

        Console.SetCursorPosition(0, 0);
        map.DisplayMap();

        npc.Draw(map);

        Console.SetCursorPosition(player.Position.X, player.Position.Y);
        Console.Write("█");
        Console.CursorVisible = false;

        while (true)
        {


            Point nextPosition = player.GetNextPosition();
            if (map.IsPointCorrect(nextPosition))
            {
                player.Move(nextPosition);
            }

            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.Write("█");

            Random random = new Random();
            Point nextNpcPosition = new(random.Next(-1, 2), random.Next(-1, 2));
            nextNpcPosition.X += npc.Position.X;
            nextNpcPosition.Y += npc.Position.Y;
            if (map.IsPointCorrect(nextNpcPosition))
            {
                npc.Move(nextNpcPosition);
            }
            
            Console.SetCursorPosition(npc.Position.X, npc.Position.Y);
            Console.Write("*");


            Console.CursorVisible = false;
        }
    }
}