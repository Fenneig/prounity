using SnakeGame;
using UnityEngine;
using Zenject;

public class CoinsWorld : MonoBehaviour
{
    [Inject] private CoinPool _coinPool;
    [Inject] private IWorldBounds _worldBounds;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
            _coinPool.Spawn(_worldBounds.GetRandomPosition());
    }
}