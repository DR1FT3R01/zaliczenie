Console.WriteLine("Hello, World!");
Console.WriteLine("Rawr");
Console.WriteLine("helo");
// idk

//Player player = new Player();
Point playerPosition = new Point(0, 0);
Player player = new Player(playerPosition);

while (true)
{
    Console.Clear();
    //Console.WriteLine($"X: {player.X} Y: {player.Y}");
    Console.SetCursorPosition(player.Position.X, player.Position.Y);
    Console.Write($"@ ({player.Position.X}, {player.Position.Y}]");
    player.Move();
}