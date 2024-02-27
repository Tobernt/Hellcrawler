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
    private float swordSpawnTimer = 0f;
    private float swordSpawnInterval = 6f;


    private bool phaseOne = true;
    private bool phaseTwo = false;
    private bool phaseThree = false;

    private bool Hit = false;


    GameObject[] allPlatforms;

    private float reactivateTimer = 0f;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        allPlatforms = GameObject.FindGameObjectsWithTag("BossPlatforms");
        DeactivateBossPlatforms2();
    }
    private void DeactivateBossPlatforms2()
    {
        GameObject[] bossPlatforms2 = GameObject.FindGameObjectsWithTag("BossPlatforms2");

        foreach (GameObject platform in bossPlatforms2)
        {
            platform.SetActive(false);
            Debug.Log("Deactivating platform: " + platform.name);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Hit == true)
        {
            reactivateTimer += Time.deltaTime;
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

        if (phaseTwo)
        {
            Debug.Log("Entering phaseTwo");
            GameObject[] bossPlatforms2 = GameObject.FindGameObjectsWithTag("BossPlatforms2");

            foreach (GameObject platform in bossPlatforms2)
            {
                platform.SetActive(true);
                Debug.Log("Activating platform: " + platform.name);
            }
        }


        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (Health >= 6 && phaseOne)
        {
            swordSpawnTimer += Time.deltaTime;
        }

        if (swordSpawnTimer >= swordSpawnInterval)
        {
            SpawnSwords();
            swordSpawnTimer = 0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Health >= 0)
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

    private void SpawnSwords()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            for (int i = 0; i < 5; i++)
            {
                float delay = i * 0.5f; // Adjust this value for the delay between each sword spawn

                Invoke("SpawnSingleSword", delay);
            }
        }
    }

    private void SpawnSingleSword()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float xOffset = 0.2f;  // Adjust this value for the space between swords
            Vector3 spawnPosition = new Vector3(transform.position.x + xOffset, transform.position.y - 0.25f, 0);
            Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - spawnPosition) * Quaternion.Euler(0, 0, -37);

            Instantiate(Resources.Load<GameObject>("PreFab/Sword"), spawnPosition, spawnRotation);
        }
    }
}