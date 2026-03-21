using UnityEngine;

/// <summary>
/// 플레이어 캐릭터 스테이터스([M]VP)
/// 기획 상 전투부분은 없어
/// 속도, 점프력 등 이동관련으로 설정.
/// </summary>
[System.Serializable]
public class PlayerStatus
{
    public Vector2 InputAxis;
    public float MoveSpeed;
    public float PushSpeed;
    public float JumpPower;

    public bool IsJumping { get; set; }
    public bool IsFalling { get; set; }

    private float _jumpVelocity;
    public float JumpVelocity
    {
        get => _jumpVelocity;
        set
        {
            if (_jumpVelocity < Physics2D.gravity.y)
                _jumpVelocity = Physics2D.gravity.y;
            else _jumpVelocity = value;
        }
    }
    public Vector2 BeforePosition { get; set; }
}
