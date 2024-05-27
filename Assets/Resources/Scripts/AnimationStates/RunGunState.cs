

public class RunGunState : IState
{
    public void Enter(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunGunState Enter Durumundayım.");
    }

    public void Execute(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunGunState Execute Durumundayım.");
    }

    public void Exit(PlayerAnimator playerAnimator)
    {
        UnityEngine.Debug.Log("RunGunState Exit Durumundayım.");
    }
}
