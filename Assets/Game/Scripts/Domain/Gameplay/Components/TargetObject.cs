using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class TargetObject : MonoBehaviour, ISaveSerializer, IReferenceResolver
    {
        ///Variable
        [field: SerializeField]
        public Entity Value { get; set; }

        private int _targetId;

        public void Serialize(ref SaveWriter writer) => writer.Write(Value == null ? -1 : Value.Id);

        public void Deserialize(ref SaveReader reader) => _targetId = reader.ReadInt();

        public void Resolve(ResolveContext context)
        {
            if (_targetId != -1)
                Value = context.EntityWorld.Get(_targetId);
        }
    }
}