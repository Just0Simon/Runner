using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeInputProcessor : InputProcessor
{
    public event System.Action SwipeUp;
    
    private Vector2 _touchStartPos;
    private bool _isTouching;
    private float _touchStartTime;

    private readonly SwipeConfiguration _configuration;

    private readonly TouchInputProcessor _touchInputProcessor;

    public SwipeInputProcessor(SwipeConfiguration configuration, TouchInputProcessor touchInputProcessor)
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
            if (Vector2.Dot(swipeVector, Vector2.up) > _configuration.SwipeDirectionMatchThreshold)
            {
                SwipeUp?.Invoke();
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