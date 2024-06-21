class Program
{

    static void Main(string[] args)
    {
        Console.ReadKey();

        Map map = new Map();

        ComposedPlayer composedPlayer = new ComposedPlayer('█', new Point(6, 5));
        ComposedEnemy composedEnemy = new ComposedEnemy('T', new Point(6, 8));
        ComposedObject composedObject = new ComposedObject('O', map);

        Point mapOrigin = new Point(5, 2);

        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;
        Console.Clear();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >= 0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            map.DrawSomethingAt(composedPlayer.VisualComponent.Visual, composedPlayer.PositionComponent.Position);
            map.DrawSomethingAt(composedEnemy.VisualComponent.Visual, composedEnemy.PositionComponent.Position);
            map.DrawSomethingAt(composedObject.VisualComponent.Visual, composedObject.RandomPositionComponent.Position);

            while (true)
            {
                Point nextPosition = composedPlayer.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    composedPlayer.Movement.Move(nextPosition);

                    map.RedrawCellAt(composedPlayer.Movement.PreviousPosition);
                    map.DrawSomethingAt(composedPlayer.VisualComponent.Visual, composedPlayer.PositionComponent.Position);

                    if (composedPlayer.DamageComponent.IsTargetInRange(composedEnemy.PositionComponent.Position))
                    {
                        WriteTextLine($"Enemy with health {composedEnemy.Health.Hp} nearby! Press E to Attack or Any other key to continue...");

                        ConsoleKeyInfo pressedKey;
                        pressedKey = Console.ReadKey();
                        if (pressedKey.Key == ConsoleKey.E)
                        {
                            composedPlayer.DamageComponent.Attack(composedEnemy.Health);
                            ClearTextLine(0);
                            WriteTextLine($"You attacked the Enemy! Enemy health:{composedEnemy.Health.Hp}");
                        }
                        else
                        {
                            ClearTextLine(0);
                            WriteTextLine("You dodged the enemy attack!");
                        }

                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(new string(' ', Console.WindowWidth));
                    }
                }

                nextPosition = composedEnemy.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    composedEnemy.Movement.Move(nextPosition);

                    map.RedrawCellAt(composedEnemy.Movement.PreviousPosition);
                    map.DrawSomethingAt(composedEnemy.VisualComponent.Visual, composedEnemy.PositionComponent.Position);
                }
            }
        }
        else
        {
            Console.WriteLine("Terminal window is to small, make it bigger");
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