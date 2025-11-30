using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorTrigger : MonoBehaviour, IInteractable
    {
        public string InteractionMessage { get; private set; }

        public void Start()
        {
            ResetInteractionMessage();
        }

        public void Interact(Inventory inventory)
        {
            if (inventory.ContainsItemWithName("Key"))
            {
                OpenDoor();
            }
            else
            {
                // put some feedback to the player that they need a key
                // into the interaction message for a few seconds?
                InteractionMessage = "You need a key to open this door.";
                // timer to reset the message
                Invoke("ResetInteractionMessage", 2f);
            }

        }
        
        private void ResetInteractionMessage()
        {
            InteractionMessage = "Press 'E' to open the door";
        }

        private void OpenDoor()
        {
            // Logic to open the door
            Debug.Log("The door has been opened!");
            // Disable all children
            foreach (Transform child in transform)
            {
                child.transform.position = new Vector3(
                    child.transform.position.x,
                    3f,
                    child.transform.position.z);
            }
        }
    }
}