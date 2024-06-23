internal class InventoryComponent
{
    public int HealthPotionAmount
    {
        get => potionAmount;
        set => potionAmount = Math.Clamp(value, 0, 100);    //nieskończoność?
    }
    int potionAmount = 0;

    public void AddToInventory(int amount)
    {
        potionAmount += amount;
    }

    public void RemoveFromInventory(int amount)
    {
        potionAmount -= amount;
    }
}