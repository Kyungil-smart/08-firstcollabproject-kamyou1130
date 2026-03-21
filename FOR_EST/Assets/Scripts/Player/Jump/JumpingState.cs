using UnityEngine;

public class JumpingState : IState
{
    private PlayerStatus _status;
    private PlayerMovement _movement;

    public JumpingState(PlayerStatus status, PlayerMovement movement)
    {
        _status = status;
        _movement = movement;
    }
    
    public void Enter()
    {
        _status.IsJumping = true;
        _movement._rigidbody.
        _status.JumpVelocity = Mathf.Sqrt(_status.JumpPower * -2.0f * Physics2D.gravity.y);
    }

    public void Update()
    {
        if(_status.JumpVelocity < 0)
            _movement.ChangeJumpState(_movement.Falling);
    }

    public void Exit()
    {
    }
}