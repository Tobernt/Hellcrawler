using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
<<<<<<< HEAD
    private float speed = 0.4f;
=======
    private float speed = 0.5f;
>>>>>>> 96d6f2fbfd6948db6e189c43d68cf4e2bdd24803
    public GameObject ScrollingBackground;
    public GameObject checkpointGround;

    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = transform;
        Vector2 myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime);

        if (transform.position.y > 50)
        {
            speed = 0;
            ScrollingBackground.GetComponent<ScrollingBackground>().speed = 0f;
            checkpointGround.SetActive(true);
        }
    }
}   