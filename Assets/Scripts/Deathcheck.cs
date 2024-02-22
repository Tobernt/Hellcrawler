using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathcheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
             //On Death of Player
        }
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
    private void Start()
    {
        
    }
    void Update()
    {

    }
}
