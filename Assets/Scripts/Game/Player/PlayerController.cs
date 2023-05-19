using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    Rigidbody2D rgb;
    Vector3 velocity;

    [Header("Bullets")]
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] Transform bulletTransform;

    [Header("Animasyon")]
    [SerializeField] Animator animator;

    [Header("Karakter Hız İşlemleri")]
    public float speedAmount = 2f;//Karakter hızı
    public float runAmount = 5f;//Karakterin koşma hızı
    public float jumpAmount = 4f;//Karakterin zıplama hızı


    #region Awake
    public void Awake() 
    {
      rgb = GetComponent<Rigidbody2D>();
    }

    #endregion

  
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Mouse0))  
        {
            Shoot();//Fixed updatede frame atladığı ve düzgün çalışmadığı için update'e yazdık.
        }
    }

    private void FixedUpdate() 
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButton("Jump")&& !animator.GetBool("isJumping"))
        {
            rgb.AddForce(Vector3.up * jumpAmount,ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
        if(Input.GetAxisRaw("Horizontal") == -1)
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        
        else if(Input.GetAxisRaw("Horizontal") == 1)
             transform.rotation = Quaternion.Euler(0f,0f,0f);

        if (Input.GetKey(KeyCode.LeftShift))  
        {
            speedAmount = runAmount;
            animator.SetBool("isRun",true);
        }
        else
        {
            speedAmount = 2f;
            animator.SetBool("isRun",false);
        }
    }


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

    #region Ateş fonksiyonu
    void Shoot()
    {
        animator.SetBool("shoot",true);
        StartCoroutine(Fire());
    } 
    private IEnumerator Fire()
    {
        GameObject bullet =  Instantiate(bulletPrefabs,bulletTransform.position,bulletTransform.rotation);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("shoot",false);
        Destroy(bullet,5f);
    }
    #endregion
    
}//class