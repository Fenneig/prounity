using System;
using Game.Views;
using Modules.Planets;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenter : IDisposable
    {
        private readonly PlanetView _planetView;
        private readonly Planet _planet;
        private readonly PlanetPopupPresenter _planetPopupPresenter;
        private readonly MoneyPresenter _moneyPresenter;
        
        public PlanetPresenter(Planet planet, PlanetView planetView, PlanetPopupPresenter planetPopupPresenter, MoneyPresenter moneyPresenter)
        {
            _planet = planet;
            _planetView = planetView;
            _planetPopupPresenter = planetPopupPresenter;
            _moneyPresenter = moneyPresenter;
            
            Subscribe();

            _planetView.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _planetView.SetCost(_planet.Price.ToString());
            _planetView.HideProgressBar();
            _planetView.HideCoin();
        }
        
        private void Subscribe()
        {
            _planetView.OnClicked += ClickHandle;
            _planetView.OnHoldClicked += HoldClickHandle;

            _planet.OnUnlocked += UnlockPlanet;
            _planet.OnIncomeTimeChanged += UpdateTime;
            _planet.OnIncomeReady += UpdateIncomeIndicator;
            _planet.OnGathered += ShowGather;
        }

        public void Dispose()
        {
            _planetView.OnClicked -= ClickHandle;
            _planetView.OnHoldClicked -= HoldClickHandle;
            
            _planet.OnUnlocked -= UnlockPlanet;
            _planet.OnIncomeTimeChanged -= UpdateTime;
            _planet.OnIncomeReady -= UpdateIncomeIndicator;
            _planet.OnGathered -= ShowGather;
        }
        
        private void UpdateIncomeIndicator(bool isReady)
        {
            if (isReady)
            {
                _planetView.HideProgressBar();
                _planetView.ShowCoin();
            }
            else
            {
                _planetView.ShowProgressBar();
                _planetView.HideCoin();
            }
        }

        private void UpdateTime(float remainTime)
        {
            _planetView.SetProgressAmount(_planet.IncomeProgress);
            int minutes = (int) remainTime / 60;
            int seconds = (int) remainTime % 60;
            _planetView.SetProgressText($"{minutes:00}m:{seconds:00}s");
        }

        private void UnlockPlanet()
        {
            _planetView.UnlockPlanet();
            _planetView.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _planetView.ShowProgressBar();
            _planetView.HideCost();
        }

        private void ClickHandle()
        {
            if (_planet.IsUnlocked)
                _planet.GatherIncome();
            else
                _planet.Unlock();
        }

        private void ShowGather(int _) => 
            _moneyPresenter.CollectCoin(_planetView.CoinPosition);

        private void HoldClickHandle()
        {
            if (!_planet.IsUnlocked)
                return;
            
            _planetPopupPresenter.Show(_planet);
        }
        
        public class Factory : PlaceholderFactory<Planet, PlanetView, PlanetPresenter> { }
    }
}