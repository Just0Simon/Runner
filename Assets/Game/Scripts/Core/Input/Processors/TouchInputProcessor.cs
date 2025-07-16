using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputProcessor : InputProcessor, ITouchInputProcessor
{
    public bool IsTouching { get; private set; }
    
    public event Action Started;
    public event Action<Vector2> Performed;
    public event Action Canceled;
    
    private InputAction _touchAction;
    private InputAction _touchDeltaAction;
    private InputAction _touchPositionAction;
    
    public override void Initialize(InputActionAsset actionAsset)
    {
        base.Initialize(actionAsset);
        
        var action = actionAsset.FindActionMap(Constants.ACTION_MAP);
        _touchAction = action.FindAction(Constants.TOUCH_ACTION);
        _touchPositionAction = action.FindAction(Constants.TOUCH_POSITION_ACTION);
        _touchDeltaAction = action.FindAction(Constants.TOUCH_DELTA_ACTION);
        
        _touchAction.started += TouchStarted;
        _touchPositionAction.performed += TouchPerformed;
        _touchAction.canceled += TouchCanceled;
    }

    public Vector2 GetPosition()
    {
        return _touchPositionAction.ReadValue<Vector2>();
    }
    
    public Vector2 GetDelta()
    {
        return _touchDeltaAction.ReadValue<Vector2>();
    }
    
    private void TouchStarted(InputAction.CallbackContext callbackContext)
    {
        IsTouching = true;
        Started?.Invoke();
    }

    private void TouchPerformed(InputAction.CallbackContext callbackContext)
    {
        if(IsTouching == false)
            return;
        
        Performed?.Invoke(callbackContext.ReadValue<Vector2>());
    }

    private void TouchCanceled(InputAction.CallbackContext callbackContext)
    {
        IsTouching = false;
        Canceled?.Invoke();
    }

    public override void Dispose()
    {
        _touchAction.started -= TouchStarted;
        _touchPositionAction.performed -= TouchStarted;
        _touchAction.canceled -= TouchCanceled;
    }
}