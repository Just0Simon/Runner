using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerJumpComponent : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 5f;

    [SerializeField]
    private float _gravity = 9.81f;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private float _groundCheckDistance = 0.1f;

    [SerializeField]
    private float _airborneColliderHeight = 1.2f;

    private float _verticalVelocity = 0f;
    private bool _isJumping = false;

    private CapsuleCollider _collider;
    private float _defaultColliderHeight;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _defaultColliderHeight = _collider.height;
    }

    private void Update()
    {
        ApplyGravity();

        if (_verticalVelocity != 0f)
        {
            transform.Translate(Vector3.up * _verticalVelocity * Time.deltaTime);
        }

        UpdateColliderHeight();

        if (_isJumping && IsGrounded() && _verticalVelocity <= 0f)
        {
            _verticalVelocity = 0f;
            _isJumping = false;
            _collider.height = _defaultColliderHeight;
        }
    }

    public void Jump()
    {
        if (IsGrounded() && !_isJumping)
        {
            _verticalVelocity = _jumpForce;
            _isJumping = true;
        }
    }

    private void ApplyGravity()
    {
        if (_isJumping)
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.up * 0.01f;
        return Physics.Raycast(origin, Vector3.down, _groundCheckDistance, _groundLayer);
    }

    private void UpdateColliderHeight()
    {
        if (_isJumping && _verticalVelocity > 0f)
        {
            _collider.height = Mathf.Lerp(_collider.height, _airborneColliderHeight, Time.deltaTime * 10f);
        }
        else if (!_isJumping || _verticalVelocity <= 0f)
        {
            _collider.height = Mathf.Lerp(_collider.height, _defaultColliderHeight, Time.deltaTime * 10f);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 origin = transform.position + Vector3.up * 0.01f;
        Gizmos.DrawLine(origin, origin + Vector3.down * _groundCheckDistance);
    }
#endif
}