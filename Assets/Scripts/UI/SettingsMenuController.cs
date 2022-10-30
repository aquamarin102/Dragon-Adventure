﻿using Profile;
using Tool;
using UnityEngine;

namespace UI
{
    internal class SettingsMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/SettingsMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly SettingsMenuView _view;

        public SettingsMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUI);
            _view.Init(SetGameStateToStart);
        }

        private void SetGameStateToStart() => _profilePlayer.CurrentState.Value = GameState.Start;

        private SettingsMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingsMenuView>();
        }
        
        
    }
}