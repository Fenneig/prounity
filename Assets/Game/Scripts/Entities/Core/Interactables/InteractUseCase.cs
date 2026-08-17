using Atomic.Entities;

namespace Game.Entities
{
    public static class InteractUseCase
    {
        public static void InteractWith(this IEntity character, IEntity interactable)
        {
            if (interactable != null && 
                interactable.HasInteractableTag() && 
                interactable.GetInteractCommand().CanInvoke(character))
            {
                interactable.GetInteractCommand().Invoke(character);
            }
        }
    }
}