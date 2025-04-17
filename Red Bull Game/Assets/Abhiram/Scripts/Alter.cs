using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enterText;

    private void Start()
    {
        enterText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (enterText.IsActive() && Input.GetKeyDown(KeyCode.E))
        {
            int count = 0;
            for (int i = 0; i < GameManagerMain.Instance.inventory.Length; i++)
            {
                if (GameManagerMain.Instance.inventory[i])
                    count++;
            }

            if (count >= 2)
                Debug.Log("You did it!!!!!!");
            else
                Debug.Log("Not yet you don't");
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
