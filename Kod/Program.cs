class Program
{
    static void Main(string[] args) //?
    {

        Console.ReadKey();

        Player player = new Player('█', new Point(6, 5));
        Enemy troll =new Enemy('T', new Point(8,8));
        NPC npc = new NPC('*', new Point (14, 16));
        
        Map map = new Map();

        //player.CurrentMap = map;    //?


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
            map.DrawSomethingAt(troll.Visual, troll.Position);

            while (true)
            {

                Point nextPosition = player.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    player.Move(nextPosition);
                    map.RedrawCellAt(player.PreviousPosition);
                    map.DrawSomethingAt(player.Visual, player.Position);
                }

                //-----

                Point npcNextPosition = npc.GetNextPosition();
                if (map.IsPointCorrect(npcNextPosition))
                {
                    npc.Move(npcNextPosition);

                    map.RedrawCellAt(npc.PreviousPosition);
                    map.DrawSomethingAt(npc.Visual, npc.Position);
                }

                //-----

                Point trollNextPosition = troll.GetNextPosition();
                if (map.IsPointCorrect(trollNextPosition))
                {
                    troll.Move(trollNextPosition);

                    map.RedrawCellAt(troll.PreviousPosition);
                    map.DrawSomethingAt(troll.Visual, troll.Position);
                }
            }
        }
        else
        {
            Console.WriteLine("Terminal window is to small, make it bigger");
        }
    }
}