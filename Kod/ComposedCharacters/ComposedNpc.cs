class ComposedNpc
{
    public VisualComponent VisualComponent { get; }
    public PositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public NameTagComponent NameTagComponent { get; }
    public DialogueComponent Dialogue { get; }

    public ComposedNpc(char visual, ConsoleColor visualColor, string nameTag, Point startingPoint)
    {
        VisualComponent = new VisualComponent(visual, visualColor);
        PositionComponent = new PositionComponent(startingPoint);
        InputComponent = new RandomInputComponent ();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        NameTagComponent = new NameTagComponent(nameTag);
        Dialogue = new DialogueComponent();
    }
}