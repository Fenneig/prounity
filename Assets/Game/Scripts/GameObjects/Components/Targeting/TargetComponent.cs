using System;
using UnityEngine;

namespace Game
{
    public sealed class TargetComponent : MonoBehaviour
    {
        public event Action<Collider2D> OnFoundTarget; 
        public event Action OnLostTarget;
        public GameObject Target { get; private set; }
        public bool HasTarget => Target != null;

        public void SetTarget(Collider2D newTarget)
        {
            OnFoundTarget?.Invoke(newTarget);
            Target = newTarget.gameObject;
        }

        public void UnsetTarget()
        {
            OnLostTarget?.Invoke();
            Target = null;
        }
    }
}