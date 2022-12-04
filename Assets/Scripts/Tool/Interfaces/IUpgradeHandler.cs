using System.Collections.Generic;

namespace Tool.Interfaces
{
    public interface IUpgradeHandler
    {
        void Upgrade(IUpgradable upgradable);
    }
    
    internal interface IUpgradeHandlersRepository : IRepository
    {
        IReadOnlyDictionary<string, IUpgradeHandler> Items { get; }
    }
}