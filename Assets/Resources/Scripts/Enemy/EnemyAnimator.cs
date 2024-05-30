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
        if (EnemyController.instance.isDead) return;
        anim = GetComponent<Animator>();
        currentState = AnimState.Idle;
    }

    private void Update()
    {
        if (EnemyController.instance.isDead) { return; }
        switch (currentState)
        {
            case AnimState.Idle:
                anim.SetBool("isWalk", false);
                break;
            case AnimState.Walk:
                anim.SetBool("isWalk", true);
                break;
            case AnimState.Attack:
                anim.SetTrigger("isAttack");
                break;
            case AnimState.Hit:
                anim.SetTrigger("isHit");
                break;
            case AnimState.Die:
                anim.SetTrigger("isDie");
                EnemyController.instance.isDead = true;
                break;
        }
    }

    public void SetAnimState(AnimState newState)
    {
        currentState = newState;
    }
}
