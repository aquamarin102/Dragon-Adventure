﻿using System.Collections.Generic;
using Game.AbilitySystem.Abilities;
using Game.Inventory.Items;
using Tool.Interfaces;

    public abstract class Repository<TKey, TValue, TConfig> : IRepository
    {
        private readonly Dictionary<TKey, TValue> _items;
        
        public IReadOnlyDictionary<TKey, TValue> Items => _items;

        protected Repository(IEnumerable<TConfig> configs) => _items = CreateItems(configs);

        public void Dispose() => _items.Clear();
        
        private Dictionary<TKey, TValue> CreateItems(IEnumerable<TConfig> configs)
        {
            var items = new Dictionary<TKey, TValue>();

            foreach (TConfig config in configs)
            {
                items[GetKey(config)] = CreateItem(config);
            }

            return items;
        }

        protected abstract TValue CreateItem(TConfig config);
        protected abstract TKey GetKey(TConfig config);

    }
