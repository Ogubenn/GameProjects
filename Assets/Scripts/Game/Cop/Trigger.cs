using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] AudioClip Dead;
   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.gameObject.CompareTag("PlayerBullet"))
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(Dead,transform.position);
        }
   }

}//class
