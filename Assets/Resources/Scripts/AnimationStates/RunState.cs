
using UnityEngine;

public class RunState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunState Enter Durumundayım.");
        playerAnimator.Animator.SetBool("isRun", true);
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        if (Input.GetKey(KeyCode.W))
        {
            UnityEngine.Debug.Log("RunState Execute Durumundayım.");

            if (Input.GetKey(KeyCode.Space))
            {
                playerAnimator.ChangeState(new JumpState());
            }
        }
        else if(Input.GetMouseButton(0))
        {
            playerAnimator.ChangeState(new ShootState());
        }
        
        else
        {
            playerAnimator.ChangeState(new IdleState());
        }
        
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isRun", false);      
    }

   
}
