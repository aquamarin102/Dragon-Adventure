﻿using System;
using System.Collections.Generic;
using Tool.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class BaseController : IDisposable
    {
        private List<IDisposable> _disposableObjects;
        private List<GameObject> _gameObjects;
        private bool _isDisposed;

        public void Dispose()
        {
            if(_isDisposed)
                return;

            _isDisposed = true;

            DisposeDisposableObjects();
            DisposeGameObjects();
            
            OnDispose();
        }

        private void DisposeDisposableObjects()
        {
            if (_disposableObjects == null)
                return;

            foreach (IDisposable disposableObject in _disposableObjects)
                disposableObject.Dispose();

            _disposableObjects.Clear();
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

        protected void AddController(BaseController baseController) => AddDisposableObject(baseController);

        protected void AddRepository(IRepository repository) => AddDisposableObject(repository);

        public void AddDisposableObject(IDisposable disposable)
        {
            _disposableObjects ??= new List<IDisposable>();
            _disposableObjects.Add(disposable);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects ??= new List<GameObject>();
            _gameObjects.Add(gameObject);
        }

        protected void Log(string message) =>
            Debug.Log($"[{GetType().Name}] {message}");
    }
