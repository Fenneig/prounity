using System;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetView : MonoBehaviour
    {
        [SerializeField] private SmartButton _button;
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _lock;
        [SerializeField] private GameObject _progressBarContainer;
        [SerializeField] private GameObject _coin;
        [SerializeField] private Image _progressBar;
        [SerializeField] private TMP_Text _progressText;
        [SerializeField] private GameObject _costContainer;
        [SerializeField] private TMP_Text _cost;

        public event Action OnClicked
        {
            add => _button.OnClick += value;
            remove => _button.OnClick -= value;
        }
        
        public event Action OnHoldClicked
        {
            add => _button.OnHold += value;
            remove => _button.OnHold -= value;
        }
        
        public event Action<PointerEventData> OnHover
        {
            add => _button.OnHover += value;
            remove => _button.OnHover -= value;
        }
        
        public event Action<PointerEventData> OnUnhover
        {
            add => _button.OnUnhover += value;
            remove => _button.OnUnhover -= value;
        }

        public Vector3 CoinPosition => _coin.transform.position;
        
        public void SetIcon(Sprite sprite) => _icon.sprite = sprite;

        public void SetCost(string cost) => _cost.text = cost;
        
        public void HideCost() => _costContainer.gameObject.SetActive(false);
        
        public void ShowProgressBar() => _progressBarContainer.SetActive(true);

        public void HideProgressBar() => _progressBarContainer.SetActive(false);
        
        public void SetProgressAmount(float progress) => _progressBar.fillAmount = progress;
        
        public void SetProgressText(string progress) => _progressText.text = progress;

        public void ShowCoin() => _coin.SetActive(true);
        
        public void HideCoin() => _coin.SetActive(false);
        
        public void UnlockPlanet() => _lock.gameObject.SetActive(false);
    }
}