using Game.Views;
using Modules.Money;
using Modules.Planets;

namespace Game.Presenters
{
    public sealed class PlanetPopupPresenter
    {
        private readonly PlanetPopupView _planetPopup;
        private readonly IMoneyStorage _moneyStorage;
        
        private Planet _planet;

        private const string POPULATION_TITLE = "Population: ";
        private const string INCOME_TITLE = "Income: ";
        private const string LEVEL_TITLE = "Level: ";

        public PlanetPopupPresenter(PlanetPopupView planetPopup, IMoneyStorage moneyStorage)
        {
            _planetPopup = planetPopup;
            _moneyStorage = moneyStorage;
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

            _moneyStorage.OnMoneyChanged += CheckMoney;
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
            
            _moneyStorage.OnMoneyChanged -= CheckMoney;
        }

        private void UpdateView()
        {
            _planetPopup.SetTitle(_planet.Name);
            _planetPopup.SetImage(_planet.GetIcon(_planet.IsUnlocked));
            UpdatePopulation(_planet.Population);
            UpdateLevel(_planet.Level);
            UpdateIncome(_planet.MinuteIncome);
            _planetPopup.SetPrice(_planet.Price.ToString());

            UpdateCost(_planet.Level);
            CheckMoney(_moneyStorage.Money, _moneyStorage.Money);
        }

        private void OnUpgrade() => _planet?.Upgrade();

        private void UpdateIncome(int income) => _planetPopup.SetIncome($"{INCOME_TITLE}{income} / sec");

        private void UpdateLevel(int level) => _planetPopup.SetLevel($"{LEVEL_TITLE}{level}/{_planet.MaxLevel}");

        private void UpdatePopulation(int population) => _planetPopup.SetPopulation($"{POPULATION_TITLE}{population}");

        private void UpdateCost(int level)
        {
            if (level == _planet.MaxLevel)
            {
                _planetPopup.ChangeToMaxLevelButton();
            }
            else
            {
                _planetPopup.ChangeToUpgradeButton();
                _planetPopup.SetPrice(_planet.Price.ToString());
            }
        }

        private void CheckMoney(int _, int __) => 
            _planetPopup.SetUpgradeInteractable(_planet.CanUpgrade);
    }
}