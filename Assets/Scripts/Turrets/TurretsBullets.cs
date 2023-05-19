using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsBullets : MonoBehaviour
{
    [SerializeField] Animator anim;
    public GameObject turretBulletPrefab;
    public Transform turretSpawnPoint;



    void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            InstantiateBullet();
            yield return new WaitForSeconds(5f);
        }   
    }

    private void InstantiateBullet()
    {
        GameObject bullet = Instantiate(turretBulletPrefab,turretSpawnPoint.position,turretSpawnPoint.rotation);
    }

    #region Turretin ölmesi ve animasyonu girmesi
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            anim.SetBool("TurretDead",true);
            Invoke("TurretDown",1.25f);//Invoke bir fonksiyonu belirlediğimiz zaman sonra çalışan bir fonksiyondur.
        }
    }

    public void TurretDown()
    {
        gameObject.SetActive(false);
    }
    #endregion
}//class
