internal class HealthComponent
{
    public int Hp
    {
        get => hp;
        set => hp = Math.Clamp(value, 0, MaxHp);
    }
    int hp = 100;
    public int MaxHp { get; set; } = 100;

        public void Heal (int amount)
    {
        Console.WriteLine ("Healing!");
        Hp =+ amount;
    }
}