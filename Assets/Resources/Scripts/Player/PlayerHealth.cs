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
    public AudioSource audioSource;


    private void Awake()
    {
        isDead = false;
        currentHealth = maxHealth;

        audioSource = GetComponent<AudioSource>();

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
