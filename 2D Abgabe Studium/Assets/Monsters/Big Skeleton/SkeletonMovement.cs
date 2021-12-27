using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    private Animator anim;
    private SkeletonAttack skeletonAttack;
    [SerializeField] private Transform player;
    [SerializeField] private float attackRange;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        skeletonAttack = GetComponent<SkeletonAttack>();
    }

    void Update()
    {
        Vector3 playerposition = player.transform.position;
        Vector3 enemyPosition = gameObject.transform.position;
        float distance = Mathf.Abs(Vector3.Distance(playerposition,enemyPosition));
        if (distance < attackRange)
        {
            anim.SetTrigger("Shoot");
        }
    }
}
