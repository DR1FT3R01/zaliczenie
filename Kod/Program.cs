
// idk

class Program
{
    static void Main(string[] args) //?
    {
        Console.CursorVisible = false;
       
        //Console.ReadKey();  //uncomment this later

        Map map = new Map();

        Point playerPosition = new Point(6, 5);
        Player player = new Player(playerPosition);

        player.CurrentMap = map;    //?

        NPC npc = new NPC(14, 16, map);

        Console.SetCursorPosition(0, 0);    //?
        Console.Clear();
        map.DisplayMap(new Point (5, 2));

        npc.Draw(map);

        map.DrawSomethingAt (player.Visual, player.Position);

        while (true)
        {


            Point nextPosition = player.GetNextPosition();
            if (map.IsPointCorrect(nextPosition))
            {
                //continue
                player.Move(nextPosition);  //?
            }
            //player.Move(nextPosition);

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

            map.RedrawCellAt(player.PreviousPosition);
            map.DrawSomethingAt (player.Visual, player.Position);

        }
    }

}