using UnityEngine;

namespace Game
{
    public class PushComponent : MonoBehaviour
    {
        [SerializeField] private float _forceX;
        [SerializeField] private float _forceY;

        public void Push(Rigidbody2D target)
        {
            int forceSign = target.transform.position.x > transform.position.x ? 1 : -1;
            
            target.AddForce(new Vector2(_forceX * forceSign, _forceY), ForceMode2D.Impulse);
        }
    }
}