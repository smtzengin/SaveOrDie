using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public int health = 100;
    public LayerMask groundLayer; 
    public Transform groundCheck; 
    public float groundCheckDistance = 0.2f; 
    
    private bool isGrounded;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    private EnemyAnimator enemyAnimator;
    public bool isDead;
    private void Awake()
    {
        instance = this;
        isDead = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        if (isDead) { return; }
        GroundCheck();  
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundLayer, QueryTriggerInteraction.Ignore);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        QuestManager.instance.IncrementQuestProgress(1);
        enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Die);
        
    }
}
