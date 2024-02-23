using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBossScript : MonoBehaviour
{
    public int Health = 9;
    private float speed = 0.5f;
    private float movementSpeed = 1.0f;
    private float RotAngleZ = 10;
    private float rightLimit = 3.8f;
    private float leftLimit = -3.8f;
    private float topLimit = 1.3f;
    private float bottomLimit = 0.8f;
    private int direction = 1;
    private float directionVertical;

    public SpawnPhaseTwoScript other;
    public SpawnPhaseTwoScript otherTwo;

    private bool phaseOne = true;
    private bool phaseTwo = false;
    private bool phaseThree = false;

    private bool Hit = false;

    private bool SpawnedPhaseTwo = false;


    GameObject[] allPlatforms;

    private float reactivateTimer = 0f;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        allPlatforms = GameObject.FindGameObjectsWithTag("BossPlatforms");
    }

    // Update is called once per frame
    void Update()
    {

        if (Hit == true) 
        {  
        reactivateTimer += Time.deltaTime;
        }

        if (phaseTwo == true && SpawnedPhaseTwo == false)
        {

            other.spawnPlatform();
            otherTwo.spawnPlatform();
            SpawnedPhaseTwo = true;
        }

        if (reactivateTimer > 3)
        {
            reactivatePlatforms();
            Hit = false;
            reactivateTimer = 0;
            
        }

        float rz = Mathf.SmoothStep(-10, RotAngleZ, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(0, 0, rz);

        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }

        if (transform.position.y > topLimit)
        {
            directionVertical = -1f;
            transform.position += new Vector3(0, directionVertical * Time.deltaTime);
        }

        if (transform.position.y > bottomLimit)
        {
            directionVertical = 1f;
            transform.position += new Vector3(0, directionVertical * Time.deltaTime);
        }

        movement = Vector3.right * direction * movementSpeed * Time.deltaTime;
        transform.Translate(movement);


        if (Health == 6 && phaseOne == true)
        {
            foreach (GameObject platforms in allPlatforms)
            {
                Destroy(platforms);
                phaseOne = false;
                phaseTwo = true;
            }
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Health >= 7)
        {
            Health--;
            foreach (GameObject platforms in allPlatforms)
                platforms.SetActive(false);
            Hit = true;

        }
    }

    private void reactivatePlatforms()
    {
        if (phaseOne == true) 
        { 
        foreach (GameObject platforms in allPlatforms)
        platforms.SetActive(true);
        reactivateTimer = 0;
        }
    }
}
