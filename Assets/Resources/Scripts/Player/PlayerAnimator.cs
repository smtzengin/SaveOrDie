using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator Animator { get; set; }
    private IState currentState;
    private IState idleState;
    private IState jumpState;
    private IState runState;
    private IState runGunState;
    private IState shootState;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        idleState = new IdleState();
        jumpState = new JumpState();
        runState = new RunState();
        runGunState = new RunGunState();
        shootState = new ShootState();

        currentState = idleState;
        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.Execute(this);
    }

    public void ChangeState(IState newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }
}
