using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portalmanager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enterText;
    [SerializeField] private string enterSceneName;

    private void Start()
    {
        enterText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (enterText.IsActive() && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(enterSceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterText.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enterText.gameObject.SetActive(false);
    }


}
