using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public AreaCheck areaCheck;
    public EnemyAnimator enemyAnimator; // EnemyAnimator referansı
    public float wanderRadius = 10f;
    public float stopDistance = 2f;
    public float attackDistance = 2f; // Saldırı mesafesi
    public int attackDamage = 10; // Saldırı hasarı
    public float attackCooldown = 2f; // Saldırı bekleme süresi

    private Transform target;
    private bool isWandering;
    private bool canAttack = true;

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
                if (distanceToTarget <= attackDistance && canAttack)
                {
                    StartCoroutine(Attack());
                }
                else
                {
                    enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Idle);
                }
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

    private IEnumerator Attack()
    {
        canAttack = false;
        enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Attack);

        yield return new WaitForSeconds(0.5f); // Saldırı animasyonunun ortasında hasar ver

        if (target != null && Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(attackCooldown); // Saldırı bekleme süresi
        canAttack = true;
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
