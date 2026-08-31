using Atomic.Entities;

/**
 * Created by Entity Domain Generator.
 */

namespace Game
{
    /// <summary>
    /// A Unity <see cref="MonoBehaviour"/> that can be attached to a GameObject to perform installation logic on an <see cref="IGameContext"/> during runtime or initialization.
    /// </summary>
    /// <remarks>
    /// Used to declaratively configure entities placed in a scene.
    /// In the Editor, it supports automatic refresh via <c>OnValidate</c>.
    /// </remarks>
    public abstract class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
    }
}
