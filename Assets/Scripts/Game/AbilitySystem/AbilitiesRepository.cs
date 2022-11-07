using System.Collections.Generic;
using DefaultNamespace;
using Game.AbilitySystem.Abilities;
using Tool.Interfaces;

namespace Game.AbilitySystem
{
    internal class AbilitiesRepository : Repository<string, IAbility, AbilityItemConfig>
    {
        public AbilitiesRepository(IEnumerable<AbilityItemConfig> configs) : base(configs)
        { }

        protected override string GetKey(AbilityItemConfig config) => config.Id;

        protected override IAbility CreateItem(AbilityItemConfig config) =>
            config.Type switch
            {
                AbilityType.Gun => new GunAbility(config), AbilityType.Jump => new JumpAbility(config), _ => StubAbility.Default
            };
    }
}