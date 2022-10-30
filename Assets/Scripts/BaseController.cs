using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController
    {
        private List<BaseController> _baseControllers;
        private List<GameObject> _gameObjects;
        private bool _isDisposed;

        public void Dispose()
        {
            if(_isDisposed)
                return;

            _isDisposed = true;

            DisposeBaseControllers();
            DisposeGameObjects();
            
            OnDispose();
        }
        
        private void DisposeBaseControllers()
        {
            if(_baseControllers == null)
                return;

            foreach (var baseController in _baseControllers)
            {
                baseController.Dispose();
            }
            
            _baseControllers.Clear();
        }
        
        private void DisposeGameObjects()
        {
            if(_gameObjects == null)
                return;

            foreach (var gameObject in _gameObjects)
            {
                Object.Destroy(gameObject);
            }
            
            _gameObjects.Clear();
        }
        
        protected virtual void OnDispose() { }

        protected void AddController(BaseController baseController)
        {
            _baseControllers ??= new List<BaseController>();
            _baseControllers.Add(baseController);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects ??= new List<GameObject>();
            _gameObjects.Add(gameObject);
        }
    }
