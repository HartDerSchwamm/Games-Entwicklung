using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanatosAttack : MonoBehaviour
{
    private bool canAttack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canAttack)
        {
            collision.GetComponent<Health>().TakeDamage(2);
            canAttack = false;                         
        }
    }

    public void EnableAttack()
    {
        canAttack = true;
    }

    public void DisableAttack()
    {
        canAttack = false;
    }
}
