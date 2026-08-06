using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic.Entities
{
    [Serializable]
    public class PriorityEntityUpdateSettings : EntityUpdateSettings
    {
        [Header("Priority")]
        [LabelText("High")]
        [PropertyRange(0, 100)]
        [OnValueChanged(nameof(Validate))]
        public int highPercent = 70;

        [LabelText("Mid")]
        [PropertyRange(0, 100)]
        [OnValueChanged(nameof(Validate))]
        public int midPercent = 20;

        [ShowInInspector, ReadOnly]
        public int lowPercent => 100 - highPercent - midPercent;

        private void Validate()
        {
            highPercent = Mathf.Clamp(highPercent, 0, 100);
            midPercent = Mathf.Clamp(midPercent, 0, 100 - highPercent);
        }
    }
}