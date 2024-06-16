class ComposedPlayer
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent Health { get; }
    public  PositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public InputComponent InputComponent { get; }

    public ComposedPlayer(char visual, Point startingPosition)
    {
        VisualComponent = new VisualComponent(visual);
        Health = new HealthComponent();
        PositionComponent = new PositionComponent(startingPosition);
        InputComponent = new InputComponent();
        Movement = new MovementComponent(PositionComponent,InputComponent);
    }
}