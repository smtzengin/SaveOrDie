

using UnityEngine;

public class ShootState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("ShootState Enter Durumundayım.");
        playerAnimator.Animator.SetBool("isShoot", true);
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        if(Input.GetMouseButton(0))
        {
            UnityEngine.Debug.Log("ShootState Execute Durumundayım.");
        }
        if (Input.GetKeyDown(KeyCode.W))
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
        UnityEngine.Debug.Log("ShootState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isShoot", false);
    }
}
