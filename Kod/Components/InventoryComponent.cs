internal class InventoryComponent
{
    public int HealthPotionAmount
    {
        get => potionAmount;
        set => potionAmount = Math.Clamp(value, 0, 100);    //nieskończoność?
    }
    int potionAmount = 0;

    public void AddPotionToInventory(int amount)
    {
        potionAmount += amount;
    }

    public void RemovePotionFromInventory(int amount)
    {
        potionAmount -= amount;
    }
}