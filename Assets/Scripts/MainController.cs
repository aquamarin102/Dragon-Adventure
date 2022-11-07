using Game;
using Game.Shed;
using Profile;
using UI;
using UnityEngine;

    internal class MainController : BaseController
    {
        private readonly Transform _placeForUI;
        private readonly ProfilePlayer _profilePlayer;

        private MainMenuController _mainMenuController;
        private SettingsMenuController _settingsMenuController;
        private ShedController _shedController;
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
                    _mainMenuController = new MainMenuController(_placeForUI, _profilePlayer);
                    _settingsMenuController?.Dispose();
                    _shedController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Settings:
                    _settingsMenuController = new SettingsMenuController(_placeForUI, _profilePlayer);
                    _mainMenuController?.Dispose();
                    _shedController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Shed:
                    _shedController = new ShedController(_placeForUI, _profilePlayer);
                    _mainMenuController?.Dispose();
                    _settingsMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _gameController = new GameController(_placeForUI, _profilePlayer);
                    _settingsMenuController?.Dispose();
                    _mainMenuController?.Dispose();
                    _shedController?.Dispose();
                    break;
                default:
                    _mainMenuController?.Dispose();
                    _settingsMenuController?.Dispose();
                    _gameController?.Dispose();
                    _shedController?.Dispose();
                    break;
            }
        }

        private void DisposeAllControllers()
        {
            _mainMenuController?.Dispose();
            _settingsMenuController?.Dispose();
            _shedController?.Dispose();
            _gameController?.Dispose();
        }

        protected override void OnDispose()
        {
            DisposeAllControllers();
            
            _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangedGameState);
        }
    }
