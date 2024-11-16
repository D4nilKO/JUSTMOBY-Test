using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WindowView : MonoBehaviour
{
    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private Transform itemContainer;

    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private Text priceText;

    [SerializeField]
    private Image bigIconImage;

    [SerializeField]
    private Button priceButton;

    private void Awake()
    {
        if (!titleText || !descriptionText || !itemContainer || !itemPrefab || !priceText || !bigIconImage ||
            !priceButton)
            Debug.LogError($"{nameof(WindowView)}: Some UI components are not assigned!", this);

        priceButton.onClick.AddListener(OnPriceButtonClick);
    }

    public void DisplayWindow(WindowData data, Dictionary<string, Sprite> itemIcons)
    {
        if (data == null)
        {
            Debug.LogError("WindowData is null.");
            return;
        }

        titleText.text = data.Title;
        descriptionText.text = data.Description;

        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in data.Items)
        {
            var itemGO = Instantiate(itemPrefab, itemContainer);
            var itemIcon = itemIcons.TryGetValue(item.Name, out Sprite icon) ? icon : null;
            itemGO.GetComponent<ItemView>()?.Setup(item.Name, item.Quantity, itemIcon);
        }

        priceText.text = data.Discount > 0 ? $"${data.Price * (1 - data.Discount):F2}" : $"${data.Price:F2}";
        bigIconImage.sprite = itemIcons.TryGetValue(data.BigIconName, out Sprite bigIcon) ? bigIcon : null;
    }

    private void OnPriceButtonClick()
    {
        Debug.Log("Price button clicked!");
        // Здесь можно вызвать события или уведомить контроллер
    }
}