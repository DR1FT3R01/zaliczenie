public class VisualComponent
{
    public char Visual { get; set; }
    public ConsoleColor VisualColor { get; set; }

    public VisualComponent(char visual, ConsoleColor visualColor)
    {
        Visual = visual;
        VisualColor = visualColor;
    }
}