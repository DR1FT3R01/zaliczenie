class ComposedEnemy
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent Health { get; }
    public PositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public InteractionComponent InteractionComponent { get; }
    public NameTagComponent NameTagComponent { get; }

    public ComposedEnemy(char visual, ConsoleColor visualColor, string nameTag, Point startingPosition)
    {
        VisualComponent = new VisualComponent(visual, visualColor);
        Health = new HealthComponent();
        PositionComponent = new PositionComponent(startingPosition);
        InputComponent = new RandomInputComponent();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        InteractionComponent = new InteractionComponent(PositionComponent);
        NameTagComponent = new NameTagComponent(nameTag);
    }

}