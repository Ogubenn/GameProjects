using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    private Animator anim;
    private Health GettingHealt;
    Rigidbody2D rb;

    [Header("Turret")]
    public  int Damage = 5;//Turretin playera verdiği hasar
    public float Force = 10f;

    [Header("Cop")]

    public int DamageCop = 100;//Copun playera verdiği hasar

    [Header("Player")]
    [SerializeField] AudioClip HurtClip;


    void Awake()
    {
        anim = GetComponent<Animator>();
        GettingHealt = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
    }

    #region Turretin mermisinin playera dokunması ve playerın canının azalması
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurretBullet"))
        {
            GettingHealt.TakeDamage(Damage);
            anim.SetTrigger("isDead");
            AudioSource.PlayClipAtPoint(HurtClip,transform.position);
            Vector2 forceDirection = transform.position - other.transform.position;
            forceDirection = forceDirection.normalized;
            rb.AddForce(forceDirection * Force,ForceMode2D.Impulse);

        }
        else if(other.gameObject.CompareTag("Cop"))
        {
            GettingHealt.TakeDamage(DamageCop);
            anim.SetTrigger("isDead");
            AudioSource.PlayClipAtPoint(HurtClip,transform.position);
        }

        if(GettingHealt.currentHealt <= 0)
            PlayerDead();
    }

    public void PlayerDead()
    {
        //gameObject.SetActive(false);
        //Checkpoint sisteminde checkpointe geri dönüş yapılacak.
    }

    #endregion

}
