
// idk

//Player player = new Player();
Point playerPosition = new Point(20, 20);
Player player = new Player(playerPosition);

while (true)
{
    Console.Clear();
    Map map = new Map();
    //Console.WriteLine($"X: {player.X} Y: {player.Y}");
    Console.SetCursorPosition(player.Position.X, player.Position.Y);
    //wyswietlanie pozycji gracza aby dobrze zrobic mape
    Console.Write($"@ ({player.Position.X},{player.Position.Y})");
    player.Move();
    
}