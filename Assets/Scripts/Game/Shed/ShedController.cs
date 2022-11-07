using System;
using System.Collections.Generic;
using Game.Inventory;
using Game.Players;
using Game.Shed.Upgrade;
using JetBrains.Annotations;
using Profile;
using Tool;
using Tool.Interfaces;
using UnityEngine;

namespace Game.Shed
{
    internal class ShedController : BaseController, IShedController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Shed/ShedView");
        private readonly ResourcePath _dataSourcePath = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");

        private readonly ShedView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly InventoryController _inventoryController;
        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;

        public ShedController([NotNull] Transform placeForUI, [NotNull] ProfilePlayer profilePlayer)
        {
            if (placeForUI == null)
                throw new ArgumentNullException(nameof(placeForUI));

            _profilePlayer = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

            _upgradeHandlersRepository = CreateRepository();
            _inventoryController = CreateInventoryController(placeForUI);
            _view = LoadView(placeForUI);
            _view.Init(Apply,Back);
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Back. Current Speed: {_profilePlayer.CurrentTransport.Speed}");
        }

        private void Apply()
        {
            _profilePlayer.CurrentTransport.Restore();

            UpgradeWithEquippedItems(
                _profilePlayer.CurrentTransport,
                _profilePlayer.Inventory.EquippedItems,
                _upgradeHandlersRepository.Items);

            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Apply. Current Speed: {_profilePlayer.CurrentTransport.Speed}");
            Log($"Apply. Current FirePower: {_profilePlayer.CurrentTransport.FirePower}");
            Log($"Apply. Current JumpHeight: {_profilePlayer.CurrentTransport.JumpHeight}");
        }
        private void Log(string message) =>
            Debug.Log($"[{GetType().Name}] {message}");
        private void UpgradeWithEquippedItems(IUpgradable upgradable, IReadOnlyList<string> equippedItems, IReadOnlyDictionary<string, IUpgradeHandler> upgradeHandlers)
        {
            foreach (string itemId in equippedItems)
                if (upgradeHandlers.TryGetValue(itemId, out IUpgradeHandler handler))
                    handler.Upgrade(upgradable);
        }

        private ShedView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ShedView>();
        }

        private InventoryController CreateInventoryController(Transform placeForUI)
        {
            var inventoryController = new InventoryController(placeForUI, _profilePlayer.Inventory);
            AddController(inventoryController);

            return inventoryController;
        }

        private UpgradeHandlersRepository CreateRepository()
        {
            UpgradeItemConfig[] upgradeItemConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);
            var repository = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddRepository(repository);

            return repository;
        }

    }
}