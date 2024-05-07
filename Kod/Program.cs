
// idk

Point playerPosition = new Point(6, 5);
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

    var previousCell = map.GetCellVisualAt(player.PreviousPosition);
    Console.SetCursorPosition(player.PreviousPosition.X, player.PreviousPosition.Y);
    Console.Write(previousCell);

    Console.SetCursorPosition(player.Position.X, player.Position.Y);
    Console.Write("█");
    Console.CursorVisible = false;
}