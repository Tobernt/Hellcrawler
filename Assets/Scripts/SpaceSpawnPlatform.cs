using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawnPlatform : MonoBehaviour
{

    public GameObject spaceSpawnPlatform;
    private float spaceSpawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPlatform", spaceSpawnTime, spaceSpawnTime);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, 0);
        Instantiate(spaceSpawnPlatform, randomSpawnPosition, Quaternion.identity);
    }

    void SpacespawnPlatform()
    {
        Vector3 randomSpaceSpawnPosition = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, 0);
        Instantiate(spaceSpawnPlatform, randomSpaceSpawnPosition, Quaternion.identity);
        spaceSpawnTime = 0;
    }

    void Update()
    {
        spaceSpawnTime += Time.deltaTime;
    }
}
