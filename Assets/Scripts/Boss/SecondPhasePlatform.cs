using UnityEngine;

public class SecondPhasePlatform : MonoBehaviour
{
    private float speed = 0.5f;
    private float movementSpeed = 1.0f;
    private float range = 2.4f;  // Range of movement
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        // Move up constantly
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Check if it reaches the upper limit, then move to the lower limit
        if (transform.localPosition.y > range)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -range, transform.localPosition.z);
        }

        // Move within the range
        movement = Vector3.up * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    // Method to activate the platform
    public void SetActivePlatform(bool active)
    {
        gameObject.SetActive(active);
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
