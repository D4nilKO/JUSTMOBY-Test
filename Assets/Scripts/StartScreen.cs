using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private Button openWindowButton;

    [SerializeField]
    private GameObject window;

    private void Start()
    {
        if (openWindowButton == null || window == null)
        {
            Debug.LogError("StartScreen: OpenWindowButton or window is not assigned!");
            return;
        }

        openWindowButton.onClick.AddListener(OpenWindow);
    }

    private void OpenWindow()
    {
        window.SetActive(true);
    }
}