public class GameLogic
{
    public void StartingScreen()
    {
        Console.CursorVisible = false;
        WriteTextLine("Press Any key to start...");
        Console.ReadKey(true);
    }
    public void TerminalIsToSmallError()
    {
        WriteTextLine("Terminal window is too small, make it bigger");
        Console.ReadKey(true);
    }
    public void ClearTerminal()
    {
        Console.SetCursorPosition(0, 0);
        Console.Clear();
    }

    public static void ClearTextLine()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string(' ', Console.WindowWidth));
    }

    public static void WriteTextLine(string text)
    {
        ClearTextLine();
        Console.SetCursorPosition(0, 0);
        Console.Write(text);
    }
}