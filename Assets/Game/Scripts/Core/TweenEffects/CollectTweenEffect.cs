using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Tween/Collect Effect",
    fileName = "New Collect Tween Effect", order = 2)]
public class CollectTweenEffect : AbstractTweenEffect
{
    [Header("Stage 1: Go high")]
    [SerializeField]
    private float _stageOneDuration;
    [SerializeField]
    private Ease _flyEase;
    [SerializeField]
    private float _additionHeight;
    
    [Header("Stage 2: Rotate around itself while scaling to zero")]
    [SerializeField]
    private float _stageTwoDuration;
    [SerializeField]
    private float _itselfRotationCount;
    [SerializeField]
    private Ease _rotationEase;
    [SerializeField]
    private RotateMode _rotateMode;
    [SerializeField]
    private Ease _scaleEase;

    [Header("Global Stage: Fly forward to be seen in camera")]
    [SerializeField]
    private float _forwardFlyDistance;
    [SerializeField]
    private Ease _forwardFlyEase;
    
    [Space]
    [SerializeField]
    private bool _destroyOnComplete;
    
    public override void Apply(Transform transform)
    {
        var targetZ = transform.position.z + _forwardFlyDistance;
        transform.DOMoveZ(targetZ, _stageOneDuration + _stageTwoDuration)
            .SetEase(_forwardFlyEase);
        
        Sequence sequence = DOTween.Sequence();
        var topHeight = transform.position.y + _additionHeight;
        sequence.Append(transform.DOMoveY(topHeight, _stageOneDuration)
                .SetEase(_flyEase))
            .AppendCallback(() => StageTwo(transform));
    }

    private void StageTwo(Transform transform)
    {
        var tween = 
            transform.DORotate(new Vector3(0, _itselfRotationCount * 360f, 0), _stageTwoDuration, _rotateMode)
                .SetEase(_rotationEase);
        transform.DOScale(Vector3.zero, _stageTwoDuration)
            .SetEase(_scaleEase);
        
        if(_destroyOnComplete)
            tween.OnComplete(() => Destroy(transform.gameObject));
    }
}