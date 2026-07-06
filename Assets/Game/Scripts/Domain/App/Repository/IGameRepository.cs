using Newtonsoft.Json.Linq;

namespace Game.App
{
    public interface IGameRepository
    {
        void Save(JObject data);
        (bool, JObject) Load(int version = -1);
    }
}