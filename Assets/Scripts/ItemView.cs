using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField]
    private Text itemNameText;

    [SerializeField]
    private Text quantityText;

    [SerializeField]
    private Image iconImage;

    public void Setup(string itemName, int quantity, Sprite icon)
    {
        if (itemNameText != null)
            itemNameText.text = itemName;

        if (quantityText != null)
            quantityText.text = quantity.ToString();

        if (iconImage != null)
            iconImage.sprite = icon;
    }
}