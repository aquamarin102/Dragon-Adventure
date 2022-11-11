namespace Tool.Interfaces
{
    public interface IUpgradable
    {
        float Speed { get; set; }
        float JumpHeight { get; set; }
        float FirePower { get; set; }
        void Restore();
    }
}