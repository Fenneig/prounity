using System;
using DG.Tweening;
using Game.Views;
using Modules.Money;
using Modules.UI;
using UnityEngine;

namespace Game.Presenters
{
    public sealed class MoneyPresenter : IDisposable
    {
        private readonly IMoneyStorage _moneyStorage;
        private readonly MoneyView _moneyView;
        private readonly ParticleAnimator _particleAnimator;
        
        private Tween _moneyTween;
        private int _displayedMoney;
        
        private const float ANIMATION_DURATION = .5f;
        
        public MoneyPresenter(IMoneyStorage moneyStorage, MoneyView moneyView, ParticleAnimator particleAnimator)
        {
            _moneyStorage = moneyStorage;
            _moneyView = moneyView;
            _particleAnimator = particleAnimator;

            _moneyStorage.OnMoneySpent += SpendMoney;
            _moneyView.SetMoney(_moneyStorage.Money.ToString());
            
            _displayedMoney = _moneyStorage.Money;
        }

        public void CollectCoin(Vector3 source) => 
            _particleAnimator.Emit(source, _moneyView.CoinTarget,  onFinished:() => AnimateMoney(_moneyStorage.Money));

        private void SpendMoney(int money, int _) => AnimateMoney(money);
        
        private void AnimateMoney(int targetMoney)
        {
            _moneyTween?.Kill();

            int startMoney = _displayedMoney;

            _moneyTween = DOTween.To(
                    () => startMoney,
                    value =>
                    {
                        startMoney = value;
                        _displayedMoney = value;

                        _moneyView.SetMoney(_displayedMoney.ToString("N0"));
                    },
                    targetMoney,
                    ANIMATION_DURATION)
                .SetEase(Ease.OutQuart);
        }
        
        public void Dispose()
        {
            _moneyStorage.OnMoneySpent -= SpendMoney;
        }
    }
}