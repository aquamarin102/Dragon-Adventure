using Tool.Interfaces;

namespace Game.Shed.Upgrade
{
    public class JumpUpgradeHandler : IUpgradeHandler
    {
    private readonly float _jumpHeight;

    public JumpUpgradeHandler(float jumpHeight) => _jumpHeight = jumpHeight;

    public void Upgrade(IUpgradable upgradable) => upgradable.JumpHeight += _jumpHeight;
    }
}