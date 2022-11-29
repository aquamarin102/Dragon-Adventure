using System;
using System.Collections.Generic;
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
        private readonly IShedView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly BaseMVCContainer _inventoryMvcContainer;
        private readonly IUpgradeHandlersRepository _upgradeHandlersRepository;

       public ShedController(
            [NotNull] IShedView view,
            [NotNull] ProfilePlayer profilePlayer,
            [NotNull] BaseMVCContainer inventoryMvcContainer,
            [NotNull] IUpgradeHandlersRepository upgradeHandlersRepository)
        {
            _view
                = view ?? throw new ArgumentNullException(nameof(view));

            _profilePlayer
                = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

            _upgradeHandlersRepository
                = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));

            _inventoryMvcContainer
                = inventoryMvcContainer ?? throw new ArgumentNullException(nameof(inventoryMvcContainer));

            _view.Init(Apply, Back);
        }

        protected override void OnDispose()
        {
            _view.Deinit();
            base.OnDispose();
        }

        private void Apply()
        {
            _profilePlayer.CurrentTransport.Restore();

            UpgradeWithEquippedItems(
                _profilePlayer.CurrentTransport,
                _profilePlayer.Inventory.EquippedItems,
                _upgradeHandlersRepository.Items);

            _profilePlayer.CurrentState.Value = GameState.Start;
            Log("Apply. " +
                $"Current Speed: {_profilePlayer.CurrentTransport.Speed}. " +
                $"Current Jump Height: {_profilePlayer.CurrentTransport.JumpHeight}");
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
            Log("Back. " +
                $"Current Speed: {_profilePlayer.CurrentTransport.Speed}. " +
                $"Current Jump Height: {_profilePlayer.CurrentTransport.JumpHeight}");
        }


        private void UpgradeWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<string> equippedItems,
            IReadOnlyDictionary<string, IUpgradeHandler> upgradeHandlers)
        {
            foreach (string itemId in equippedItems)
                if (upgradeHandlers.TryGetValue(itemId, out IUpgradeHandler handler))
                    handler.Upgrade(upgradable);
        }
    }

}

   
