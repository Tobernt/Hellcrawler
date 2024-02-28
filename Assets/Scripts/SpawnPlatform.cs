using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject Platform;
    private float spawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPlatform", spawnTime, spawnTime);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, 0);
        Instantiate(Platform, randomSpawnPosition, Quaternion.identity);
    }

    void spawnPlatform()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, 0);
        Instantiate(Platform, randomSpawnPosition, Quaternion.identity);
        spawnTime = 0;
    }

    void Update()
    {
        spawnTime += Time.deltaTime;

        if (transform.position.y > 50)
        {
            Destroy(this.gameObject);
        }
    }
}
