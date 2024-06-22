class Program
{

    static void Main(string[] args)
    {
        Console.ReadKey();

        Map map = new Map();

        ComposedPlayer player = new ComposedPlayer('█', new Point(6, 5));
        ComposedEnemy troll = new ComposedEnemy('T', "Troll", new Point(6, 8));
        ComposedObject healthPotion = new ComposedObject('O', "Health Potion", map);
        ComposedNpc hoodedFigure = new ComposedNpc('*', "Hooded Figure", new Point(15, 16));

        Point mapOrigin = new Point(4, 1);

        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;
        Console.Clear();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >= 0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            map.DrawSomethingAt(player.VisualComponent.Visual, player.PositionComponent.Position);
            map.DrawSomethingAt(troll.VisualComponent.Visual, troll.PositionComponent.Position);
            map.DrawSomethingAt(healthPotion.VisualComponent.Visual, healthPotion.PositionComponent.Position);
            map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.PositionComponent.Position);

            while (true)
            {
                Point nextPosition = player.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    player.Movement.Move(nextPosition);

                    map.RedrawCellAt(player.Movement.PreviousPosition);
                    map.DrawSomethingAt(player.VisualComponent.Visual, player.PositionComponent.Position);

                    if (player.InteractionComponent.IsTargetInRange(troll.PositionComponent.Position))
                    {
                        WriteTextLine($"Troll is nearby! Press E to Attack or Any other key to continue...");

                        ConsoleKeyInfo pressedKey;
                        pressedKey = Console.ReadKey();
                        if (pressedKey.Key == ConsoleKey.E)
                        {
                            player.InteractionComponent.Attack(troll.Health);
                            ClearTextLine(0);
                            WriteTextLine($"You attacked the Enemy! Enemy health:{troll.Health.Hp}");
                        }
                        else
                        {
                            ClearTextLine(0);
                            WriteTextLine("You ran away!");
                        }

                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(new string(' ', Console.WindowWidth));
                    }
                }

                nextPosition = troll.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    troll.Movement.Move(nextPosition);

                    map.RedrawCellAt(troll.Movement.PreviousPosition);
                    map.DrawSomethingAt(troll.VisualComponent.Visual, troll.PositionComponent.Position);
                }

                nextPosition = hoodedFigure.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    hoodedFigure.Movement.Move(nextPosition);

                    map.RedrawCellAt(hoodedFigure.Movement.PreviousPosition);
                    map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.PositionComponent.Position);
                }
            }
        }
        else
        {
            Console.WriteLine("Terminal window is too small, make it bigger");
            Console.ReadKey(true); 
        }
    }

    public static void ClearTextLine(int row)
    {
        int currentLineCursor = row;
        Console.SetCursorPosition(0, row);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public static void WriteTextLine(string text)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(text);
    }
}