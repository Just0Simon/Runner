using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Tween/Interface Coin Effect",
    fileName = "New Interface Coin Tween Effect", order = 2)]
public class InterfaceCoinTweenEffect : AbstractTweenEffect
{
    [Header("Stage 1: Fly towards target")]
    [SerializeField]
    private float _stageOneDuration;
    [SerializeField]
    private Ease _stageOneEase;
    [SerializeField]
    private Vector2 _anchoredTargetPosition;
    
    [Header("Stage 2: Scale right before reaching target")]
    [SerializeField]
    private float _stageTwoDuration;
    [SerializeField]
    private Ease _stageTwoEase;
    [SerializeField]
    private Vector3 _targetScale;
    
    [Space]
    private bool _destroyOnComplete;
    
    public override void Apply(Transform transform)
    {
        if (transform is not RectTransform rectTransform)
        {
            Debug.LogError("Target transform is not a RectTransform");
            return;
        }
        
        Sequence tweenSequence = DOTween.Sequence();

        // Stage 1: move to target anchored position
        tweenSequence.Append(
            rectTransform.DOAnchorPos(_anchoredTargetPosition, _stageOneDuration)
                .SetEase(_stageOneEase)
        );

        // Stage 2: scale animation starts slightly before the move ends
        float scaleStartTime = Mathf.Max(0, _stageOneDuration - _stageTwoDuration);
        tweenSequence.Insert(
            scaleStartTime,
            rectTransform.DOScale(_targetScale, _stageTwoDuration)
                .SetEase(_stageTwoEase)
        );

        // Optional: destroy on complete
        if (_destroyOnComplete)
        {
            tweenSequence.OnComplete(() =>
            {
                Destroy(rectTransform.gameObject);
            });
        }
    }
}