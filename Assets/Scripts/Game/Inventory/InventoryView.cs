using System;
using System.Collections.Generic;
using Game.Inventory.Items;
using Tool.Interfaces;
using UnityEngine;

namespace Game.Inventory
{
    internal class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private GameObject _itemViewPrefab;
        [SerializeField] private Transform _placeForItem;

        private readonly Dictionary<string, ItemView> _itemViews = new Dictionary<string, ItemView>();

        private void OnDestroy() => Clear();
        

        public void Display(IEnumerable<IItem> itemsCollection, Action<string> itemClicked)
        {
            Clear();

            foreach (IItem item in _itemViews.Values)
                _itemViews[item.Id] = CreateItemView(item, itemClicked);
        }

        public void Clear()
        {
            foreach (ItemView itemView in _itemViews.Values)
            {
                DestroyItemView(itemView);
            }
            _itemViews.Clear();
        }

        public void Select(string id) => _itemViews[id].Select();

        public void Unselect(string id) => _itemViews[id].Unselect();

        private ItemView CreateItemView(IItem item, Action<string> itemClicked)
        {
            GameObject objectView = Instantiate(_itemViewPrefab, _placeForItem, false);
            ItemView itemView = objectView.GetComponent<ItemView>();
            
            itemView.Init(item, () => itemClicked?.Invoke(item.Id));

            return itemView;
        }
        
        private void DestroyItemView(ItemView itemView)
        {
            itemView.Deinit();
            Destroy(itemView.gameObject);
        }
        
    }
}