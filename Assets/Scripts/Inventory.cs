using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Basic inventory system to hold items.
    /// </summary>
    public class Inventory: MonoBehaviour
    {
        private readonly List<TakableItem> items;

        public Inventory()
        {
            items = new List<TakableItem>();
        }

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(TakableItem item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Removes an item from the inventory.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if the item was removed, false if it was not found.</returns>
        public bool RemoveItem(TakableItem item)
        {
            return items.Remove(item);
        }

        /// <summary>
        /// Checks if the inventory contains a specific item.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <returns>True if the item is in the inventory, false otherwise.</returns>
        public bool ContainsItemWithName(string itemName)
        {
            return items.Find(x => x.ItemName == itemName) != null;
        }
        
        public bool UseItemByName(string itemName)
        {
            TakableItem item = items.Find(x => x.ItemName == itemName);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets a list of all items in the inventory.
        /// </summary>
        /// <returns>A list of items.</returns>
        public List<TakableItem> GetItems()
        {
            return new List<TakableItem>(items);
        }
        
        public bool ContainsAnySmallKey()
        {
            return items.Exists(x => x.ItemName.Contains("Small Key"));
        }
    }
}