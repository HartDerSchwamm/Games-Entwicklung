using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGunAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;

    public void GunAttack()
    {
        projectile.transform.position = firePoint.position;
        projectile.GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));
    }
}
