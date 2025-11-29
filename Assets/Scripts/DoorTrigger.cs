using UnityEngine;

namespace DefaultNamespace
{
    public class DoorTrigger : MonoBehaviour, IInteractable
    {
        private readonly string _interactionMessage = "Press 'E' to open the door";

        public string InteractionMessage => _interactionMessage;

        public void Interact()
        {
            // Logic to open the door
            Debug.Log("The door has been opened!");
        }
    }
}