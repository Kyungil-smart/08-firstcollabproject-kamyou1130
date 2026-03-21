using UnityEngine;

public class JumpStandbyState : IState
{
    private PlayerStatus _status;
    private PlayerMovement _movement;

    public JumpStandbyState(PlayerStatus status, PlayerMovement movement)
    {
        _status = status;
        _movement = movement;
    }
    
    public void Enter()
    {
        Debug.Log("Jump Standby");
        _status.IsJumping = false;
        _status.IsFalling = false;
        _status.JumpVelocity = Physics2D.gravity.y;
    }

    public void Update()
    {
        if(!_movement.IsGround())
            _movement.ChangeJumpState(_movement.Falling);
    }

    public void Exit()
    {
    }
}