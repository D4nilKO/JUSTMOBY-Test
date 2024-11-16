using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    private const int minQuantity = 3;
    private const int maxQuantity = 6;

    [SerializeField]
    private Button openWindowButton;

    [SerializeField]
    private WindowController window;

    [SerializeField]
    private TMP_InputField quantityInputField;

    private void Start()
    {
        if (openWindowButton == null || window == null || quantityInputField == null)
        {
            Debug.LogError($"Some UI components is not assigned!", gameObject);
            return;
        }

        openWindowButton.onClick.AddListener(OpenWindow);
    }

    private void OpenWindow()
    {
        bool tryParse = int.TryParse(quantityInputField.text, out int quantity);

        if (tryParse)
        {
            quantity = Mathf.Clamp(quantity, minQuantity, maxQuantity);
            window.Init(quantity);
        }
        else
        {
            Debug.LogError($"Invalid quantity input!", gameObject);
        }
    }
}