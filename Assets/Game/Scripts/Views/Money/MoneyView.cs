using TMPro;
using UnityEngine;

namespace Game.Views
{
    public sealed class MoneyView : MonoBehaviour
    {
        [SerializeField] private Transform _coinTarget;
        [SerializeField] private TMP_Text _text;
        
        public Vector3 CoinTarget => _coinTarget.position;

        public void SetMoney(string money) => _text.text = money;
    }
}