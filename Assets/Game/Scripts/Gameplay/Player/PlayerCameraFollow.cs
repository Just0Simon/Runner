using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    [SerializeField]
    private float _followSpeed = 10f;
    [SerializeField]
    private Vector3 _targetOffset;
    
    private PlayerTransformModel _playerTransformModel;

    public void Initialize(PlayerTransformModel playerTransformModel)
    {
        _playerTransformModel = playerTransformModel;
    }

    private void LateUpdate()
    {
        if (_playerTransformModel.Transform is null)
            return;

        Vector3 targetPosition = _playerTransformModel.Transform.position + _targetOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _followSpeed);
    }
}