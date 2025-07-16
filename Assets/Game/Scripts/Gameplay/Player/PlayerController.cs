using UnityEngine;

[RequireComponent(typeof(PlayerMovementComponent), typeof(PlayerJumpComponent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimator _animator;
        
    private PlayerJumpComponent _playerJumpComponent;
    private PlayerMovementComponent _playerMovementComponent;
    
    private ISwipeInputProcessor _swipeInputProcessor;
    private IStrafeInputProcessor _strafeInputProcessor;

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
            _swipeInputProcessor.Swipe -= Swipe;
    }
        
    public void Initialize(ISwipeInputProcessor swipeInputProcessor, IStrafeInputProcessor strafeInputProcessor)
    {
        _strafeInputProcessor = strafeInputProcessor;
        _swipeInputProcessor = swipeInputProcessor;
        _animator.SetSpeed(_playerMovementComponent.CurrentSpeed);

        _swipeInputProcessor.Swipe += Swipe;
    }
    
    public void Stop()
    {
        _playerMovementComponent.Stop();
        _animator.SetSpeed(0);
    }

    private void Swipe(ISwipeInputProcessor.SwipeDirection swipeDirection)
    {
        if(swipeDirection != ISwipeInputProcessor.SwipeDirection.Up)
            return;
        
        _playerJumpComponent.Jump();
        _animator.TriggerJump();
    }
}