using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Game.App
{
    public interface IGameRepository
    {
        UniTask<(bool, int)> Save(JObject data, int version);
        UniTask<(bool, JObject)> Load(int version);
    }
}