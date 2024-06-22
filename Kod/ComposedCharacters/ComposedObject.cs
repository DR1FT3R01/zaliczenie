class ComposedObject
{
    public VisualComponent VisualComponent { get; }
    public RandomPositionComponent PositionComponent { get; }
    public Map CurrentMap { get; }
    public NameTagComponent NameTagComponent { get; }
    public ComposedObject(char visual, ConsoleColor visualColor, string nameTag, Map map)
    {
        CurrentMap = map;
        VisualComponent = new VisualComponent(visual, visualColor);
        PositionComponent = new RandomPositionComponent(map);
        NameTagComponent = new NameTagComponent(nameTag);
    }
}