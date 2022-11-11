﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class SettingsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonBack;

        public void Init(UnityAction startGame) => _buttonBack.onClick.AddListener(startGame);

        public void OnDestroy() => _buttonBack.onClick.RemoveAllListeners();


    }
}