using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Move Components")]
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Other Player Components")]
    private PlayerAnimator playerAnimator;
    private PlayerHealth playerHealth;
    private AudioSource audioSource;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isMoving;

    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerHealth = GetComponent<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerHealth != null && playerHealth.currentHealth == 0) return;

        GroundCheck();
        Move();
        Jump();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void Move()
    {
        if (!QuestManager.instance.isQuestStarted) return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            playerAnimator.ChangeState(new RunState());
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(PlayFootsteps());
            }
        }
        else
        {
            playerAnimator.ChangeState(new IdleState());
            isMoving = false;
        }
    }

    void Jump()
    {
        //if (!QuestManager.instance.isQuestStarted) return;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            playerAnimator.ChangeState(new JumpState());
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator PlayFootsteps()
    {
        while (isMoving)
        {
            if (isGrounded)
            {
                AudioManager.instance.PlayAudioClip(audioSource, "PlayerFootstep");
            }
            yield return new WaitForSeconds(0.5f); // Adım seslerinin çalma sıklığı
        }
    }
}
