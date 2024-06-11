using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isGrounded = true;
    public float speed = 20f;
    public float horizontalSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }


    public void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -3.5f, 3.5f);
        transform.position = newPosition;

        // if (Input.GetKeyDown(KeyCode.A) && transform.position.x>-2)
        // {
        //     transform.position = new Vector3((transform.position.x-2), 1, transform.position.z);
        // }
        // if (Input.GetKeyDown(KeyCode.D) && transform.position.x<2)
        // {
        //     transform.position = new Vector3((transform.position.x+2), 1, transform.position.z);
        // }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Trigger Game Over logic here
            Debug.Log("Game Over!");
            Time.timeScale = 0; // Pauses the game
        }
    }
}
