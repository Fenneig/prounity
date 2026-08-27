using Modules.AI;

namespace Game.Gameplay
{
    public interface IStateSwitcher
    {
        void SwitchState<T>(ICondition condition = null) where T : IState;
    }
}