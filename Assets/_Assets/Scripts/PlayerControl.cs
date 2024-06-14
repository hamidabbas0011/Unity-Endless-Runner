using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10f;
    public float laneWidth = 2f;
    public float jumpForce = 10f;
    public float slideDuration = 0.5f;
    public float jumpDuration = 0.5f; // Duration for the entire jump (up and down)
    public float scoreMultiplier = 1f;
    [SerializeField]private TMP_Text coinText;
    [SerializeField]private TMP_Text scoreText;
    private float score = 0f;
    private int currentLane = 0;
    private bool isJumping = false;
    private bool isSliding = false;
    public int coins = 0;
    private Rigidbody rb;
    private CapsuleCollider playerCollider;
    private Vector3 originalColliderSize;

    void Start()
    {
        coinText.text = $"Coins: {coins}";
        scoreText.text = "0";
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        originalColliderSize = playerCollider.height * Vector3.up;
    }

    void Update()
    {
        // Move forward constantly
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Handle lane switching
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > -1)
        {
            currentLane--;
            MovePlayer();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
        {
            currentLane++;
            MovePlayer();
        }

        // Handle jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping && !isSliding)
        {
            StartCoroutine(Jump());
        }

        // Handle slide
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding && !isJumping)
        {
            StartCoroutine(Slide());
        }
        
        // Update the score based on the player's forward movement
        score += transform.position.z * scoreMultiplier * Time.deltaTime;
        scoreText.text = /Mathf.FloorToInt(score).ToString();

    }

    void MovePlayer()
    {
        Vector3 targetPosition = new Vector3(currentLane * laneWidth, transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    IEnumerator Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Wait for half of the jump duration to simulate the upward motion
        yield return new WaitForSeconds(jumpDuration / 2);

        // Apply downward force to make the landing quicker
        rb.AddForce(Vector3.down * jumpForce * 2, ForceMode.Impulse);

        // Wait for the second half of the jump duration to complete the landing
        yield return new WaitForSeconds(jumpDuration / 2);

        isJumping = false;
    }

    IEnumerator Slide()
    {
        isSliding = true;
        playerCollider.height = originalColliderSize.y / 4;
        yield return new WaitForSeconds(slideDuration);
        playerCollider.height = originalColliderSize.y;
        isSliding = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            coins++;
            coinText.text = $"Coins: {coins}";
        }  
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Triggered");
            //Destroy(other.gameObject);
        }
        
    }
    
    
}
