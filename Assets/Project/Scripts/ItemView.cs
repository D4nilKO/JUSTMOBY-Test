using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image iconImage;

    public void Setup(int quantity, Sprite icon)
    {
        if (quantityText == null)
        {
            Debug.LogError("Quantity text is not assigned in the inspector.", gameObject);
            return;
        }

        if (iconImage == null)
        {
            Debug.LogError("Icon image is not assigned in the inspector.", gameObject);
            return;
        }

        if (icon == null)
        {
            Debug.LogError("Icon is null.", gameObject);
            return;
        }

        quantityText.text = quantity.ToString();
        iconImage.sprite = icon;
    }
}