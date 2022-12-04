using Game.Inventory;
using Game.Shed.Upgrade;
using Profile;
using Tool;
using Tool.Interfaces;
using UnityEngine;

namespace Game.Shed
{
    internal class ShedMvcContainer : BaseMVCContainer
    {
      private static readonly ResourcePath _viewPath = new("Prefabs/Shed/ShedView");
        private static readonly ResourcePath _dataSourcePath = new("Configs/Shed/UpgradeItemConfigDataSource");


        public ShedMvcContainer(ProfilePlayer profilePlayer, Transform placeForUi) =>
            CreateController(profilePlayer, placeForUi);


        private ShedController CreateController(ProfilePlayer profilePlayer, Transform placeForUi)
        {
            InventoryMvcContainer inventoryMvcContainer = CreateInventoryContainer(profilePlayer.Inventory, placeForUi);
            UpgradeHandlersRepository shedRepository = CreateRepository();
            ShedView shedView = LoadView(placeForUi);

            return new ShedController
            (
                shedView,
                profilePlayer,
                inventoryMvcContainer,
                shedRepository
            );
        }

        private InventoryMvcContainer CreateInventoryContainer(IInventoryModel model, Transform placeForUi)
        {
            var container = new InventoryMvcContainer(model, placeForUi);
            AddContainer(container);

            return container;
        }

        private UpgradeHandlersRepository CreateRepository()
        {
            UpgradeItemConfig[] upgradeConfigs = LoadConfigs();
            var repository = new UpgradeHandlersRepository(upgradeConfigs);
            AddRepository(repository);

            return repository;
        }

        private UpgradeItemConfig[] LoadConfigs() =>
            ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);

        private ShedView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ShedView>();
        }
    }
}