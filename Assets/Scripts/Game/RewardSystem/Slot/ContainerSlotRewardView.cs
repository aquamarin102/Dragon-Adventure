using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.RewardSystem.Slot
{
    internal class ContainerSlotRewardView : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Image _originalBackground;
        [SerializeField] private Image _selectBackground;
        [SerializeField] private Image _iconResource;
        [SerializeField] private TMP_Text _textCooldownPeriod;
        [SerializeField] private TMP_Text _countReward;

        [Header("Settings")]
        [SerializeField] private string _cooldownPeriodKey;

        public void SetData(Reward reward, int countCooldownPeriods, bool isSelected)
        {
            _iconResource.sprite = reward.IconResource;
            _textCooldownPeriod.text = $"{_cooldownPeriodKey} {countCooldownPeriods}";
            _countReward.text = reward.CountResource.ToString();

            UpdateBackground(isSelected);
        }

        private void UpdateBackground(bool isSelected)
        {
            _originalBackground.gameObject.SetActive(!isSelected);
            _selectBackground.gameObject.SetActive(isSelected);
        }
    }
}