using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public static Jumping instance {  get; private set; }

    private Vector3 gravity = new Vector3 (0f, -9.8f, 0f);
    private Vector3 direction;
    private Rigidbody2D rb;
    private float strength = 5f;

    public bool jumpedAtleastOnce;


    private void Start()
    {
        if (instance == null)
            instance = this;

        rb = GetComponent<Rigidbody2D>();
        direction = Vector3.zero;
        jumpedAtleastOnce = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump_performed();
        }
        if (jumpedAtleastOnce)
        {

            direction.y += gravity.y * Time.deltaTime;
            transform.position += direction * Time.deltaTime;
        }

    }

    private void Jump_performed()
    {

            direction = Vector3.up * strength;
            if (!jumpedAtleastOnce)
            {
                jumpedAtleastOnce = true;
                GetComponentInChildren<SpriteRenderer>().enabled = !GetComponentInChildren<SpriteRenderer>().enabled;
                GameManager.instance.message.gameObject.SetActive(false);
                GameManager.instance.tensDisplay.gameObject.SetActive(true);
                GameManager.instance.onesDisplay.gameObject.SetActive(true);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("score"))
        {
            GameManager.points += 1;
        }
        Debug.Log(collision.gameObject.tag);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        GameManager.instance.TryAgain();

    }


}
