using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;

        public void Inint(UnityAction startGame, UnityAction settingsAction)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(settingsAction);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
        }
    }
}