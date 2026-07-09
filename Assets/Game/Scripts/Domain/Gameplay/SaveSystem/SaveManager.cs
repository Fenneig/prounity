using System.Threading;
using Cysharp.Threading.Tasks;
using Game.App;
using UnityEngine;

namespace Game.Gameplay
{
    public class SaveManager
    {
        private readonly ISaveSerializer[] _serializers;
        private readonly IGameRepository _gameRepository;
        private int _version;
        private const string SAVE_VERSION_PREFS_KEY = "Version";

        public SaveManager(ISaveSerializer[] serializers, IGameRepository gameRepository)
        {
            _serializers = serializers;
            _gameRepository = gameRepository;

            _version = PlayerPrefs.GetInt(SAVE_VERSION_PREFS_KEY, 0);
        } 

        public async UniTask<(bool, int)> Save(CancellationToken ct = default)
        {
            _version++;

            SaveWriter writer = new SaveWriter();

            foreach (var serializer in _serializers)
                serializer.Serialize(ref writer);

            (bool success, int version) = await _gameRepository.Save(writer.ToArray(), _version, ct);

            if (success) 
                PlayerPrefs.SetInt(SAVE_VERSION_PREFS_KEY, _version);
            
            return (success, version);
        }

        public async UniTask<(bool, int)> Load(string version, CancellationToken ct = default)
        {
            int actualVersion = string.IsNullOrEmpty(version) ? PlayerPrefs.GetInt(SAVE_VERSION_PREFS_KEY, 0) : int.Parse(version);
            
            (bool success, byte[] bytes) = await _gameRepository.Load(actualVersion, ct);

            if (!success)
                return (false, -1);
            
            SaveReader reader = new SaveReader(bytes);
            
            foreach (ISaveSerializer serializer in _serializers)
                serializer.Deserialize(ref reader);

            return (true, actualVersion);
        }
    }
}