using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeInputProcessor : InputProcessor, ISwipeInputProcessor
{
    public event System.Action<ISwipeInputProcessor.SwipeDirection> Swipe;
    
    private Vector2 _touchStartPos;
    private bool _isTouching;
    private float _touchStartTime;

    private readonly SwipeConfiguration _configuration;

    private readonly ITouchInputProcessor _touchInputProcessor;

    public SwipeInputProcessor(SwipeConfiguration configuration, ITouchInputProcessor touchInputProcessor)
    {
        _touchInputProcessor = touchInputProcessor;
        _configuration = configuration;
    }

    public override void Initialize(InputActionAsset actionAsset)
    {
        base.Initialize(actionAsset);

        _touchInputProcessor.Started += OnTouchStarted;
        _touchInputProcessor.Canceled += OnTouchEnded;
    }

    private void OnTouchStarted()
    {
        // Record the start of the touch
        _touchStartPos = _touchInputProcessor.GetPosition();
        _touchStartTime = Time.time;
        _isTouching = true;
    }

    private void OnTouchEnded()
    {
        if (_isTouching)
        {
            // Calculate swipe direction and distance
            Vector2 touchEndPos = _touchInputProcessor.GetPosition();
            Vector2 swipeVector = touchEndPos - _touchStartPos;
            
            if(swipeVector.y < _configuration.SwipeThreshold)
                return;
            
            if(Time.time - _touchStartTime >= _configuration.SwipeTimeThreshold)
                return;
            
            swipeVector.Normalize();
            var upDirectionDotProduct = Vector2.Dot(swipeVector, Vector2.up);
            
            if (upDirectionDotProduct > _configuration.SwipeDirectionMatchThreshold)
            {
                Swipe?.Invoke(ISwipeInputProcessor.SwipeDirection.Up);
            }
            
            var downDirectionDotProduct = Vector2.Dot(swipeVector, Vector2.down);
            if (downDirectionDotProduct > _configuration.SwipeDirectionMatchThreshold)
            {
                Swipe?.Invoke(ISwipeInputProcessor.SwipeDirection.Down);
            }
            
            var rightDirectionDotProduct = Vector2.Dot(swipeVector, Vector2.right);
            if (rightDirectionDotProduct > _configuration.SwipeDirectionMatchThreshold)
            {
                Swipe?.Invoke(ISwipeInputProcessor.SwipeDirection.Right);
            }
            
            var leftDirectionDotProduct = Vector2.Dot(swipeVector, Vector2.left);
            if (leftDirectionDotProduct > _configuration.SwipeDirectionMatchThreshold)
            {
                Swipe?.Invoke(ISwipeInputProcessor.SwipeDirection.Left);
            }
        }
        _isTouching = false;
    }

    public override void Dispose()
    {
        _touchInputProcessor.Started -= OnTouchStarted;
        _touchInputProcessor.Canceled -= OnTouchEnded;
    }
}