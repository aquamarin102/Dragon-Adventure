using System.Collections.Generic;
using Game.Inventory.Items;
using UnityEngine;
using UnityEngine.Events;

namespace Tool.Interfaces
{
    public interface IItem
    {
        string Id { get; }
        ItemInfo Info { get; }
    }

    internal interface IItemView
    {
        void Init(IItem item, UnityAction clickAction);
    }

    internal interface IItemsRepository : IRepository
    {
        IReadOnlyDictionary<string,IItem> Items { get; }
    }

    
}