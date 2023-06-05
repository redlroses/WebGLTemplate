﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public void Load() { }

        private TData GetDataFor<TData, TKey>(TKey key, IReadOnlyDictionary<TKey, TData> from) =>
            from.TryGetValue(key, out TData staticData)
                ? staticData
                : throw new NullReferenceException(
                    $"There is no {from.First().Value.GetType().Name} data with key: {key}");

        private Dictionary<TKey, TData> LoadFor<TData, TKey>(string path, Func<TData, TKey> keySelector)
            where TData : ScriptableObject =>
            Resources
                .LoadAll<TData>(path)
                .ToDictionary(keySelector, x => x);
    }
}