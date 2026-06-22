using Modules.Utils;
using UnityEngine;

namespace Game.Systems
{
    public sealed class PlayerShipBoundsClamper : MonoBehaviour
    {
        private TransformBounds _playerArea;
        
        public void Construct(TransformBounds playerArea) => 
            _playerArea = playerArea;
        
        private void LateUpdate() => 
            transform.position = _playerArea.ClampInBounds(transform.position);
    }
}