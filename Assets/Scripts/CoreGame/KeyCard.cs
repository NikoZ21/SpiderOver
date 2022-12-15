using UnityEngine;
using UnityEngine.UI;

public class KeyCard : MonoBehaviour
{
    public enum KeyCardColor
    {
        black,
        brown,
        yellow,
        orange,
        red
    }

    public KeyCardColor keyCardColor;

    public Sprite keyCardSprite;
}