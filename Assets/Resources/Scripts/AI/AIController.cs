using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public CharacterController characterController;
    public AreaCheck areaCheck;
    public EnemyAnimator enemyAnimator; // EnemyAnimator referansı
    public float wanderRadius = 10f;
    public float stopDistance = 2f;

    private Transform target;
    private bool isWandering;

    private void Start()
    {
        areaCheck.aiController = this;
        StartCoroutine(Wander());
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget > stopDistance)
            {
                navMeshAgent.SetDestination(target.position);
                enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Walk); 
            }
            else
            {
                navMeshAgent.ResetPath();
                enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Attack); 
            }
        }
        else if (isWandering)
        {
            enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Walk); 
        }
        else
        {
            enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Idle); 
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        transform.LookAt(target.position);
        isWandering = false;
        StopCoroutine(Wander());
    }

    public void ClearTarget()
    {
        target = null;
        isWandering = true;
        StartCoroutine(Wander());
    }

    private IEnumerator Wander()
    {
        isWandering = true;
        while (isWandering)
        {
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
            randomDirection += transform.position;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, -1);
            navMeshAgent.SetDestination(navHit.position);

            yield return new WaitForSeconds(5f);
        }
    }
}
