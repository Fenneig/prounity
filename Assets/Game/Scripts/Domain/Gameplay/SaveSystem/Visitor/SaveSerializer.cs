using System.Collections.Generic;
using System.IO;
using Game.Common;
using Game.Gameplay.Extensions;
using Modules.Entities;

namespace Game.Gameplay
{
    public sealed class SaveSerializer : ISaveSerializer
    {
        private readonly EntityWorld _entityWorld;
        private readonly EntityCatalog _entityCatalog;
        
        public SaveSerializer(EntityWorld entityWorld, EntityCatalog entityCatalog)
        {
            _entityWorld = entityWorld;
            _entityCatalog = entityCatalog;
        }
        
        public void Serialize(Countdown countdown, BinaryWriter writer)
        {
            writer.Write(countdown.Current);
        }

        public void Deserialize(Countdown countdown, BinaryReader reader)
        {
            countdown.Current = reader.ReadSingle();
        }

        public void Serialize(DestinationPoint destinationPoint, BinaryWriter writer)
        {
            writer.Write(destinationPoint.Value);
        }

        public void Deserialize(DestinationPoint destinationPoint, BinaryReader reader)
        {
            destinationPoint.Value = reader.ReadVector3();
        }

        public void Serialize(Health health, BinaryWriter writer)
        {
            writer.Write(health.Current);
        }

        public void Deserialize(Health health, BinaryReader reader)
        {
            health.Current = reader.ReadInt32();
        }

        public void Serialize(ProductionOrder productionOrder, BinaryWriter writer)
        {
            writer.Write(productionOrder.Queue.Count);

            foreach (var config in productionOrder.Queue)
                writer.Write(config.Name);
        }

        public void Deserialize(ProductionOrder productionOrder, BinaryReader reader)
        {
            int count = reader.ReadInt32();
            
            var queueNames = new List<string>(count);

            for (int i = 0; i < count; i++)
                queueNames.Add(reader.ReadString());
            
            List<EntityConfig> queue = new List<EntityConfig>();
            
            foreach (var configName in queueNames)
                if (_entityCatalog.FindConfig(configName, out EntityConfig config))
                    queue.Add(config);

            productionOrder.Queue = queue;
        }

        public void Serialize(ResourceBag resourceBag, BinaryWriter writer)
        {
            writer.Write((int)resourceBag.Type);
            writer.Write(resourceBag.Current);
        }

        public void Deserialize(ResourceBag resourceBag, BinaryReader reader)
        {
            resourceBag.Type = (ResourceType)reader.ReadInt32();
            resourceBag.Current = reader.ReadInt32();
        }

        public void Serialize(TargetObject targetObject, BinaryWriter writer)
        { 
            writer.Write(targetObject.Value == null ? -1 : targetObject.Value.Id);
        }

        public void Deserialize(TargetObject targetObject, BinaryReader reader)
        {
            int targetId = reader.ReadInt32();
            targetObject.Value = targetId == -1 ? null : _entityWorld.Get(targetId);
        }

        public void Serialize(Team team, BinaryWriter writer)
        {
            writer.Write((int)team.Type);
        }

        public void Deserialize(Team team, BinaryReader reader)
        {
            team.Type = (TeamType)reader.ReadInt32();
        }
    }
}