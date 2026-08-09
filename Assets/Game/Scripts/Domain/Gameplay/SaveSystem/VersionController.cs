using UnityEngine;

namespace Game.Gameplay
{
    public sealed class VersionController
    {
        private const string SAVE_VERSION_PREFS_KEY = "Version";

        private int _currentVersion = PlayerPrefs.GetInt(SAVE_VERSION_PREFS_KEY, 0);

        public int Current => _currentVersion;

        public int Next => _currentVersion + 1;

        public void SetCurrent(int version)
        {
            _currentVersion = version;
            PlayerPrefs.SetInt(SAVE_VERSION_PREFS_KEY, version);
            PlayerPrefs.Save();
        }
    }
}