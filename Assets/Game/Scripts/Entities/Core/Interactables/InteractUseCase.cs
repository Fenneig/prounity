namespace Game.Entities
{
    public static class InteractUseCase
    {
        public static void InteractWith(this IGameEntity character, IGameEntity interactable)
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