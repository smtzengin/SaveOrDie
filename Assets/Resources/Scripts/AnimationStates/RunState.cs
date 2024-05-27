

public class RunState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunState Enter Durumundayım.");
        playerAnimator.Animator.SetBool("isRun", true);
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunState Execute Durumundayım.");
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunState Exit Durumundayım.");
        playerAnimator.Animator.SetBool("isRun", false);      
    }

   
}
