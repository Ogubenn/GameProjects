using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealt;

    public int outHealth = 5;

    public HealthBar healthBar;

    void Start()
    {
        currentHealt = maxHealth;
        healthBar.SetMaxHealt(maxHealth);
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(outHealth);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealt -= damage;
        healthBar.SetHealth(currentHealt);
    }


}//class
