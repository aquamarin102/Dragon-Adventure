using Game;
using Profile;
using UI;
using UnityEngine;

    internal class MainController : BaseController
    {
        private readonly Transform _placeForUI;
        private readonly ProfilePlayer _profilePlayer;

        private MainMenuController _mainMenuController;
        private SettingsMenuController _settingsMenuController;
        private GameController _gameController;

        public MainController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _placeForUI = placeForUI;
            _profilePlayer = profilePlayer;
            
            profilePlayer.CurrentState.SubscribeOnChange(OnChangedGameState);
            OnChangedGameState(_profilePlayer.CurrentState.Value);
        }

        private void OnChangedGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    DisposeAllControllers();
                    _mainMenuController = new MainMenuController(_placeForUI, _profilePlayer);
                    break;
                case GameState.Settings:
                    DisposeAllControllers();
                    _settingsMenuController = new SettingsMenuController(_placeForUI, _profilePlayer);
                    break;
                case GameState.Game:
                    DisposeAllControllers();
                    _gameController = new GameController(_profilePlayer);
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        private void DisposeAllControllers()
        {
            _mainMenuController?.Dispose();
            _settingsMenuController?.Dispose();
            _gameController?.Dispose();
        }

        protected override void OnDispose()
        {
            DisposeAllControllers();
            
            _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangedGameState);
        }
    }
