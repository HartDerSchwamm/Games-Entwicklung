using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    PlayerMovement playerMovement;
    public float currentHealth { get; private set; }


    private void Awake()
    {
        currentHealth = startingHealth;
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
      
        if (currentHealth > 0)
        {
            playerMovement.GetDamage();
            
        }
        else
        {
            playerMovement.Die();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
            print(currentHealth);
        }
    }
}
