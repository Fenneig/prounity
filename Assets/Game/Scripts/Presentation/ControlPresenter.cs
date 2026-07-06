using System;
using Game.Gameplay;
using UnityEngine;

namespace Game.Presentation
{
    public class ControlPresenter : IControlsPresenter
    {
        private readonly SaveManager _saveManager;

        public ControlPresenter(SaveManager saveManager)
        {
            _saveManager = saveManager;
        }

        public void Save(Action<bool, int> callback)
        {
            try
            {
                callback.Invoke(true, _saveManager.Save());
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Save cancelled");
                callback?.Invoke(false, -1);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                callback?.Invoke(false, -1);
            }
        }

        public void Load(string version, Action<bool, int> callback)
        {
            Debug.Log($"load version {version}");
            try
            {
                int parsedVersion = string.IsNullOrEmpty(version) ? -1 : int.Parse(version);
                _saveManager.Load();
                callback.Invoke(true, parsedVersion);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Load cancelled");
                callback?.Invoke(false, -1);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                callback?.Invoke(false, -1);
            }
        }
    }
}