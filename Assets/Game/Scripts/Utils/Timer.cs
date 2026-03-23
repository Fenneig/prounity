using System;
using UnityEngine;

namespace Game.Utils
{
    [Serializable]
    public sealed class Timer
    {
        [SerializeField] private float _value;

        private float _timeLeft;
        
        public bool IsFinished => _timeLeft <= 0;
        public event Action OnFinished;

        public Timer()
        {
            _timeLeft = _value;
        }

        public Timer(float value)
        {
            _value = value;
            _timeLeft = value;
        }
        
        public void Reset() => 
            _timeLeft = _value;
        
        public void SetValue(float newValue) => 
            _value = newValue;
        
        public void Tick(float amount)
        {
            if (_timeLeft <= 0)
                return;
            
            _timeLeft -= amount;
            
            if (_timeLeft <= 0)
                OnFinished?.Invoke();
        }
    }
}