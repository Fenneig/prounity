using Unity.Entities;
using UnityEngine;

namespace Game.GameEntities.Content
{
    public class AnimatorReference : IComponentData
    {
        public Animator Value;
    }
}