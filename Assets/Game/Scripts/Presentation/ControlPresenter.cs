using System;
using Game.Gameplay;

namespace Game.Presentation
{
    public class ControlPresenter : IControlsPresenter
    {
        private readonly SaveManager _saveManager;

        public ControlPresenter(SaveManager saveManager)
        {
            _saveManager = saveManager;
        }

        public void Save(Action<bool, int> callback) => callback.Invoke(true, _saveManager.Save());

        public void Load(string version, Action<bool, int> callback)
        {
            int parsedVersion = int.TryParse(version, out int result) ? result : -1;
            callback.Invoke(true, _saveManager.Load(parsedVersion));
        }
    }
}