using UnityEngine;
using UnityEngine.InputSystem;

public class StrafeInputProcessor : InputProcessor, IStrafeInputProcessor
{
    public float XDelta { get; private set; }
    
    private readonly ITouchInputProcessor _touchInputProcessor;
    private readonly StrafeConfiguration _configuration;

    private int _currentDirection;
    private Vector2 _touchStartPosition;
    
    public StrafeInputProcessor(StrafeConfiguration configuration, ITouchInputProcessor touchInputProcessor)
    {
        _configuration = configuration;
        _touchInputProcessor = touchInputProcessor;
    }

    public override void Initialize(InputActionAsset actionAsset)
    {
        base.Initialize(actionAsset);

        _touchInputProcessor.Started += OnTouchStarted;
        _touchInputProcessor.Performed += OnTouchPerformed;
        _touchInputProcessor.Canceled += OnTouchCanceled;
    }

    private void OnTouchStarted()
    {
        _touchStartPosition = _touchInputProcessor.GetPosition();
    }
    
    private void OnTouchPerformed(Vector2 touchPosition)
    {
        Vector2 direction = _touchStartPosition - touchPosition;
        direction.Normalize();
        
        float newXDelta = _touchInputProcessor.GetDelta().x;
        int newDirection = Mathf.RoundToInt(Mathf.Sign(newXDelta));

        // Cancel strafe if its Y-axis is suppressing X-axis(mean that it's swipe and not a strafe)
        if (Mathf.Abs(Vector2.Dot(direction, Vector2.right)) < _configuration.DirectionMatchThreshold)
        {
            XDelta = 0;
            return;
        }
            
        // If no movement or same direction, accept immediately
        if (newDirection == 0 || newDirection == _currentDirection)
        {
            XDelta = newXDelta;
            return;
        }

        // If direction is opposite, apply threshold check
        if (Mathf.Abs(newXDelta) > _configuration.DirectionChangeThreshold)
        {
            _currentDirection = newDirection;
            XDelta = newXDelta;
        }
    }

    private void OnTouchCanceled()
    {
        XDelta = 0;
        
    }

    public override void Dispose()
    {
        _touchInputProcessor.Performed -= OnTouchPerformed;
    }
}