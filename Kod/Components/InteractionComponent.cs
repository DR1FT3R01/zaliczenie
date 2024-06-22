internal class InteractionComponent
{
    private int range = 1;
    private int strength = 10;
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

    public void Attack(HealthComponent targetHealthComponent)
    {
        targetHealthComponent.TakeDamage(strength);
    }

    public void StartDialogue()
    {

    }

    public static void ClearTextLine(int row)
    {
        int currentLineCursor = row;
        Console.SetCursorPosition(0, row);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public static void WriteTextLine(string text)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(text);
    }

    private void MiniGame()
    {
        WriteTextLine("MiniGame!");
    }

}