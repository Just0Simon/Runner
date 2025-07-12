using UnityEngine;

namespace Game.Scripts.Gameplay.Collectibles
{
    public class CoinCollectableManager : MonoBehaviour
    {
        [SerializeField]
        private IntegerVariableScriptableObject _gameScoreVariable;
        
        [SerializeField]
        private CoinCollectedEvent _coinCollectedEvent;
        
        private void Awake()
        {
            _coinCollectedEvent.Event += OnCoinCollected;
        }

        private void OnDestroy()
        {
            _coinCollectedEvent.Event -= OnCoinCollected;
        }
        private void OnCoinCollected(CollectibleCoin coin)
        {
            _gameScoreVariable.Value = _gameScoreVariable.Value + coin.Amount;
        }
    }
}