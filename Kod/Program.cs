class Program
{

    static void Main(string[] args)
    {
        GameLogic gameLogic = new GameLogic();

        gameLogic.StartingScreen();

        Map map = new Map();
        Point mapOrigin = new Point(4, 2);
        Point inventoryPosition = new Point(77, 2);

        ComposedPlayer player = new ComposedPlayer('█', ConsoleColor.Cyan, new Point(9, 4));
        ComposedEnemy troll = new ComposedEnemy('T', ConsoleColor.Green, "Troll", map);
        ComposedObject healthPotion = new ComposedObject('&', ConsoleColor.Red, "Health Potion", map);
        ComposedNpc hoodedFigure = new ComposedNpc('*', ConsoleColor.Yellow, "Hooded Figure", map);

        gameLogic.ClearTerminal();

        if (map.Size.X + mapOrigin.X >= 0 && map.Size.X + mapOrigin.X < Console.BufferWidth
            && map.Size.Y + mapOrigin.Y >= 0 && map.Size.Y + mapOrigin.Y < Console.BufferHeight)
        {
            map.DisplayMap(mapOrigin);

            map.DrawSomethingAt(player.VisualComponent.Visual, player.VisualComponent.VisualColor, player.PositionComponent.GetPosition());
            map.DrawSomethingAt(troll.VisualComponent.Visual, troll.VisualComponent.VisualColor, troll.PositionComponent.GetPosition());
            map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.VisualComponent.VisualColor, hoodedFigure.PositionComponent.GetPosition());
            map.DrawSomethingAt(healthPotion.VisualComponent.Visual, healthPotion.VisualComponent.VisualColor, healthPotion.PositionComponent.GetPosition());

            map.UpdatePlayerStats(inventoryPosition, mapOrigin, player.Health.Hp, player.Inventory.HealthPotionAmount);

            while (player.Health.IsAlive())
            {

                Point nextPosition = player.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    player.Movement.Move(nextPosition);

                    map.RedrawCellAt(player.Movement.PreviousPosition);
                    map.DrawSomethingAt(player.VisualComponent.Visual, player.VisualComponent.VisualColor, player.PositionComponent.GetPosition());

                    //=== IsEnemyInRange

                    if (player.InteractionComponent.IsTargetInRange(troll.PositionComponent.GetPosition()) && troll.Health.IsAlive())
                    {
                        gameLogic.WriteTextLine($"{troll.NameTagComponent.NameTag} is nearby! Press E to Attack or Any other key to continue...");
                        if (player.InteractionComponent.IsPressedKeyCorrect())
                        {
                            player.AttackComponent.Attack(troll.Health);
                            gameLogic.WriteTextLine($"You attacked the Enemy! {troll.NameTagComponent.NameTag} health:{troll.Health.Hp}");

                            if (!troll.Health.IsAlive())
                            {
                                map.RedrawCellAt(troll.PositionComponent.GetPosition());
                                gameLogic.WriteTextLine("You killed the Enemy!");
                            }
                        }
                        else
                        {
                            gameLogic.WriteTextLine("Nothing happened!");
                        }
                    }

                    //=== IsNPCInRange

                    else if (player.InteractionComponent.IsTargetInRange(hoodedFigure.PositionComponent.GetPosition()))
                    {
                        gameLogic.WriteTextLine($"{hoodedFigure.NameTagComponent.NameTag} is nearby! Press E to Interact or Any other key to continue...");

                        if (player.InteractionComponent.IsPressedKeyCorrect())
                        {
                            hoodedFigure.Dialogue.StartDialogue(player.Inventory);
                            map.UpdatePlayerStats(inventoryPosition, mapOrigin, player.Health.Hp, player.Inventory.HealthPotionAmount);
                        }
                        else
                        {
                            gameLogic.WriteTextLine("Nothing happened!");
                        }
                    }

                    //=== IsObjectInRange

                    else if (player.InteractionComponent.IsTargetInRange(healthPotion.PositionComponent.GetPosition()) && healthPotion.isPickedUp == false)
                    {
                        gameLogic.WriteTextLine($"{healthPotion.NameTagComponent.NameTag} is nearby! Press E to Pick up or Any other key to continue...");

                        if (player.InteractionComponent.IsPressedKeyCorrect())
                        {
                            player.InteractionComponent.PickUp(healthPotion, 1, player.Inventory);
                            map.RedrawCellAt(healthPotion.PositionComponent.GetPosition());
                            map.UpdatePlayerStats(inventoryPosition, mapOrigin, player.Health.Hp, player.Inventory.HealthPotionAmount);
                        }
                        else
                        {
                            gameLogic.WriteTextLine("Nothing happened!");
                        }
                    }

                    //=== NothingInRange

                    else
                    {
                        gameLogic.ClearTextLine();
                    }
                }

                nextPosition = troll.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    if (troll.Health.IsAlive())
                    {
                        troll.Movement.Move(nextPosition);

                        map.RedrawCellAt(troll.Movement.PreviousPosition);
                        map.DrawSomethingAt(troll.VisualComponent.Visual, troll.VisualComponent.VisualColor, troll.PositionComponent.GetPosition());

                        // if (troll.InteractionComponent.IsTargetInRange(player.PositionComponent.Position))
                        // {
                        //     troll.InteractionComponent.Attack(player.Health);
                        //     gameLogic.WriteTextLine($"{troll.NameTagComponent.NameTag} attacked you! Press Any key to continue...");
                        //     map.UpdatePlayerStats(inventoryPosition, mapOrigin, player.Health.Hp, player.Inventory.HealthPotionAmount);
                        //     Console.ReadKey(true);
                        //     gameLogic.ClearTextLine();
                        // }
                    }

                }
                nextPosition = hoodedFigure.Movement.GetNextPosition();
                if (map.IsPointCorrect(nextPosition))
                {
                    hoodedFigure.Movement.Move(nextPosition);

                    map.RedrawCellAt(hoodedFigure.Movement.PreviousPosition);
                    map.DrawSomethingAt(hoodedFigure.VisualComponent.Visual, hoodedFigure.VisualComponent.VisualColor, hoodedFigure.PositionComponent.GetPosition());
                }

                if (!healthPotion.isPickedUp)
                {
                    map.DrawSomethingAt(healthPotion.VisualComponent.Visual, healthPotion.VisualComponent.VisualColor, healthPotion.PositionComponent.GetPosition());
                }
            }
            gameLogic.ClearTerminal();
            gameLogic.WriteTextLine("You died! Press Any key to quit...");
            Console.ReadKey(true);
        }
        else
        {
            gameLogic.TerminalIsToSmallError();
        }
    }
}