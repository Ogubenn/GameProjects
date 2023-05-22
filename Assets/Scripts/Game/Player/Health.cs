using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject RestartMenu;
    public int maxHealth = 100;//max can
    public int currentHealt;//geçerli can

    public int outHealth = 5;//düşmandan damage yiyince giden can miktarı
    

    public HealthBar healthBar;

    void Start()
    {
        currentHealt = maxHealth;
        healthBar.SetMaxHealt(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        healthBar.SetHealth(currentHealt);
        if (currentHealt <= 0)
            PlayerDead();
    }

    public void PlayerDead()
    {
        gameObject.SetActive(false);
        RestartMenu.SetActive(true);
        Time.timeScale = 0;

    }


}//class
