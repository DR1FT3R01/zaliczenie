class Program
{
    static void Main(string[] args) //?
    {

        Console.ReadKey();

        Player player = new Player('█', new Point(6, 5));
        Enemy troll = new Enemy('T', new Point(8, 8));
        NPC npc = new NPC('*', new Point(14, 16));

        Character[] characters = new Character[]
        {
            player,
            troll,
            npc
        };

        Map map = new Map();

        //player.CurrentMap = map;    //?


        Point mapOrigin = new Point(5, 2);

        Console.SetCursorPosition(0, 0);    //?
        Console.CursorVisible = false;
        Console.Clear();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >= 0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            foreach (var character in characters)
            {
                map.DrawSomethingAt(character.Visual, character.Position);
            }

            while (true)
            {
                foreach (var character in characters)
                {
                    Point nextPosition = character.GetNextPosition();
                    if (map.IsPointCorrect(nextPosition))
                    {
                        character.Move(nextPosition);
                        map.RedrawCellAt(character.PreviousPosition);
                        map.DrawSomethingAt(character.Visual, character.Position);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Terminal window is to small, make it bigger");
        }
    }
}