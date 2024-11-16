using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "IconBank", menuName = "ScriptableObjects/IconBank")]
public class IconBank : ScriptableObject
{
    [SerializeField]
    private List<ItemIconData> iconDataList = new List<ItemIconData>();

    public bool TryGetIcon(string iconName, out Sprite icon)
    {
        icon = null;

        if (string.IsNullOrEmpty(iconName) == false)
        {
            icon = iconDataList.FirstOrDefault(data => data.ItemName == iconName)?.Icon;
        }

        return icon != null;
    }
}