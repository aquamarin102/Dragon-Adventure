using Game.Inventory;
using Game.Players;
using Game.Players.Boat;
using Game.Players.Car;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly TransportModel CurrentTransport;
        public readonly InventoryModel Inventory;


        public ProfilePlayer(float transportSpeed, float jumpHeight, TransportType transportType, GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>(initialState);
            CurrentTransport = new TransportModel(transportSpeed, jumpHeight, transportType);
            Inventory = new InventoryModel();
        }
    }
}