using System;
using UnityEngine;

namespace Game
{
    public sealed class ForceComponent : MonoBehaviour
    {
        [SerializeField] private float _forceX;
        [SerializeField] private float _forceY;
        [SerializeField] private Transform _forceInitPoint;
        [SerializeField] private LayerMask _activateMask;
        [SerializeField] private float _radius = .2f;
        [SerializeField] private Collider2D _selfCollider;
        
        public interface ICondition
        {
            bool Evaluate();
        }

        private ICondition _condition;
        
        public void SetCondition(ICondition condition) => _condition = condition;

        public bool CanForce => _condition == null || _condition.Evaluate();
        
        public void ForceAtTarget(GameObject target)
        {
            if (target == null)
                throw new NullReferenceException($"Object {name} trying force at target with null target");
            
            ApplyForce(target);
        }
        
        public void ForceAtTarget(Rigidbody2D target)
        {
            if (target == null)
                throw new NullReferenceException($"Object {name} trying force at target with null target");
            
            ApplyForce(target);
        }

        public void ForceAtZone()
        {
            var hits = Physics2D.OverlapCircleAll(_forceInitPoint.position, _radius, _activateMask);
            foreach (var hit in hits)
            {
                if (hit == _selfCollider)
                    continue;
                
                ApplyForce(hit);
            }
        }
        
        public void ApplyForce(GameObject target) => 
            ApplyForce(target.GetComponent<Rigidbody2D>());

        public void ApplyForce(Collider2D hit)
        {
            var rb = hit != null ? hit.GetComponent<Rigidbody2D>() : null;

            ApplyForce(rb);
        }

        public void ApplyForce(Rigidbody2D target)
        {
            if (target == null)
                return;
            
            int forceSign = target.transform.position.x > transform.position.x ? 1 : -1;
            
            target.AddForce(new Vector2(_forceX * forceSign, _forceY), ForceMode2D.Impulse);
        }
    }
}