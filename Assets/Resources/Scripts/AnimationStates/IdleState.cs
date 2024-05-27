


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
        
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("IdleState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isIdle", false);
    }
}
