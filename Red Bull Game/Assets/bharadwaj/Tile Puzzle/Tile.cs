using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int correctIndex;
    public int currentIndex;
    public Image image;

    public void SetTile(Sprite sprite, int correctIdx, int currentIdx)
    {
        image.sprite = sprite;
        correctIndex = correctIdx;
        currentIndex = currentIdx;
    }
}
