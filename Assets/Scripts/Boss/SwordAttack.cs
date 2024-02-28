using UnityEngine;
using UnityEngine.Analytics;

public class SwordAttack : MonoBehaviour
{
    private Transform player;
    private Transform mainCamera;
    public float rotationOffsetZ = -37.0f; // Adjust this value as needed
    private float speed = 1.2f;
    private float delayBeforeAttack = 1.0f; // Adjust this value for the delay before attacking
    private bool isAttacking = false;

    void Start()
    {        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main.transform;

        // Make the sword a child of the MainCamera
        transform.SetParent(mainCamera);

        // Start the attack after 1 second
        Invoke("StartAttack", delayBeforeAttack);
        Destroy(gameObject, 4.0f);
    }

    void StartAttack()
    {
        isAttacking = true;
    }

    void Update()
    {
        if (isAttacking && player != null)
        {
            // Point the sword at the player with a Z rotation offset
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.right = targetPosition - transform.position;
            transform.Rotate(new Vector3(0, 0, rotationOffsetZ));

            // Move the sword towards the player in world space
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {            
            // Destroy the player object upon collision
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("BossPlatforms"))
        {
            // Destroy the sword when it touches BossPlatforms
            Destroy(gameObject);
        }
    }
}
