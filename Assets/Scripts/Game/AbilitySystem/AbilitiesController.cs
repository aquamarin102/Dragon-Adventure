using Tool;
using System;
using System.Collections.Generic;
using Game.AbilitySystem.Abilities;
using UnityEngine;
using JetBrains.Annotations;
using Tool.Interfaces;


namespace Game.AbilitySystem
{
   internal class AbilitiesController : BaseController, IAbilitiesController
    {
        private readonly IAbilitiesView _view;
        private readonly IAbilitiesRepository _repository;
        private readonly IAbilityActivator _abilityActivator;


        public AbilitiesController(
            [NotNull] IAbilitiesView view,
            [NotNull] IAbilitiesRepository repository,
            [NotNull] IEnumerable<IAbilityItem> items,
            [NotNull] IAbilityActivator activator)
        {
            _view
                = view ?? throw new ArgumentNullException(nameof(view));

            _repository
                = repository ?? throw new ArgumentNullException(nameof(repository));

            _abilityActivator
                = activator ?? throw new ArgumentNullException(nameof(activator));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _view.Display(items, OnAbilityViewClicked);
        }


        protected override void OnDispose() =>
            _view.Clear();


        private void OnAbilityViewClicked(string abilityId)
        {
            if (_repository.Items.TryGetValue(abilityId, out IAbility ability))
                ability.Apply(_abilityActivator);
        }
    }
}