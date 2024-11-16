using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public Item(string name, int quantity)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Item" : name;
        Quantity = Mathf.Max(1, quantity);
    }
}