﻿using Profile;
using Tool;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUI);
            _view.Inint(StartGame, SettingsMenu);
        }

        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() => _profilePlayer.CurrentState.Value = GameState.Game;
        private void SettingsMenu() => _profilePlayer.CurrentState.Value = GameState.Settings;
        
    }
}