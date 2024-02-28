using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathcheck : MonoBehaviour
{
    public GameObject GameOver;
    private float speed;
    public GameObject ScrollingBackground;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameOver.SetActive(true);
            Destroy(collision.gameObject);
            
            ScrollingBackground.GetComponent<ScrollingBackground>().speed = 0f;
            Time.timeScale = 0;

            //On Death of Player
        }
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
