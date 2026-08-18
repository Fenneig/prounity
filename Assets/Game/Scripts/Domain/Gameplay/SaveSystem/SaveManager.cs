using System;
using System.IO;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.App;

namespace Game.Gameplay
{
    public sealed class SaveManager
    {
        private readonly EntitySaveSerializer _entitySaveSerializer;
        private readonly IGameRepository _gameRepository;
        private readonly IHashProvider _hashProvider;
        private readonly VersionProvider _versionProvider;

        private const int DEFAULT_CAPACITY = 4096;
        private const int HASH_SIZE = 32;
        
        public SaveManager(EntitySaveSerializer entitySaveSerializer, IGameRepository gameRepository, IHashProvider hashProvider, VersionProvider versionProvider)
        {
            _entitySaveSerializer = entitySaveSerializer;
            _gameRepository = gameRepository;
            _hashProvider = hashProvider;
            _versionProvider = versionProvider;
        }   

        public async UniTask<(bool, int)> Save(CancellationToken ct = default)
        {
            using var stream = new MemoryStream(DEFAULT_CAPACITY);
            await using var writer = new BinaryWriter(stream, Encoding.UTF8, true);
                
            stream.Position = 0;
            stream.SetLength(0);
            
            _entitySaveSerializer.Serialize(writer);

            byte[] data = stream.ToArray();

            byte[] hash = _hashProvider.Compute(data);

            byte[] fileData = new byte[data.Length + HASH_SIZE];
            
            Buffer.BlockCopy(data, 0, fileData, 0, data.Length);
            Buffer.BlockCopy(hash, 0, fileData, data.Length, HASH_SIZE);

            int version = _versionProvider.Next;
            
            (bool success, int savedVersion) = await _gameRepository.Save(fileData, version, ct);

            if (success) 
                _versionProvider.SetCurrent(savedVersion);
            
            return (success, savedVersion);
        }

        public async UniTask<(bool, int)> Load(string version, CancellationToken ct = default)
        {
            int actualVersion;

            if (string.IsNullOrWhiteSpace(version))
                actualVersion = _versionProvider.Current;
            else if (!int.TryParse(version, out actualVersion))
                return (false, -1);

            (bool success, byte[] bytes) =
                await _gameRepository.Load(actualVersion, ct);

            if (!success || !TryValidate(bytes, out byte[] data))
                return (false, -1);

            using var stream = new MemoryStream(data);
            using var reader = new BinaryReader(stream, Encoding.UTF8);

            _entitySaveSerializer.Deserialize(reader);

            return (true, actualVersion);
        }

        private bool TryValidate(byte[] fileData, out byte[] data)
        {
            data = null;

            if (fileData == null || fileData.Length < HASH_SIZE)
                return false;
            
            int fileDataLength = fileData.Length - HASH_SIZE;
            byte[] hash = new byte[HASH_SIZE];
            Buffer.BlockCopy(fileData, fileDataLength, hash, 0, HASH_SIZE);
            
            data = new byte[fileDataLength];
            Buffer.BlockCopy(fileData, 0, data, 0, fileDataLength);
            
            return _hashProvider.Verify(data, hash);
        }
    }
}