public interface IState
{
    void Enter(PlayerAnimator playerAnimator);
    void Execute(PlayerAnimator playerAnimator);
    void Exit(PlayerAnimator playerAnimator);
}