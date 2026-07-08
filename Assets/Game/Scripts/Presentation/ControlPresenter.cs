using System;
using Cysharp.Threading.Tasks;
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

        public void Save(Action<bool, int> callback) => SaveAsync(callback).Forget();

        public void Load(string version, Action<bool, int> callback) => LoadAsync(version, callback).Forget();

        private async UniTask SaveAsync(Action<bool, int> callback)
        {
            var (success, version) = await _saveManager.Save();
            callback.Invoke(success, version);
        }

        private async UniTask LoadAsync(string version, Action<bool, int> callback)
        {
            var (success, loadedVersion) = await _saveManager.Load(version);
            callback.Invoke(success, loadedVersion);
        }
    }
}