Console.WriteLine("Hello, World!");
Console.WriteLine("Rawr");
Console.WriteLine("helo");
// idk

Player player = new Player();

while (true)
{
    //Console.Clear();
    Console.WriteLine($"X: {player.X} Y: {player.Y}");
    //Console.SetCursorPosition(player.X, player.Y);
    Console.Write("@");
    player.Move();
}