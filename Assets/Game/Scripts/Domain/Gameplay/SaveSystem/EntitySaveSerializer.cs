using System.Collections.Generic;
using System.IO;
using Game.Gameplay.Extensions;
using Modules.Entities;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Gameplay
{
    public sealed class EntitySaveSerializer
    {
        private readonly EntityWorld _entityWorld;
        private readonly ISaveSerializer _saveSerializer;

        public EntitySaveSerializer(EntityWorld entityWorld, ISaveSerializer saveSerializer)
        {
            _entityWorld = entityWorld;
            _saveSerializer = saveSerializer;
        }

        public void Serialize(BinaryWriter writer)
        {
            var entities = _entityWorld.GetAll();

            writer.Write(entities.Count);

            foreach (var entity in entities)
                SaveEntityHeader(writer, entity);

            writer.Write(entities.Count);

            foreach (var entity in entities)
            {
                writer.Write(entity.Id);
                SaveComponents(writer, entity);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            List<Entity> loadedEntities = ListPool<Entity>.Get();
            LoadEntityWorld(reader, loadedEntities);
            RemoveExtraEntities(loadedEntities);
            LoadEntityData(reader);
            ListPool<Entity>.Release(loadedEntities);
        }

        private void SaveEntityHeader(BinaryWriter writer, Entity entity)
        {
            writer.Write(entity.Name);
            writer.Write(entity.Id);

            Transform entityTransform = entity.transform;

            writer.Write(entityTransform.position);
            writer.Write(entityTransform.rotation);
        }

        private void SaveComponents(BinaryWriter writer, Entity entity)
        {
            var components = entity.GetComponents<ISerializableComponent>();

            foreach (var component in components)
                component.Serialize(_saveSerializer, writer);
        }

        private void LoadEntityWorld(BinaryReader reader, List<Entity> loadedEntities)
        {
            int entitiesCount = reader.ReadInt32();

            for (int i = 0; i < entitiesCount; i++)
            {
                string name = reader.ReadString();
                int id = reader.ReadInt32();

                Vector3 position = reader.ReadVector3();
                Quaternion rotation = reader.ReadQuaternion();

                if (_entityWorld.TryGet(id, out Entity entity) && entity.name == name)
                    entity.transform.SetPositionAndRotation(position, rotation);
                else
                    entity = _entityWorld.Spawn(name, position, rotation, id);

                loadedEntities.Add(entity);
            }
        }

        private void RemoveExtraEntities(List<Entity> loadedEntities)
        {
            List<Entity> entitiesToDestroy = new List<Entity>();
            foreach (var entity in _entityWorld.GetAll())
                if (!loadedEntities.Contains(entity))
                    entitiesToDestroy.Add(entity);

            foreach (var entity in entitiesToDestroy)
                _entityWorld.Destroy(entity.Id);
        }

        private void LoadEntityData(BinaryReader reader)
        {
            int entitiesCount = reader.ReadInt32();

            for (int i = 0; i < entitiesCount; i++)
            {
                int entityId = reader.ReadInt32();

                if (!_entityWorld.TryGet(entityId, out Entity entity))
                    throw new InvalidDataException(
                        $"Cannot load components: entity {entityId} does not exist.");

                LoadComponents(reader, entity);
            }
        }

        private void LoadComponents(BinaryReader reader, Entity entity)
        {
            foreach (var serializer in entity.GetComponents<ISerializableComponent>())
                serializer.Deserialize(_saveSerializer, reader);
        }
    }
}