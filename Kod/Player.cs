class Player
{










   public void Move()
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (pressedKey.Key == ConsoleKey.A)
        {
            X -= 1;
        }
        else if(pressedKey.Key == ConsoleKey.D)
        {
            X += 1;
        }
    }
}