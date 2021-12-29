using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanatosMovement : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform player;
    [SerializeField] private float attackRange;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 playerposition = player.transform.position;
        Vector3 enemyPosition = gameObject.transform.position;
        float distance = Mathf.Abs(Vector3.Distance(playerposition, enemyPosition));
        if (distance < attackRange)
        {
            anim.SetTrigger("attack");
        }
    }

    public void EnableAttack()
    {
        gameObject.GetComponentInChildren<ThanatosAttack>().EnableAttack();
    }

    public void DisableAttack()
    {
        gameObject.GetComponentInChildren<ThanatosAttack>().DisableAttack();
    }
}
