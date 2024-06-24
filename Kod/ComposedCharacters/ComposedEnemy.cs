class ComposedEnemy
{
    public VisualComponent VisualComponent { get; }
    public HealthComponent Health { get; }
    public IPositionComponent PositionComponent { get; }
    public MovementComponent Movement { get; }
    public IInputComponent InputComponent { get; }
    public NameTagComponent NameTagComponent { get; }
    public AttackComponent AttackComponent { get; }
    public Map Map { get; }

    public ComposedEnemy(char visual, ConsoleColor visualColor, string nameTag, Map currentMap)
    {
        Map = currentMap;
        VisualComponent = new VisualComponent(visual, visualColor);
        Health = new HealthComponent();
        PositionComponent = new RandomPositionComponent(currentMap);
        InputComponent = new RandomInputComponent();
        Movement = new MovementComponent(PositionComponent, InputComponent);
        NameTagComponent = new NameTagComponent(nameTag);
        AttackComponent = new AttackComponent();
    }

}