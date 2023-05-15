using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    Rigidbody2D rgb;
    Vector3 velocity;
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] Transform bulletTransform;

    public Animator animator;

    public float speedAmount = 2f;
    public float runAmount = 5f;
    public float jumpAmount = 4f;
    public bool shoot = false;



    public void Awake() 
    {
      rgb = GetComponent<Rigidbody2D>();
    }

#region update
    private void FixedUpdate() 
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);//GetAxis yatay veya dikey girdileri yakalamak için kullanılır.Normal değeri sıfırdır ama klavyeden tuşa basıldığı zaman negatif veya pozitif değer döndürür.Veloicty rigitbodyini hız değişkenini tutar.Sadece yatay eksende hareketini sağlar.
        transform.position += velocity * speedAmount * Time.deltaTime;//playerın pozisyonu velocityle ve bizim verdiğimiz float değerle çarpılır.Normal zamana uyarlanıp karaktermizin hareket etmesini sağlar.
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));//Speed parametresi yatay düzlemde eksi değer alabileceği için Horizontal değerin mutlak değerini kullanıyoruz.

        if (Input.GetButton("Jump")&& !animator.GetBool("isJumping"))
        {
            rgb.AddForce(Vector3.up * jumpAmount,ForceMode2D.Impulse);//Impulse anlık kuvvet uygular.
            animator.SetBool("isJumping", true);
        }
        //Playerımızın sağa sola kafasını çevirmesi bakış işlemini yapar.Quaternion nesnelerin dönmesini temsil eder.Eular ise dönmmenin korrdinatları.
        if(Input.GetAxisRaw("Horizontal") == -1)
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        
        else if(Input.GetAxisRaw("Horizontal") == 1)
             transform.rotation = Quaternion.Euler(0f,0f,0f);

        if (Input.GetKey(KeyCode.LeftShift))  
        {
            Debug.Log("Koşuyor");
            speedAmount = runAmount;
            animator.SetBool("isRun",true);
        }
        else
        {
            speedAmount = 2f;
            animator.SetBool("isRun",false);
        }

       if (Input.GetKey(KeyCode.Mouse0))  
        {
            Debug.Log("ateşediyor");
            animator.SetBool("shoot",true);
            StartCoroutine(Fire());
            
        }
        else
          animator.SetBool("shoot",false);

    }

    #endregion

    #region Isjumpingi groundla eşleme kontrol işemleri

    private void OnCollisionEnter2D(Collision2D collision) 
    {
      if(collision.gameObject.tag == "Ground")
      {
        animator.SetBool("isJumping", false);
      }  
    }
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground")
      {
        animator.SetBool("isJumping", true);
      }        
    }
    #endregion
    private IEnumerator Fire()
    {
        Instantiate(bulletPrefabs,bulletTransform.position,bulletTransform.rotation);
        Destroy(bulletPrefabs,2f);
        yield return new WaitForSeconds(3f);
    }
    
}//class