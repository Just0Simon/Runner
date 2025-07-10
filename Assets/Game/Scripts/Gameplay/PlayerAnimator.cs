using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string JUMP_KEY = "Jump";
    private const string SPEED_KEY = "Speed";
    
    private readonly int _jumpKeyHash = Animator.StringToHash(JUMP_KEY);
    private readonly int _speedKeyHash = Animator.StringToHash(SPEED_KEY);
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerJump()
    {
        _animator.SetTrigger(_jumpKeyHash);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedKeyHash, speed);
    }
}