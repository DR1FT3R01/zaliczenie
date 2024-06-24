class ComposedPlayer
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent Health { get; }
    public IPositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public InteractionComponent InteractionComponent { get; }
    public InventoryComponent Inventory { get; }
    public AttackComponent AttackComponent { get; }

    public ComposedPlayer(char visual, ConsoleColor visualColor, Point startingPosition)
    {
        VisualComponent = new VisualComponent(visual, visualColor);
        Health = new HealthComponent();
        PositionComponent = new ProvidedPositionComponent(startingPosition);
        InputComponent = new KeyboardInputComponent();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        InteractionComponent = new InteractionComponent(PositionComponent);
        Inventory = new InventoryComponent();
        AttackComponent = new AttackComponent(PositionComponent);
    }
}