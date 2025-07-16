using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int _jumpKeyHash = Animator.StringToHash(Constants.JUMP_KEY);
    private readonly int _speedKeyHash = Animator.StringToHash(Constants.SPEED_KEY);
    
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