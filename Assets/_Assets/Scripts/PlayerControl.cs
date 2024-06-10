using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }


    public void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x>-2)
        {
            transform.position = new Vector3((transform.position.x-2), 1, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x<2)
        {
            transform.position = new Vector3((transform.position.x+2), 1, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
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
