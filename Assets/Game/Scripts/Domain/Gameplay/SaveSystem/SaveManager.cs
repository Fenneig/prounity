using System.Threading;
using Cysharp.Threading.Tasks;
using Game.App;
using Newtonsoft.Json.Linq;
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

        public UniTask<(bool, int)> Save(CancellationToken ct = default)
        {
            _version++;

            JObject gameData = new JObject();

            foreach (var serializer in _serializers)
                gameData.Add(serializer.Key, serializer.Serialize());

            PlayerPrefs.SetInt(VERSION, _version);
            
            return _gameRepository.Save(gameData, _version);
        }

        public async UniTask<(bool, int)> Load(string version, CancellationToken ct = default)
        {
            int actualVersion = string.IsNullOrEmpty(version) ? -1 : int.Parse(version);
            
            (bool success, JObject gameData) = await _gameRepository.Load(actualVersion);

            if (success)
                foreach (ISaveSerializer serializer in _serializers)
                    if (gameData.TryGetValue(serializer.Key, out JToken data))
                        serializer.Deserialize(data);

            return (success, actualVersion);
        }
    }
}