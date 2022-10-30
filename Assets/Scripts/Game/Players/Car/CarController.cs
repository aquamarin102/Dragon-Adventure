﻿using Tool;
using UnityEngine;

namespace Game.Players.Car
{
    internal class CarController : TransportController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Car");
        private readonly CarView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public CarController() : base()
        {
            _view = LoadView();
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<CarView>();
        }
    }
}