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
                GiveLockerContent(inventory);
                if (string.IsNullOrEmpty(lockerContentItemName))
                {
                    InteractionMessage = "The locker is empty.";
                }
                else
                {
                    InteractionMessage = $"A {lockerContentItemName} dropped out of the locker.";
                }

                isTaken = true;
            }
            else
            {
                // does not have the required key
                if (inventory.ContainsAnySmallKey())
                {
                    InteractionMessage = "The small key you have doesn't fit this locker.";
                }
                else if (isTaken)
                {
                    InteractionMessage = "You have already taken the contents of this locker.";
                }
                else
                {
                    InteractionMessage = "You need a key to open this door.";
                }
                
                // timer to reset the message
                Invoke("ResetInteractionMessage", 5f);
            }

        }
        
        private void ResetInteractionMessage()
        {
            InteractionMessage = "Press 'E' to unlock";
        }

        private void GiveLockerContent(Inventory inventory)
        {
            // Logic to open the door
            Debug.Log("The locker has been opened!");

            // activate all children
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            
            // timer to reset the message
            Invoke("ResetInteractionMessage", 2f);
            
        }
    }
}