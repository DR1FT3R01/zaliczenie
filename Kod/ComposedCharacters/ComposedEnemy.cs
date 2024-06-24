class ComposedEnemy
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent Health { get; }
    public PositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public NameTagComponent NameTagComponent { get; }
    public AttackComponent AttackComponent { get; }

    public ComposedEnemy(char visual, ConsoleColor visualColor, string nameTag, Point startingPosition)
    {
        VisualComponent = new VisualComponent(visual, visualColor);
        Health = new HealthComponent();
        PositionComponent = new PositionComponent(startingPosition);
        InputComponent = new RandomInputComponent();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        NameTagComponent = new NameTagComponent(nameTag);
        AttackComponent = new AttackComponent();
    }

}