using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets2 : MonoBehaviour
{
  
    public float bulletSpeed = 20f;
    public Rigidbody2D rb; 

    void Start()
    {
        rb.velocity = (-1*transform.right) * bulletSpeed;
    }
    
}
