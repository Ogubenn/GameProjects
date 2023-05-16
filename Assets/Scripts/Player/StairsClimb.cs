using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsClimb : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    Vector3 velocity;

    private float speed = 2f;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {

            Debug.Log("Merdiven çıkıyor");
            anim.SetBool("Climb",true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x,verticalInput * speed);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {
            anim.SetBool("Climb",false);
            rb.velocity = Vector2.zero;
        }
    }
}//class
