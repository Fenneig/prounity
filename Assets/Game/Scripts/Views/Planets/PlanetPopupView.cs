using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Views
{
    public class PlanetPopupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _planetImage;
        [SerializeField] private TMP_Text _population;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _income;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _priceText;
        
        public event UnityAction OnUpgradeClicked
        {
            add => _upgradeButton.onClick.AddListener(value);
            remove => _upgradeButton.onClick.RemoveListener(value);
        }

        public event UnityAction OnCloseClicked
        {
            add => _closeButton.onClick.AddListener(value);
            remove => _closeButton.onClick.RemoveListener(value);
        }

        public void Show() => gameObject.SetActive(true);
        
        public void Hide() => gameObject.SetActive(false);

        public void SetTitle(string title) => _title.text = title;
        
        public void SetImage(Sprite sprite) => _planetImage.sprite = sprite;
        
        public void SetPopulation(string population) => _population.text = population;

        public void SetLevel(string level) => _level.text = level;

        public void SetIncome(string income) => _income.text = income;

        public void SetPrice(string price) => _priceText.text = price;

        public void ShowPrice() => _upgradeButton.gameObject.SetActive(true);
        public void HidePrice() => _upgradeButton.gameObject.SetActive(false);
    }
}