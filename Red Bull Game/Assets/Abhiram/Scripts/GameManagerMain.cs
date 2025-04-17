using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMain : MonoBehaviour
{
    public static GameManagerMain Instance { get; private set; }

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
        UpdateInventoryVisuals();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-assign item references here (example assumes names)
        items[0] = GameObject.Find("can");
        items[1] = GameObject.Find("wings");
        items[2] = GameObject.Find("energy");
        items[3] = GameObject.Find("logo");

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
