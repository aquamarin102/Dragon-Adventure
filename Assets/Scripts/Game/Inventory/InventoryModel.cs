using System.Collections.Generic;
using Tool.Interfaces;

namespace Game.Inventory
{
    internal class InventoryModel : IInventoryModel
    {
        private readonly List<string> _equippedItems = new List<string>();

        public IReadOnlyList<string> EquippedItems => _equippedItems;
        
        public void EquipItem(string itemID)
        {
            if (!IsEquipped(itemID))
            {
                _equippedItems.Add(itemID);
            }
        }

        public void UnequipItem(string itemID)
        {
            if (IsEquipped(itemID))
            {
                _equippedItems.Remove(itemID);
            }
        }

        public bool IsEquipped(string itemID) => _equippedItems.Contains(itemID);
    }
}