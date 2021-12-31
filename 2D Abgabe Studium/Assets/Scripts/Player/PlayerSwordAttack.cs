using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{  
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeHit(damage);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
