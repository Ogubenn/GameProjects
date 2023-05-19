using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsClimb : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    Vector3 velocity;

    private float speed = 2f;//Playerın merdiveni çıkma hızı
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    #region Merdivenden çıkmak
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {
            rb.gravityScale = 0f;//Merdivenden çıkması için yerçekimini sıfırlıyoruz.
            anim.SetBool("Climb",true);
        }
    }

    #endregion 

    #region Merdivende Kalmak
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x,verticalInput * speed);
        }
    }

    #endregion

    #region Merdivenden ayrılmak
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {
            anim.SetBool("Climb",false);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 1f;//Yerçekimini tekrardan 1 e getiriyoruz ve normal haline dönüyor.
        }
       
    }

    #endregion
}//class
