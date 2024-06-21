public class MiniGame
{
    internal bool DidThePlayerWin()
    {
        Random rng = new Random();
        int generatedNumber = rng.Next(1, 4);

        Console.SetCursorPosition(0, 0);
        Console.Write("                                                                          ");
        Console.SetCursorPosition(0, 0);
        Console.Write("Guess a number between 1 and 3:");
        int.TryParse(Console.ReadLine()?.Trim(), out int guess);

        if (guess == generatedNumber)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("You guessed right! Press Any key to continue...                       ");
            Console.ReadKey(true);
            return true;
        }
        else
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("You guessed wrong! Press Any key to continue...                       ");
            Console.ReadKey(true);
            return false;
        }
    }
}