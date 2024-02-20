using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSpawn : MonoBehaviour
{

    public GameObject Platform;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-1f, 1f), this.transform.position.y, 0);
        Instantiate(Platform, randomSpawnPosition, Quaternion.identity);
        Destroy(this.gameObject);
    }
    // Update is called once per frame

    void Update()
    {

    }
}
