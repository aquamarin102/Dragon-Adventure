using System;
using System.Collections.Generic;
using Game.AbilitySystem.Abilities;
using Game.Players;
using UnityEngine;
using UnityEngine.Events;

namespace Tool.Interfaces
{
    internal interface IAbility
    {
        void Apply(IAbilityActivator activator);
    }
    
    internal interface IAbilitiesController
    { }
    
    internal interface IAbilitiesView
    {
        void Display(IEnumerable<IAbilityItem> abilityItems, Action<string> clicked);
        void Clear();
    }
    
    internal interface IAbilitiesRepository : IRepository
    {
        IReadOnlyDictionary<string, IAbility> Items { get; }
    }
    
    internal interface IAbilityButtonView
    {
        void Init(Sprite icon, UnityAction click);
        void Deinit();
    }
    
    internal interface IAbilityActivator
    {
        GameObject ViewGameObject { get; }
        float JumpHeight { get; }
    }
    
    internal interface IAbilityItem
    {
        string Id { get; }
        Sprite Icon { get; }
        AbilityType Type { get; }
        GameObject Projectile { get; }
        float Value { get; }
    }
}