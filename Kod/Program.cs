class Program
{
    static void Main(string[] args) //?
    {

        //Console.ReadKey();  //uncomment this later

        Point playerPosition = new Point(6, 5);
        Player player = new Player(playerPosition);
        Map map = new Map();

        player.CurrentMap = map;    //?

        NPC npc = new NPC(14, 16, map);
        Point mapOrigin = new Point(5, 2);

        Console.SetCursorPosition(0, 0);    //?
        Console.CursorVisible = false;
        Console.Clear();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >=0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            map.DrawSomethingAt(npc.Visual, npc.Position);
            map.DrawSomethingAt(player.Visual, player.Position);

            while (true)
            {

                Point nextPosition = player.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    //continue
                    player.Move(nextPosition);  //?
                }
                //player.Move(nextPosition);

                map.RedrawCellAt(player.PreviousPosition);
                map.DrawSomethingAt(player.Visual, player.Position);

                /*
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
                */

                //player.Move(nextPosition);  //?

            }
        }
        else
        {
            Console.WriteLine("Terminal window is to small, make it bigger");
        }
    }
}