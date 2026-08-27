using Modules.AI;

namespace Game.Gameplay
{
    public interface IState
    {
        void SetCondition(ICondition invokeCondition);
        public void Enter();
        public void OnFixedTick();
    }
}