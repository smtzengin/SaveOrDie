

using UnityEngine;

public class JumpState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("JumpState Enter Durumundayım.");
        playerAnimator.Animator.SetBool("isJump", true);
    }

    public void Execute(PlayerAnimator playerAnimator)
    {

        if (Input.GetKey(KeyCode.Space))
        {
            UnityEngine.Debug.Log("JumpState Execute Durumundayım.");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.ChangeState(new RunState());
        }
        else
        {
            playerAnimator.ChangeState(new IdleState());
        }

    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("JumpState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isJump", false);
    }
}
