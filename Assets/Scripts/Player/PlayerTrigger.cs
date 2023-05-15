using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            //Düşman can azalma işlemleri yapılıcak*******
            Debug.Log("düşmana hit atıyorum");
        }
    }
}
