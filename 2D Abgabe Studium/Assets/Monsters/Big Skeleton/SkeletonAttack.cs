using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] private Transform skeletonFirePoint;
    [SerializeField] private GameObject skeletonProjectile;

    public void Charge()
    {
        skeletonProjectile.transform.position = skeletonFirePoint.position;
        skeletonProjectile.GetComponent<SkeletonProjectile>().SetDirection(-Mathf.Sign(transform.localScale.x));
        skeletonProjectile.GetComponent<SkeletonProjectile>().Charge();
    }

    public void Fire()
    {
        skeletonProjectile.GetComponent<SkeletonProjectile>().Fire();
    }
}
