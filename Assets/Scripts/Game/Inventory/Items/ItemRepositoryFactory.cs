using Tool;

namespace Game.Inventory.Items
{
    internal sealed class ItemRepositoryFactory
    {
        private readonly ResourcePath _path = new ResourcePath("Configs/Inventory/ItemConfigDataSource");

        public ItemsRepository Create()
        {
            ItemConfig[] itemConfigs = ContentDataSourceLoader.LoadItemConfigs(_path);
            return new ItemsRepository(itemConfigs);
        }
    }
}