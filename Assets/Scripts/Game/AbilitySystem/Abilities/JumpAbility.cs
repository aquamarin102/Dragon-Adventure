using System;
using System.Diagnostics.CodeAnalysis;
using Tool.Interfaces;
using UnityEngine;

namespace Game.AbilitySystem.Abilities
{
    internal class JumpAbility : IAbility
    {
        private readonly AbilityItemConfig _config;

        public JumpAbility([NotNull] AbilityItemConfig config) =>
            _config = config ?? throw new ArgumentNullException(nameof(config));
        
        public void Apply(IAbilityActivator activator)
        {
            var projectile = activator.ViewGameObject.GetComponent<Rigidbody2D>();
            Vector3 force = activator.ViewGameObject.transform.up * activator.TransportModel.JumpHeight;
            projectile.AddForce(force, ForceMode2D.Force);
            Debug.Log("Jump " + force.ToString());
        }
    }
}