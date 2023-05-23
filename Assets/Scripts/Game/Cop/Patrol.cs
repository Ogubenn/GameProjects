using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    public LayerMask groundLayer; // Yere temas eden collider tipi tespit etmek için

    private bool movingRight = true;

    public Transform groundDetection;
    

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);//right yönünde hareket eder sped kadar ve zamana uyarlanmış şekilde.

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance,groundLayer);//Bir raycast oluşturur.aldğı ilk parametre bizim verdğimiz ground detection yani boş objenin positionu,.2.parametre düşeyde raycast,3.parametre uzaklık,distance ışının hareket edebileceği maks.mesafe)raycast çarpıtğı ilk nesnenin bilgilerini tutar.
        if(!groundInfo.collider)
        {
            if(movingRight)
            {
                transform.eulerAngles = new Vector3(0,-180,0);//transfor.eulerAngles nesnenin rotasyonunu okumak ve değiştirmek için kullanılır.
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight= true;
            }
        }
    }
}//class