using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public LayerMask groundLayer; 
    public Transform groundCheck; 
    public float groundCheckDistance = 0.2f; 

    private bool isGrounded;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GroundCheck();
        if (isGrounded)
        {
            
            navMeshAgent.enabled = true;
            rb.isKinematic = true;
        }
        else
        {
            
            navMeshAgent.enabled = false;
            rb.isKinematic = false;
        }
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
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
