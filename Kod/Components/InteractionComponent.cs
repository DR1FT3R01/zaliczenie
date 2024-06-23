using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

internal class InteractionComponent
{
    ConsoleKeyInfo pressedKey;
    private int range = 1;
    private int strength = 10;
    private int healingAmount = 30;
    private string? providedSign;
    private readonly PositionComponent positionComponent;

    public InteractionComponent(PositionComponent positionComponent)
    {
        this.positionComponent = positionComponent;
    }

    public bool IsTargetInRange(Point targetPosition)
    {
        int distanceX = Math.Abs(positionComponent.Position.X - targetPosition.X);
        int distanceY = Math.Abs(positionComponent.Position.Y - targetPosition.Y);

        return (distanceX <= range && distanceY == 0 || distanceX == 0 && distanceY <= range);
    }

    public bool CheckPressedKey()
    {
        pressedKey = Console.ReadKey(true);
        if (pressedKey.Key == ConsoleKey.E)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Attack(HealthComponent targetHealthComponent)
    {
        targetHealthComponent.TakeDamage(strength);
    }

    public void Heal(HealthComponent targetHealthComponent, InventoryComponent targetInventory)
    {
        if(targetInventory.HealthPotionAmount > 0)
        {
            targetHealthComponent.Heal(healingAmount);
            targetInventory.RemovePotionFromInventory(1);
        }
        else
        {
            WriteTextLine("You don't have any potions!");
        }
    }

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
    public void PickUp(ComposedObject targetObject, int amount, InventoryComponent playerInventory)
    {
        WriteTextLine($"Added {amount}x {targetObject.NameTagComponent.NameTag} to your inventory.");
         playerInventory.AddPotionToInventory(1);
        targetObject.isPickedUp = true;
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