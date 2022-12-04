using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tool
{
    public class CustomText : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        public string Text
        {
            get => GetText();
            set => SetText(value);
        }

        private void OnValidate() => Initialize();

        private void Start() => Initialize();

        private void Initialize()
        {
            bool hasAnyTextComponent = TryAttachTextComponent(ref _text) | TryAttachTextComponent(ref _textMeshProUGUI);

            if (!hasAnyTextComponent)
                throw new UnityException("Can't attach any text component!");
        }

        private bool TryAttachTextComponent<TComponent>(ref TComponent component) where TComponent : Component
        {
            if (component != null)
                return true;

            return TryGetComponent(out component);
        }

        private void SetText(string text)
        {
            if (_text != null)
                _text.text = text;
            else if (_textMeshProUGUI != null)
                _textMeshProUGUI.text = text;
        }

        private string GetText()
        {
            if (_text != null)
                return _text.text;

            if (_textMeshProUGUI != null)
                return _textMeshProUGUI.text;

            return string.Empty;
        }
    }
}