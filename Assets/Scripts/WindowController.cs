using UnityEngine;
using System.Collections.Generic;

public class WindowController : MonoBehaviour
{
    [SerializeField]
    private WindowView windowView;

    [SerializeField]
    private List<ItemIconData> itemIconsData;

    private Dictionary<string, Sprite> itemIcons;

    private void Start()
    {
        if (windowView == null)
        {
            Debug.LogError($"{nameof(WindowController)}: {nameof(windowView)} is not assigned!", this);
            return;
        }

        // Инициализируем словарь иконок
        itemIcons = new Dictionary<string, Sprite>();

        foreach (var itemData in itemIconsData)
        {
            if (!string.IsNullOrEmpty(itemData.ItemName) && itemData.Icon != null)
            {
                itemIcons[itemData.ItemName] = itemData.Icon;
            }
        }

        // Создаем тестовые данные
        List<Item> items = new List<Item>
        {
            new Item("Wood", 40),
            new Item("Stone", 20),
            new Item("Iron", 20)
        };

        var windowData = new WindowData("Набор начинающего строителя",
            "Поможет установить на плот все необходимые постройки", items, 3.99f, 0.34f, "BigIcon");

        // Передаем данные во View для отображения
        windowView.DisplayWindow(windowData, itemIcons);
    }
}