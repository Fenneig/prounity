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
        private const string VERSION = "Version";

        public SaveManager(ISaveSerializer[] serializers, IGameRepository gameRepository)
        {
            _serializers = serializers;
            _gameRepository = gameRepository;

            _version = PlayerPrefs.GetInt(VERSION, 0);
        } 

        public async UniTask<(bool, int)> Save(CancellationToken ct = default)
        {
            _version++;

            SaveWriter writer = new SaveWriter();

            foreach (var serializer in _serializers)
                serializer.Serialize(ref writer);

            PlayerPrefs.SetInt(VERSION, _version);

            return await _gameRepository.Save(writer.ToArray(), _version);
        }

        public async UniTask<(bool, int)> Load(string version, CancellationToken ct = default)
        {
            int actualVersion = string.IsNullOrEmpty(version) ? PlayerPrefs.GetInt(VERSION, 0) : int.Parse(version);
            
            (bool success, byte[] bytes) = await _gameRepository.Load(actualVersion);

            if (!success)
                return (false, -1);
            
            SaveReader reader = new SaveReader(bytes);
            
            foreach (ISaveSerializer serializer in _serializers)
                serializer.Deserialize(ref reader);

            return (true, actualVersion);
        }
    }
}