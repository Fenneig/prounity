using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.App
{
    public interface IGameRepository
    {
        UniTask<(bool, int)> Save(byte[] data, int version, CancellationToken ct = default);
        UniTask<(bool, byte[])> Load(int version, CancellationToken ct = default);
    }
}