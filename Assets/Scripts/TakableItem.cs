using UnityEngine;

namespace DefaultNamespace
{
    public class TakableItem : MonoBehaviour, IInteractable
    {
        [SerializeField]
        public string ItemName = "Item";
        
        // prefab that can be instantiated on drop
        public GameObject ItemPrefab;
        
        private bool isTaken = false;
        public string InteractionMessage => $"Press 'E' to pick up {ItemName}";

        public void Interact(Inventory inventory)
        {
            inventory.AddItem(this);
            Debug.Log($"{ItemName} has been added to your inventory.");
            isTaken = true;
            gameObject.SetActive(false);
        }
    }
}