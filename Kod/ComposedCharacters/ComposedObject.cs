class ComposedObject
{
    public VisualComponent VisualComponent { get; }
    public RandomPositionComponent RandomPositionComponent { get; }
    public Map CurrentMap { get; }
    public ComposedObject(char visual, Map map)
    {
        CurrentMap = map;
        VisualComponent = new VisualComponent(visual);
        RandomPositionComponent = new RandomPositionComponent(map);
    }
}