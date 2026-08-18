using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public sealed class VersionProvider : IInitializable
    {
        private const string SAVE_VERSION_PREFS_KEY = "Version";

        private int _currentVersion;

        public int Current => _currentVersion;

        public int Next => _currentVersion + 1;

        public void SetCurrent(int version)
        {
            _currentVersion = version;
            PlayerPrefs.SetInt(SAVE_VERSION_PREFS_KEY, version);
            PlayerPrefs.Save();
        }

        public void Initialize() => 
            _currentVersion = PlayerPrefs.GetInt(SAVE_VERSION_PREFS_KEY, 0);
    }
}