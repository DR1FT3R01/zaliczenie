internal class AttackComponent
{
    private int strength = 10;
    private int range = 1;
    private readonly IPositionComponent positionComponent;

    public AttackComponent(IPositionComponent positionComponent)
    {
        this.positionComponent = positionComponent;
    }

    public void Attack(HealthComponent targetHealthComponent)
    {
        targetHealthComponent.TakeDamage(strength);
    }

        public bool IsTargetInRange(Point targetPosition)
    {
        int distanceX = Math.Abs(positionComponent.GetPosition().X - targetPosition.X);
        int distanceY = Math.Abs(positionComponent.GetPosition().Y - targetPosition.Y);

        return (distanceX <= range && distanceY == 0 || distanceX == 0 && distanceY <= range);
    }
}
