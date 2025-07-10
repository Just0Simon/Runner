using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    public float CurrentSpeed { get; private set; }
    
    [SerializeField]
    private float _forwardMoveSpeed;
    
    [SerializeField]
    private float _strafeSpeed;

    [SerializeField]
    private Vector2 _horizontalMoveClamp;
    
    private void Awake()
    {
        CurrentSpeed = _forwardMoveSpeed;
    }
    
    public void Move(float horizontalDirection)
    {
        // Forward translate
        transform.Translate(Vector3.forward * _forwardMoveSpeed * Time.deltaTime);
        
        // Strafe translate
        Vector3 horizontalTranslateDirection = Vector3.right * horizontalDirection;
        horizontalTranslateDirection.Normalize();
        
        transform.Translate(horizontalTranslateDirection * _strafeSpeed * Time.deltaTime);
        
        // Clamp position on x-axis
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _horizontalMoveClamp.x, _horizontalMoveClamp.y);
        transform.position = clampedPosition;
    }
}