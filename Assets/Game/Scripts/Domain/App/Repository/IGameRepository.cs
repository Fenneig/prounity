using Newtonsoft.Json.Linq;

namespace Game.App
{
    public interface IGameRepository
    {
        void Save(JObject data, int version);
        (bool, JObject) Load(int version);
    }
}