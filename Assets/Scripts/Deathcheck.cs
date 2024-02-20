using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathcheck : MonoBehaviour
{
    float speed = 0.001f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(collision.gameObject);        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
    private void Start()
    {

        Transform myTransform = transform;
        Vector2 myPosition = transform.position;
        
    }
    void Update()
    {
        transform.position += new Vector3(0, speed);
    }
}
