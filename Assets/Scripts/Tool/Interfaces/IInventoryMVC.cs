using System;
using System.Collections.Generic;

namespace Tool.Interfaces
{
    internal interface IInventoryModel
    {
        IReadOnlyList<string> EquippedItems { get; }
        void EquipItem(string itemID);
        void UnequipItem(string itemID);
        bool IsEquipped(string itemID);
    }
    
    internal interface IInventoryView
    {
        void Display(IEnumerable<IItem> itemsCollection, Action<string> itemClicked);
        void Clear();
        void Select(string id);
        void Unselect(string id);
    }

    internal interface IInventoryController
    {
    }
}