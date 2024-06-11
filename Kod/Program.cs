Console.CursorVisible = false;

Point playerPosition = new Point(6, 5);
Player player = new Player(playerPosition);

Map map = new Map();
NPC npc = new NPC(12, 15, map);

Console.Clear();
map.DisplayMap(new Point (5, 2));
npc.Draw(map);

Console.Clear();
map.DisplayMap(new Point (5, 2));

map.DrawSomethingAt (player.Visual, player.Position);

while (true)
{
    Point nextPosition = player.GetNextPosition();

    if (!map.IsPointCorrect(nextPosition))
    {
        continue;
    }

    player.Move(nextPosition);

    var previousCell = map.GetCellVisualAt(player.PreviousPosition);
    map.DrawSomethingAt(previousCell, player.PreviousPosition);
    map.DrawSomethingAt (player.Visual, player.Position);
}