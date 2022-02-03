using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Page
{
    public Sprite pageImage;

    [TextArea(5,10)]
    public string storyText;
}
