namespace DefaultNamespace
{
    public interface IInteractable
    {
        public string InteractionMessage { get; }
        // public void Interact();

        public void Interact(Inventory inventory);
    }
}