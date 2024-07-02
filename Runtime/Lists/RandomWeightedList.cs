using System.Collections.Generic;
using UnityEngine;

namespace LL_Unity_Utils.Lists
{
    [System.Serializable]
    public class RandomWeightedList<T> where T : IWeighable
    {
        public List<T> weightedList = new();

        public void Add(T _object)
        {
            weightedList.Add(_object);
            SortList();
        }

        public void Add(List<T> _list)
        {
            foreach (var entry in _list)
            {
                weightedList.Add(entry);
            }
            SortList();
        }

        public void Add(params T[] _list)
        {
            foreach (var entry in _list)
            {
                weightedList.Add(entry);
            }
            SortList();
        }

        public T GetRandom()
        {
            int totalWeight = 0, processedWeight = 0;
            T output = default;

            if (weightedList[0].Weight == weightedList[^1].Weight) return weightedList[Random.Range(0, weightedList.Count)];

            foreach (var entry in weightedList)
            {
                totalWeight += entry.Weight;
            }
            var random = Random.Range(1, totalWeight + 1);

            foreach (var entry in weightedList)
            {
                processedWeight += entry.Weight;
                if (random <= processedWeight)
                {
                    output = entry;
                    break;
                }
            }
            return output;
        }

        public void SortList()
        {
            weightedList.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        }
    }
}
