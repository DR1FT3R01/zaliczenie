namespace zaliczenie.Kod
{
    public class GameConsole
    {
        private List<string> messages = new List<string>();
        private int consoleWidth;
        private int consoleHeight;

        public GameConsole(int width, int height)
        {
            consoleWidth = width;
            consoleHeight = height;
            AddMessage("hi");
        }

        public void AddMessage(string message)
        {
            messages.Add(message);
            if (messages.Count > consoleHeight)
            {
                messages.RemoveAt(0);
            }
        }

        public void DisplayMessages()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < consoleHeight; i++)
            {
                if (i < messages.Count)
                {
                    Console.WriteLine(messages[i].PadRight(consoleWidth));
                }
                else
                {
                    Console.WriteLine(new string(' ', consoleWidth));
                }
            }
        }
    }

}
