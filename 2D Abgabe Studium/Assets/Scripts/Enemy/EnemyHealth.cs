using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float maxHealth;
    public HealthbarBehavior healthbar;
    public float health;
    [SerializeField] private GameObject floatingDamagePoints;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        health = maxHealth;
        healthbar.SetHealth(health, maxHealth);
    }

    public void TakeHit(float damage)
    {
        health -= damage;
        healthbar.SetHealth(health, maxHealth);
        GameObject points = Instantiate(floatingDamagePoints, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(damage.ToString());

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



