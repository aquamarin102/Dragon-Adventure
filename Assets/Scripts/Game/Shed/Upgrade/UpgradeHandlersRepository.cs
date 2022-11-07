using System.Collections.Generic;
using DefaultNamespace;
using Tool.Interfaces;

namespace Game.Shed.Upgrade
{
    internal class UpgradeHandlersRepository : Repository<string, IUpgradeHandler, UpgradeItemConfig>, IUpgradeHandlersRepository
    {
        public UpgradeHandlersRepository(IEnumerable<UpgradeItemConfig> configs) : base(configs)
        {
        }

        protected override IUpgradeHandler CreateItem(UpgradeItemConfig config) => config.Type switch
        {
            UpgradeType.Speed => new SpeedUpgradeHandler(config.Value),
            UpgradeType.FirePower => new FireUpgradeHandler(config.Value),
            UpgradeType.JumpHeight => new JumpUpgradeHandler(config.Value),
            _ => StubUpgradeHandler.Default
        };

        protected override string GetKey(UpgradeItemConfig config) => config.Id;
    }
}