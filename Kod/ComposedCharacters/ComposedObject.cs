class ComposedObject
{
    public VisualComponent VisualComponent { get; }
    public IPositionComponent PositionComponent { get; }
    public Map Map { get; }
    public NameTagComponent NameTagComponent { get; }
    public bool isPickedUp { get; set; } = false;
    public ComposedObject(char visual, ConsoleColor visualColor, string nameTag, Map currentMap)
    {
        Map = currentMap;
        VisualComponent = new VisualComponent(visual, visualColor);
        PositionComponent = new RandomPositionComponent(currentMap);
        NameTagComponent = new NameTagComponent(nameTag);
    }
}