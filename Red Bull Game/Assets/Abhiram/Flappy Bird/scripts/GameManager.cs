using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    private int prevpoint = -1;
    private int textureDimension;
    private Sprite tens;
    private Sprite ones;


    public static int points = 0;
    public static List<GameObject> poles = new List<GameObject>();

    [SerializeField] private List<Texture2D> numbers = new List<Texture2D>();
    [SerializeField] private GameObject TryAgainMenu;
    [SerializeField] private GameObject Congrates;
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameObject tensDisplay;
    public GameObject onesDisplay;
    public Transform message;


    private SpriteRenderer tensRenderer;
    private SpriteRenderer onesRenderer;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        points = 0;
        prevpoint = -1;
        textureDimension = Mathf.Max(numbers[0].width, numbers[0].height);

        tensRenderer = tensDisplay.GetComponent<SpriteRenderer>();
        onesRenderer = onesDisplay.GetComponent<SpriteRenderer>();

        TryAgainMenu.SetActive(false);
        message.gameObject.SetActive(true);
        tensDisplay.SetActive(false);
        onesDisplay.SetActive(false);
        Congrates.SetActive(false);
    }

    private void Update()
    {
        if (points >= 100)
        {
            Congrates.SetActive(true);
            Time.timeScale = 0f;
        }

        if (prevpoint != points && Jumping.instance.jumpedAtleastOnce)
        {
            int tensDigit = (int)points / 10;
            int onesDigit = (int)points % 10;
            tens = Sprite.Create(numbers[tensDigit], new Rect(0, 0, numbers[tensDigit].width, numbers[tensDigit].height), new Vector3(0.5f, 0f, 1f));
            ones = Sprite.Create(numbers[onesDigit], new Rect(0, 0, numbers[onesDigit].width, numbers[onesDigit].height), new Vector3(-0.5f, 0f, 1f));

            tensRenderer.sprite = tens;
            onesRenderer.sprite = ones;


            prevpoint = points;
        }

        
    }

    public void TryAgain()
    {
        TryAgainMenu.SetActive(true);
        scoreText.text = points.ToString();
    }

    public void ReTry()
    {
        SceneManager.LoadScene("GAME");
        Time.timeScale = 1.0f;
        points = 0;
        prevpoint = -1;
    }
}
