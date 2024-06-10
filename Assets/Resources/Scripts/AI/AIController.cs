using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public enum EnemyType
    {
        Zombie,
        Witch
    }

    public EnemyType enemyType;
    public NavMeshAgent navMeshAgent;
    public AreaCheck areaCheck;
    public EnemyAnimator enemyAnimator;
    public float wanderRadius = 10f;
    public float stopDistance = 2f;
    public float attackDistance = 2f;
    public float witchAttackDistance = 10f; // Witch için saldırı mesafesi
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    public GameObject spellPrefab; // Witch için büyü prefabı

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
        if (!navMeshAgent.isActiveAndEnabled) return;

        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (enemyType == EnemyType.Witch)
            {
                if (distanceToTarget > witchAttackDistance)
                {
                    navMeshAgent.SetDestination(target.position);
                    enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Walk);
                }
                else
                {
                    navMeshAgent.ResetPath();
                    if (distanceToTarget <= witchAttackDistance && canAttack)
                    {
                        StartCoroutine(CastSpell());
                    }
                    else
                    {
                        enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Idle);
                    }
                }
            }
            else // Zombie için
            {
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
        while (target != null && Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            canAttack = false;
            enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Attack);
            yield return new WaitForSeconds(0.5f);

            if (target != null && Vector3.Distance(transform.position, target.position) <= attackDistance)
            {
                PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage);
                }
            }

            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }

    private IEnumerator CastSpell()
    {
        while (target != null && Vector3.Distance(transform.position, target.position) <= witchAttackDistance)
        {
            canAttack = false;
            enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Attack);
            yield return new WaitForSeconds(0.5f);

            if (target != null)
            {
                GameObject spell = Instantiate(spellPrefab, transform.position + Vector3.up, Quaternion.identity);
                spell.GetComponent<Spell>().Initialize(target);
            }

            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
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
            if (navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(navHit.position);
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
