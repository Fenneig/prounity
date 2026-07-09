using Cysharp.Threading.Tasks;

namespace Game.App
{
    public interface IGameRepository
    {
        UniTask<(bool, int)> Save(byte[] data, int version);
        UniTask<(bool, byte[])> Load(int version);
    }
}