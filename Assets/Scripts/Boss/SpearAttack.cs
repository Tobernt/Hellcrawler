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
    private float yPos;  // Store the calculated y-position

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

            // Calculate the initial yPos
            yPos = mainCamera.position.y - 3.75f + spacing * transform.GetSiblingIndex() + 0.5f;

            // Start the attack after the specified delay
            Invoke("StartAttack", delayBeforeAttack);
        }
        else
        {
            Debug.LogError("MainCamera not found. Make sure the camera is tagged as 'MainCamera'.");
        }
    }

    void StartAttack()
    {
        isAttacking = true;

        // Set the initial yPos when the attack starts
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
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
