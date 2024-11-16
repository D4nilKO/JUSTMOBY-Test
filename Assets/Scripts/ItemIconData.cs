using UnityEngine;

[CreateAssetMenu(fileName = "ItemIconData", menuName = "ScriptableObjects/ItemIconData", order = 1)]
public class ItemIconData : ScriptableObject
{
    [field: SerializeField]
    public string ItemName { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    private void OnValidate()
    {
        if (string.IsNullOrWhiteSpace(ItemName))
            Debug.LogWarning($"{nameof(ItemIconData)}: Item name is empty!", this);

        if (Icon == null)
            Debug.LogWarning($"{nameof(ItemIconData)}: Icon is not assigned!", this);
    }
}