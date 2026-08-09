using System.IO;

namespace Game.Gameplay
{
    public interface ISaveSerializer
    {
        void Serialize(Countdown countdown, BinaryWriter writer);
        void Deserialize(Countdown countdown, BinaryReader reader);
        void Serialize(DestinationPoint destinationPoint, BinaryWriter writer);
        void Deserialize(DestinationPoint destinationPoint, BinaryReader reader);
        void Serialize(Health health, BinaryWriter writer);
        void Deserialize(Health health, BinaryReader reader);
        void Serialize(ProductionOrder productionOrder, BinaryWriter writer);
        void Deserialize(ProductionOrder productionOrder, BinaryReader reader);
        void Serialize(ResourceBag resourceBag, BinaryWriter writer);
        void Deserialize(ResourceBag resourceBag, BinaryReader reader);
        void Serialize(TargetObject targetObject, BinaryWriter writer);
        void Deserialize(TargetObject targetObject, BinaryReader reader);
        void Serialize(Team team, BinaryWriter writer);
        void Deserialize(Team team, BinaryReader reader);
    }
}