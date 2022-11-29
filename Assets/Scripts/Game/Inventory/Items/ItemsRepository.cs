using System.Collections.Generic;

using Tool.Interfaces;

namespace Game.Inventory.Items
{
    internal class ItemsRepository : Repository<string, IItem, ItemConfig>, IItemsRepository
    {
        public ItemsRepository(IEnumerable<ItemConfig> configs) : base(configs)
        {
        }

        protected override IItem CreateItem(ItemConfig config) =>
            new Item
            (
                config.Id,
                new ItemInfo
                (
                    config.Title,
                    config.Icon
                )
            );



        protected override string GetKey(ItemConfig config) => config.Id;
    }
}