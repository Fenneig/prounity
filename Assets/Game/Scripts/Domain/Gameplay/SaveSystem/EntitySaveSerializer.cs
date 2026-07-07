using System.Collections.Generic;
using Modules.Entities;
using Newtonsoft.Json.Linq;
using SampleGame.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public class EntitySaveSerializer : ISaveSerializer<EntityData[]>
    {
        private EntityWorld _entityWorld;
        private ResolveContext _context;
        
        public EntitySaveSerializer(EntityWorld entityWorld, ResolveContext resolveContext)
        {
            _entityWorld = entityWorld;
            _context = resolveContext;
        }

        public string Key => "Units";
        public EntityData[] Serialize()
        {
            List<EntityData> unitData = new List<EntityData>();
            
            var entities = _entityWorld.GetAll();

            foreach (var entity in entities)
            {
                var saveData = new Dictionary<string, JToken>();

                foreach (var serializer in entity.GetComponents<ISaveSerializer>()) 
                    saveData.Add(serializer.Key, serializer.Serialize());

                unitData.Add(new EntityData
                {
                    Name = entity.Name,
                    Id = entity.Id,
                    Transform = new SerializableTransform(entity.transform),
                    SaveData = saveData
                });
            }

            return unitData.ToArray();
        }

        public void Deserialize(EntityData[] value)
        {
            List<Entity> entities = new List<Entity>();
            foreach (var data in value)
            {
                if (_entityWorld.TryGet(data.Id, out Entity entity))
                {
                    UpdateEntityTransform(entity, data);
                    LoadEntity(entity, data);
                    entities.Add(entity);
                }
                else
                {
                    var newEntity = _entityWorld.Spawn(data.Name, data.Transform.Position, Quaternion.Euler(data.Transform.Rotation), data.Id);
                    LoadEntity(newEntity, data);
                    entities.Add(newEntity);
                }
            }

            foreach (var entity in entities)
            {
                if (entity.TryGetComponent(out IReferenceResolver resolver))
                    resolver.Resolve(_context);
            }
        }

        private void UpdateEntityTransform(Entity entity, EntityData data)
        {
            entity.transform.position = data.Transform.Position;
            entity.transform.rotation = Quaternion.Euler(data.Transform.Rotation);
            entity.transform.localScale = data.Transform.Scale;
        }

        private void LoadEntity(Entity entity, EntityData data)
        {
            foreach (var serializer in entity.GetComponents<ISaveSerializer>())
                serializer.Deserialize(data.SaveData[serializer.Key]);
        }
    }

    public struct SerializableTransform
    {
        public SerializedVector3 Position;
        public SerializedVector3 Rotation;
        public SerializedVector3 Scale;
        
        public SerializableTransform(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation.eulerAngles;
            Scale = transform.localScale;
        }
    }
    
    public struct EntityData
    {
        public string Name;
        public int Id;
        public SerializableTransform Transform;
        public Dictionary<string, JToken> SaveData;
    }
}