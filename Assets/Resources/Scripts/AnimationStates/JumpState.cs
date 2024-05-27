

public class JumpState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("JumpState Enter Durumundayım.");
        playerAnimator.Animator.SetBool("isJump", true);
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("JumpState Execute Durumundayım.");
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("JumpState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isJump", false);
    }
}
