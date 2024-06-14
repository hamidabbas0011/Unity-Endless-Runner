using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
    // public GameObject obstaclePrefab;
    // public Transform player;
    // public float spawnDistance = 30f;
    // public float spawnInterval = 2f;
    // public float obstacleYPosition = 0.5f; // Fixed Y position for obstacles
    // private float lastSpawnTime;
    //
    // void Update()
    // {
    //     if (Time.time > lastSpawnTime + spawnInterval)
    //     {
    //         // Calculate spawn position
    //         Vector3 spawnPosition = player.position + Vector3.forward * spawnDistance;
    //         spawnPosition.x = Random.Range(-1, 2) * 2; // Adjust lane position
    //         spawnPosition.y = obstacleYPosition; // Set fixed Y position
    //
    //         // Spawn the obstacle
    //         Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    //         lastSpawnTime = Time.time;
    //     }
    // }
}
