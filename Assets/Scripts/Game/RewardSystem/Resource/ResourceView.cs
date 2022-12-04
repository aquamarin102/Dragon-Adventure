using System;
using UnityEngine;

namespace Game.RewardSystem.Resource
{
    internal class ResourceView : MonoBehaviour
    {
        [SerializeField] private ResourceSlotView _currencyWood;
        [SerializeField] private ResourceSlotView _currentDiamond;


        public void Init(int woodCount, int diamondCount)
        {
            SetWood(woodCount);
            SetDiamond(diamondCount);
        }

        public void SetWood(int value) => _currencyWood.SetData(value);
        public void SetDiamond(int value) => _currentDiamond.SetData(value);
    }
}