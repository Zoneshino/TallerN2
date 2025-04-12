using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        AppleGreen,
        AppleRed,
        Banana,
        Medkit,
        Star
    }

    public ItemType type;

    public int GetValue()
    {
        switch (type)
        {
            case ItemType.AppleGreen: return 1;
            case ItemType.AppleRed: return 5;
            default: return 0;
        }
    }
}
