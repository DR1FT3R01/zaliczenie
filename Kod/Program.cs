class Program
{

    static void Main(string[] args)
    {
        GameLogic gameLogic= new GameLogic();

        gameLogic.StartingScreen();
        
        Map map = new Map();
        Point mapOrigin = new Point(4, 2);

        ComposedPlayer player = new ComposedPlayer('█', ConsoleColor.Cyan, new Point(9, 4));
        ComposedEnemy troll = new ComposedEnemy('T', ConsoleColor.Green, "Troll", new Point(40, 25));
        ComposedObject healthPotion = new ComposedObject('O', ConsoleColor.Red, "Health Potion", map);
        ComposedNpc hoodedFigure = new ComposedNpc('*', ConsoleColor.Yellow, "Hooded Figure", new Point(60, 6));

        gameLogic.ClearTerminal();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >= 0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            map.DrawSomethingAt(player.VisualComponent.Visual, player.VisualComponent.VisualColor, player.PositionComponent.Position);
            map.DrawSomethingAt(troll.VisualComponent.Visual, troll.VisualComponent.VisualColor, troll.PositionComponent.Position);
            map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.VisualComponent.VisualColor, hoodedFigure.PositionComponent.Position);

            map.DrawSomethingAt(healthPotion.VisualComponent.Visual, healthPotion.VisualComponent.VisualColor, healthPotion.PositionComponent.Position);

            while (true)
            {
                Point nextPosition = player.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    player.Movement.Move(nextPosition);

                    map.RedrawCellAt(player.Movement.PreviousPosition);
                    map.DrawSomethingAt(player.VisualComponent.Visual, player.VisualComponent.VisualColor, player.PositionComponent.Position);
                    
                    //=== IsEnemyInRange

                    if (player.InteractionComponent.IsTargetInRange(troll.PositionComponent.Position) && troll.Health.IsAlive())
                    {
                        WriteTextLine($"{troll.NameTagComponent.NameTag} is nearby! Press E to Attack or Any other key to continue...");
                        if (player.InteractionComponent.CheckPressedKey())
                        {
                            player.InteractionComponent.Attack(troll.Health, troll.NameTagComponent.NameTag);
                            
                            if(!troll.Health.IsAlive())
                            {
                                map.RedrawCellAt(troll.PositionComponent.Position);
                                WriteTextLine("You killed the Enemy!");
                            }
                        }
                        else
                        {
                            WriteTextLine("Nothing happened!");
                        }
                    }

                    //=== IsNPCInRange
                    
                    else if (player.InteractionComponent.IsTargetInRange(hoodedFigure.PositionComponent.Position))
                    {
                        WriteTextLine($"{hoodedFigure.NameTagComponent.NameTag} is nearby! Press E to Interact or Any other key to continue...");

                        if (player.InteractionComponent.CheckPressedKey())
                        {
                            player.InteractionComponent.StartDialogue();
                        }
                        else
                        {
                            WriteTextLine("Nothing happened!");
                        }
                    }
                    
                    //=== IsObjectInRange
                    
                    else if (player.InteractionComponent.IsTargetInRange(healthPotion.PositionComponent.Position) && healthPotion.isPickedUp == false)
                    {
                        WriteTextLine($"{healthPotion.NameTagComponent.NameTag} is nearby! Press E to Pick up or Any other key to continue...");

                        if (player.InteractionComponent.CheckPressedKey())
                        {
                            player.InteractionComponent.PickUp(healthPotion, 1);
                            map.RedrawCellAt(healthPotion.PositionComponent.Position);
                        }
                        else
                        {
                            map.DrawSomethingAt(healthPotion.VisualComponent.Visual, healthPotion.VisualComponent.VisualColor, healthPotion.PositionComponent.Position);
                            WriteTextLine("Nothing happened!");
                        }
                    }
                    
                    //=== NothingInRange
                    
                    else
                    {
                        ClearTextLine();
                    }
                }

                nextPosition = troll.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    if(troll.Health.IsAlive())
                    {
                    troll.Movement.Move(nextPosition);

                    map.RedrawCellAt(troll.Movement.PreviousPosition);
                    map.DrawSomethingAt(troll.VisualComponent.Visual, troll.VisualComponent.VisualColor, troll.PositionComponent.Position);
                    }
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
            gameLogic.TerminalIsToSmallError();
        }
    }

    public static void ClearTextLine()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string(' ', Console.WindowWidth));
    }

    public static void WriteTextLine(string text)
    {
        ClearTextLine();
        Console.SetCursorPosition(0, 0);
        Console.Write(text);
    }
}