using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> groundTiles; // List of ground tiles
    public int numberOfGrounds = 10;
    public float groundLength = 30f;
    public Transform groundSpawnController;
    private List<GameObject> grounds = new List<GameObject>();

    void Start()
    {
        // Spawn the first ground tile
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        SpawnGroundTile(spawnPosition, 0);

        // Spawn the rest of the ground tiles randomly from the list (excluding the first)
        for (int i = 1; i < numberOfGrounds; i++)
        {
            spawnPosition = new Vector3(0, 0, i * groundLength);
            SpawnGroundTile(spawnPosition, Random.Range(1, groundTiles.Count));
        }
    }

    void Update()
    {
        if (grounds[0].transform.position.z + groundLength < Camera.main.transform.position.z)
        {
            GameObject ground = grounds[0];
            grounds.RemoveAt(0);
            ground.transform.position += Vector3.forward * groundLength * numberOfGrounds;

            // Spawn a new ground tile at the updated position, choosing randomly (excluding the first tile)
            GameObject newGround = Instantiate(groundTiles[Random.Range(1, groundTiles.Count)], ground.transform.position, Quaternion.identity);
            grounds.Add(newGround);

            // Destroy the old ground tile
            Destroy(ground);
        }
    }
    
    void SpawnGroundTile(Vector3 position, int index)
    {
        GameObject groundTile = Instantiate(groundTiles[index], position, Quaternion.identity);
        grounds.Add(groundTile);
    }
}
