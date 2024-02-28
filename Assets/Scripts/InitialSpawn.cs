using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSpawn : MonoBehaviour
{
    public GameObject Platform;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-2f, 2f), this.transform.position.y, 0);
        Instantiate(Platform, randomSpawnPosition, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
