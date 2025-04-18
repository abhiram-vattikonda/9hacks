using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMain : MonoBehaviour
{
    public static GameManagerMain Instance { get; private set; }

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private GameObject[] items = new GameObject[4];
    public bool[] inventory = new bool[4];

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        background.transform.localPosition = new Vector3 (0, 0, 30f);
        videoPlayer.SetActive(false);
        UpdateInventoryVisuals();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-assign item references here (example assumes names)
        items[0] = GameObject.Find("can");
        items[1] = GameObject.Find("wings");
        items[2] = GameObject.Find("energy");
        items[3] = GameObject.Find("logo");
        videoPlayer = GameObject.Find("VideoPlayer");

        UpdateInventoryVisuals();
    }

    public void UpdateInventoryVisuals()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (items[i] != null)
                items[i].SetActive(inventory[i]);
        }
    }
}
