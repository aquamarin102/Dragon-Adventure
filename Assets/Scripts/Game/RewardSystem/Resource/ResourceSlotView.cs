using TMPro;
using UnityEngine;

namespace Game.RewardSystem.Resource
{
    internal class ResourceSlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;

        public void SetData(int count) => _count.text = count.ToString();
    }
}