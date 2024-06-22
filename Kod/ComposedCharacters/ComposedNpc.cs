class ComposedNpc
{
    public VisualComponent VisualComponent { get; }
    public PositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public NameTagComponent NameTagComponent { get; }

    public ComposedNpc(char visual, string nameTag, Point startingPoint)
    {
        VisualComponent = new VisualComponent(visual);
        PositionComponent = new PositionComponent(startingPoint);
        InputComponent = new RandomInputComponent ();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        NameTagComponent = new NameTagComponent(nameTag);
    }
}