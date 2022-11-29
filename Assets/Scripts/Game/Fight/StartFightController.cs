﻿using System;
using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Fight
{
    internal class StartFightController : BaseController
    {
        public event Action OnFightButtonPressed = delegate {  };

        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Fight/StartFightView");

        private readonly StartFightView _view;
        private readonly ProfilePlayer _profilePlayer;

        public StartFightController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartFight);
        }

        

        private StartFightView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<StartFightView>();
        }
        
        private void StartFight() => OnFightButtonPressed.Invoke();
    }
}