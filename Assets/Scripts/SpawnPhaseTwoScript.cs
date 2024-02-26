using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPhaseTwoScript : MonoBehaviour
{

    public GameObject Platform;

    // Start is called before the first frame update
        void Start()
    {
    }
    // Update is called once per frame

    public void spawnPlatform()
    {
        Vector3 randomSpawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Instantiate(Platform, randomSpawnPosition, Quaternion.identity);

    }

    void Update()
    {
    }
}
