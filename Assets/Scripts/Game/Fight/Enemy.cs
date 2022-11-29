
using Game.Fight.Interfaces;
using UnityEngine;

namespace Game.Fight
{
    internal class Enemy : IEnemy
    {
        private const float KMoney = 5f;
        private const float KPower = 1.5f;
        private const float KCrimeRate = 3f;
        private const float KHealth = 7f;
        private const float KSummary = 0.3f;
        private const float MaxHealthPlayer = 20f;

        private readonly string _name;

        private int _moneyPlayer;
        private int _powerPlayer;
        private int _healthPlayer;
        private int _crimeRatePlayer;

        public Enemy(string name) => _name = name;
        
        public void Update(PlayerData playerData)
        {
            switch (playerData.DataType)
            {
                case DataType.Money:
                    _moneyPlayer = playerData.Value;
                    break;

                case DataType.Health:
                    _healthPlayer = playerData.Value;
                    break;

                case DataType.Power:
                    _powerPlayer = playerData.Value;
                    break;

                case DataType.Crime:
                    _crimeRatePlayer = playerData.Value;
                    break;
            }

            Debug.Log($"Notified {_name} change to {playerData}");
        }

        public int CalculationPower()
        {
            float healthRatio = _healthPlayer / KHealth;
            float moneyRatio = _moneyPlayer / KMoney;
            float powerRatio = _powerPlayer / KPower;
            float crimeRateRatio = _crimeRatePlayer / KCrimeRate;
            float summaryRatio = moneyRatio + healthRatio + powerRatio + crimeRateRatio;

            return (int)(summaryRatio * KSummary * MaxHealthPlayer);
        }
        
    }
}