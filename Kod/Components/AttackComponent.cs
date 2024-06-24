internal class AttackComponent
{
    private int strength = 10;

    public void Attack(HealthComponent targetHealthComponent)
    {
        targetHealthComponent.TakeDamage(strength);
    }
}
