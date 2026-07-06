using SampleGame.Common;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class ResourceBag : MonoBehaviour, ISaveSerializer<ResourceBag.Snapshot>
    {
        public struct Snapshot
        {
            public ResourceType Type;
            public int Current;
            
            public Snapshot(ResourceType type, int current)
            {
                Type = type;
                Current = current;
            }
            
            public Snapshot(ResourceBag bag) : this(bag.Type, bag.Current) {}
        }
        
        ///Variable
        [field: SerializeField]
        public ResourceType Type { get; set; }
        
        ///Variable
        [field: SerializeField]
        public int Current { get; set; }
        
        ///Const
        [field: SerializeField]
        public int Capacity { get; set; }

        public Snapshot Serialize() => new(this);

        public void Deserialize(Snapshot value)
        {
            Type = value.Type;
            Current = value.Current;
        }
    }
}