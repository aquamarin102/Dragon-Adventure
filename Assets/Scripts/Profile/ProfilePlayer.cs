using Game.Inventory;
using Game.Players;
using Game.RewardSystem.Resource;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly TransportModel CurrentTransport;
        public readonly InventoryModel Inventory;
        public readonly ResourceModel Currency;
        


        public ProfilePlayer(float transportSpeed, float transportJumpHeight, TransportType transportType, GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>(initialState);
            CurrentTransport = new TransportModel(transportSpeed, transportJumpHeight, transportType);
            Inventory = new InventoryModel();
            Currency = new ResourceModel();
        }
        
    }
}