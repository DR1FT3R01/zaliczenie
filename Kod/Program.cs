
// idk

Point playerPosition = new Point(4, 4);
Player player = new Player(playerPosition);
 
Map map = new Map();

Console.Clear();
//Console.WriteLine($"Current position ({player.Position.X},{player.Position.Y})");

map.DisplayMap();

Console.SetCursorPosition(player.Position.X, player.Position.Y);
Console.Write("█");
Console.CursorVisible = false;

while (true)
{
    Point nextPosition = player.GetNextPosition();

    if (!map.IsPointCorrect(nextPosition))
    {
        continue;
    }

    player.Move(nextPosition);

    char previousCell = map.GetCellAt(player.PreviousPosition);
    Console.SetCursorPosition(player.PreviousPosition.X, player.PreviousPosition.Y);
    Console.Write(previousCell);

    Console.SetCursorPosition(player.Position.X, player.Position.Y);
    Console.Write("█");
    Console.CursorVisible = false;
}