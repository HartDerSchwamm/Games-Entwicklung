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
        float distance = Vector3.Distance(playerposition, enemyPosition);
        float absDistance = Mathf.Abs(distance);
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (absDistance < attackRange)
        {
            anim.SetBool("attack",true);
        }else
        {
            anim.SetBool("attack", false);
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
