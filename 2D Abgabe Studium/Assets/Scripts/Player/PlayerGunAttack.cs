using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGunAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;

    public void GunAttack()
    {
        projectiles[0].transform.position = firePoint.position;
        projectiles[0].GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));
    }
}
