class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();

        Map map = new Map();

        ComposedPlayer composedPlayer = new ComposedPlayer('█', new Point(6, 5));
        ComposedEnemy composedEnemy= new ComposedEnemy('T', new Point(6,8));
        ComposedObject composedObject = new ComposedObject('O', map);

        Point mapOrigin = new Point(5, 2);

        Console.SetCursorPosition(0, 0);    //?
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

                    // if (composedPlayer.DamageComponent.IsTargetInRange(enemyHere.RandomPositionComponent.Position))
                    // {
                    //     composedPlayer.DamageComponent.Attack();
                    // }
                    // else
                    // {
                    //     Console.SetCursorPosition(0, 0);
                    //     Console.Write("               ");
                    // }
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
}