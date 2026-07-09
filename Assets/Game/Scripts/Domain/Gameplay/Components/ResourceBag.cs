using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    //Can be extended
    public sealed class ResourceBag : MonoBehaviour, ISaveSerializer
    {
        ///Variable
        [field: SerializeField]
        public ResourceType Type { get; set; }
        
        ///Variable
        [field: SerializeField]
        public int Current { get; set; }
        
        ///Const
        [field: SerializeField]
        public int Capacity { get; set; }
        
        public void Serialize(ref SaveWriter writer)
        {
            writer.Write((int)Type);
            writer.Write(Current);
        }

        public void Deserialize(ref SaveReader reader)
        {
            Type = (ResourceType)reader.ReadInt();
            Current = reader.ReadInt();
        }
    }
}