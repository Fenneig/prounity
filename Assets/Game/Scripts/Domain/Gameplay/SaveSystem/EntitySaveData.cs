using System.Collections.Generic;

namespace Game.Gameplay
{
    public sealed class EntitySaveData
    {
        public int Id;
        public string Name;
        public Dictionary<string, object> Components = new();
    }
}