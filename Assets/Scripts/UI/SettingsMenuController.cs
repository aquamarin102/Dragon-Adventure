using System;
using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    internal class SettingsMenuController : BaseController
    {
        public event Action OnBackPressed = delegate { };
        
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/SettingsMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly SettingsMenuView _view;

        public SettingsMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUI);
            _view.Init(Back);
        }

        private void Back() =>
            OnBackPressed.Invoke();

        private SettingsMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingsMenuView>();
        }
        
        
    }
}