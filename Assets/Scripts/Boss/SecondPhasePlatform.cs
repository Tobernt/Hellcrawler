using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhasePlatform : MonoBehaviour
{
    private float speed = 0.5f;
    private float movementSpeed = 1.0f;
    private float upLimit = 3f;
    private float downLimit = -3f;
    private float direction = 1;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = transform;
        Vector2 myPosition = transform.position;
        this.gameObject.transform.parent = GameObject.FindWithTag("MainCamera").transform; ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);

        if (transform.position.y > upLimit)
        {
            direction = -0.5f;
        }
        else if (transform.position.y < downLimit)
        {
            direction = 1.5f;
        }
        movement = Vector3.up * direction * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        movement = Vector3.up * direction * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
