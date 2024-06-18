internal class DamageComponent
{
    private int range = 1;
    private int strength = 10;
    private readonly PositionComponent positionComponent;

    public DamageComponent(PositionComponent positionComponent)
    {
        this.positionComponent = positionComponent;
    }

    public bool IsTargetInRange(Point targetPosition)
    {
        int distanceX = Math.Abs(positionComponent.Position.X - targetPosition.X);
        int distanceY = Math.Abs(positionComponent.Position.Y - targetPosition.Y);

        return (distanceX <= range && distanceY == 0 || distanceX == 0 && distanceY <= range);
    }
    public void Attack(HealthComponent targetHealthComponent)
    {
        targetHealthComponent.TakeDamage(strength);
    }
}