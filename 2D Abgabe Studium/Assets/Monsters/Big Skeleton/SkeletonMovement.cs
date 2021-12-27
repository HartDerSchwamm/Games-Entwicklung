using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    private Animator anim;
    private SkeletonAttack skeletonAttack;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        skeletonAttack = GetComponent<SkeletonAttack>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Shoot");
        }
    }
}
