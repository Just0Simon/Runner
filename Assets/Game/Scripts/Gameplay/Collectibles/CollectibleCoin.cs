using System;
using UnityEngine;

namespace Game.Scripts.Gameplay.Collectibles
{
    public class CollectibleCoin : MonoBehaviour
    {
        [field: SerializeField]
        public int Amount { get; private set; } = 1;

        [SerializeField]
        private Collider _collider;
        
        [SerializeField]
        private CoinCollectedEvent collectedEvent;

        [Header("Floating Animation")]
        [SerializeField]
        private float _transitionDuration = 1f;
        [SerializeField]
        private float _floatingHeight = 1;
        
        [SerializeField]
        private AbstractTweenEffect _collectEffect;

        private bool _collected;
        private float _timer;
        private bool _floatingDirection;
        private float _defaultHeight;

        private void Awake()
        {
            _defaultHeight = transform.position.y;
        }

        private void Update()
        {
            FloatingTick();
        }

        // Only player layer can trigger callback. Player Component validation is not necessary.
        private void OnTriggerEnter(Collider other)
        {
            _collected = true;
            _collider.enabled = false;
            
            collectedEvent.Invoke(this);
            
            _collectEffect.Apply(transform);
        }

        private void FloatingTick()
        {
            if (_collected)
                return;
            
            if (_timer >= _transitionDuration || _timer < 0)
            {
                _floatingDirection = !_floatingDirection;
            }
            
            _timer += _floatingDirection ? Time.deltaTime : -Time.deltaTime;
            var position = transform.position;
            position.y = _defaultHeight + Mathf.Cos(_timer / _transitionDuration) * _floatingHeight;
            transform.position = position;
        }

        [ContextMenu("Collect Collected")]
        private void Collect()
        {
            _collected = true;
            _collectEffect.Apply(transform);
        }
    }
}