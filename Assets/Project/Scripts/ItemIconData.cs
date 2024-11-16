using UnityEngine;

[System.Serializable]
public class ItemIconData
{
    [field: SerializeField]
    public string ItemName { get; private set; }

    [field: SerializeField]
    public Sprite Icon { get; private set; }
}