internal class DialogueComponent
{
    private string? providedSign;

    public void StartDialogue(InventoryComponent playerInventory)
    {
        Console.CursorVisible = true;
        do
        {
            WriteTextLine("Do you want to play a game? (y/n): ");
            providedSign = Console.ReadLine()?.ToLower().Trim();
        } while (providedSign != "y" && providedSign != "n");

        if (providedSign == "y")
        {
            MiniGame(playerInventory);
        }
        else
        {
            Console.CursorVisible = false;
            WriteTextLine("Let me know if you change your mind...");
        }
    }

    private void MiniGame(InventoryComponent playerInventory)
    {
        int attempts = 5;
        int miniGameMinRange = 0;
        int miniGameMaxRange = 30;

        Random rng = new Random();
        int generatedNumber = rng.Next(miniGameMinRange, miniGameMaxRange + 1);

        WriteTextLine($"You have {attempts} attempts. Guess a number between {miniGameMinRange} and {miniGameMaxRange}: ");
        int.TryParse(Console.ReadLine()?.Trim(), out int guess);
        attempts -= 1;

        while (attempts > 0)
        {
            if (guess < generatedNumber)
            {
                WriteTextLine($"[Attempt(s) left: {attempts}] Try something higher: ");
            }
            else if (guess > generatedNumber)
            {
                WriteTextLine($"[Attempt(s) left: {attempts}] Try something lower: ");
            }
            attempts -= 1;
            int.TryParse(Console.ReadLine()?.Trim(), out guess);
        }

        if (guess == generatedNumber)
        {
            playerInventory.AddPotionToInventory(1);
            WriteTextLine($"You guessed! Here's your prize... bye for now...");
        }
        else
        {
            WriteTextLine("Sorry, it's not your day... bye...");
        }

        Console.CursorVisible = false;

    }

    private void ClearTextLine()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string(' ', Console.WindowWidth));
    }

    private void WriteTextLine(string text)
    {
        ClearTextLine();
        Console.SetCursorPosition(0, 0);
        Console.Write(text);
    }
}