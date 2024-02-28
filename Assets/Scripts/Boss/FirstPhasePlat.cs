using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPhasePlat : MonoBehaviour
{

    private float movementSpeed = 1.0f;
    private float rightLimit = 3f;
    private float leftLimit = -3f;
    private int direction = 1;
    private float directionVertical;
    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.right * direction * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
