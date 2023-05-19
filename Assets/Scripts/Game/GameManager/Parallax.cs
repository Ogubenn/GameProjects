using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cam;

    [SerializeField] private float moveSpeed;

    void Update() 
    {
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0f, 0f);

        if(cam.position.x  >= transform.position.x + 18f)
        {
            transform.position = new Vector2(cam.position.x + 18f,transform.position.y);
        } 

    }



}//class