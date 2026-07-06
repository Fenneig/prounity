using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class TargetObject : MonoBehaviour, ISaveSerializer<int>, IReferenceResolver
    {
        ///Variable
        [field: SerializeField]
        public Entity Value { get; set; }

        private int _targetId;
        
        public int Serialize() => Value == null ? -1 : Value.Id;
        
        public void Deserialize(int value) => _targetId = value;

        public void Resolve(ResolveContext context)
        {
            if (_targetId != -1)
                Value = context.EntityWorld.Get(_targetId);
        }
    }
}