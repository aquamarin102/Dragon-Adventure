using System.Collections.Generic;
using Game.AbilitySystem.Abilities;
using Tool.Interfaces;

namespace Game.AbilitySystem
{
    internal class AbilitiesRepository : Repository<string, IAbility, IAbilityItem>, IAbilitiesRepository
    {
        public AbilitiesRepository(IEnumerable<IAbilityItem> abilityItems) : base(abilityItems)
        { }

        protected override IAbility CreateItem(IAbilityItem abilityItem) =>
            abilityItem.Type switch
            {
                AbilityType.Gun => new GunAbility(abilityItem),
                AbilityType.Jump => new JumpAbility(abilityItem),
                _ => StubAbility.Default
            };



        protected override string GetKey(IAbilityItem abilityItem) => abilityItem.Id;
    }
}