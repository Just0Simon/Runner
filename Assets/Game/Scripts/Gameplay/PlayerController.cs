using UnityEngine;

[RequireComponent(typeof(PlayerMovementComponent), typeof(PlayerJumpComponent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimator _animator;
        
    private PlayerMovementComponent _playerMovementComponent;
    
    private SwipeInputProcessor _swipeInputProcessor;
    private StrafeInputProcessor _strafeInputProcessor;

    private void Awake()
    {
        _playerMovementComponent = GetComponent<PlayerMovementComponent>();
    }

    private void Update()
    {
        _playerMovementComponent.Move(_strafeInputProcessor.XDelta);
        _animator.SetSpeed(_playerMovementComponent.CurrentSpeed);
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
            
        _swipeInputProcessor.SwipeUp += SwipeUp;
    }

    private void SwipeUp()
    {
        _animator.TriggerJump();
    }
}