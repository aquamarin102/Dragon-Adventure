using Game.Players;
using Game.Players.Boat;
using Game.Players.Car;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public TransportModel CurrentCar;
        public TransportType TransportType;

        public ProfilePlayer(float speedCar, GameState initialState, TransportType transportType) : this(speedCar)
        {
            CurrentState.Value = initialState;
            this.TransportType = transportType;

            LoadCar(speedCar);
        }

        private void LoadCar(float speedCar)
        {
            switch (TransportType)
            {
                case TransportType.Car:
                    CurrentCar = new CarModel(speedCar);
                    break;
                case TransportType.Boat:
                    CurrentCar = new BoatModel(speedCar);
                    break;
                default:
                    CurrentCar = null;
                    break;
            }
        }

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
        }
    }
}