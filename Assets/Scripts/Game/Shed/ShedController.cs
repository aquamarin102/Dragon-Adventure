using System;
using Game.Inventory;
using Game.Players;
using JetBrains.Annotations;
using Profile;
using Tool.Interfaces;
using UnityEngine;

namespace Game.Shed
{
    internal class ShedController : BaseController, IShedController
    {
        private readonly ShedView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly InventoryController _inventoryController;
        private readonly TransportUpgrader _transportUpgrader;

        public ShedController([NotNull] Transform placeForUI, [NotNull] ProfilePlayer profilePlayer)
        {
            if (placeForUI == null)
                throw new ArgumentNullException(nameof(placeForUI));

            _profilePlayer = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

            var _inventoryController = new InventoryController(placeForUI, _profilePlayer.Inventory);
            AddController(_inventoryController);

            _view = new ShedFactory().CreateView(placeForUI);
            AddGameObject(_view.gameObject);

            _transportUpgrader = new TransportUpgrader(_profilePlayer.CurrentTransport, _profilePlayer.Inventory.EquippedItems);
            AddDisposableObject(_transportUpgrader);

            _view.Init(Apply, Back);
        }

        private void Back()
        {
            _transportUpgrader.Upgrade();

            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Back. Current Speed: {_profilePlayer.CurrentTransport.Speed}");
        }

        private void Apply()
        {
            _transportUpgrader.Upgrade();

            _profilePlayer.CurrentState.Value = GameState.Start;
            Log($"Apply. Current Speed: {_profilePlayer.CurrentTransport.Speed}");
        }

    }
}