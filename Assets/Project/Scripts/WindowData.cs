using System.Collections.Generic;
using UnityEngine;

public class WindowData
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public List<Item> Items { get; private set; }
    public float Price { get; private set; }
    public float Discount { get; private set; }
    public string BigIconName { get; private set; }

    public WindowData(string title, string description, IReadOnlyCollection<Item> items, float price, float discount,
        string bigIconName)
    {
        Title = string.IsNullOrWhiteSpace(title)
            ? "Default Title"
            : title;

        Description = string.IsNullOrWhiteSpace(description)
            ? "Default Description"
            : description;

        Items = items?.Count > 0
            ? new List<Item>(items)
            : throw new System.ArgumentException("Items list cannot be null or empty");

        Price = Mathf.Max(0, price);
        Discount = Mathf.Clamp(discount, 0, 1);

        BigIconName = string.IsNullOrWhiteSpace(bigIconName)
            ? "DefaultIcon"
            : bigIconName;
    }
}