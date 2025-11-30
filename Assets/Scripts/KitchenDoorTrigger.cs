using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class KitchenDoorTrigger : MonoBehaviour, IInteractable
    {
        public string requiredItemName = "Kitchen Key";
        
        public string InteractionMessage { get; private set; }
        
        private KitchenDoorScript  doorScript;

        public void Start()
        {
            ResetInteractionMessage();
            doorScript = GetComponent<KitchenDoorScript>();
        }

        public void Interact(Inventory inventory)
        {
            if (inventory.ContainsItemWithName(requiredItemName))
            {
                OpenDoor();
            }
            else
            {
                // put some feedback to the player that they need a key
                // into the interaction message for a few seconds?
                InteractionMessage = "You need a key to open this door.";
                Debug.Log(inventory);
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
            Debug.Log("The ktichen door has been opened!");
            // Disable all children
            doorScript.OpenDoor();
        }
    }
}