using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePopScript : MonoBehaviour
{
    // public GameObject Player = new GameObject("Player");

    public Animator anim;
    public bool time = false;
    private float timer = 1f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            timer = 0f;
            time = true;
        }
    }
    void Update()
    {
        
        if(time == true && timer > 1f)
        {
            anim.Play("BubblePop");
            timer = 0f;

            Destroy(this.gameObject, 1);
        }

        if(time == true)
        {
            timer += Time.deltaTime;
        }
    }
}
