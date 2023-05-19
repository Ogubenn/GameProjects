using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsBullets : MonoBehaviour
{
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject,2f);
        }
    }
}//class
