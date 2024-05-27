

using UnityEngine;

public class ShootState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("ShootState Enter Durumundayım.");
        playerAnimator.Animator.SetTrigger("isShoot");
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("ShootState Execute Durumundayım.");
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("ShootState Exit Durumundayım.");
        //playerAnimator.Animator.SetBool("isShoot", false);
    }
}
