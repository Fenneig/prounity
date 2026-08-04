using UnityEngine;

namespace Game
{
    public sealed class PhysicsComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public void Disable()
        {
            _rigidbody2D.simulated = false;
        }
    }
}