using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Tween/Destroy Effect",
    fileName = "New Destroy Tween Effect", order = 2)]
public class DestroyTweenEffect : AbstractTweenEffect
{
    [SerializeField]
    private Ease _scaleInEase;
    
    [SerializeField]
    private float _scaleInDuration;
    [SerializeField]
    private Vector3 _scaleInValue;
    
    [SerializeField]
    private bool _destroyOnComplete;
    [SerializeField]
    private float _destroyDelay;
    public override void Apply(Transform transform)
    {
        var sequence = DOTween.Sequence();
        
        var tween = transform.DOScale(_scaleInValue, _scaleInDuration)
            .SetEase(_scaleInEase);
        
        sequence.Append(tween);
        if(_destroyOnComplete is false)
            return;
        sequence.AppendInterval(_destroyDelay);
        sequence.AppendCallback(() => Destroy(transform.gameObject));
    }
}