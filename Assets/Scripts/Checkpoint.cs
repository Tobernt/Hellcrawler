using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointPlatform;
    public Transform spawnPoint;
    private float spawnYPosition = 5f;

    private bool hasSpawned = false;

    void checkpoint()
    {
        if (Camera.main.transform.position.y >= spawnYPosition && !hasSpawned)
        {
            Vector3 spawnPoint = new Vector3(spawnYPosition, this.transform.position.y);
            // Spawn the object at the specified spawn point
            Instantiate(checkpointPlatform, spawnPoint, Quaternion.identity);
            hasSpawned = true; // Set the flag to prevent spawning multiple times
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkpoint();
    }
}
