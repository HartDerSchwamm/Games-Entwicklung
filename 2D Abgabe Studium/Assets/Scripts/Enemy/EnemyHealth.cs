using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] private float maxHealth;
    public HealthbarBehavior healthbar;
    public float health;



    private void Start()
    {
        health = maxHealth;
        healthbar.SetHealth(health, maxHealth);
    }

    public void TakeHit (float damage)
    {
        health -= damage;
        healthbar.SetHealth(health, maxHealth);

        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
