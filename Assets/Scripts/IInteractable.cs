namespace DefaultNamespace
{
    public interface IInteractable
    {
        public string InteractionMessage { get; }
        // public void Interact();
        // public string GetMessage();

        public void Interact(Inventory inventory);
    }
}