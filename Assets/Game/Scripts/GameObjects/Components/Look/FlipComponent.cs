using UnityEngine;

namespace Game
{
    public sealed class FlipComponent : MonoBehaviour
    {
        public void Flip(Transform target)
        {
            Vector2 direction = target.position - this.transform.position;
            this.Flip(direction.x);
        }
        
        public void Flip(float direction)
        {
            float angle = direction > 0 ? 0 : 180;
            this.transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}