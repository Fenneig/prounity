using Game.Views;
using Modules.Planets;

namespace Game.Presenters
{
    public class PlanetPopupPresenter
    {
        private Planet _planet;
        private PlanetPopupView _planetPopup;
        
        public PlanetPopupPresenter(PlanetPopupView planetPopup)
        {
            _planetPopup = planetPopup;
        }

        public void Show(Planet planet)
        {
            _planet = planet;
            _planetPopup.Show();
            UpdateView();

            _planetPopup.OnUpgradeClicked += OnUpgrade;
            _planetPopup.OnCloseClicked += Hide;
            
            _planet.OnIncomeChanged += UpdateIncome;
            _planet.OnUpgraded += UpdateLevel;
            _planet.OnPopulationChanged += UpdatePopulation;
            _planet.OnUpgraded += UpdateCost;
        }

        public void Hide()
        {
            _planetPopup.Hide();
            
            _planetPopup.OnUpgradeClicked -= OnUpgrade;
            _planetPopup.OnCloseClicked -= Hide;
            
            _planet.OnIncomeChanged -= UpdateIncome;
            _planet.OnUpgraded -= UpdateLevel;
            _planet.OnPopulationChanged -= UpdatePopulation;
            _planet.OnUpgraded -= UpdateCost;
        }

        private void OnUpgrade() => _planet?.Upgrade();

        private void UpdateIncome(int income) => _planetPopup.SetIncome(income.ToString());

        private void UpdateLevel(int level) => _planetPopup.SetLevel(level.ToString());
        
        private void UpdatePopulation(int population) => _planetPopup.SetPopulation(population.ToString());

        private void UpdateCost(int level)
        {
            if (level == _planet.MaxLevel)
                _planetPopup.HidePrice();
            else
                _planetPopup.SetPrice(_planet.Price.ToString());
        }
        private void UpdateView()
        {
            _planetPopup.SetTitle(_planet.Name);
            _planetPopup.SetImage(_planet.GetIcon(_planet.IsUnlocked));
            _planetPopup.SetPopulation(_planet.Population.ToString());
            _planetPopup.SetLevel(_planet.Level.ToString());
            _planetPopup.SetIncome(_planet.MinuteIncome.ToString());
            _planetPopup.SetPrice(_planet.Price.ToString());
            
            if (_planet.IsMaxLevel)
                _planetPopup.HidePrice();
            else
                _planetPopup.ShowPrice();
        }
    }
}