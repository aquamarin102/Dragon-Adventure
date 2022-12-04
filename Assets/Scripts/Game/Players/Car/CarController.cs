﻿using Profile;
using Tool;
using UnityEngine;

namespace Game.Players.Car
{
    internal class CarController : TransportController
    { 
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Transport/Car");
        private readonly CarView _view;

        public override GameObject ViewGameObject => _view.gameObject;


        public CarController(TransportModel model) : base(model) =>
            _view = LoadView();


        private CarView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<CarView>();
        }
    }
}