using UnityEngine;

namespace Game.Scripts.Gameplay.Collectibles
{
    [CreateAssetMenu(menuName = "Collection/Coin/Collect Event",
        fileName = "New Coin Collectible Event", order = 2)]
    public class CoinCollectedEvent : GenericScriptableObjectEvent<CollectibleCoin> { }
}