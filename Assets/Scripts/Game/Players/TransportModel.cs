﻿using Profile;
using Tool.Interfaces;

namespace Game.Players
{
    internal class TransportModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        private readonly float _defaultJumpHeight;
        private readonly float _defaultFirePower = 1f;

        public readonly TransportType Type;
        public float Speed { get; set; }
        public float JumpHeight { get; set; }
        public float FirePower { get; set; }

        public TransportModel(float speed, float jumpHeight, TransportType type)
        {
            _defaultSpeed = speed;
            _defaultJumpHeight = jumpHeight;
            Speed = speed;
            JumpHeight = jumpHeight;
            Type = type;
            FirePower = _defaultFirePower;
        }
        
        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpHeight = _defaultJumpHeight;
            FirePower = _defaultFirePower;
        }
    }
}