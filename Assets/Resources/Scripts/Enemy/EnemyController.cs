using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    private AreaCheck areaCheck;
    private EnemyAnimator enemyAnimator;
    public bool isDead;

    public Slider healthSlider;

    private void Awake()
    {
        instance = this;
        isDead = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        areaCheck = GetComponentInChildren<AreaCheck>();
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
        healthSlider.value = health;
        if (health <= 0)
        {
            isDead = true;
            health = 0;
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        QuestManager.instance.IncrementQuestProgress(1);
        enemyAnimator.SetAnimState(EnemyAnimator.AnimState.Die);
        areaCheck.sphereCollider.enabled = false;
        navMeshAgent.enabled = false; 
        enemyAnimator.StopAllAnimations();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }



}
