using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic.Entities
{
    [Serializable]
    public class EntityUpdateSettings
    {
        [LabelText("Frame Budget (ms)")]
        public float frameBudget = 0.003f;
     
        [Header("Batching")]
        public int minBatchSize = 1024;
        public int maxBatchSize = 2048;
        public int batchScaleDown = 2;
        public int batchStepUp = 256;
    }
}