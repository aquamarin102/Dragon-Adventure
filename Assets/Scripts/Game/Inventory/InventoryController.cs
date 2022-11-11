using System;
using Game.Inventory.Items;
using JetBrains.Annotations;
using Tool;
using Tool.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Inventory
{
    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly InventoryView _view;
        private readonly IInventoryModel _model;
        private readonly ItemsRepository _repository;

        public InventoryController( Transform placeForUI, IInventoryModel inventoryModel)
        {
            _view = new InventoryFactory().CreateView(placeForUI);
            AddGameObject(_view.gameObject);

            _model = inventoryModel;

            _repository = new ItemRepositoryFactory().Create();
            AddRepository(_repository);
            
            _view.Display(_repository.Items.Values, OnItemClicked);

            foreach (var itemID in _model.EquippedItems)
            {
                _view.Select(itemID);
            }
        }

        protected override void OnDispose()
        {
            _view.Clear();
            base.OnDispose();
        }

        private void OnItemClicked(string itemId)
        {
            bool equipped = _model.IsEquipped(itemId);

            if (equipped)
                UnequipItem(itemId);
            else
                EquipItem(itemId);
        }

        private void EquipItem(string itemId)
        {
            _view.Select(itemId);
            _model.EquipItem(itemId);
        }

        private void UnequipItem(string itemId)
        {
            _view.Unselect(itemId);
            _model.UnequipItem(itemId);
        }
    }
}