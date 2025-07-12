using Game.Scripts.Gameplay.Collectibles;
using UnityEngine;

public class CoinsCollectionInterface : MonoBehaviour
{
    [SerializeField]
    private Transform _coinsContainer;
    
    [SerializeField]
    private GameObject _coinPrefab;
    
    [SerializeField]
    private CoinCollectedEvent _collectedEvent;
    [SerializeField]
    private AbstractTweenEffect _coinTweenEffect;

    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main;
        _collectedEvent.Event += OnCoinsCollected;
    }

    private void OnDestroy()
    {
        _collectedEvent.Event -= OnCoinsCollected;
    }

    private void OnCoinsCollected(CollectibleCoin collectibleCoin)
    {
        var screenPosition = _camera.WorldToScreenPoint(collectibleCoin.transform.position);
        
        var coin = Instantiate(_coinPrefab,  _coinsContainer);
        coin.transform.position = screenPosition;
        _coinTweenEffect.Apply(coin.transform);
    }
}