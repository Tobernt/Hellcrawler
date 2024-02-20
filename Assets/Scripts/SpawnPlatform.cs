using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public GameObject Platform;
    public float spawnTime = 2f;

    // Start is called before the first frame update
        void Start()
    {
        InvokeRepeating("spawnPlatform", spawnTime, spawnTime);
    }
    // Update is called once per frame

    void spawnPlatform()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-1f, 1f), this.transform.position.y, 0);
        Instantiate(Platform, randomSpawnPosition, Quaternion.identity);
    }

    void Update()
    {

    }
}
