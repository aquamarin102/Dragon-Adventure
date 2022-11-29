using Game.Inventory.Items;
using Tool;
using Tool.Interfaces;
using UnityEngine;

namespace Game.Inventory
{
    internal class InventoryMvcContainer : BaseMVCContainer
    {
        private static readonly ResourcePath _viewPath = new("Prefabs/Inventory/InventoryView");
        private static readonly ResourcePath _dataSourcePath = new("Configs/Inventory/ItemConfigDataSource");
        
        public InventoryMvcContainer(IInventoryModel model, Transform placeForUi) =>
            CreateController(model, placeForUi);


        private InventoryController CreateController(IInventoryModel model, Transform placeForUi)
        {
            InventoryView view = LoadView(placeForUi);
            ItemsRepository repository = CreateRepository();

            var inventoryController = new InventoryController(view, model, repository);
            AddController(inventoryController);

            return inventoryController;
        }

        private InventoryView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi);
            AddGameObject(objectView);

            return objectView.GetComponent<InventoryView>();
        }

        private ItemConfig[] LoadConfigs() =>
            ContentDataSourceLoader.LoadItemConfigs(_dataSourcePath);

        private ItemsRepository CreateRepository()
        {
            ItemConfig[] itemConfigs = LoadConfigs();
            var repository = new ItemsRepository(itemConfigs);
            AddRepository(repository);

            return repository;
        }
    }
}