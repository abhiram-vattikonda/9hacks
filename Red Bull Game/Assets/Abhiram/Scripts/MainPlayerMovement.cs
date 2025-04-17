using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovemetn : MonoBehaviour
{
    private Rigidbody2D rb;


    private float movementSpeed = 3f;
    private float jumpSpeed  = 500f;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isGrounded)
        {
            rb.gravityScale = 2.1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!isGrounded)
            {
                rb.gravityScale += 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpSpeed);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
