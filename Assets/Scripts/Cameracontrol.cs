using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
    public float speed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = transform;
        Vector2 myPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed);
    }
}   