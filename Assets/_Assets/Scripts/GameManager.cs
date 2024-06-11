using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnParent;
    public float spawnInterval = 2f;
    private float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= spawnInterval)
        {
            SpawnObstacle();
            _timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float spawnPositionX = Random.Range(-2f, 2f);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0.5f, transform.position.z);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity,spawnParent);
    }
}
