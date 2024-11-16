using UnityEngine;

public class Item
{
    private const string defaultName = "Unnamed Item";
    
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public Item(string name, int quantity)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? defaultName
            : name;

        Quantity = Mathf.Max(1, quantity);
    }
}