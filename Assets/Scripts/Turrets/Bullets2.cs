using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets2 : MonoBehaviour
{
  
    public float bulletSpeed = 20f;
    public Rigidbody2D rb; 

    [Range(-1, 1)]
    [SerializeField] public int trans = 1;//Turretin nereye mermi atacağı değişkeni 1 se sağ -1 se sol

    void Start()
    {
        rb.velocity = (trans*transform.right) * bulletSpeed;//baştaki sayıyı -1 yapınca lefte ateş eder 1 olursa righta ateş eder.
    }
    
}
