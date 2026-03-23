using Modules.Utils;
using UnityEngine;

namespace Game.Utils
{
    public sealed class PositionDistributor : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        
        private int _index;

        public Vector2 GetNextPosition()
        {
            if (_index >= _spawnPositions.Length)
            {
                _spawnPositions.Shuffle();
                _index = 0;
            }

            return _spawnPositions[_index++].position;
        }
    }
}