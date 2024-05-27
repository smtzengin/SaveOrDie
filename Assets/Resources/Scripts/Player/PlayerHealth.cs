using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int minHealth;
    public bool isDead;
    public event Action OnPlayerHealthChanged;


    private void Awake()
    {
        isDead = false;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if(isDead) return;

        if(currentHealth > minHealth)
        {
            currentHealth -= damage;
            OnPlayerHealthChanged?.Invoke();
        }
        else
        {
            currentHealth = minHealth;
            isDead = true;
        }
    }


}
