class ComposedNpc
{
    public VisualComponent VisualComponent { get; }
    public IPositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public NameTagComponent NameTagComponent { get; }
    public DialogueComponent Dialogue { get; }
    public Map Map { get; }

    public ComposedNpc(char visual, ConsoleColor visualColor, string nameTag, Map currentMap)
    {
        Map = currentMap;
        VisualComponent = new VisualComponent(visual, visualColor);
        PositionComponent = new RandomPositionComponent(currentMap);
        InputComponent = new RandomInputComponent ();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        NameTagComponent = new NameTagComponent(nameTag);
        Dialogue = new DialogueComponent();
    }
}