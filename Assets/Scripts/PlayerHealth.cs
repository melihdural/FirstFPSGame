using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (currentHealth>0f)
            {
                TakeDamage(10f);
            }
            
            if(currentHealth<=0f)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMenager>().Death();
            }
        }
    }


    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
