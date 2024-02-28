using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBossScript : MonoBehaviour
{
    public int Health = 6;
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
    private bool phaseTwoActivated = false;
    private bool phaseOne = true;
    private bool phaseTwo = false;
    private bool spearsSpawned = false;
    private SecondPhasePlatform[] secondPhasePlatforms;
    private int currentSpearIndex = 0;
    private float delayBetweenSpears = 1f;
    private float lastHitTime = 0f;
    private float hitCooldown = 3f;

    private bool Hit = false;

    GameObject[] allPlatforms;
    public GameObject CheckpointDoor;

    private float reactivateTimer = 0f;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        allPlatforms = GameObject.FindGameObjectsWithTag("BossPlatforms");
        secondPhasePlatforms = FindObjectsOfType<SecondPhasePlatform>();
        DeactivateSecondPhasePlatforms();
    }

    // Update is called once per frame
    void Update()
    {

        if (phaseTwo && !spearsSpawned)
        {
            InvokeRepeating("SpawnSingleSpear", 0f, delayBetweenSpears); // Adjust the delay as needed
            spearsSpawned = true; // Set the flag to true to indicate spears are spawned
        }


        if (phaseTwo && !phaseTwoActivated)
        {
            Debug.Log("Entering phaseTwo");

            // Activate second phase platforms
            foreach (SecondPhasePlatform platform in secondPhasePlatforms)
            {
                platform.SetActivePlatform(true);
            }

            phaseTwoActivated = true; // Set the flag to true to indicate phase two has been activated
        }

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


        if (Health == 3 && phaseOne == true)
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
            CheckpointDoor.SetActive(true);
            Destroy(this.gameObject);
        }

        if (Health >= 3 && phaseOne)
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
        if (collision.gameObject.tag == "Player" && Health >= 0 && Time.time - lastHitTime >= hitCooldown)
        {
            Health--;
            foreach (GameObject platforms in allPlatforms)
                platforms.SetActive(false);
            Hit = true;

            // Update the last hit time
            lastHitTime = Time.time;
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

    private void DeactivateSecondPhasePlatforms()
    {
        // Deactivate second phase platforms at the start
        foreach (SecondPhasePlatform platform in secondPhasePlatforms)
        {
            platform.gameObject.SetActive(false);
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
    private void SpawnSingleSpear()
    {
        float startY = -1.75f;
        float endY = 1.75f;
        float spacing = 0.25f;
        float xPosLeft = -3.7f;
        float xPosRight = 3.7f;

        if (startY + currentSpearIndex * spacing <= endY)
        {
            // Spawn spear on the left side
            Vector3 leftSpawnPosition = new Vector3(xPosLeft, startY + currentSpearIndex * spacing, 1);
            Quaternion leftSpawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(Resources.Load<GameObject>("PreFab/Spear"), leftSpawnPosition, leftSpawnRotation);

            // Spawn spear on the right side with rotation
            Vector3 rightSpawnPosition = new Vector3(xPosRight, startY + currentSpearIndex * spacing, 1);
            Quaternion rightSpawnRotation = Quaternion.Euler(0, 0, 180); // Rotate the spear on the right side
            Instantiate(Resources.Load<GameObject>("PreFab/Spear"), rightSpawnPosition, rightSpawnRotation);

            currentSpearIndex++;
        }
        else
        {
            // Reset the spear spawning when all spears are spawned
            currentSpearIndex = 0;
        }
    }
}