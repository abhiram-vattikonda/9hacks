using UnityEngine;
using TMPro; // Add this at the top
using UnityEngine.SceneManagement;


public class IceBreakingScript : MonoBehaviour
{
    public Sprite[] breakStages;         // Breaking levels from healed to broken
    public GameObject drinkCan;          // The object to show at the end

    private SpriteRenderer sr;
    private float breakProgress = 0f;     // 0 = full heal, max = fully broken
    private float maxBreak = 7f;
    public float breakPerTap = 1f;
    public float healPerSecond = 1f;

    private bool isRevealed = false;
    public TextMeshProUGUI breakingText;

    [SerializeField] private GameObject textCanvas;
    [SerializeField] private GameObject finalCanvas;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        drinkCan.SetActive(false);
        UpdateSprite();
        textCanvas.SetActive(true);
        finalCanvas.SetActive(false);
    }

    void Update()
    {
        if (breakProgress > 0 && !isRevealed)
        {
            breakProgress -= healPerSecond * Time.deltaTime;
            breakProgress = Mathf.Clamp(breakProgress, 0, maxBreak);
            UpdateSprite();
        }

        if (breakProgress >= maxBreak)
        {
            textCanvas.SetActive(false);
            finalCanvas.SetActive(true);
            GameManagerMain.Instance.inventory[0] = true;
        }
    }

    void OnMouseDown()
    {
        if (isRevealed) return;

        breakProgress += breakPerTap;
        breakProgress = Mathf.Clamp(breakProgress, 0, maxBreak);

        UpdateSprite();

        if (breakProgress >= maxBreak)
        {
            RevealCan();
        }
    }

    void UpdateSprite()
    {
        int stage = Mathf.Clamp(Mathf.RoundToInt(breakProgress), 0, breakStages.Length - 1);
        sr.sprite = breakStages[stage];

        float remaining = maxBreak - breakProgress;

        if (breakingText != null)
            breakingText.text = "Remaining Break Amount: " + remaining.ToString("F2");

        Debug.Log("Remaining Break Amount: " + remaining.ToString("F2"));

        if (breakingText != null)
        {
            breakingText.text = "Breaking Remaining: " + Mathf.CeilToInt(remaining);

            // Change color as player gets closer to success
            if (remaining <= 1f)
                breakingText.color = Color.red;
            else if (remaining <= 3f)
                breakingText.color = Color.yellow;
            else
                breakingText.color = Color.cyan;
    }

}

    void RevealCan()
    {
        isRevealed = true;
        sr.enabled = false;
        drinkCan.SetActive(true);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
