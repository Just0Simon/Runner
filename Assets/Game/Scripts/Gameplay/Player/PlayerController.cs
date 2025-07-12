using UnityEngine;

[RequireComponent(typeof(PlayerMovementComponent), typeof(PlayerJumpComponent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimator _animator;
        
    private PlayerJumpComponent _playerJumpComponent;
    private PlayerMovementComponent _playerMovementComponent;
    
    private SwipeInputProcessor _swipeInputProcessor;
    private StrafeInputProcessor _strafeInputProcessor;

    private void Awake()
    {
        _playerJumpComponent = GetComponent<PlayerJumpComponent>();
        _playerMovementComponent = GetComponent<PlayerMovementComponent>();
    }

    private void Update()
    {
        _playerMovementComponent.Move(_strafeInputProcessor.XDelta);
    }

    private void OnDestroy()
    {
        if(_swipeInputProcessor != null)
            _swipeInputProcessor.SwipeUp -= SwipeUp;
    }
        
    public void Initialize(SwipeInputProcessor swipeInputProcessor, StrafeInputProcessor strafeInputProcessor)
    {
        _strafeInputProcessor = strafeInputProcessor;
        _swipeInputProcessor = swipeInputProcessor;
        _animator.SetSpeed(_playerMovementComponent.CurrentSpeed);

        _swipeInputProcessor.SwipeUp += SwipeUp;
    }
    
    public void Stop()
    {
        _playerMovementComponent.Stop();
        _animator.SetSpeed(0);
    }

    private void SwipeUp()
    {
        _playerJumpComponent.Jump();
        _animator.TriggerJump();
    }
}