using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public enum AnimState
    {
        Idle,
        Walk,
        Attack,
        Hit,
        Die
    }

    private Animator anim;
    public AnimState currentState;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentState = AnimState.Idle;
    }

    private void Update()
    {
        switch (currentState)
        {
            case AnimState.Idle:
                anim.SetBool("isWalk", false);
                anim.SetBool("isAttack", false);
                break;
            case AnimState.Walk:
                anim.SetBool("isWalk", true);
                anim.SetBool("isAttack", false);
                break;
            case AnimState.Attack:
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalk", false);
                anim.SetBool("isAttack",true);
                break;
            case AnimState.Hit:
                anim.SetTrigger("isHit");
                break;
            case AnimState.Die:
                anim.SetBool("isDie", true);
                break;
        }
    }

    public void SetAnimState(AnimState newState)
    {
        currentState = newState;
    }
}
