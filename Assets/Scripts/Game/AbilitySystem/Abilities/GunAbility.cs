﻿using System;
using JetBrains.Annotations;
using Tool;
using Tool.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.AbilitySystem.Abilities
{
    internal class GunAbility : IAbility
    {
        private const float TIME_TO_DESTROY = 5f;
        private readonly IAbilityItem _abilityItem;
        
        public GunAbility([NotNull] IAbilityItem abilityItem) => 
            _abilityItem = abilityItem ?? throw new ArgumentNullException(nameof(abilityItem));
        
        
        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_abilityItem.Projectile).GetComponent<Rigidbody2D>();
            Vector3 force = activator.ViewGameObject.transform.right * _abilityItem.Value;
            projectile.AddForce(force, ForceMode2D.Force);
            GameObject.Destroy(projectile.gameObject, TIME_TO_DESTROY);
        }
    }
}