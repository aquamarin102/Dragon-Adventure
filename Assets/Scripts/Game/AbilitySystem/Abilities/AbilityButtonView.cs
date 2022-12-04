using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.AbilitySystem.Abilities
{
    internal class AbilityButtonView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        private void OnDestroy() => Deinit();

        internal void Init(Sprite icon, UnityAction click)
        {
            _icon.sprite = icon;
            _button.onClick.AddListener(click);
        }

        internal void Deinit()
        {
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }
    }
}