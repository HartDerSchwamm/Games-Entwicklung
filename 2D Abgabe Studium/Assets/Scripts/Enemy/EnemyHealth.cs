using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float maxHealth;
    public HealthbarBehavior healthbar;
    public float health;

     private void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
            anim.SetTrigger("dead");
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
