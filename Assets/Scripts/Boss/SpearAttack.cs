using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : MonoBehaviour
{
    private Transform mainCamera;
    private Vector3 initialDirection;
    private float speed = 3f;
    private float delayBeforeAttack = 4.0f;
    private bool isAttacking = false;
    private float spacing;  // Adjust this value for the spacing between spears
    private static List<float> yPosList = new List<float>();  // Store the yPos of each spawned spear

    void Start()
    {
        // Find the main camera by tag
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;

        if (mainCamera != null)
        {
            // Set the spear's initial position and direction
            if (transform.localPosition.x < 0)
            {
                transform.position = new Vector3(-3.7f, Random.Range(-1.75f, 3.75f), 1);
                initialDirection = Vector3.right;
            }
            else
            {
                transform.position = new Vector3(3.7f, Random.Range(-1.75f, 3.75f), 1);
                initialDirection = Vector3.left;
            }

            // Make the spear a child of the MainCamera
            transform.SetParent(mainCamera);

            // Set the spacing value when starting the attack
            spacing = 0.25f; // Adjust this value for the spacing between spears

            // Calculate the initial yPos based on the previously spawned spear's yPos
            float yPos = yPosList.Count > 0 ? yPosList[yPosList.Count - 1] + spacing : mainCamera.position.y - 1.75f + 0.5f;

            // Set the initial yPos when the attack starts
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

            // Add the yPos to the list
            yPosList.Add(yPos);

            // Start the attack coroutine
            StartCoroutine(AttackCoroutine());
        }
        else
        {
            Debug.LogError("MainCamera not found. Make sure the camera is tagged as 'MainCamera'.");
        }
    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBeforeAttack);

            StartAttack();
        }
    }

    void StartAttack()
    {
        isAttacking = true;

        // Set the yPos based on the previously spawned spear's yPos
        float yPos = yPosList.Count > 0 ? yPosList[yPosList.Count - 1] + spacing : mainCamera.position.y - 1.75f + 0.5f;

        // Reset yPos to the bottom if it exceeds the upper limit
        if (yPos > mainCamera.position.y + 1.75f)
        {
            yPos = mainCamera.position.y - 1.75f + spacing;
        }

        // Set the initial yPos when the attack starts
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        // Add the yPos to the list
        yPosList.Add(yPos);
    }

    void Update()
    {
        if (isAttacking)
        {
            // Move the spear horizontally based on its initial direction
            transform.position += initialDirection * speed * Time.deltaTime;

            Destroy(gameObject, 5.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the player object upon collision
            Destroy(other.gameObject);
        }
    }
}
