

using UnityEngine;

public class IdleState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("IdleState Enter Durumundayım.");
        playerAnimator.Animator.SetBool("isIdle", true);
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("IdleState Execute Durumundayım.");

        if(Input.GetKey(KeyCode.W))
        {
            playerAnimator.ChangeState(new RunState());
        }
        else if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.ChangeState(new ShootState());
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.ChangeState(new JumpState());
        }
        
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("IdleState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isIdle", false);
    }
}
