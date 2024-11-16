using UnityEngine;
using System.Collections.Generic;

public class WindowController : MonoBehaviour
{
    [SerializeField]
    private WindowView windowView;

    [SerializeField]
    private IconBank iconBank;

    public void Init(int itemsQuantity)
    {
        if (windowView == null)
        {
            Debug.LogError($"{nameof(WindowController)}: {nameof(windowView)} is not assigned!", this);
            return;
        }

        windowView.gameObject.SetActive(true);

        WindowData windowData = GetWindowData(itemsQuantity);
        windowView.DisplayWindow(windowData, iconBank);
    }

    private WindowData GetWindowData(int itemsQuantity)
    {
        // Создаем тестовые данные

        List<Item> itemsPool = new List<Item>
        {
            new Item("Wood", 40),
            new Item("Stone", 20),
            new Item("Iron", 20)
        };

        List<Item> items = new List<Item>();

        for (int i = 0; i < itemsQuantity; i++)
        {
            int randomIndex = Random.Range(0, itemsPool.Count);
            Item randomItem = itemsPool[randomIndex];
            items.Add(randomItem);
        }

        string title = "Набор начинающего строителя";
        string description = "Поможет установить на плот все необходимые постройки";
        float price = 3.99f;
        float discount = 0.34f;
        string bigIconName = "BigIcon";

        return new WindowData(title, description, items, price, discount, bigIconName);
    }
}