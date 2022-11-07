using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SwipeDetection
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : Singleton<InputManager>
    {
        private PlayerControls _playerControls;
        private Camera _mainCamera;
        
        public delegate void StartTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch; 
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnEndTouch; 
        
        private void Awake()
        {
            _playerControls = new PlayerControls();
            _mainCamera = Camera.main;
        }
        private void Start()
        {
            _playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
            _playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        }

        

        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            if (OnStartTouch != null)
            {
                OnStartTouch(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)ctx.startTime);
            }
        }
        
        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            if (OnEndTouch != null)
            {
                OnEndTouch(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)ctx.time);
            }
        }

        public Vector2 PrimaryPosition()
        {
            return Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}