using Tool;

namespace Game.Shed.Upgrade
{
    internal sealed class UpgradeHandlerRepositoryFactory
    {
        private readonly ResourcePath _path = new ResourcePath("Configs/Shed/UpgradeItemConfigDataSource");

        public UpgradeHandlersRepository Create()
        {
            UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_path);
            var repository = new UpgradeHandlersRepository(upgradeConfigs);
            return repository;
        }
    }
}