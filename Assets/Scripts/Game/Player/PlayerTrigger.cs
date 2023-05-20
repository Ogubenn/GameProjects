using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Animator anim;
    private Health GettingHealt;
    public  int EnemyDamage = 5;//Turretin playera verdiği hasar

    void Awake()
    {
        anim = GetComponent<Animator>();
        GettingHealt = GetComponent<Health>();
    }

    #region Turretin mermisinin playera dokunması ve playerın canının azalması
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurretBullet"))
        {
            GettingHealt.TakeDamage(EnemyDamage);
            anim.SetTrigger("isDead");
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
