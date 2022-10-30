using Profile;
using UnityEngine;

    internal class Root : MonoBehaviour
    {
        private const float SpeedCar = 15f;
        private const GameState InitialState = GameState.Start;

        [SerializeField] private Transform _placeForUI;

        private MainController _mainController;

        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(SpeedCar, InitialState, TransportType.Car);
            _mainController = new MainController(_placeForUI, profilePlayer);
        }

        private void OnDestroy()
        {
            _mainController.Dispose();
        }
    }

