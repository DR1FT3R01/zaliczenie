class Program
{

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        WriteTextLine("Press Any key to start...");
        Console.ReadKey(true);

        Map map = new Map();

        ComposedPlayer player = new ComposedPlayer('█', ConsoleColor.Cyan, new Point(9, 4));
        ComposedEnemy troll = new ComposedEnemy('T', ConsoleColor.Green, "Troll", new Point(40, 25));
        ComposedObject healthPotion = new ComposedObject('O', ConsoleColor.Red, "Health Potion", map);
        ComposedNpc hoodedFigure = new ComposedNpc('*', ConsoleColor.Yellow, "Hooded Figure", new Point(60, 6));

        Point mapOrigin = new Point(4, 2);

        Console.SetCursorPosition(0, 0);
        Console.Clear();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >= 0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            map.DrawSomethingAt(player.VisualComponent.Visual, player.VisualComponent.VisualColor, player.PositionComponent.Position);
            map.DrawSomethingAt(troll.VisualComponent.Visual, troll.VisualComponent.VisualColor, troll.PositionComponent.Position);
            map.DrawSomethingAt(healthPotion.VisualComponent.Visual, healthPotion.VisualComponent.VisualColor, healthPotion.PositionComponent.Position);
            map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.VisualComponent.VisualColor, hoodedFigure.PositionComponent.Position);

            while (true)
            {
                Point nextPosition = player.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    player.Movement.Move(nextPosition);

                    map.RedrawCellAt(player.Movement.PreviousPosition);
                    map.DrawSomethingAt(player.VisualComponent.Visual, player.VisualComponent.VisualColor, player.PositionComponent.Position);

                    ConsoleKeyInfo pressedKey;
                    if (player.InteractionComponent.IsTargetInRange(troll.PositionComponent.Position))
                    {
                        WriteTextLine($"Troll is nearby! Press E to Attack or Any other key to continue...");

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
                            WriteTextLine("Nothing happened!");
                        }

                    }
                    else if (player.InteractionComponent.IsTargetInRange(hoodedFigure.PositionComponent.Position))
                    {
                        WriteTextLine($"Hooded Figure is nearby! Press E to Interact or Any other key to continue...");

                        pressedKey = Console.ReadKey();
                        if (pressedKey.Key == ConsoleKey.E)
                        {
                            player.InteractionComponent.StartDialogue();
                        }
                        else
                        {
                            ClearTextLine(0);
                            WriteTextLine("Nothing happened!");
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
                    map.DrawSomethingAt(troll.VisualComponent.Visual, troll.VisualComponent.VisualColor, troll.PositionComponent.Position);
                }

                nextPosition = hoodedFigure.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    hoodedFigure.Movement.Move(nextPosition);

                    map.RedrawCellAt(hoodedFigure.Movement.PreviousPosition);
                    map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.VisualComponent.VisualColor, hoodedFigure.PositionComponent.Position);
                }
            }
        }
        else
        {
            WriteTextLine("Terminal window is too small, make it bigger");
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