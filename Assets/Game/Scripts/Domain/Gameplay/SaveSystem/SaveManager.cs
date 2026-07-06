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

        public int Save()
        {
            JObject gameData = new JObject();

            foreach (var serializer in _serializers)
                gameData.Add(serializer.Key, serializer.Serialize());

            _gameRepository.Save(gameData);

            PlayerPrefs.SetInt(VERSION, ++_version);
            return _version;
        }

        public void Load(int version = -1)
        {
            (bool success, JObject gameData) = _gameRepository.Load(version);

            if (success)
                foreach (ISaveSerializer serializer in _serializers)
                    if (gameData.TryGetValue(serializer.Key, out JToken data))
                        serializer.Deserialize(data);
        }
    }
}