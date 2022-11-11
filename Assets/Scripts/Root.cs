using Profile;
using UnityEngine;

    internal class Root : MonoBehaviour
    {
        private const float SpeedCar = 15f;
        private const float JumpHeightCar = 250f;
        private const GameState InitialState = GameState.Start;
        private const TransportType TransportType = Profile.TransportType.Car;

        [SerializeField] private Transform _placeForUi;

        private MainController _mainController;


        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(SpeedCar, JumpHeightCar, TransportType, InitialState);
            _mainController = new MainController(_placeForUi, profilePlayer);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }

