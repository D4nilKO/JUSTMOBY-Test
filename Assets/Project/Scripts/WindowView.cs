using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text titleText;

    [SerializeField]
    private TMP_Text descriptionText;

    [SerializeField]
    private Transform itemContainer;

    [SerializeField]
    private ItemView itemPrefab;

    [SerializeField]
    private TMP_Text priceText;

    [SerializeField]
    private TMP_Text discountText;

    [SerializeField]
    private TMP_Text oldPriceText;

    [SerializeField]
    private Image bigIconImage;

    [SerializeField]
    private Button priceButton;

    [SerializeField]
    private Sprite defaultIcon;

    private void Awake()
    {
        if (!titleText || !descriptionText || !itemContainer || !itemPrefab || !priceText || !bigIconImage ||
            !priceButton || !oldPriceText || !discountText)
            Debug.LogError($"Some UI components are not assigned!", gameObject);

        priceButton.onClick.AddListener(OnPriceButtonClick);

        gameObject.SetActive(false);
    }

    public void DisplayWindow(WindowData data, IconBank itemIcons)
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

        foreach (Item item in data.Items)
        {
            ItemView itemView = Instantiate(itemPrefab, itemContainer);

            Sprite itemIcon = itemIcons.TryGetIcon(item.Name, out Sprite icon)
                ? icon
                : defaultIcon;

            itemView.Setup(item.Quantity, itemIcon);
        }

        priceText.text = $"${data.Price:F2}";

        float oldPrice = data.Price / (1 - data.Discount);
        oldPriceText.text = $"$<s>{oldPrice:F2}</s>";

        discountText.text = data.Discount > 0
            ? $"-{data.Discount * 100}%"
            : string.Empty;

        bigIconImage.sprite = itemIcons.TryGetIcon(data.BigIconName, out Sprite bigIcon)
            ? bigIcon
            : defaultIcon;
    }

    private void OnPriceButtonClick()
    {
        Debug.Log("Price button clicked!");
        // Здесь можно вызвать события или уведомить контроллер
    }
}