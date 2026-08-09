using System.IO;

namespace Game.Gameplay
{
    public interface ISerializableComponent
    {
        void Serialize(ISaveSerializer serializer, BinaryWriter binaryWriter);
        void Deserialize(ISaveSerializer serializer, BinaryReader reader);
    }
}