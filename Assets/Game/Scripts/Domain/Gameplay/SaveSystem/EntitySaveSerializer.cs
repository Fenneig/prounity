using System.Collections.Generic;
using Modules.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class EntitySaveSerializer : ISaveSerializer
    {
        private readonly EntityWorld _entityWorld;
        private readonly ResolveContext _context;
        
        private readonly List<Entity> _loadedEntities = new();

        public EntitySaveSerializer(EntityWorld entityWorld, ResolveContext resolveContext)
        {
            _entityWorld = entityWorld;
            _context = resolveContext;
        }

        public void Serialize(ref SaveWriter writer)
        {
            var entities = _entityWorld.GetAll();
            writer.Write(entities.Count);

            foreach (var entity in entities) 
                SaveEntity(ref writer, entity);
        }

        public void Deserialize(ref SaveReader reader)
        {
            _loadedEntities.Clear();
            int entitiesCount = reader.ReadInt();

            for (int i = 0; i < entitiesCount; i++) 
                LoadEntity(ref reader);

            foreach (var entity in _loadedEntities)
                foreach (var resolver in entity.GetComponents<IReferenceResolver>())
                    resolver.Resolve(_context);
        }

        private void SaveEntity(ref SaveWriter writer, Entity entity)
        {
            writer.Write(entity.Name);
            writer.Write(entity.Id);
            
            Transform entityTransform = entity.transform;

            writer.Write(entityTransform.position);
            writer.Write(entityTransform.rotation);

            var serializers = entity.GetComponents<ISaveSerializer>();

            foreach (var serializer in serializers)
                serializer.Serialize(ref writer);
        }

        private void LoadEntity(ref SaveReader reader)
        {
            string name = reader.ReadString();
            int id = reader.ReadInt();

            Vector3 position = reader.ReadVector3();
            Quaternion rotation = reader.ReadQuaternion();
            
            if (_entityWorld.TryGet(id, out Entity entity))
            {
                entity.transform.position = position;
                entity.transform.rotation = rotation;
            }
            else
            {
                entity = _entityWorld.Spawn(name, position, rotation, id);
            }
            
            LoadComponents(ref reader, entity);
            _loadedEntities.Add(entity);
        }

        private void LoadComponents(ref SaveReader reader, Entity entity)
        {
            foreach (var serializer in entity.GetComponents<ISaveSerializer>())
                serializer.Deserialize(ref reader);
        }
    }
}