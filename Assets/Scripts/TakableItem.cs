using UnityEngine;

namespace DefaultNamespace
{
    public class TakableItem : MonoBehaviour, IInteractable
    {
        [SerializeField]
        public string ItemName = "Item";
        
        [SerializeField]
        public string displayNameOverride = null;
        
        // Optional display name for UI, defaults to ItemName if not set
        private string DisplayName => string.IsNullOrEmpty(displayNameOverride) ? ItemName : displayNameOverride;
        
        public bool doesNotDisappearOnTake = false;
        
        public string interactionMessageOverride = null;
        
        // prefab that can be instantiated on drop
        public GameObject ItemPrefab;
        
        private bool isTaken = false;
        
        public string InteractionMessage =>
            !string.IsNullOrEmpty(interactionMessageOverride)
                ? interactionMessageOverride
                : $"Press 'E' to take {DisplayName}";

        public string GetMessage()
        {
            return string.IsNullOrEmpty(interactionMessageOverride) ? interactionMessageOverride : $"Press 'E' to take {DisplayName}";
        }
        
        public void Interact(Inventory inventory)
        {
            inventory.AddItem(this);
            Debug.Log($"{ItemName} has been added to your inventory.");
            isTaken = true;
            if (!doesNotDisappearOnTake)
            {
                gameObject.SetActive(false);
            }
        }

        public override string ToString()
        {
            return ItemName + "(shown as '" + DisplayName + "')";
        }
    }
}