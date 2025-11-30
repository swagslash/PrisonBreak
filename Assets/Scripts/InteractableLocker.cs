using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InteractableLocker : MonoBehaviour, IInteractable
    {
        public string requiredItemName = "";
        
        public string lockerContentItemName = "";

        private bool isTaken = false;
            
        public string InteractionMessage { get; private set; }

        public void Start()
        {
            ResetInteractionMessage();
        }

        public void Interact(Inventory inventory)
        {
            if (inventory.ContainsItemWithName(requiredItemName) && !isTaken)
            {
                GiveLockerContent();
                InteractionMessage = "You got " + lockerContentItemName + " from the locker.";
                isTaken = true;
            }
            else
            {
                // does not have the required key
                if (inventory.ContainsAnySmallKey())
                {
                    InteractionMessage = "The small key you have doesn't fit this locker.";
                }
                else if (isTaken || string.IsNullOrEmpty(lockerContentItemName))
                {
                    InteractionMessage = "The locker is empty.";
                    isTaken = true;
                }
                else
                {
                    InteractionMessage = "You need a key to open this door.";
                }
                
                // timer to reset the message
                // Invoke("ResetInteractionMessage", 3f);
            }

        }
        
        private void ResetInteractionMessage()
        {
            InteractionMessage = "Press 'E' to unlock";
        }

        private void GiveLockerContent()
        {
            // Logic to open the door
            Debug.Log("The door has been opened!");
            // put some feedback to the player that they need a key
            // into the interaction message for a few seconds?
            InteractionMessage = "You got ${lockerContentItemName} from the locker.";
            // timer to reset the message
            Invoke("ResetInteractionMessage", 2f);
            
        }
    }
}