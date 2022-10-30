using JoostenProductions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.InputLogic
{
    internal class FloatInputJoystick : BaseInputView, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        
        [Header("Components")]
        
        [SerializeField] private Joystick _joystick;
        [SerializeField] private CanvasGroup _container;

        [Header("Settings")] 
        
        [SerializeField] private float _enabledAlpha = 1f;
        [SerializeField] private float _disabledAlpha = 0f;
        [SerializeField] private float _inputMultiplier = 10f;

        private bool _usingJoystick;

        private void Start() => UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() => UpdateManager.UnsubscribeFromUpdate(Move);

        private void Move()
        {
            if(!_usingJoystick)
                return;

            float axisOffset = CrossPlatformInputManager.GetAxis(HORIZONTAL_AXIS);
            float moveValue = _speed * _inputMultiplier * Time.deltaTime * axisOffset;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
            {
                OnRightMove(abs);
            }
            else if (sign < 0)
            {
                OnLeftMove(abs);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _joystick.transform.position = eventData.position;
            _joystick.SetStartPosition(eventData.position);
            _joystick.OnPointerDown(eventData);
            StartUsing();
        }

        

        public void OnPointerUp(PointerEventData eventData)
        {
            _joystick.OnPointerUp(eventData);
            FinishUsing();
        }



        public void OnDrag(PointerEventData eventData) => _joystick.OnDrag(eventData);

        private void StartUsing()
        {
            _usingJoystick = true;
            SetActive(true);
        }
        
        private void FinishUsing()
        {
            _usingJoystick = false;
            SetActive(false);
        }
        
        private void SetActive(bool active) => _container.alpha = active ? _enabledAlpha : _disabledAlpha;
        
    }
}