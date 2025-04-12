using UnityEngine;

public class Apple : MonoBehaviour
{
    public enum AppleType { Green, Red }
    public AppleType type;

    public int GetValue()
    {
        return type == AppleType.Green ? 1 : 5;
    }
}
