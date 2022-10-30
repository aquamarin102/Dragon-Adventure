
using System;
using JoostenProductions;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.InputLogic
{
    internal class InputJoystickView : BaseInputView
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        
        [SerializeField] private float _inputMultiplier = 10f;

        private void Start() => UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);
        
        private void Move()
        {
            float axisOffset = CrossPlatformInputManager.GetAxis(HORIZONTAL_AXIS);
            float moveValue = _inputMultiplier * Time.deltaTime * axisOffset;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
            {
                OnRightMove(abs);
            }
            else
            {
                OnLeftMove(abs);
            }
        }
    }
}