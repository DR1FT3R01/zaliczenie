using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

internal class InteractionComponent
{
    ConsoleKeyInfo pressedKey;
    private int range = 1;
    private int strength = 10;
    private int healingAmount = 30;
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