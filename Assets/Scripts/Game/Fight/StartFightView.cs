using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Fight
{
    internal class StartFightView : MonoBehaviour
    {
        [SerializeField] private Button _startFightButton;

        public void Init(UnityAction startFight) => _startFightButton.onClick.AddListener(startFight);

        public void OnDestroy() => _startFightButton.onClick.RemoveAllListeners();
    }
}