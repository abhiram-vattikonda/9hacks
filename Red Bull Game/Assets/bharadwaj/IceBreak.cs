using UnityEngine;

public class IceScript : MonoBehaviour
{
    public Sprite[] healingStages; // Sprites showing healing progress
    public GameObject drinkCan;

    private SpriteRenderer sr;
    private int tapCount = 0;
    private int maxTaps;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = healingStages[0];
        drinkCan.SetActive(false);
        maxTaps = healingStages.Length;
    }

    void OnMouseDown()
    {
        tapCount++;

        if (tapCount < maxTaps)
        {
            sr.sprite = healingStages[tapCount];
        }
        else
        {
            sr.enabled = false; // Hide the ice
            drinkCan.SetActive(true);
        }

        Debug.Log("Tapped! Count: " + tapCount);
    }
}
